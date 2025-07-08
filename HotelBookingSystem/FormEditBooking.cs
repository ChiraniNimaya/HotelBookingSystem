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
    public partial class FormEditBooking : Form
    {
        private Booking bookingToEdit;
        public FormEditBooking(Booking booking)
        {
            InitializeComponent();
            bookingToEdit = booking;
            DateTimePickerCheckin.MinDate = DateTime.Today;
        }

        private void FormEditBooking_Load(object sender, EventArgs e)
        {
            // Guest details
            TextBoxGuestName.Text = bookingToEdit.Guest.Name;
            TextBoxNIC.Text = bookingToEdit.Guest.NIC;
            TextBoxAddress.Text = bookingToEdit.Guest.Address;
            TextBoxMobileNumber.Text = bookingToEdit.Guest.MobileNumber;
            TextBoxEmail.Text = bookingToEdit.Guest.Email;
            CheckBoxResident.Checked = bookingToEdit.Guest.IsResident;

            //Dates
            DateTimePickerCheckin.Value = bookingToEdit.CheckInDate;
            DateTimePickerCheckout.Value = bookingToEdit.CheckOutDate;

            //Booking details
            TextBoxBookingId.Text = bookingToEdit.BookingId.ToString();
            CheckBoxRecurring.Checked = bookingToEdit.IsRecurring;
            TextBoxSpecialRequests.Text = bookingToEdit.SpecialRequests;

            TextBoxBookingId.ReadOnly = true;

            // Room selection: assign values to numeric counters
            foreach (var room in bookingToEdit.Rooms)
            {
                switch (room.RoomType)
                {
                    case RoomType.Standard:
                        NumericUpDownStandard.Value = room.NumberOfRooms;
                        break;
                    case RoomType.Deluxe:
                        NumericUpDownDeluxe.Value = room.NumberOfRooms;
                        break;
                    case RoomType.Suite:
                        NumericUpDownSuite.Value = room.NumberOfRooms;
                        break;
                    case RoomType.Family:
                        NumericUpDownFamily.Value = room.NumberOfRooms;
                        break;
                }
            }
        }

        private void DateTimePickerCheckin_ValueChanged(object sender, EventArgs e)
        {
            DateTimePickerCheckout.MinDate = DateTimePickerCheckin.Value.AddDays(1);

            if (DateTimePickerCheckout.Value <= DateTimePickerCheckin.Value)
            {
                DateTimePickerCheckout.Value = DateTimePickerCheckin.Value.AddDays(1);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Gather updated room selections
            var updatedRooms = new List<Room>();
            if (NumericUpDownStandard.Value > 0)
                updatedRooms.Add(new Room { RoomType = RoomType.Standard, NumberOfRooms = (int)NumericUpDownStandard.Value });
            if (NumericUpDownDeluxe.Value > 0)
                updatedRooms.Add(new Room { RoomType = RoomType.Deluxe, NumberOfRooms = (int)NumericUpDownDeluxe.Value });
            if (NumericUpDownSuite.Value > 0)
                updatedRooms.Add(new Room { RoomType = RoomType.Suite, NumberOfRooms = (int)NumericUpDownSuite.Value });
            if (NumericUpDownFamily.Value > 0)
                updatedRooms.Add(new Room { RoomType = RoomType.Family, NumberOfRooms = (int)NumericUpDownFamily.Value });

            // Check that at least one room type is selected
            if (updatedRooms.Count == 0)
            {
                MessageBox.Show("Please select at least one room type with quantity greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check availability using BookingManager
            bool roomsAvailable = BookingManager.AreRoomsAvailable(
                updatedRooms,
                DateTimePickerCheckin.Value,
                DateTimePickerCheckout.Value,
                excludeBookingId: bookingToEdit.BookingId
            );

            if (!roomsAvailable)
            {
                MessageBox.Show("The selected rooms are not available for the given date range.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Update guest details
            bookingToEdit.Guest.Name = TextBoxGuestName.Text.ToString();
            bookingToEdit.Guest.NIC = TextBoxNIC.Text;
            bookingToEdit.Guest.Address = TextBoxAddress.Text;
            bookingToEdit.Guest.MobileNumber = TextBoxMobileNumber.Text;
            bookingToEdit.Guest.Email = TextBoxEmail.Text;
            bookingToEdit.Guest.IsResident = CheckBoxResident.Checked;

            //Update dates
            bookingToEdit.CheckInDate = DateTimePickerCheckin.Value;
            bookingToEdit.CheckOutDate = DateTimePickerCheckout.Value;

            //Update booking details
            bookingToEdit.IsRecurring = CheckBoxRecurring.Checked;
            bookingToEdit.SpecialRequests = TextBoxSpecialRequests.Text;

            bookingToEdit.Rooms.Clear();
            bookingToEdit.Rooms.AddRange(updatedRooms);

            bookingToEdit.CalculateTotalBookingPrice();

            MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
