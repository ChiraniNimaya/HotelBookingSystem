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
            ListBoxSpecialRequests = new RichTextBox();
            LabelRoomType = new Label();
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
            LinkLabelFamily = new LinkLabel();
            LinkLabelSuite = new LinkLabel();
            LinkLabelDeluxe = new LinkLabel();
            LinkLabelStandard = new LinkLabel();
            NumericUpDownFamily = new NumericUpDown();
            NumericUpDownSuite = new NumericUpDown();
            NumericUpDownDeluxe = new NumericUpDown();
            NumericUpDownStandard = new NumericUpDown();
            GroupBoxGuest.SuspendLayout();
            GroupBoxBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownFamily).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownSuite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownDeluxe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownStandard).BeginInit();
            SuspendLayout();
            // 
            // LabelCheckin
            // 
            LabelCheckin.AutoSize = true;
            LabelCheckin.Location = new Point(67, 57);
            LabelCheckin.Name = "LabelCheckin";
            LabelCheckin.Size = new Size(127, 23);
            LabelCheckin.TabIndex = 1;
            LabelCheckin.Text = "Check-in Date :";
            // 
            // LabelCheckout
            // 
            LabelCheckout.AutoSize = true;
            LabelCheckout.Location = new Point(67, 104);
            LabelCheckout.Name = "LabelCheckout";
            LabelCheckout.Size = new Size(139, 23);
            LabelCheckout.TabIndex = 3;
            LabelCheckout.Text = "Check-out Date :";
            // 
            // CheckinDatePicker
            // 
            CheckinDatePicker.Location = new Point(256, 57);
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
            CheckoutDatePicker.Location = new Point(256, 99);
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
            CheckBoxRecurring.Location = new Point(447, 454);
            CheckBoxRecurring.Name = "CheckBoxRecurring";
            CheckBoxRecurring.Size = new Size(140, 27);
            CheckBoxRecurring.TabIndex = 9;
            CheckBoxRecurring.Text = "Recurring stay";
            CheckBoxRecurring.UseVisualStyleBackColor = true;
            CheckBoxRecurring.CheckedChanged += CheckBoxRecurring_CheckedChanged;
            // 
            // LabelSpecialRequests
            // 
            LabelSpecialRequests.AutoSize = true;
            LabelSpecialRequests.Location = new Point(70, 311);
            LabelSpecialRequests.Name = "LabelSpecialRequests";
            LabelSpecialRequests.Size = new Size(145, 23);
            LabelSpecialRequests.TabIndex = 10;
            LabelSpecialRequests.Text = "Special Requests :";
            // 
            // ListBoxSpecialRequests
            // 
            ListBoxSpecialRequests.Location = new Point(276, 308);
            ListBoxSpecialRequests.Name = "ListBoxSpecialRequests";
            ListBoxSpecialRequests.Size = new Size(311, 140);
            ListBoxSpecialRequests.TabIndex = 11;
            ListBoxSpecialRequests.Text = "";
            // 
            // LabelRoomType
            // 
            LabelRoomType.AutoSize = true;
            LabelRoomType.Location = new Point(72, 165);
            LabelRoomType.Name = "LabelRoomType";
            LabelRoomType.Size = new Size(104, 23);
            LabelRoomType.TabIndex = 12;
            LabelRoomType.Text = "Room Type :";
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Font = new Font("Segoe UI", 10F);
            ButtonSubmit.Location = new Point(1259, 584);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(115, 38);
            ButtonSubmit.TabIndex = 16;
            ButtonSubmit.Text = "Submit";
            ButtonSubmit.UseVisualStyleBackColor = true;
            ButtonSubmit.Click += ButtonSubmit_ClickAsync;
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
            LabelNIC.Size = new Size(114, 23);
            LabelNIC.TabIndex = 19;
            LabelNIC.Text = "NIC/Passport:";
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
            GroupBoxGuest.Location = new Point(49, 40);
            GroupBoxGuest.Name = "GroupBoxGuest";
            GroupBoxGuest.Size = new Size(653, 414);
            GroupBoxGuest.TabIndex = 31;
            GroupBoxGuest.TabStop = false;
            GroupBoxGuest.Text = "Enter the Guest Information:";
            // 
            // GroupBoxBooking
            // 
            GroupBoxBooking.Controls.Add(LinkLabelFamily);
            GroupBoxBooking.Controls.Add(LinkLabelSuite);
            GroupBoxBooking.Controls.Add(LinkLabelDeluxe);
            GroupBoxBooking.Controls.Add(LinkLabelStandard);
            GroupBoxBooking.Controls.Add(NumericUpDownFamily);
            GroupBoxBooking.Controls.Add(NumericUpDownSuite);
            GroupBoxBooking.Controls.Add(NumericUpDownDeluxe);
            GroupBoxBooking.Controls.Add(NumericUpDownStandard);
            GroupBoxBooking.Controls.Add(LabelCheckin);
            GroupBoxBooking.Controls.Add(LabelCheckout);
            GroupBoxBooking.Controls.Add(CheckinDatePicker);
            GroupBoxBooking.Controls.Add(CheckBoxRecurring);
            GroupBoxBooking.Controls.Add(CheckoutDatePicker);
            GroupBoxBooking.Controls.Add(LabelSpecialRequests);
            GroupBoxBooking.Controls.Add(ListBoxSpecialRequests);
            GroupBoxBooking.Controls.Add(LabelRoomType);
            GroupBoxBooking.Font = new Font("Segoe UI", 10F);
            GroupBoxBooking.Location = new Point(768, 40);
            GroupBoxBooking.Name = "GroupBoxBooking";
            GroupBoxBooking.Size = new Size(623, 512);
            GroupBoxBooking.TabIndex = 32;
            GroupBoxBooking.TabStop = false;
            GroupBoxBooking.Text = "Enter the Booking Details:";
            // 
            // LinkLabelFamily
            // 
            LinkLabelFamily.AutoSize = true;
            LinkLabelFamily.Location = new Point(421, 220);
            LinkLabelFamily.Name = "LinkLabelFamily";
            LinkLabelFamily.Size = new Size(57, 23);
            LinkLabelFamily.TabIndex = 25;
            LinkLabelFamily.TabStop = true;
            LinkLabelFamily.Text = "Family";
            LinkLabelFamily.LinkClicked += LinkLabelFamily_LinkClicked;
            // 
            // LinkLabelSuite
            // 
            LinkLabelSuite.AutoSize = true;
            LinkLabelSuite.Location = new Point(421, 173);
            LinkLabelSuite.Name = "LinkLabelSuite";
            LinkLabelSuite.Size = new Size(48, 23);
            LinkLabelSuite.TabIndex = 24;
            LinkLabelSuite.TabStop = true;
            LinkLabelSuite.Text = "Suite";
            LinkLabelSuite.LinkClicked += LinkLabelSuite_LinkClicked;
            // 
            // LinkLabelDeluxe
            // 
            LinkLabelDeluxe.AutoSize = true;
            LinkLabelDeluxe.Location = new Point(237, 220);
            LinkLabelDeluxe.Name = "LinkLabelDeluxe";
            LinkLabelDeluxe.Size = new Size(62, 23);
            LinkLabelDeluxe.TabIndex = 23;
            LinkLabelDeluxe.TabStop = true;
            LinkLabelDeluxe.Text = "Deluxe";
            LinkLabelDeluxe.LinkClicked += LinkLabelDeluxe_LinkClicked;
            // 
            // LinkLabelStandard
            // 
            LinkLabelStandard.AutoSize = true;
            LinkLabelStandard.Location = new Point(237, 173);
            LinkLabelStandard.Name = "LinkLabelStandard";
            LinkLabelStandard.Size = new Size(78, 23);
            LinkLabelStandard.TabIndex = 22;
            LinkLabelStandard.TabStop = true;
            LinkLabelStandard.Text = "Standard";
            LinkLabelStandard.LinkClicked += LinkLabelStandard_LinkClicked;
            // 
            // NumericUpDownFamily
            // 
            NumericUpDownFamily.Location = new Point(491, 215);
            NumericUpDownFamily.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            NumericUpDownFamily.Name = "NumericUpDownFamily";
            NumericUpDownFamily.Size = new Size(59, 30);
            NumericUpDownFamily.TabIndex = 21;
            NumericUpDownFamily.ValueChanged += NumericUpDownFamily_ValueChanged;
            // 
            // NumericUpDownSuite
            // 
            NumericUpDownSuite.Location = new Point(491, 170);
            NumericUpDownSuite.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NumericUpDownSuite.Name = "NumericUpDownSuite";
            NumericUpDownSuite.Size = new Size(59, 30);
            NumericUpDownSuite.TabIndex = 20;
            NumericUpDownSuite.ValueChanged += NumericUpDownSuite_ValueChanged;
            // 
            // NumericUpDownDeluxe
            // 
            NumericUpDownDeluxe.Location = new Point(321, 215);
            NumericUpDownDeluxe.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericUpDownDeluxe.Name = "NumericUpDownDeluxe";
            NumericUpDownDeluxe.Size = new Size(59, 30);
            NumericUpDownDeluxe.TabIndex = 19;
            NumericUpDownDeluxe.ValueChanged += NumericUpDownDeluxe_ValueChanged;
            // 
            // NumericUpDownStandard
            // 
            NumericUpDownStandard.Location = new Point(321, 170);
            NumericUpDownStandard.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            NumericUpDownStandard.Name = "NumericUpDownStandard";
            NumericUpDownStandard.Size = new Size(59, 30);
            NumericUpDownStandard.TabIndex = 18;
            NumericUpDownStandard.ValueChanged += NumericUpDownStandard_ValueChanged;
            // 
            // FormBookingSubmission
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1836, 668);
            Controls.Add(GroupBoxBooking);
            Controls.Add(GroupBoxGuest);
            Controls.Add(ButtonSubmit);
            Name = "FormBookingSubmission";
            Text = "Booking Submission";
            Load += FormBookingSubmission_Load;
            GroupBoxGuest.ResumeLayout(false);
            GroupBoxGuest.PerformLayout();
            GroupBoxBooking.ResumeLayout(false);
            GroupBoxBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownFamily).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownSuite).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownDeluxe).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownStandard).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label LabelCheckin;
        private Label LabelCheckout;
        private DateTimePicker CheckinDatePicker;
        private DateTimePicker CheckoutDatePicker;
        private CheckBox CheckBoxRecurring;
        private Label LabelSpecialRequests;
        private RichTextBox ListBoxSpecialRequests;
        private Label LabelRoomType;
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
        private NumericUpDown NumericUpDownFamily;
        private NumericUpDown NumericUpDownSuite;
        private NumericUpDown NumericUpDownDeluxe;
        private NumericUpDown NumericUpDownStandard;
        private LinkLabel LinkLabelFamily;
        private LinkLabel LinkLabelSuite;
        private LinkLabel LinkLabelDeluxe;
        private LinkLabel LinkLabelStandard;
    }
}