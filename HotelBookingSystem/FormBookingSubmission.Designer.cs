namespace HotelBookingSystem
{
    partial class FormBookingSubmission
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
            LabelCheckin = new Label();
            LabelCheckout = new Label();
            CheckinDatePicker = new DateTimePicker();
            CheckoutDatePicker = new DateTimePicker();
            CheckBoxRecurring = new CheckBox();
            LabelSpecialRequests = new Label();
            TextBoxSpecialRequests = new RichTextBox();
            LabelRoomType = new Label();
            RoomSingle = new RadioButton();
            RoomDouble = new RadioButton();
            RoomTriple = new RadioButton();
            ButtonSubmit = new Button();
            LabelAddress = new Label();
            LabelMobileNumber = new Label();
            LabelNIC = new Label();
            LabelName = new Label();
            LabelEmail = new Label();
            TextBoxName = new TextBox();
            TextBoxNIC = new TextBox();
            TextBoxAddress = new TextBox();
            TextBoxMobileNumber = new TextBox();
            TextBoxEmail = new TextBox();
            RadioButtonNonResident = new RadioButton();
            RadioButtonResident = new RadioButton();
            LabelResidency = new Label();
            GroupBoxGuest = new GroupBox();
            GroupBoxBooking = new GroupBox();
            ButtonGenerateReceipt = new Button();
            GroupBoxGuest.SuspendLayout();
            GroupBoxBooking.SuspendLayout();
            SuspendLayout();
            // 
            // LabelCheckin
            // 
            LabelCheckin.AutoSize = true;
            LabelCheckin.Location = new Point(70, 73);
            LabelCheckin.Name = "LabelCheckin";
            LabelCheckin.Size = new Size(127, 23);
            LabelCheckin.TabIndex = 1;
            LabelCheckin.Text = "Check-in Date :";
            // 
            // LabelCheckout
            // 
            LabelCheckout.AutoSize = true;
            LabelCheckout.Location = new Point(70, 120);
            LabelCheckout.Name = "LabelCheckout";
            LabelCheckout.Size = new Size(139, 23);
            LabelCheckout.TabIndex = 3;
            LabelCheckout.Text = "Check-out Date :";
            // 
            // CheckinDatePicker
            // 
            CheckinDatePicker.Location = new Point(259, 73);
            CheckinDatePicker.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            CheckinDatePicker.MinDate = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckinDatePicker.Name = "CheckinDatePicker";
            CheckinDatePicker.Size = new Size(311, 30);
            CheckinDatePicker.TabIndex = 5;
            CheckinDatePicker.Value = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckinDatePicker.ValueChanged += CheckinDatePicker_ValueChanged;
            // 
            // CheckoutDatePicker
            // 
            CheckoutDatePicker.Location = new Point(259, 115);
            CheckoutDatePicker.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            CheckoutDatePicker.MinDate = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckoutDatePicker.Name = "CheckoutDatePicker";
            CheckoutDatePicker.Size = new Size(311, 30);
            CheckoutDatePicker.TabIndex = 6;
            CheckoutDatePicker.Value = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckoutDatePicker.ValueChanged += CheckoutDatePicker_ValueChanged;
            // 
            // CheckBoxRecurring
            // 
            CheckBoxRecurring.AutoSize = true;
            CheckBoxRecurring.Location = new Point(820, 802);
            CheckBoxRecurring.Name = "CheckBoxRecurring";
            CheckBoxRecurring.Size = new Size(124, 24);
            CheckBoxRecurring.TabIndex = 9;
            CheckBoxRecurring.Text = "Recurring stay";
            CheckBoxRecurring.UseVisualStyleBackColor = true;
            // 
            // LabelSpecialRequests
            // 
            LabelSpecialRequests.AutoSize = true;
            LabelSpecialRequests.Location = new Point(70, 213);
            LabelSpecialRequests.Name = "LabelSpecialRequests";
            LabelSpecialRequests.Size = new Size(145, 23);
            LabelSpecialRequests.TabIndex = 10;
            LabelSpecialRequests.Text = "Special Requests :";
            // 
            // TextBoxSpecialRequests
            // 
            TextBoxSpecialRequests.Location = new Point(259, 213);
            TextBoxSpecialRequests.Name = "TextBoxSpecialRequests";
            TextBoxSpecialRequests.Size = new Size(311, 140);
            TextBoxSpecialRequests.TabIndex = 11;
            TextBoxSpecialRequests.Text = "";
            // 
            // LabelRoomType
            // 
            LabelRoomType.AutoSize = true;
            LabelRoomType.Location = new Point(70, 170);
            LabelRoomType.Name = "LabelRoomType";
            LabelRoomType.Size = new Size(104, 23);
            LabelRoomType.TabIndex = 12;
            LabelRoomType.Text = "Room Type :";
            // 
            // RoomSingle
            // 
            RoomSingle.AutoSize = true;
            RoomSingle.Location = new Point(259, 170);
            RoomSingle.Name = "RoomSingle";
            RoomSingle.Size = new Size(77, 27);
            RoomSingle.TabIndex = 13;
            RoomSingle.TabStop = true;
            RoomSingle.Text = "Single";
            RoomSingle.UseVisualStyleBackColor = true;
            RoomSingle.CheckedChanged += RoomSingle_CheckedChanged;
            // 
            // RoomDouble
            // 
            RoomDouble.AutoSize = true;
            RoomDouble.Location = new Point(357, 170);
            RoomDouble.Name = "RoomDouble";
            RoomDouble.Size = new Size(86, 27);
            RoomDouble.TabIndex = 14;
            RoomDouble.TabStop = true;
            RoomDouble.Text = "Double";
            RoomDouble.UseVisualStyleBackColor = true;
            RoomDouble.CheckedChanged += RoomDouble_CheckedChanged;
            // 
            // RoomTriple
            // 
            RoomTriple.AutoSize = true;
            RoomTriple.Location = new Point(471, 170);
            RoomTriple.Name = "RoomTriple";
            RoomTriple.Size = new Size(72, 27);
            RoomTriple.TabIndex = 15;
            RoomTriple.TabStop = true;
            RoomTriple.Text = "Triple";
            RoomTriple.UseVisualStyleBackColor = true;
            RoomTriple.CheckedChanged += RoomTriple_CheckedChanged;
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Font = new Font("Segoe UI", 10F);
            ButtonSubmit.Location = new Point(1262, 465);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(115, 38);
            ButtonSubmit.TabIndex = 16;
            ButtonSubmit.Text = "Submit";
            ButtonSubmit.UseVisualStyleBackColor = true;
            ButtonSubmit.Click += ButtonSubmit_Click;
            // 
            // LabelAddress
            // 
            LabelAddress.AutoSize = true;
            LabelAddress.Location = new Point(71, 177);
            LabelAddress.Name = "LabelAddress";
            LabelAddress.Size = new Size(79, 23);
            LabelAddress.TabIndex = 21;
            LabelAddress.Text = "Address :";
            // 
            // LabelMobileNumber
            // 
            LabelMobileNumber.AutoSize = true;
            LabelMobileNumber.Location = new Point(71, 220);
            LabelMobileNumber.Name = "LabelMobileNumber";
            LabelMobileNumber.Size = new Size(139, 23);
            LabelMobileNumber.TabIndex = 20;
            LabelMobileNumber.Text = "Mobile Number :";
            // 
            // LabelNIC
            // 
            LabelNIC.AutoSize = true;
            LabelNIC.Location = new Point(71, 127);
            LabelNIC.Name = "LabelNIC";
            LabelNIC.Size = new Size(43, 23);
            LabelNIC.TabIndex = 19;
            LabelNIC.Text = "NIC:";
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new Point(71, 80);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(65, 23);
            LabelName.TabIndex = 18;
            LabelName.Text = "Name :";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(71, 265);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(60, 23);
            LabelEmail.TabIndex = 22;
            LabelEmail.Text = "Email :";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(286, 73);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(268, 30);
            TextBoxName.TabIndex = 23;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // TextBoxNIC
            // 
            TextBoxNIC.Location = new Point(286, 120);
            TextBoxNIC.Name = "TextBoxNIC";
            TextBoxNIC.Size = new Size(268, 30);
            TextBoxNIC.TabIndex = 24;
            TextBoxNIC.TextChanged += TextBoxNIC_TextChanged;
            // 
            // TextBoxAddress
            // 
            TextBoxAddress.Location = new Point(286, 170);
            TextBoxAddress.Name = "TextBoxAddress";
            TextBoxAddress.Size = new Size(268, 30);
            TextBoxAddress.TabIndex = 25;
            TextBoxAddress.TextChanged += TextBoxAddress_TextChanged;
            // 
            // TextBoxMobileNumber
            // 
            TextBoxMobileNumber.Location = new Point(286, 213);
            TextBoxMobileNumber.Name = "TextBoxMobileNumber";
            TextBoxMobileNumber.Size = new Size(268, 30);
            TextBoxMobileNumber.TabIndex = 26;
            TextBoxMobileNumber.TextChanged += TextBoxMobileNumber_TextChanged;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(286, 265);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(268, 30);
            TextBoxEmail.TabIndex = 27;
            TextBoxEmail.TextChanged += TextBoxEmail_TextChanged;
            // 
            // RadioButtonNonResident
            // 
            RadioButtonNonResident.AutoSize = true;
            RadioButtonNonResident.Location = new Point(405, 316);
            RadioButtonNonResident.Name = "RadioButtonNonResident";
            RadioButtonNonResident.Size = new Size(136, 27);
            RadioButtonNonResident.TabIndex = 30;
            RadioButtonNonResident.TabStop = true;
            RadioButtonNonResident.Text = "Non-Resident";
            RadioButtonNonResident.UseVisualStyleBackColor = true;
            RadioButtonNonResident.CheckedChanged += RadioButtonNonResident_CheckedChanged;
            // 
            // RadioButtonResident
            // 
            RadioButtonResident.AutoSize = true;
            RadioButtonResident.Location = new Point(289, 318);
            RadioButtonResident.Name = "RadioButtonResident";
            RadioButtonResident.Size = new Size(96, 27);
            RadioButtonResident.TabIndex = 29;
            RadioButtonResident.TabStop = true;
            RadioButtonResident.Text = "Resident";
            RadioButtonResident.UseVisualStyleBackColor = true;
            RadioButtonResident.CheckedChanged += RadioButtonResident_CheckedChanged;
            // 
            // LabelResidency
            // 
            LabelResidency.AutoSize = true;
            LabelResidency.Location = new Point(71, 320);
            LabelResidency.Name = "LabelResidency";
            LabelResidency.Size = new Size(94, 23);
            LabelResidency.TabIndex = 28;
            LabelResidency.Text = "Residency :";
            // 
            // GroupBoxGuest
            // 
            GroupBoxGuest.Controls.Add(TextBoxNIC);
            GroupBoxGuest.Controls.Add(RadioButtonNonResident);
            GroupBoxGuest.Controls.Add(LabelName);
            GroupBoxGuest.Controls.Add(RadioButtonResident);
            GroupBoxGuest.Controls.Add(LabelNIC);
            GroupBoxGuest.Controls.Add(LabelResidency);
            GroupBoxGuest.Controls.Add(LabelMobileNumber);
            GroupBoxGuest.Controls.Add(TextBoxEmail);
            GroupBoxGuest.Controls.Add(LabelAddress);
            GroupBoxGuest.Controls.Add(TextBoxMobileNumber);
            GroupBoxGuest.Controls.Add(LabelEmail);
            GroupBoxGuest.Controls.Add(TextBoxAddress);
            GroupBoxGuest.Controls.Add(TextBoxName);
            GroupBoxGuest.Font = new Font("Segoe UI", 10F);
            GroupBoxGuest.Location = new Point(35, 28);
            GroupBoxGuest.Name = "GroupBoxGuest";
            GroupBoxGuest.Size = new Size(653, 400);
            GroupBoxGuest.TabIndex = 31;
            GroupBoxGuest.TabStop = false;
            GroupBoxGuest.Text = "Enter the Guest Information:";
            // 
            // GroupBoxBooking
            // 
            GroupBoxBooking.Controls.Add(LabelCheckin);
            GroupBoxBooking.Controls.Add(LabelCheckout);
            GroupBoxBooking.Controls.Add(CheckinDatePicker);
            GroupBoxBooking.Controls.Add(RoomTriple);
            GroupBoxBooking.Controls.Add(CheckoutDatePicker);
            GroupBoxBooking.Controls.Add(RoomDouble);
            GroupBoxBooking.Controls.Add(LabelSpecialRequests);
            GroupBoxBooking.Controls.Add(RoomSingle);
            GroupBoxBooking.Controls.Add(TextBoxSpecialRequests);
            GroupBoxBooking.Controls.Add(LabelRoomType);
            GroupBoxBooking.Font = new Font("Segoe UI", 10F);
            GroupBoxBooking.Location = new Point(754, 28);
            GroupBoxBooking.Name = "GroupBoxBooking";
            GroupBoxBooking.Size = new Size(623, 400);
            GroupBoxBooking.TabIndex = 32;
            GroupBoxBooking.TabStop = false;
            GroupBoxBooking.Text = "Enter the Booking Details:";
            // 
            // ButtonGenerateReceipt
            // 
            ButtonGenerateReceipt.Font = new Font("Segoe UI", 10F);
            ButtonGenerateReceipt.Location = new Point(754, 466);
            ButtonGenerateReceipt.Name = "ButtonGenerateReceipt";
            ButtonGenerateReceipt.Size = new Size(159, 38);
            ButtonGenerateReceipt.TabIndex = 33;
            ButtonGenerateReceipt.Text = "Generate Receipt";
            ButtonGenerateReceipt.UseVisualStyleBackColor = true;
            // 
            // FormBookingSubmission
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 768);
            Controls.Add(ButtonGenerateReceipt);
            Controls.Add(GroupBoxBooking);
            Controls.Add(GroupBoxGuest);
            Controls.Add(ButtonSubmit);
            Controls.Add(CheckBoxRecurring);
            Name = "FormBookingSubmission";
            Text = "Booking Submission";
            Load += FormBookingSubmission_Load;
            GroupBoxGuest.ResumeLayout(false);
            GroupBoxGuest.PerformLayout();
            GroupBoxBooking.ResumeLayout(false);
            GroupBoxBooking.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LabelCheckin;
        private Label LabelCheckout;
        private DateTimePicker CheckinDatePicker;
        private DateTimePicker CheckoutDatePicker;
        private CheckBox CheckBoxRecurring;
        private Label LabelSpecialRequests;
        private RichTextBox TextBoxSpecialRequests;
        private Label LabelRoomType;
        private RadioButton RoomSingle;
        private RadioButton RoomDouble;
        private RadioButton RoomTriple;
        private Button ButtonSubmit;
        private Label LabelAddress;
        private Label LabelMobileNumber;
        private Label LabelNIC;
        private Label LabelName;
        private Label LabelEmail;
        private TextBox TextBoxName;
        private TextBox TextBoxNIC;
        private TextBox TextBoxAddress;
        private TextBox TextBoxMobileNumber;
        private TextBox TextBoxEmail;
        private RadioButton RadioButtonNonResident;
        private RadioButton RadioButtonResident;
        private Label LabelResidency;
        private GroupBox GroupBoxGuest;
        private GroupBox GroupBoxBooking;
        private Button ButtonGenerateReceipt;
    }
}