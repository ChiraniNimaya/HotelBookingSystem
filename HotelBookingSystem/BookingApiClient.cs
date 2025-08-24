using Azure;
using HotelBooking.API.Models;
using HotelBookingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public class ApiResponse<T>
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }

        public class BookingPostErrorResponse
        {
            public Dictionary<string, int> UnavailableRooms { get; set; }
        }

        public class BookingPostSuccessResponse
        {
            public int BookingId { get; set; }
            public float TotalPrice { get; set; }
            public List<int> RoomIds { get; set; }

            public List<string> FailedMonths { get; set; }
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

                // Deserialize to BookingSuccessResponse
               

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<BookingPostSuccessResponse>>();

                    if (result == null)
                    {
                        MessageBox.Show("Booking succeeded but no details were returned.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

                    // Check if there are failed months
                    if (result.Data.FailedMonths != null && result.Data.FailedMonths.Any())
                    {
                        // Format month names into a nice string
                        string failedMonthsList = string.Join(", ", result.Data.FailedMonths);

                        MessageBox.Show(
                            $"Booking created, but some recurring months could not be booked.\n\n" +
                            $"Booking ID: {result.Data.BookingId}\n" +
                            $"Total Price: {result.Data.TotalPrice:C}\n\n" +
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
                            $"Booking created!\n\nBooking ID: {result.Data.BookingId}\n" + 
                            $"Total Price: {result.Data.TotalPrice:C}\n" + 
                            $"Room numbers allocated : {string.Join(", ", result.Data.RoomIds)}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) // Rooms unavailable
                {
                    
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<BookingPostErrorResponse>>();
                    
                    if (result.Status == null)
                    {
                        MessageBox.Show("Booking failed but server didn't return an error message.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    string msg = $"{result.Message} \n\n";
                    if (result.Data?.UnavailableRooms != null && result.Data.UnavailableRooms.Any())
                    {
                        foreach (var kvp in result.Data.UnavailableRooms)
                        {
                            msg += $"{kvp.Key}: {kvp.Value} not available\n";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Booking failed, Some rooms are unavailable for the entered time period.",
                                        "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
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
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<Booking>>($"api/booking/{bookingId}");
                return result.Data;
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
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<List<Booking>>>($"api/booking/nic/{nic}");
                return result.Data;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        // Get bookings by Week
        public async Task<List<Booking>> GetBookingsByWeekAsync(string date) //yyyy-MM-DD format
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<List<Booking>>>($"api/booking/week/{date}");
                return result.Data;
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
                var result = await response.Content.ReadFromJsonAsync <ApiResponse<BookingDeleteResponse>>();

                if (result.Data.GuestId != 0)
                {
                    return result.Data.GuestId;
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
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<BookingPostSuccessResponse>>();

                    if (result == null)
                    {
                        MessageBox.Show("Booking updated successfully, but no details were returned.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

                    // Standard success message
                    MessageBox.Show(
                        $"Booking updated!\n\nBooking ID: {result.Data.BookingId}\n" +
                        $"Total Price: {result.Data.TotalPrice:C}\n" +
                        $"Rooms allocated: {string.Join(", ", result.Data.RoomIds)}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) // Rooms unavailable
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<BookingPostErrorResponse>>();

                    if (result.Status == null)
                    {
                        MessageBox.Show("Booking update failed but server didn't return an error message.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    string msg = $"{result.Message} \n\n";
                    foreach (var kvp in result.Data.UnavailableRooms)
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
                MessageBox.Show($"An error occurred while updating booking : {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

    }

}

