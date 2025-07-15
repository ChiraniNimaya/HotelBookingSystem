using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
                var viewModelList = results.Select(b => new BookingViewModel(b)).ToList();
                DataGridViewBookings.DataSource = new BindingList<BookingViewModel>(viewModelList);
            }
            else
            {
                MessageBox.Show("No bookings found for the given criteria.");
            }

        }

        private void SetupDataGridView()
        {
            DataGridViewBookings.Columns.Clear();

            DataGridViewBookings.AutoGenerateColumns = false;
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Booking ID", DataPropertyName = "BookingId" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Guest Name", DataPropertyName = "GuestName" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIC", DataPropertyName = "NIC" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-In Date", DataPropertyName = "CheckInDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-Out Date", DataPropertyName = "CheckOutDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Room(s)", DataPropertyName = "RoomSummary" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recurring Stay?", DataPropertyName = "IsRecurring" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Special Requests", DataPropertyName = "SpecialRequests" });


            var editButton = new DataGridViewButtonColumn
            {
                HeaderText = "Edit Booking",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };

            var deleteButton = new DataGridViewButtonColumn
            {
                HeaderText = "Delete Booking",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            DataGridViewBookings.Columns.Add(editButton);
            DataGridViewBookings.Columns.Add(deleteButton);

            DataGridViewBookings.CellClick += DataGridViewBookings_CellClick;
        }

        private void DataGridViewBookings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = DataGridViewBookings.Columns[e.ColumnIndex];

                // Get the booking for the clicked row
                var viewModel = (BookingViewModel)DataGridViewBookings.Rows[e.RowIndex].DataBoundItem;
                Booking selectedBooking = BookingManager.GetAllBookings().FirstOrDefault(b => b.BookingId == viewModel.BookingId);


                // Handle Delete Booking button
                if (column.HeaderText == "Delete Booking")
                {
                    var confirm = MessageBox.Show(
                        $"Are you sure you want to delete booking ID {selectedBooking.BookingId}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        BookingManager.GetAllBookings().Remove(selectedBooking); // Remove from main list

                        // Refresh DataGridView
                        var updatedList = BookingManager.GetAllBookings()
                            .Where(b =>
                                (searchBookingId.HasValue && b.BookingId == searchBookingId.Value) ||
                                (!string.IsNullOrWhiteSpace(searchNIC) && b.Guest.NIC.Equals(searchNIC, StringComparison.OrdinalIgnoreCase))
                            )
                            .ToList();

                        var viewModelList = updatedList.Select(b => new BookingViewModel(b)).ToList();
                        DataGridViewBookings.DataSource = new BindingList<BookingViewModel>(viewModelList);

                        MessageBox.Show("Booking deleted successfully.");
                    }
                }
                if (column.HeaderText == "Edit Booking")
                {
                    FormEditBooking formEditBooking = new FormEditBooking(selectedBooking);
                    if (formEditBooking.ShowDialog() == DialogResult.OK)
                    {
                        var updatedList = BookingManager.GetAllBookings()
                            .Where(b =>
                                (searchBookingId.HasValue && b.BookingId == searchBookingId.Value) ||
                                (!string.IsNullOrWhiteSpace(searchNIC) && b.Guest.NIC.Equals(searchNIC, StringComparison.OrdinalIgnoreCase))
                            )
                            .Select(b => new BookingViewModel(b))
                            .ToList();

                        DataGridViewBookings.DataSource = new BindingList<BookingViewModel>(updatedList);
                    }
                }
            }

        }
    }
}
