namespace HotelBookingSystem
{
    partial class FormSearchView
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
            DataGridViewBookings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridViewBookings).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewBookings
            // 
            DataGridViewBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewBookings.Location = new Point(75, 52);
            DataGridViewBookings.Name = "DataGridViewBookings";
            DataGridViewBookings.RowHeadersWidth = 51;
            DataGridViewBookings.Size = new Size(1231, 313);
            DataGridViewBookings.TabIndex = 0;
            // 
            // FormSearchView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 450);
            Controls.Add(DataGridViewBookings);
            Name = "FormSearchView";
            Text = "Search Results";
            Load += FormSearchView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridViewBookings;
    }
}