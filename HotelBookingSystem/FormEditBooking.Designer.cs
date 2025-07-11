﻿namespace HotelBookingSystem
{
    partial class FormEditBooking
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
            LabelGuestInfo = new Label();
            LabelGuestName = new Label();
            LabelNIC = new Label();
            LabelAddress = new Label();
            LabelMobileNumber = new Label();
            LabelEmail = new Label();
            label5 = new Label();
            LabelBookingId = new Label();
            LabelCheckin = new Label();
            LabelCheckout = new Label();
            LabelRoomType = new Label();
            TextBoxGuestName = new TextBox();
            TextBoxNIC = new TextBox();
            TextBoxAddress = new TextBox();
            TextBoxMobileNumber = new TextBox();
            TextBoxEmail = new TextBox();
            TextBoxBookingId = new TextBox();
            LabelSpecialRequests = new Label();
            DateTimePickerCheckin = new DateTimePicker();
            DateTimePickerCheckout = new DateTimePicker();
            ButtonSave = new Button();
            CheckBoxRecurring = new CheckBox();
            CheckBoxResident = new CheckBox();
            TextBoxSpecialRequests = new TextBox();
            LabelStandard = new Label();
            LabelDeluxe = new Label();
            LabelSuite = new Label();
            LabelFamily = new Label();
            NumericUpDownStandard = new NumericUpDown();
            NumericUpDownDeluxe = new NumericUpDown();
            NumericUpDownSuite = new NumericUpDown();
            NumericUpDownFamily = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownStandard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownDeluxe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownSuite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownFamily).BeginInit();
            SuspendLayout();
            // 
            // LabelGuestInfo
            // 
            LabelGuestInfo.AutoSize = true;
            LabelGuestInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelGuestInfo.Location = new Point(76, 48);
            LabelGuestInfo.Name = "LabelGuestInfo";
            LabelGuestInfo.Size = new Size(161, 23);
            LabelGuestInfo.TabIndex = 0;
            LabelGuestInfo.Text = "Guest Information ";
            // 
            // LabelGuestName
            // 
            LabelGuestName.AutoSize = true;
            LabelGuestName.Location = new Point(125, 104);
            LabelGuestName.Name = "LabelGuestName";
            LabelGuestName.Size = new Size(97, 20);
            LabelGuestName.TabIndex = 1;
            LabelGuestName.Text = "Guest Name :";
            // 
            // LabelNIC
            // 
            LabelNIC.AutoSize = true;
            LabelNIC.Location = new Point(182, 149);
            LabelNIC.Name = "LabelNIC";
            LabelNIC.Size = new Size(40, 20);
            LabelNIC.TabIndex = 2;
            LabelNIC.Text = "NIC :";
            // 
            // LabelAddress
            // 
            LabelAddress.AutoSize = true;
            LabelAddress.Location = new Point(153, 188);
            LabelAddress.Name = "LabelAddress";
            LabelAddress.Size = new Size(69, 20);
            LabelAddress.TabIndex = 3;
            LabelAddress.Text = "Address :";
            // 
            // LabelMobileNumber
            // 
            LabelMobileNumber.AutoSize = true;
            LabelMobileNumber.Location = new Point(101, 226);
            LabelMobileNumber.Name = "LabelMobileNumber";
            LabelMobileNumber.Size = new Size(121, 20);
            LabelMobileNumber.TabIndex = 4;
            LabelMobileNumber.Text = "Mobile Number :";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(169, 269);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(53, 20);
            LabelEmail.TabIndex = 5;
            LabelEmail.Text = "Email :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(792, 48);
            label5.Name = "label5";
            label5.Size = new Size(178, 23);
            label5.TabIndex = 6;
            label5.Text = "Booking Information";
            // 
            // LabelBookingId
            // 
            LabelBookingId.AutoSize = true;
            LabelBookingId.Location = new Point(775, 104);
            LabelBookingId.Name = "LabelBookingId";
            LabelBookingId.Size = new Size(90, 20);
            LabelBookingId.TabIndex = 7;
            LabelBookingId.Text = "Booking ID :";
            // 
            // LabelCheckin
            // 
            LabelCheckin.AutoSize = true;
            LabelCheckin.Location = new Point(756, 149);
            LabelCheckin.Name = "LabelCheckin";
            LabelCheckin.Size = new Size(109, 20);
            LabelCheckin.TabIndex = 8;
            LabelCheckin.Text = "Check-in Date :";
            // 
            // LabelCheckout
            // 
            LabelCheckout.AutoSize = true;
            LabelCheckout.Location = new Point(746, 188);
            LabelCheckout.Name = "LabelCheckout";
            LabelCheckout.Size = new Size(119, 20);
            LabelCheckout.TabIndex = 9;
            LabelCheckout.Text = "Check-out Date :";
            // 
            // LabelRoomType
            // 
            LabelRoomType.AutoSize = true;
            LabelRoomType.Location = new Point(774, 226);
            LabelRoomType.Name = "LabelRoomType";
            LabelRoomType.Size = new Size(91, 20);
            LabelRoomType.TabIndex = 10;
            LabelRoomType.Text = "Room Type :";
            // 
            // TextBoxGuestName
            // 
            TextBoxGuestName.Location = new Point(310, 97);
            TextBoxGuestName.Name = "TextBoxGuestName";
            TextBoxGuestName.Size = new Size(125, 27);
            TextBoxGuestName.TabIndex = 12;
            // 
            // TextBoxNIC
            // 
            TextBoxNIC.Location = new Point(310, 142);
            TextBoxNIC.Name = "TextBoxNIC";
            TextBoxNIC.Size = new Size(125, 27);
            TextBoxNIC.TabIndex = 13;
            // 
            // TextBoxAddress
            // 
            TextBoxAddress.Location = new Point(310, 185);
            TextBoxAddress.Name = "TextBoxAddress";
            TextBoxAddress.Size = new Size(125, 27);
            TextBoxAddress.TabIndex = 14;
            // 
            // TextBoxMobileNumber
            // 
            TextBoxMobileNumber.Location = new Point(310, 226);
            TextBoxMobileNumber.Name = "TextBoxMobileNumber";
            TextBoxMobileNumber.Size = new Size(125, 27);
            TextBoxMobileNumber.TabIndex = 15;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(310, 266);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(125, 27);
            TextBoxEmail.TabIndex = 16;
            // 
            // TextBoxBookingId
            // 
            TextBoxBookingId.Location = new Point(933, 101);
            TextBoxBookingId.Name = "TextBoxBookingId";
            TextBoxBookingId.Size = new Size(125, 27);
            TextBoxBookingId.TabIndex = 17;
            // 
            // LabelSpecialRequests
            // 
            LabelSpecialRequests.AutoSize = true;
            LabelSpecialRequests.Location = new Point(738, 342);
            LabelSpecialRequests.Name = "LabelSpecialRequests";
            LabelSpecialRequests.Size = new Size(127, 20);
            LabelSpecialRequests.TabIndex = 18;
            LabelSpecialRequests.Text = "Special Requests :";
            // 
            // DateTimePickerCheckin
            // 
            DateTimePickerCheckin.Location = new Point(933, 144);
            DateTimePickerCheckin.Name = "DateTimePickerCheckin";
            DateTimePickerCheckin.Size = new Size(250, 27);
            DateTimePickerCheckin.TabIndex = 24;
            DateTimePickerCheckin.ValueChanged += DateTimePickerCheckin_ValueChanged;
            // 
            // DateTimePickerCheckout
            // 
            DateTimePickerCheckout.Location = new Point(933, 185);
            DateTimePickerCheckout.Name = "DateTimePickerCheckout";
            DateTimePickerCheckout.Size = new Size(250, 27);
            DateTimePickerCheckout.TabIndex = 25;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(1118, 428);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(125, 48);
            ButtonSave.TabIndex = 26;
            ButtonSave.Text = "Save Changes";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // CheckBoxRecurring
            // 
            CheckBoxRecurring.AutoSize = true;
            CheckBoxRecurring.Location = new Point(1100, 385);
            CheckBoxRecurring.Name = "CheckBoxRecurring";
            CheckBoxRecurring.Size = new Size(126, 24);
            CheckBoxRecurring.TabIndex = 27;
            CheckBoxRecurring.Text = "Recurring Stay";
            CheckBoxRecurring.UseVisualStyleBackColor = true;
            // 
            // CheckBoxResident
            // 
            CheckBoxResident.AutoSize = true;
            CheckBoxResident.Location = new Point(381, 324);
            CheckBoxResident.Name = "CheckBoxResident";
            CheckBoxResident.Size = new Size(88, 24);
            CheckBoxResident.TabIndex = 28;
            CheckBoxResident.Text = "Resident";
            CheckBoxResident.UseVisualStyleBackColor = true;
            // 
            // TextBoxSpecialRequests
            // 
            TextBoxSpecialRequests.Location = new Point(933, 339);
            TextBoxSpecialRequests.Name = "TextBoxSpecialRequests";
            TextBoxSpecialRequests.Size = new Size(310, 27);
            TextBoxSpecialRequests.TabIndex = 29;
            // 
            // LabelStandard
            // 
            LabelStandard.AutoSize = true;
            LabelStandard.Location = new Point(933, 238);
            LabelStandard.Name = "LabelStandard";
            LabelStandard.Size = new Size(69, 20);
            LabelStandard.TabIndex = 30;
            LabelStandard.Text = "Standard";
            // 
            // LabelDeluxe
            // 
            LabelDeluxe.AutoSize = true;
            LabelDeluxe.Location = new Point(933, 288);
            LabelDeluxe.Name = "LabelDeluxe";
            LabelDeluxe.Size = new Size(55, 20);
            LabelDeluxe.TabIndex = 31;
            LabelDeluxe.Text = "Deluxe";
            // 
            // LabelSuite
            // 
            LabelSuite.AutoSize = true;
            LabelSuite.Location = new Point(1118, 238);
            LabelSuite.Name = "LabelSuite";
            LabelSuite.Size = new Size(42, 20);
            LabelSuite.TabIndex = 32;
            LabelSuite.Text = "Suite";
            // 
            // LabelFamily
            // 
            LabelFamily.AutoSize = true;
            LabelFamily.Location = new Point(1109, 285);
            LabelFamily.Name = "LabelFamily";
            LabelFamily.Size = new Size(51, 20);
            LabelFamily.TabIndex = 33;
            LabelFamily.Text = "Family";
            // 
            // NumericUpDownStandard
            // 
            NumericUpDownStandard.Location = new Point(1008, 236);
            NumericUpDownStandard.Name = "NumericUpDownStandard";
            NumericUpDownStandard.Size = new Size(59, 27);
            NumericUpDownStandard.TabIndex = 34;
            // 
            // NumericUpDownDeluxe
            // 
            NumericUpDownDeluxe.Location = new Point(1008, 283);
            NumericUpDownDeluxe.Name = "NumericUpDownDeluxe";
            NumericUpDownDeluxe.Size = new Size(59, 27);
            NumericUpDownDeluxe.TabIndex = 35;
            // 
            // NumericUpDownSuite
            // 
            NumericUpDownSuite.Location = new Point(1167, 236);
            NumericUpDownSuite.Name = "NumericUpDownSuite";
            NumericUpDownSuite.Size = new Size(59, 27);
            NumericUpDownSuite.TabIndex = 36;
            // 
            // NumericUpDownFamily
            // 
            NumericUpDownFamily.Location = new Point(1167, 281);
            NumericUpDownFamily.Name = "NumericUpDownFamily";
            NumericUpDownFamily.Size = new Size(59, 27);
            NumericUpDownFamily.TabIndex = 37;
            // 
            // FormEditBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1401, 627);
            Controls.Add(NumericUpDownFamily);
            Controls.Add(NumericUpDownSuite);
            Controls.Add(NumericUpDownDeluxe);
            Controls.Add(NumericUpDownStandard);
            Controls.Add(LabelFamily);
            Controls.Add(LabelSuite);
            Controls.Add(LabelDeluxe);
            Controls.Add(LabelStandard);
            Controls.Add(TextBoxSpecialRequests);
            Controls.Add(CheckBoxResident);
            Controls.Add(CheckBoxRecurring);
            Controls.Add(ButtonSave);
            Controls.Add(DateTimePickerCheckout);
            Controls.Add(DateTimePickerCheckin);
            Controls.Add(LabelSpecialRequests);
            Controls.Add(TextBoxBookingId);
            Controls.Add(TextBoxEmail);
            Controls.Add(TextBoxMobileNumber);
            Controls.Add(TextBoxAddress);
            Controls.Add(TextBoxNIC);
            Controls.Add(TextBoxGuestName);
            Controls.Add(LabelRoomType);
            Controls.Add(LabelCheckout);
            Controls.Add(LabelCheckin);
            Controls.Add(LabelBookingId);
            Controls.Add(label5);
            Controls.Add(LabelEmail);
            Controls.Add(LabelMobileNumber);
            Controls.Add(LabelAddress);
            Controls.Add(LabelNIC);
            Controls.Add(LabelGuestName);
            Controls.Add(LabelGuestInfo);
            Name = "FormEditBooking";
            Text = "FormEditBooking";
            Load += FormEditBooking_Load;
            ((System.ComponentModel.ISupportInitialize)NumericUpDownStandard).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownDeluxe).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownSuite).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownFamily).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelGuestInfo;
        private Label LabelGuestName;
        private Label LabelNIC;
        private Label LabelAddress;
        private Label LabelMobileNumber;
        private Label LabelEmail;
        private Label label5;
        private Label LabelBookingId;
        private Label LabelCheckin;
        private Label LabelCheckout;
        private Label LabelRoomType;
        private TextBox TextBoxGuestName;
        private TextBox TextBoxNIC;
        private TextBox TextBoxAddress;
        private TextBox TextBoxMobileNumber;
        private TextBox TextBoxEmail;
        private TextBox TextBoxBookingId;
        private Label LabelSpecialRequests;
        private DateTimePicker DateTimePickerCheckin;
        private DateTimePicker DateTimePickerCheckout;
        private Button ButtonSave;
        private CheckBox CheckBoxRecurring;
        private CheckBox CheckBoxResident;
        private TextBox TextBoxSpecialRequests;
        private Label LabelStandard;
        private Label LabelDeluxe;
        private Label LabelSuite;
        private Label LabelFamily;
        private NumericUpDown NumericUpDownStandard;
        private NumericUpDown NumericUpDownDeluxe;
        private NumericUpDown NumericUpDownSuite;
        private NumericUpDown NumericUpDownFamily;
    }
}