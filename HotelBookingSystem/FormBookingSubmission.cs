using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HotelBookingSystem
{
    public partial class FormBookingSubmission : Form
    {
        private Room room = new Room();
        private Guest guest = new Guest();
        DateTime checkInDate, checkOutDate;
        bool isRecurring;
        public FormBookingSubmission()
        {
            InitializeComponent();
        }

        private void FormBookingSubmission_Load(object sender, EventArgs e)
        {
            CheckinDatePicker.MinDate = DateTime.Now;
            ButtonSubmit.Enabled = false;
            ButtonGenerateReceipt.Enabled = false;
        }
        private void EnableSubmission()
        {
            bool isDateRangeValid = CheckinDatePicker.Value.Date < CheckoutDatePicker.Value.Date;
            bool isRoomSelected = RoomSingle.Checked || RoomDouble.Checked || RoomTriple.Checked;
            bool isResidencySelected = RadioButtonResident.Checked || RadioButtonNonResident.Checked;

            bool areFieldsValid =
                !string.IsNullOrWhiteSpace(TextBoxName.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxNIC.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxAddress.Text) &&
                IsValidMobile(TextBoxMobileNumber.Text) &&
                IsValidEmail(TextBoxEmail.Text);

            bool canButtonsEnable = isDateRangeValid && isRoomSelected && isResidencySelected && areFieldsValid;
            ButtonSubmit.Enabled = ButtonGenerateReceipt.Enabled = canButtonsEnable;
        }
        private bool IsValidMobile(string mobile)
        {
            return Regex.IsMatch(mobile, @"^\d{10}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void CheckinDatePicker_ValueChanged(object sender, EventArgs e)
        {
            CheckoutDatePicker.MinDate = CheckinDatePicker.Value.AddDays(1);
            checkInDate = CheckinDatePicker.Value.Date;
            EnableSubmission();
        }

        private void CheckoutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            checkOutDate = CheckoutDatePicker.Value.Date;
            EnableSubmission();
        }

        private void RoomSingle_CheckedChanged(object sender, EventArgs e)
        {
            room.RoomType = RoomType.SingleRoom;
            EnableSubmission();
        }

        private void RoomDouble_CheckedChanged(object sender, EventArgs e)
        {
            room.RoomType = RoomType.DoubleRoom;
            EnableSubmission();
        }

        private void RoomTriple_CheckedChanged(object sender, EventArgs e)
        {
            room.RoomType = RoomType.TripleRoom;
            EnableSubmission();
        }


        private void RadioButtonResident_CheckedChanged(object sender, EventArgs e)
        {
            guest.IsResident = true;
            EnableSubmission();
        }

        private void RadioButtonNonResident_CheckedChanged(object sender, EventArgs e)
        {
            guest.IsResident = false;
            EnableSubmission();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            guest.Name = TextBoxName.Text;
            EnableSubmission();
        }

        private void TextBoxNIC_TextChanged(object sender, EventArgs e)
        {
            guest.NIC = TextBoxNIC.Text;
            EnableSubmission();
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e)
        {
            guest.Address = TextBoxAddress.Text;
            EnableSubmission();
        }

        private void TextBoxMobileNumber_TextChanged(object sender, EventArgs e)
        {
            guest.MobileNumber = TextBoxMobileNumber.Text;
            EnableSubmission();
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            guest.Email = TextBoxEmail.Text;
            EnableSubmission();
        }

        private void CheckBoxRecurring_CheckedChanged(object sender, EventArgs e)
        {
            isRecurring = true;
            EnableSubmission();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string specialRequests = string.Join(", ", ListBoxSpecialRequests.Text.Split('\n'));

            Booking booking = new Booking(guest, checkInDate, checkOutDate, isRecurring, specialRequests, room);

            // Store the booking
            BookingManager.AddBooking(booking);

            MessageBox.Show($"New Booking has been Submitted. Booking ID is {booking.BookingId}", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        
    }
}
