using HotelBookingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HotelBookingSystem
{
    public partial class FormEditBooking : Form
    {
        private Booking bookingToEdit;
        private readonly BookingApiClient apiClient;
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
            CheckBoxRecurring.Enabled = false;

            // Room selection: assign values to numeric counters
            foreach (var roomInfo in bookingToEdit.RoomInfo)
            {
                switch (roomInfo.Key)
                {
                    case RoomType.Standard:
                        NumericUpDownStandard.Value = roomInfo.Value;
                        break;
                    case RoomType.Deluxe:
                        NumericUpDownDeluxe.Value = roomInfo.Value;
                        break;
                    case RoomType.Suite:
                        NumericUpDownSuite.Value = roomInfo.Value;
                        break;
                    case RoomType.Family:
                        NumericUpDownFamily.Value = roomInfo.Value;
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

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            // Gather updated room selections
            Dictionary<RoomType, int> updatedRoomInfo = new Dictionary<RoomType, int>();
            if (NumericUpDownStandard.Value > 0)
                updatedRoomInfo.Add(RoomType.Standard, (int)NumericUpDownStandard.Value );
            if (NumericUpDownDeluxe.Value > 0)
                updatedRoomInfo.Add(RoomType.Deluxe, (int)NumericUpDownDeluxe.Value);
            if (NumericUpDownSuite.Value > 0)
                updatedRoomInfo.Add(RoomType.Suite, (int)NumericUpDownSuite.Value);
            if (NumericUpDownFamily.Value > 0)
                updatedRoomInfo.Add(RoomType.Family, (int)NumericUpDownFamily.Value);

            // Check that at least one room type is selected
            if (updatedRoomInfo.Count == 0)
            {
                MessageBox.Show("Please select at least one room type with quantity greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update guest details
            GuestDTO guestDto = new GuestDTO();
            guestDto.Name = TextBoxGuestName.Text.ToString();
            guestDto.NIC = TextBoxNIC.Text;
            guestDto.Address = TextBoxAddress.Text;
            guestDto.MobileNumber = TextBoxMobileNumber.Text;
            guestDto.Email = TextBoxEmail.Text;
            guestDto.IsResident = CheckBoxResident.Checked;

            BookingDTO newBookingDto = new BookingDTO();
            newBookingDto.BookingId = bookingToEdit.BookingId;
            newBookingDto.CheckInDate = DateTimePickerCheckin.Value;
            newBookingDto.CheckOutDate = DateTimePickerCheckout.Value;
            newBookingDto.IsRecurring = bookingToEdit.IsRecurring;

            string specialRequests = string.Join(", ", TextBoxSpecialRequests.Text.Split('\n'));
            newBookingDto.SpecialRequests = specialRequests;

            bookingToEdit.RoomInfo.Clear();
            newBookingDto.RoomInfo = updatedRoomInfo;

            newBookingDto.GuestDto = guestDto;

            var apiClient = new BookingApiClient();
            bool result = await apiClient.UpdateBookingAsync(bookingToEdit.BookingId, newBookingDto);
            if (result)
            {
                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
