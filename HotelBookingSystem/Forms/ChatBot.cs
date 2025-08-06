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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelBookingSystem
{
    public partial class FormChatBot : Form
    {
        private ChatbotApiClient _chatbotClient;
        public FormChatBot()
        {
            InitializeComponent();
        }

        private void ChatBot_Load(object sender, EventArgs e)
        {
            ButtonChatbotSend.Enabled = false;
            _chatbotClient = new ChatbotApiClient();
        }

        private void TextBoxUserQuery_TextChanged(object sender, EventArgs e)
        {
            string userQuery = TextBoxUserQuery.Text;
            if (!string.IsNullOrEmpty(userQuery))
            {
                ButtonChatbotSend.Enabled = true;
            }
        }

        private async void ButtonChatbotSend_Click(object sender, EventArgs e)
        {
            string userMessage = TextBoxUserQuery.Text.Trim();
            AppendChat("You", userMessage);

            string botReply = await _chatbotClient.AskAsync(userMessage);
            AppendChat("Bot", botReply);

            TextBoxUserQuery.Clear();
        }

        private void AppendChat(string sender, string message)
        {
            if (sender == "You")
                RichTextBoxAnswer.SelectionColor = Color.Blue;
            else
                RichTextBoxAnswer.SelectionColor = Color.Green;

            RichTextBoxAnswer.AppendText($"{sender}: {message}\n\n");
            RichTextBoxAnswer.ScrollToCaret();
        }

    }
}
