namespace HotelBookingSystem
{
    partial class FormSearchBooking
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
            ButtonSearchNIC = new Button();
            ButtonSearchBookingId = new Button();
            TextBoxSearchNIC = new TextBox();
            TextBoxSearchBookingId = new TextBox();
            LabelNIC = new Label();
            LabelBookingId = new Label();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // ButtonSearchNIC
            // 
            ButtonSearchNIC.Location = new Point(426, 89);
            ButtonSearchNIC.Name = "ButtonSearchNIC";
            ButtonSearchNIC.Size = new Size(173, 29);
            ButtonSearchNIC.TabIndex = 0;
            ButtonSearchNIC.Text = "Search by NIC";
            ButtonSearchNIC.UseVisualStyleBackColor = true;
            ButtonSearchNIC.Click += ButtonSearchNIC_ClickAsync;
            // 
            // ButtonSearchBookingId
            // 
            ButtonSearchBookingId.Location = new Point(426, 209);
            ButtonSearchBookingId.Name = "ButtonSearchBookingId";
            ButtonSearchBookingId.Size = new Size(173, 29);
            ButtonSearchBookingId.TabIndex = 1;
            ButtonSearchBookingId.Text = "Search by Booking ID";
            ButtonSearchBookingId.UseVisualStyleBackColor = true;
            ButtonSearchBookingId.Click += ButtonSearchBookingId_ClickAsync;
            // 
            // TextBoxSearchNIC
            // 
            TextBoxSearchNIC.Location = new Point(125, 89);
            TextBoxSearchNIC.Name = "TextBoxSearchNIC";
            TextBoxSearchNIC.Size = new Size(231, 27);
            TextBoxSearchNIC.TabIndex = 2;
            TextBoxSearchNIC.TextChanged += TextBoxSearchNIC_TextChanged;
            // 
            // TextBoxSearchBookingId
            // 
            TextBoxSearchBookingId.Location = new Point(125, 211);
            TextBoxSearchBookingId.Name = "TextBoxSearchBookingId";
            TextBoxSearchBookingId.Size = new Size(231, 27);
            TextBoxSearchBookingId.TabIndex = 3;
            TextBoxSearchBookingId.TextChanged += TextBoxSearchBookingId_TextChanged;
            // 
            // LabelNIC
            // 
            LabelNIC.AutoSize = true;
            LabelNIC.Location = new Point(125, 48);
            LabelNIC.Name = "LabelNIC";
            LabelNIC.Size = new Size(78, 20);
            LabelNIC.TabIndex = 4;
            LabelNIC.Text = "Enter NIC :";
            // 
            // LabelBookingId
            // 
            LabelBookingId.AutoSize = true;
            LabelBookingId.Location = new Point(125, 170);
            LabelBookingId.Name = "LabelBookingId";
            LabelBookingId.Size = new Size(128, 20);
            LabelBookingId.TabIndex = 5;
            LabelBookingId.Text = "Enter Booking ID :";
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(591, 283);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(94, 29);
            ButtonClose.TabIndex = 6;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FormSearchBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 404);
            Controls.Add(ButtonClose);
            Controls.Add(LabelBookingId);
            Controls.Add(LabelNIC);
            Controls.Add(TextBoxSearchBookingId);
            Controls.Add(TextBoxSearchNIC);
            Controls.Add(ButtonSearchBookingId);
            Controls.Add(ButtonSearchNIC);
            Name = "FormSearchBooking";
            Text = "Search Booking";
            Load += FormSearchBooking_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonSearchNIC;
        private Button ButtonSearchBookingId;
        private TextBox TextBoxSearchNIC;
        private TextBox TextBoxSearchBookingId;
        private Label LabelNIC;
        private Label LabelBookingId;
        private Button ButtonClose;
    }
}