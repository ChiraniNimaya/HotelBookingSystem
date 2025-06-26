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
            LabelEnter = new Label();
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
            SuspendLayout();
            // 
            // LabelEnter
            // 
            LabelEnter.AutoSize = true;
            LabelEnter.Font = new Font("Segoe UI", 12F);
            LabelEnter.Location = new Point(32, 41);
            LabelEnter.Name = "LabelEnter";
            LabelEnter.Size = new Size(236, 28);
            LabelEnter.TabIndex = 0;
            LabelEnter.Text = "Enter the Booking Details:";
            // 
            // LabelCheckin
            // 
            LabelCheckin.AutoSize = true;
            LabelCheckin.Location = new Point(75, 96);
            LabelCheckin.Name = "LabelCheckin";
            LabelCheckin.Size = new Size(109, 20);
            LabelCheckin.TabIndex = 1;
            LabelCheckin.Text = "Check-in Date :";
            // 
            // LabelCheckout
            // 
            LabelCheckout.AutoSize = true;
            LabelCheckout.Location = new Point(75, 143);
            LabelCheckout.Name = "LabelCheckout";
            LabelCheckout.Size = new Size(119, 20);
            LabelCheckout.TabIndex = 3;
            LabelCheckout.Text = "Check-out Date :";
            // 
            // CheckinDatePicker
            // 
            CheckinDatePicker.Location = new Point(264, 96);
            CheckinDatePicker.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            CheckinDatePicker.MinDate = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckinDatePicker.Name = "CheckinDatePicker";
            CheckinDatePicker.Size = new Size(250, 27);
            CheckinDatePicker.TabIndex = 5;
            CheckinDatePicker.Value = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckinDatePicker.ValueChanged += CheckinDatePicker_ValueChanged;
            // 
            // CheckoutDatePicker
            // 
            CheckoutDatePicker.Location = new Point(264, 138);
            CheckoutDatePicker.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            CheckoutDatePicker.MinDate = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckoutDatePicker.Name = "CheckoutDatePicker";
            CheckoutDatePicker.Size = new Size(250, 27);
            CheckoutDatePicker.TabIndex = 6;
            CheckoutDatePicker.Value = new DateTime(2025, 6, 25, 0, 0, 0, 0);
            CheckoutDatePicker.ValueChanged += CheckoutDatePicker_ValueChanged;
            // 
            // CheckBoxRecurring
            // 
            CheckBoxRecurring.AutoSize = true;
            CheckBoxRecurring.Location = new Point(400, 397);
            CheckBoxRecurring.Name = "CheckBoxRecurring";
            CheckBoxRecurring.Size = new Size(124, 24);
            CheckBoxRecurring.TabIndex = 9;
            CheckBoxRecurring.Text = "Recurring stay";
            CheckBoxRecurring.UseVisualStyleBackColor = true;
            // 
            // LabelSpecialRequests
            // 
            LabelSpecialRequests.AutoSize = true;
            LabelSpecialRequests.Location = new Point(75, 236);
            LabelSpecialRequests.Name = "LabelSpecialRequests";
            LabelSpecialRequests.Size = new Size(127, 20);
            LabelSpecialRequests.TabIndex = 10;
            LabelSpecialRequests.Text = "Special Requests :";
            // 
            // TextBoxSpecialRequests
            // 
            TextBoxSpecialRequests.Location = new Point(264, 236);
            TextBoxSpecialRequests.Name = "TextBoxSpecialRequests";
            TextBoxSpecialRequests.Size = new Size(260, 120);
            TextBoxSpecialRequests.TabIndex = 11;
            TextBoxSpecialRequests.Text = "";
            // 
            // LabelRoomType
            // 
            LabelRoomType.AutoSize = true;
            LabelRoomType.Location = new Point(75, 193);
            LabelRoomType.Name = "LabelRoomType";
            LabelRoomType.Size = new Size(91, 20);
            LabelRoomType.TabIndex = 12;
            LabelRoomType.Text = "Room Type :";
            // 
            // RoomSingle
            // 
            RoomSingle.AutoSize = true;
            RoomSingle.Location = new Point(264, 193);
            RoomSingle.Name = "RoomSingle";
            RoomSingle.Size = new Size(71, 24);
            RoomSingle.TabIndex = 13;
            RoomSingle.TabStop = true;
            RoomSingle.Text = "Single";
            RoomSingle.UseVisualStyleBackColor = true;
            RoomSingle.CheckedChanged += RoomSingle_CheckedChanged;
            // 
            // RoomDouble
            // 
            RoomDouble.AutoSize = true;
            RoomDouble.Location = new Point(351, 193);
            RoomDouble.Name = "RoomDouble";
            RoomDouble.Size = new Size(79, 24);
            RoomDouble.TabIndex = 14;
            RoomDouble.TabStop = true;
            RoomDouble.Text = "Double";
            RoomDouble.UseVisualStyleBackColor = true;
            RoomDouble.CheckedChanged += RoomDouble_CheckedChanged;
            // 
            // RoomTriple
            // 
            RoomTriple.AutoSize = true;
            RoomTriple.Location = new Point(447, 191);
            RoomTriple.Name = "RoomTriple";
            RoomTriple.Size = new Size(67, 24);
            RoomTriple.TabIndex = 15;
            RoomTriple.TabStop = true;
            RoomTriple.Text = "Triple";
            RoomTriple.UseVisualStyleBackColor = true;
            RoomTriple.CheckedChanged += RoomTriple_CheckedChanged;
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Font = new Font("Segoe UI", 10F);
            ButtonSubmit.Location = new Point(434, 448);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(115, 38);
            ButtonSubmit.TabIndex = 16;
            ButtonSubmit.Text = "Submit";
            ButtonSubmit.UseVisualStyleBackColor = true;
            ButtonSubmit.Click += ButtonSubmit_Click;
            // 
            // FormBookingSubmission
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 513);
            Controls.Add(ButtonSubmit);
            Controls.Add(RoomTriple);
            Controls.Add(RoomDouble);
            Controls.Add(RoomSingle);
            Controls.Add(LabelRoomType);
            Controls.Add(TextBoxSpecialRequests);
            Controls.Add(LabelSpecialRequests);
            Controls.Add(CheckBoxRecurring);
            Controls.Add(CheckoutDatePicker);
            Controls.Add(CheckinDatePicker);
            Controls.Add(LabelCheckout);
            Controls.Add(LabelCheckin);
            Controls.Add(LabelEnter);
            Name = "FormBookingSubmission";
            Text = "Booking Submission";
            Load += FormBookingSubmission_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelEnter;
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
    }
}