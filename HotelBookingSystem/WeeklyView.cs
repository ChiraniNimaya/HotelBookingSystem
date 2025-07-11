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
        public FormWeeklyView(DateTime targetDate)
        {
            this.targetDate = targetDate;
            InitializeComponent();
        }

        private void FormWeeklyView_Load(object sender, EventArgs e)
        {

            // Get bookings for the week and map to BookingViewModel
            var weeklyBookings = BookingManager.GetBookingsForWeek(targetDate)
                                  .Select(b => new BookingViewModel(b))
                                  .ToList();

            DataGridWeeklyView.DataSource = new BindingList<BookingViewModel>(weeklyBookings);

            DataGridWeeklyView.Columns["BookingID"].HeaderText = "Booking ID";
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
    }
}
