namespace HotelBookingSystem
{
    partial class FormChatBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelAskMe = new Label();
            TextBoxUserQuery = new TextBox();
            ButtonChatbotSend = new Button();
            LabelAnswer = new Label();
            SuspendLayout();
            // 
            // LabelAskMe
            // 
            LabelAskMe.AutoSize = true;
            LabelAskMe.Location = new Point(36, 32);
            LabelAskMe.Name = "LabelAskMe";
            LabelAskMe.Size = new Size(127, 20);
            LabelAskMe.TabIndex = 0;
            LabelAskMe.Text = "Ask me anything...";
            // 
            // TextBoxUserQuery
            // 
            TextBoxUserQuery.Location = new Point(75, 68);
            TextBoxUserQuery.Name = "TextBoxUserQuery";
            TextBoxUserQuery.Size = new Size(347, 27);
            TextBoxUserQuery.TabIndex = 1;
            TextBoxUserQuery.TextChanged += TextBoxUserQuery_TextChanged;
            // 
            // ButtonChatbotSend
            // 
            ButtonChatbotSend.Location = new Point(328, 120);
            ButtonChatbotSend.Name = "ButtonChatbotSend";
            ButtonChatbotSend.Size = new Size(94, 29);
            ButtonChatbotSend.TabIndex = 2;
            ButtonChatbotSend.Text = "Send";
            ButtonChatbotSend.UseVisualStyleBackColor = true;
            // 
            // LabelAnswer
            // 
            LabelAnswer.AutoSize = true;
            LabelAnswer.Location = new Point(401, 188);
            LabelAnswer.Name = "LabelAnswer";
            LabelAnswer.Size = new Size(206, 20);
            LabelAnswer.TabIndex = 3;
            LabelAnswer.Text = "Answer will be displayed here";
            // 
            // FormChatBot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LabelAnswer);
            Controls.Add(ButtonChatbotSend);
            Controls.Add(TextBoxUserQuery);
            Controls.Add(LabelAskMe);
            Name = "FormChatBot";
            Text = "ChatBot";
            Load += ChatBot_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelAskMe;
        private TextBox TextBoxUserQuery;
        private Button ButtonChatbotSend;
        private Label LabelAnswer;
    }
}