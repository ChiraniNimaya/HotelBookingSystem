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
            bool isRoomSelected = RoomSingle.Checked || RoomDouble.Checked || RoomTriple.Checked;
            bool isResidencySelected = RadioButtonResident.Checked || RadioButtonNonResident.Checked;

            bool areFieldsValid =
                !string.IsNullOrWhiteSpace(TextBoxName.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxNIC.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxAddress.Text) &&
                IsValidMobile(TextBoxMobileNumber.Text) &&
                IsValidEmail(TextBoxEmail.Text);

            ButtonSubmit.Enabled = isDateRangeValid && isRoomSelected && isResidencySelected && areFieldsValid;
        }
        private bool IsValidMobile(string mobile)
        {
            return Regex.IsMatch(mobile, @"^\d{10}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        private void InputFields_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void CheckinDatePicker_ValueChanged(object sender, EventArgs e)
        {
            CheckoutDatePicker.MinDate = CheckinDatePicker.Value.AddDays(1);
            EnableSubmission();
        }

        private void CheckoutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void RoomSingle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void RoomDouble_CheckedChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void RoomTriple_CheckedChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Booking has been Submitted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void RadioButtonResident_CheckedChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void RadioButtonNonResident_CheckedChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void TextBoxNIC_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void TextBoxMobileNumber_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            EnableSubmission();
        }
    }
}
