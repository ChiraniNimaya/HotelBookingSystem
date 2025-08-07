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

                if (bookings == null)
                {
                    MessageBox.Show("No bookings for the requested week.", "No Bookings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

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

                // Prevent auto-generating all columns
                DataGridWeeklyView.AutoGenerateColumns = false;

                // Clear existing columns
                DataGridWeeklyView.Columns.Clear();

                // Manually define only the columns you want
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "BookingId",
                    HeaderText = "Booking ID"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GuestName",
                    HeaderText = "Guest Name"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NIC",
                    HeaderText = "NIC No."
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CheckInDate",
                    HeaderText = "Check-In Date"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CheckOutDate",
                    HeaderText = "Check-Out Date"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "RoomSummary",
                    HeaderText = "Room(s)"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "IsResident",
                    HeaderText = "Is Resident?"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "IsRecurring",
                    HeaderText = "Recurring stay?"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SpecialRequests",
                    HeaderText = "Special Requests"
                });
                DataGridWeeklyView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalPrice",
                    HeaderText = "Total Price (LKR)"
                });

                // Now bind the data
                DataGridWeeklyView.DataSource = new BindingList<BookingViewModel>(weeklyBookings);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load weekly bookings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
