using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelBookingSystem.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class BookingApiClient
    {
        private readonly HttpClient _httpClient;

        public BookingApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7153/")
            };
        }

        public class BookingSuccessResponse
        {
            public int BookingId { get; set; }
            public float TotalPrice { get; set; }
            public List<int> RoomIds { get; set; }

            public List<string> FailedMonths { get; set; }
        }

        public class BookingErrorResponse
        {
            public string Message { get; set; }
            public Dictionary<string, int> UnavailableRooms { get; set; }
        }

        public class BookingDeleteResponse
        {
            public int GuestId { get; set; }
        }


        public async Task<bool> SubmitBookingAsync(BookingDTO dto)
        {

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/booking", dto);

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    // Deserialize to BookingSuccessResponse
                    var success = await response.Content.ReadFromJsonAsync<BookingSuccessResponse>();

                    if (success == null)
                    {
                        MessageBox.Show("Booking succeeded but no details were returned.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

                    // Check if there are failed months
                    if (success.FailedMonths != null && success.FailedMonths.Any())
                    {
                        // Format month names into a nice string
                        string failedMonthsList = string.Join(", ", success.FailedMonths);

                        MessageBox.Show(
                            $"Booking created, but some recurring months could not be booked.\n\n" +
                            $"Booking ID: {success.BookingId}\n" +
                            $"Total Price: {success.TotalPrice:C}\n\n" +
                            $"Failed Months: {failedMonthsList}",
                            "Partial Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        // Default success message
                        MessageBox.Show(
                            $"Booking created!\n\nBooking ID: {success.BookingId}\n" + 
                            $"Total Price: {success.TotalPrice:C}\n" + 
                            $"Room numbers allocated : {string.Join(", ", success.RoomIds)}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) // Rooms unavailable
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<BookingErrorResponse>();

                    if (errorContent == null)
                    {
                        MessageBox.Show("Booking failed but server didn't return an error message.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    string msg = $"{errorContent.Message}\n\n";
                    foreach (var kvp in errorContent.UnavailableRooms)
                    {
                        msg += $"{kvp.Key}: {kvp.Value} not available\n";
                    }

                    MessageBox.Show(msg, "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else  // Unexpected server error
                {
                    string serverMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{serverMsg}", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Get booking by ID
        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Booking>($"api/booking/{bookingId}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        // Get bookings by NIC
        public async Task<List<Booking>> GetBookingsByNicAsync(string nic)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Booking>>($"api/booking/nic/{nic}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        // Get bookings by Week
        public async Task<List<Booking>> GetBookingsByWeekAsync(DateTime date)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Booking>>($"api/booking/week/{date}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        // Delete selected booking 
        public async Task<int> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/booking/{bookingId}");
                // Deserialize to BookingSuccessResponse
                var success = await response.Content.ReadFromJsonAsync<BookingDeleteResponse>();

                if (success.GuestId != 0)
                {
                    return success.GuestId;
                }
                return 0;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Update selected booking
        public async Task<bool> UpdateBookingAsync(int bookingId, BookingDTO dto)
        {
            try
            {
                
                var response = await _httpClient.PutAsJsonAsync($"api/booking/{bookingId}", dto);

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    // Deserialize to BookingSuccessResponse
                    var success = await response.Content.ReadFromJsonAsync<BookingSuccessResponse>();

                    if (success == null)
                    {
                        MessageBox.Show("Booking updated successfully, but no details were returned.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

                    // Standard success message
                    MessageBox.Show(
                        $"Booking updated!\n\nBooking ID: {success.BookingId}\n" +
                        $"Total Price: {success.TotalPrice:C}\n" +
                        $"Rooms allocated: {string.Join(", ", success.RoomIds)}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) // Rooms unavailable
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<BookingErrorResponse>();

                    if (errorContent == null)
                    {
                        MessageBox.Show("Booking update failed but server didn't return an error message.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    string msg = $"{errorContent.Message}\n\n";
                    foreach (var kvp in errorContent.UnavailableRooms)
                    {
                        msg += $"{kvp.Key}: {kvp.Value} not available\n";
                    }

                    MessageBox.Show(msg, "Booking Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else  // Unexpected server error
                {
                    string serverMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{serverMsg}", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




    }

}

