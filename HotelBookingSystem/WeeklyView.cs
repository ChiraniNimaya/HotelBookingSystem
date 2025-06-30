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
        public FormWeeklyView()
        {
            InitializeComponent();
        }

        private void FormWeeklyView_Load(object sender, EventArgs e)
        {
            var weeklyBookings = BookingManager.GetBookingsForCurrentWeek().Select(b => new
            {
                BookingID = b.BookingId,
                GuestName = b.Guest.Name,
                NIC = b.Guest.NIC,
                CheckIn = b.CheckInDate.ToShortDateString(),
                CheckOut = b.CheckOutDate.ToShortDateString(),
                RoomType = b.Room.RoomType.ToString(),
                Price = b.TotalPrice,
                SpecialRequests = string.Join(", ", b.SpecialRequests)
            })
            .ToList();

            DataGridWeeklyView.DataSource = weeklyBookings;

            DataGridWeeklyView.Columns["BookingID"].HeaderText = "Booking ID";
            DataGridWeeklyView.Columns["GuestName"].HeaderText = "Guest Name";
            DataGridWeeklyView.Columns["NIC"].HeaderText = "NIC No.";
            DataGridWeeklyView.Columns["CheckIn"].HeaderText = "Check-In Date";
            DataGridWeeklyView.Columns["CheckOut"].HeaderText = "Check-Out Date";
            DataGridWeeklyView.Columns["RoomType"].HeaderText = "Room Type";
            DataGridWeeklyView.Columns["Price"].HeaderText = "Total Price";
            DataGridWeeklyView.Columns["SpecialRequests"].HeaderText = "Special Requests";
        }
    }
}
