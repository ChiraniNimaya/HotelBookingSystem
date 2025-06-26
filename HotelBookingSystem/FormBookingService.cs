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
            FormWeeklyView formWeeklyView = new FormWeeklyView();
            formWeeklyView.Show();
        }
    }
}
