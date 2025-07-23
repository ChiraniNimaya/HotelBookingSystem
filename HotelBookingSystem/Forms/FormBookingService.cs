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
    public partial class FormBookingService : Form
    {
        public FormBookingService()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            FormBookingSubmission formBookingSubmission = new FormBookingSubmission();
            formBookingSubmission.ShowDialog();
        }

        private void ButtonRequest_Click(object sender, EventArgs e)
        {
            // Create a simple form with DateTimePicker
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select a Date for the Week",
                StartPosition = FormStartPosition.CenterScreen
            };

            DateTimePicker datePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(35, 20),
                Width = 200
            };

            Button confirmation = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(80, 60),
                Width = 75
            };

            prompt.Controls.Add(datePicker);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            // Show dialog and get selected date
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                DateTime targetDate = datePicker.Value.Date;
                FormWeeklyView formWeeklyView = new FormWeeklyView(targetDate);
                formWeeklyView.Show();
            }
        }


        private void ButtonChatBot_Click(object sender, EventArgs e)
        {
            FormChatBot formChatBot = new FormChatBot();
            formChatBot.Show();
        }

        private void ButtonEditBookings_Click(object sender, EventArgs e)
        {
            FormSearchBooking formSearchBooking = new FormSearchBooking();
            formSearchBooking.ShowDialog();
        }
    }
}
