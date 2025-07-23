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

        public async Task<bool> SubmitBookingAsync(BookingDTO dto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/booking", dto);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed: {response.StatusCode}\nDetails: {error}");
            }
            return response.IsSuccessStatusCode;
        }

    }

}
