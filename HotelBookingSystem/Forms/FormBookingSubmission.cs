using Azure;
using HotelBookingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HotelBookingSystem
{
    public partial class FormBookingSubmission : Form
    {
        private Dictionary<RoomType, int> roomInfo = new Dictionary<RoomType, int>();
        private Guest guest = new Guest();
        DateTime checkInDate, checkOutDate;
        bool isRecurring;
        float totalPrice;

        private int selectedStandard => (int)NumericUpDownStandard.Value;
        private int selectedDeluxe => (int)NumericUpDownDeluxe.Value;
        private int selectedSuite => (int)NumericUpDownSuite.Value;
        private int selectedFamily => (int)NumericUpDownFamily.Value;

        public FormBookingSubmission()
        {
            InitializeComponent();
        }

        private void FormBookingSubmission_Load(object sender, EventArgs e)
        {
            CheckinDatePicker.MinDate = DateTime.Now;
            ButtonSubmit.Enabled = false;
        }
        private void EnableSubmission()
        {
            bool isDateRangeValid = CheckinDatePicker.Value.Date < CheckoutDatePicker.Value.Date;
            bool isRoomSelected = selectedStandard + selectedDeluxe + selectedSuite + selectedFamily > 0;
            bool isResidencySelected = RadioButtonResident.Checked || RadioButtonNonResident.Checked;

            bool areFieldsValid =
                !string.IsNullOrWhiteSpace(TextBoxName.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxNIC.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxAddress.Text) &&
                IsValidMobile(TextBoxMobileNumber.Text) &&
                IsValidEmail(TextBoxEmail.Text);

            bool canButtonsEnable = isDateRangeValid && isRoomSelected && isResidencySelected && areFieldsValid;
            ButtonSubmit.Enabled = canButtonsEnable;
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
            isRecurring = CheckBoxRecurring.Checked; ;
            EnableSubmission();
        }
        private void NumericUpDownStandard_ValueChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void NumericUpDownDeluxe_ValueChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void NumericUpDownSuite_ValueChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void NumericUpDownFamily_ValueChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }
        private async void ButtonSubmit_ClickAsync(object sender, EventArgs e)
        {
            roomInfo.Clear();

            // Store selected rooms in rooms list
            if (selectedStandard > 0)
                roomInfo.Add(RoomType.Standard, selectedStandard );
            if (selectedDeluxe > 0)
                roomInfo.Add(RoomType.Deluxe, selectedDeluxe);
            if (selectedSuite > 0)
                roomInfo.Add(RoomType.Suite, selectedSuite);
            if (selectedFamily > 0)
                roomInfo.Add(RoomType.Family, selectedFamily);

            string specialRequests = string.Join(", ", ListBoxSpecialRequests.Text.Split('\n'));

            BookingDTO newBookingDto = new BookingDTO();
            newBookingDto.CheckInDate = checkInDate;
            newBookingDto.CheckOutDate = checkOutDate;
            newBookingDto.IsRecurring = isRecurring;
            newBookingDto.SpecialRequests = specialRequests;
            newBookingDto.RoomInfo = roomInfo;

            GuestDTO guestDto = new GuestDTO();
            guestDto.GuestId = guest.GuestId;
            guestDto.Name = guest.Name;
            guestDto.NIC = guest.NIC;
            guestDto.Address = guest.Address;
            guestDto.MobileNumber = guest.MobileNumber;
            guestDto.Email = guest.Email;
            guestDto.IsResident = guest.IsResident;

            var guestApiClient = new GuestApiClient();
            int guestId = await guestApiClient.SubmitGuestAsync(guestDto);

            var bookingApiClient = new BookingApiClient();
            if (guestId != 0)
            {
                newBookingDto.GuestId = guestId;
                bool bookingResult = await bookingApiClient.SubmitBookingAsync(newBookingDto); // Error handled in SubmitBookingAsync
                if (bookingResult)
                {
                }
            }
            else
            {
                MessageBox.Show("Error in storing guest information. Try again.","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void LinkLabelStandard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string roomDetails = "Standard – Basic amenities, ideal for solo/couple stay (Max: 2 people)\n";

            MessageBox.Show(roomDetails, "Standard Room Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelDeluxe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string roomDetails = "Deluxe – Spacious with better view and facilities (Max: 3 people)\n";

            MessageBox.Show(roomDetails, "Deluxe Room Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelSuite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string roomDetails = "Suite – Luxury space with living area and extras (Max: 4 people)\n";

            MessageBox.Show(roomDetails, "Suite Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelFamily_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string roomDetails = "Family – Large space for groups or families (Max: 5 people)\n";

            MessageBox.Show(roomDetails, "Family Room Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
