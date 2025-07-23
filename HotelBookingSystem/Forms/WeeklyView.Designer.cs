namespace HotelBookingSystem
{
    partial class FormWeeklyView
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
            DataGridWeeklyView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridWeeklyView).BeginInit();
            SuspendLayout();
            // 
            // DataGridWeeklyView
            // 
            DataGridWeeklyView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridWeeklyView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridWeeklyView.BackgroundColor = SystemColors.GradientActiveCaption;
            DataGridWeeklyView.BorderStyle = BorderStyle.Fixed3D;
            DataGridWeeklyView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridWeeklyView.Dock = DockStyle.Fill;
            DataGridWeeklyView.Location = new Point(0, 0);
            DataGridWeeklyView.Name = "DataGridWeeklyView";
            DataGridWeeklyView.RowHeadersWidth = 51;
            DataGridWeeklyView.Size = new Size(1507, 519);
            DataGridWeeklyView.TabIndex = 0;
            // 
            // FormWeeklyView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1507, 519);
            Controls.Add(DataGridWeeklyView);
            Name = "FormWeeklyView";
            Text = "Weekly View";
            Load += FormWeeklyView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridWeeklyView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridWeeklyView;
    }
}