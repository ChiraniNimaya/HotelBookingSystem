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
            bool isRadioSelected = RoomSingle.Checked || RoomDouble.Checked || RoomTriple.Checked;

            ButtonSubmit.Enabled = isDateRangeValid && isRadioSelected;
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
    }
}
