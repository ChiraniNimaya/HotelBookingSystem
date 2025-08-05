using HotelBooking.API.Models;
using HotelBookingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static HotelBookingSystem.BookingApiClient;

namespace HotelBookingSystem
{
    public class GuestApiClient
    {
        private readonly HttpClient _httpClient;

        public GuestApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7153/")
            };
        }

        public class GuestPostSuccessResponse
        {
            public int GuestId { get; set; }
        }

        public class GuestGetSuccessResponse
        {
            public Guest Guest { get; set; }

        }

        public async Task<int> SubmitGuestAsync(GuestDTO dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/guest", dto);

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    // Deserialize to GuestSuccessResponse 
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<GuestPostSuccessResponse>>();
                    if (result.Data.GuestId != 0)
                        return result.Data.GuestId;
                    MessageBox.Show($"An error occurred: {result.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else 
                {  
                    return 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Get booking by ID
        public async Task<Guest> GetGuestByIdAsync(int guestId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<GuestGetSuccessResponse>>($"api/guest/{guestId}");
                return result.Data.Guest;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        // Get bookings by NIC
        public async Task<Guest> GetGuestByNicAsync(string nic)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<GuestGetSuccessResponse>>($"api/guest/nic/{nic}");
                return result.Data.Guest;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<bool> DeleteGuestAsync(int guestId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/guest/{guestId}");

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    return true;
                }
                else { return false; }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}