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
    public partial class FormSearchView : Form
    {
        private readonly string? searchNIC;
        private readonly int? searchBookingId;

        public FormSearchView(string nic)
        {
            InitializeComponent();
            searchNIC = nic;
        }

        public FormSearchView(int bookingId)
        {
            InitializeComponent();
            searchBookingId = bookingId;
        }

        private void FormSearchView_Load(object sender, EventArgs e)
        {
            List<Booking> results = new();

            if (searchBookingId.HasValue)
            {
                results = BookingManager.GetAllBookings()
                    .Where(b => b.BookingId == searchBookingId.Value)
                    .ToList();
            }
            else if (!string.IsNullOrWhiteSpace(searchNIC))
            {
                results = BookingManager.GetAllBookings()
                    .Where(b => b.Guest.NIC.Equals(searchNIC, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (results.Any())
            {
                SetupDataGridView();
                DataGridViewBookings.DataSource = new BindingList<Booking>(results);
            }
            else
            {
                MessageBox.Show("No bookings found for the given criteria.");
                //DataGridViewBookings.Visible = false; 
            }

        }

        private void SetupDataGridView()
        {
            DataGridViewBookings.Columns.Clear();

            DataGridViewBookings.AutoGenerateColumns = false;
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Booking ID", DataPropertyName = "BookingId" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Customer Name", DataPropertyName = "CustomerName" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIC", DataPropertyName = "NIC" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-In", DataPropertyName = "CheckInDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-Out", DataPropertyName = "CheckOutDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Room Type", DataPropertyName = "RoomType" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recurring Stay?", DataPropertyName = "IsRecurring" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Special Requests", DataPropertyName = "SpecialRequests" });
            

            var editButton = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };

            var deleteButton = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            DataGridViewBookings.Columns.Add(editButton);
            DataGridViewBookings.Columns.Add(deleteButton);

            DataGridViewBookings.CellClick += DataGridViewBookings_CellClick;
        }

        private void DataGridViewBookings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
