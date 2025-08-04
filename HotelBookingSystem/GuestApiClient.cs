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

        public class GuestSuccessResponse
        {
            public int GuestId { get; set; }
        }

        public async Task<int> SubmitGuestAsync(GuestDTO dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/guest", dto);

                if (response.IsSuccessStatusCode) // Success (200 OK)
                {
                    // Deserialize to GuestSuccessResponse 
                    var success = await response.Content.ReadFromJsonAsync<GuestSuccessResponse>();
                    return success.GuestId;
                }
                else {  return 0; }
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
                return await _httpClient.GetFromJsonAsync<Guest>($"api/guest/{guestId}");
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
                return await _httpClient.GetFromJsonAsync<Guest>($"api/guest/nic/{nic}");
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