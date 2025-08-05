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
    public partial class FormWeeklyView : Form
    {
        private DateTime targetDate;
        private readonly BookingApiClient bookingApiClient;
        private readonly GuestApiClient guestApiClient;
        public FormWeeklyView(DateTime targetDate)
        {
            InitializeComponent();
            this.targetDate = targetDate;
            bookingApiClient = new BookingApiClient();
            guestApiClient = new GuestApiClient();
        }

        private async void FormWeeklyView_Load(object sender, EventArgs e)
        {
            try
            {
                // Convert targetDate to "yyyy-MM-dd" format
                string formattedDate = targetDate.ToString("yyyy-MM-dd");
                // Get bookings for the target week
                var bookings = await bookingApiClient.GetBookingsByWeekAsync(formattedDate);

                // Prepare a list of BookingViewModels
                var weeklyBookings = new List<BookingViewModel>();

                foreach (var booking in bookings)
                {
                    // Fetch guest info for the current booking
                    var guest = await guestApiClient.GetGuestByIdAsync(booking.GuestId);

                    if (guest != null)
                    {
                        // Map to ViewModel and add to the list
                        var viewModel = new BookingViewModel(booking, guest);
                        weeklyBookings.Add(viewModel);
                    }
                }

                // Bind to DataGridView
                DataGridWeeklyView.DataSource = new BindingList<BookingViewModel>(weeklyBookings);

                // Set column headers
                DataGridWeeklyView.Columns["BookingId"].HeaderText = "Booking ID";
                DataGridWeeklyView.Columns["GuestName"].HeaderText = "Guest Name";
                DataGridWeeklyView.Columns["NIC"].HeaderText = "NIC No.";
                DataGridWeeklyView.Columns["CheckInDate"].HeaderText = "Check-In Date";
                DataGridWeeklyView.Columns["CheckOutDate"].HeaderText = "Check-Out Date";
                DataGridWeeklyView.Columns["RoomSummary"].HeaderText = "Room(s)";
                DataGridWeeklyView.Columns["IsResident"].HeaderText = "Is Resident?";
                DataGridWeeklyView.Columns["IsRecurring"].HeaderText = "Recurring stay?";
                DataGridWeeklyView.Columns["SpecialRequests"].HeaderText = "Special Requests";
                DataGridWeeklyView.Columns["TotalPrice"].HeaderText = "Total Price (LKR)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load weekly bookings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
