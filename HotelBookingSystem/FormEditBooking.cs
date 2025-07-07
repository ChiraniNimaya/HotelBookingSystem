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
            ComboBoxRoomType.DataSource = Enum.GetValues(typeof(RoomType));

            TextBoxBookingId.Text = bookingToEdit.BookingId.ToString();
            TextBoxGuestName.Text = bookingToEdit.Guest.Name;
            TextBoxNIC.Text = bookingToEdit.Guest.NIC;
            TextBoxAddress.Text = bookingToEdit.Guest.Address;
            TextBoxMobileNumber.Text = bookingToEdit.Guest.MobileNumber;
            TextBoxEmail.Text = bookingToEdit.Guest.Email;
            CheckBoxResident.Checked = bookingToEdit.Guest.IsResident;
            DateTimePickerCheckin.Value = bookingToEdit.CheckInDate;
            DateTimePickerCheckout.Value = bookingToEdit.CheckOutDate;
            ComboBoxRoomType.SelectedItem = bookingToEdit.Room.RoomType;
            CheckBoxRecurring.Checked = bookingToEdit.IsRecurring;
            TextBoxSpecialRequests.Text = bookingToEdit.SpecialRequests;

            TextBoxBookingId.ReadOnly = true;
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
            bookingToEdit.Guest.Name = TextBoxGuestName.Text.ToString();
            bookingToEdit.Guest.NIC = TextBoxNIC.Text;
            bookingToEdit.Guest.Address = TextBoxAddress.Text;
            bookingToEdit.Guest.MobileNumber = TextBoxMobileNumber.Text;
            bookingToEdit.Guest.Email = TextBoxEmail.Text;
            bookingToEdit.Guest.IsResident = CheckBoxResident.Checked;

            bookingToEdit.CheckInDate = DateTimePickerCheckin.Value;
            bookingToEdit.CheckOutDate = DateTimePickerCheckout.Value;
            bookingToEdit.Room.RoomType = (RoomType)ComboBoxRoomType.SelectedItem;
            bookingToEdit.IsRecurring = CheckBoxRecurring.Checked;
            bookingToEdit.SpecialRequests = TextBoxSpecialRequests.Text;

            MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
