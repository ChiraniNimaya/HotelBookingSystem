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
        private List<Room> rooms = new List<Room>();
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
            isRecurring = true;
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
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            rooms.Clear();

            // Store selected rooms in rooms list
            if (selectedStandard > 0)
                rooms.Add(new Room { RoomType = RoomType.Standard, NumberOfRooms = selectedStandard });
            if (selectedDeluxe > 0)
                rooms.Add(new Room { RoomType = RoomType.Deluxe, NumberOfRooms = selectedDeluxe });
            if (selectedSuite > 0)
                rooms.Add(new Room { RoomType = RoomType.Suite, NumberOfRooms = selectedSuite });
            if (selectedFamily > 0)
                rooms.Add(new Room { RoomType = RoomType.Family, NumberOfRooms = selectedFamily });

            if (!BookingManager.AreRoomsAvailable(rooms, checkInDate, checkOutDate))
            {
                MessageBox.Show("One or more room types are not available for the selected dates.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string specialRequests = string.Join(", ", ListBoxSpecialRequests.Text.Split('\n'));

            Booking booking = new Booking(guest, checkInDate, checkOutDate, isRecurring, specialRequests, rooms);

            PricingManager.UpdateTotalBookingPrice(booking);
            totalPrice = booking.TotalPrice;

            // Store the booking
            BookingManager.AddBooking(booking);

            int bookingCount = 1;

            if (isRecurring)
            {
                for (int i = 1; i <= 11; i++) // Next 11 months
                {
                    DateTime recurringCheckIn = checkInDate.AddMonths(i);
                    DateTime recurringCheckOut = checkOutDate.AddMonths(i);

                    // Clone room list
                    var clonedRooms = rooms.Select(r => new Room { RoomType = r.RoomType, NumberOfRooms = r.NumberOfRooms }).ToList();

                    if (BookingManager.AreRoomsAvailable(clonedRooms, recurringCheckIn, recurringCheckOut))
                    {
                        Booking recurringBooking = new Booking(guest, recurringCheckIn, recurringCheckOut, true, specialRequests, clonedRooms);
                        PricingManager.UpdateTotalBookingPrice(recurringBooking);
                        BookingManager.AddBooking(recurringBooking);
                        bookingCount++;
                    }
                }
            }

            MessageBox.Show($"New Booking has been Submitted.\n" +
                $"Booking ID: {booking.BookingId}\n" +
                $"Total Price: LKR {totalPrice}.00\n" +
                $"{(isRecurring ? $"Recurring bookings added for next {bookingCount - 1} months." : "")}",
                "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
