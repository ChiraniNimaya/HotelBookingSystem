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


        public async Task<bool> SubmitBookingAsync(BookingDTO dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/booking", dto);

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    // Deserialize to BookingSuccessResponse instead of BookingDTO
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
                            $"Booking created!\n\nBooking ID: {success.BookingId}\nTotal Price: {success.TotalPrice:C}",
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
    }

}

