namespace HotelBookingSystem
{
    partial class FormBookingService
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
            LabelWelcome = new Label();
            ButtonSubmit = new Button();
            ButtonRequest = new Button();
            SuspendLayout();
            // 
            // LabelWelcome
            // 
            LabelWelcome.AutoSize = true;
            LabelWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelWelcome.Location = new Point(124, 44);
            LabelWelcome.Name = "LabelWelcome";
            LabelWelcome.Size = new Size(513, 37);
            LabelWelcome.TabIndex = 0;
            LabelWelcome.Text = "Welcome to the Hotel Booking Service";
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Location = new Point(283, 165);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(203, 41);
            ButtonSubmit.TabIndex = 1;
            ButtonSubmit.Text = "Submit New Booking";
            ButtonSubmit.UseVisualStyleBackColor = true;
            ButtonSubmit.Click += ButtonSubmit_Click;
            // 
            // ButtonRequest
            // 
            ButtonRequest.Location = new Point(283, 243);
            ButtonRequest.Name = "ButtonRequest";
            ButtonRequest.Size = new Size(203, 38);
            ButtonRequest.TabIndex = 2;
            ButtonRequest.Text = "Request Weekly Report";
            ButtonRequest.UseVisualStyleBackColor = true;
            ButtonRequest.Click += ButtonRequest_Click;
            // 
            // FormBookingService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonRequest);
            Controls.Add(ButtonSubmit);
            Controls.Add(LabelWelcome);
            Name = "FormBookingService";
            Text = "FormBookingService";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelWelcome;
        private Button ButtonSubmit;
        private Button ButtonRequest;
    }
}