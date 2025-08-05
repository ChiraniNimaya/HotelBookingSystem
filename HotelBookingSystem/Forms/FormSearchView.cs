using HotelBooking.API.DTOs;
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
        private readonly BookingApiClient bookingApiClient;
        private readonly GuestApiClient guestApiClient;
        private readonly List<Booking> searchBooking;
        private Guest guest;

        public string? currentSearchNic;
        public int? currentSearchBookingId;

        public FormSearchView(Booking booking, int bookingId)
        {
            InitializeComponent();
            bookingApiClient = new BookingApiClient();
            guestApiClient = new GuestApiClient();
            searchBooking = booking != null ? new List<Booking> { booking } : new List<Booking>();
            currentSearchBookingId = bookingId;
        }
        
        public FormSearchView(List<Booking> booking, string nic)
        {
            InitializeComponent();
            bookingApiClient = new BookingApiClient();
            guestApiClient = new GuestApiClient();
            searchBooking = booking;
            currentSearchNic = nic;
        }

        private async void FormSearchView_Load(object sender, EventArgs e)
        {
            guest = await guestApiClient.GetGuestByIdAsync(searchBooking.FirstOrDefault().GuestId);
            if (searchBooking.Any())
            {
                SetupDataGridView();
                var viewModelList = searchBooking.Select(b => new BookingViewModel(b, guest)).ToList();
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
            DataGridViewBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Enable auto row height


            DataGridViewBookings.AutoGenerateColumns = false;
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Booking ID", DataPropertyName = "BookingId" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Guest Name", DataPropertyName = "GuestName" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIC", DataPropertyName = "NIC" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-In Date", DataPropertyName = "CheckInDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check-Out Date", DataPropertyName = "CheckOutDate" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Room(s)", DataPropertyName = "RoomSummary", Width = 250, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recurring Stay?", DataPropertyName = "IsRecurring" });
            DataGridViewBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Special Requests", DataPropertyName = "SpecialRequests", Width = 375, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });


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

        private async void DataGridViewBookings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignore header or invalid clicks
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                var column = DataGridViewBookings.Columns[e.ColumnIndex];

                // Get the booking for the clicked row
                var viewModel = (BookingViewModel)DataGridViewBookings.Rows[e.RowIndex].DataBoundItem;
                Booking selectedBooking = searchBooking.FirstOrDefault(b => b.BookingId == viewModel.BookingId);


                // DELETE logic
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
                        // Disable the grid to prevent further clicks during deletion
                        DataGridViewBookings.Enabled = false;

                        try
                        {
                            // Call API to delete
                            int guestId = await bookingApiClient.DeleteBookingAsync(selectedBooking.BookingId);
                            if (guestId != 0) 
                            { 
                                bool success = await guestApiClient.DeleteGuestAsync(guestId);
                                if (!success)
                                    MessageBox.Show("Unable to delete guest information.",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            // Refresh the booking data in place
                            await RefreshBookingData();

                            MessageBox.Show("Booking deleted successfully.",
                                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting booking:\n\n{ex}",
                                           "Delete Booking Error",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Re-enable the grid (though we're closing the form anyway)
                            DataGridViewBookings.Enabled = true;
                        }
                    }
                }
                if (column.HeaderText == "Edit Booking")
                {
                    var confirm = MessageBox.Show(
                        $"Are you sure you want to edit booking ID {selectedBooking.BookingId}?",
                        "Confirm Edit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        var selectedUpdatedBookings = await bookingApiClient.GetBookingByIdAsync(selectedBooking.BookingId);
                        FormEditBooking formEditBooking = new FormEditBooking(selectedUpdatedBookings);
                        if (formEditBooking.ShowDialog() == DialogResult.OK)
                        {
                            await RefreshBookingData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and show a user-friendly message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Re-enable the grid if it was disabled
                DataGridViewBookings.Enabled = true;
            }
        }

        // Helper method to refresh the grid data
        private async Task RefreshBookingData()
        {
            try
            {
                List<Booking> updatedBookings = new List<Booking>();

                if (!string.IsNullOrEmpty(currentSearchNic))
                {
                    updatedBookings = await bookingApiClient.GetBookingsByNicAsync(currentSearchNic);
                }
                else if (currentSearchBookingId.HasValue)
                {
                    var singleBooking = await bookingApiClient.GetBookingByIdAsync(currentSearchBookingId.Value);
                    if (singleBooking != null)
                        updatedBookings.Add(singleBooking);
                }

                // Check if no data was returned
                if (updatedBookings == null || !updatedBookings.Any())
                {
                    DataGridViewBookings.DataSource = null;
                    DataGridViewBookings.Visible = false; // or use .Enabled = false;
                    this.Close();

                    return;
                }

                // Convert to BookingViewModel list
                var bookingViewModels = updatedBookings.Select(b => new BookingViewModel(b, guest)).ToList();

                // Update the DataSource
                DataGridViewBookings.Visible = true;
                DataGridViewBookings.DataSource = null;
                DataGridViewBookings.DataSource = bookingViewModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
