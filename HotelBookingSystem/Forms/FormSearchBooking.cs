using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class FormSearchBooking : Form
    {
        private readonly BookingApiClient apiClient;
        public FormSearchBooking()
        {
            InitializeComponent();
            apiClient = new BookingApiClient();


        }

        private void FormSearchBooking_Load(object sender, EventArgs e)
        {
            ButtonSearchNIC.Enabled = false;
            ButtonSearchBookingId.Enabled = false;
        }

        private void TextBoxSearchNIC_TextChanged(object sender, EventArgs e)
        {
            ButtonSearchNIC.Enabled = !string.IsNullOrWhiteSpace(TextBoxSearchNIC.Text);
        }

        private void TextBoxSearchBookingId_TextChanged(object sender, EventArgs e)
        {
            ButtonSearchBookingId.Enabled = !string.IsNullOrWhiteSpace(TextBoxSearchBookingId.Text);
        }

        private async void ButtonSearchBookingId_ClickAsync(object sender, EventArgs e)
        {
            if (!int.TryParse(TextBoxSearchBookingId.Text.Trim(), out int bookingId))
            {
                MessageBox.Show("Booking ID must be a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxSearchBookingId.Focus();
                return;
            }
            
            var booking = await apiClient.GetBookingByIdAsync(bookingId);

            if (booking != null)
            {
                FormSearchView formSearchView = new FormSearchView(booking, bookingId);
                formSearchView.ShowDialog();
            }
            else
            {
                MessageBox.Show("No booking found with the given Booking ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void ButtonSearchNIC_ClickAsync(object sender, EventArgs e)
        {
            string nic = TextBoxSearchNIC.Text.Trim();

            var bookings = await apiClient.GetBookingsByNicAsync(nic);

            if (bookings != null && bookings.Any())
            {
                FormSearchView formSearchView = new FormSearchView(bookings, nic);
                formSearchView.ShowDialog();
            }
            else
            {
                MessageBox.Show("No bookings found for the given NIC.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
