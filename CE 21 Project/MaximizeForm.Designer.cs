namespace ScheduleMaster
{
    partial class MaximizeForm
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
            this.AllSchedulesView = new System.Windows.Forms.Button();
            this.AllSchedulesAdd = new System.Windows.Forms.Button();
            this.AllSchedulesDelete = new System.Windows.Forms.Button();
            this.MainData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).BeginInit();
            this.SuspendLayout();
            // 
            // AllSchedulesView
            // 
            this.AllSchedulesView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllSchedulesView.Cursor = System.Windows.Forms.Cursors.Default;
            this.AllSchedulesView.Location = new System.Drawing.Point(700, 469);
            this.AllSchedulesView.Name = "AllSchedulesView";
            this.AllSchedulesView.Size = new System.Drawing.Size(65, 23);
            this.AllSchedulesView.TabIndex = 1004;
            this.AllSchedulesView.Text = "Close";
            this.AllSchedulesView.UseVisualStyleBackColor = true;
            this.AllSchedulesView.Click += new System.EventHandler(this.AllSchedulesView_Click);
            // 
            // AllSchedulesAdd
            // 
            this.AllSchedulesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllSchedulesAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.AllSchedulesAdd.Location = new System.Drawing.Point(630, 469);
            this.AllSchedulesAdd.Name = "AllSchedulesAdd";
            this.AllSchedulesAdd.Size = new System.Drawing.Size(65, 23);
            this.AllSchedulesAdd.TabIndex = 1003;
            this.AllSchedulesAdd.Text = "Add New";
            this.AllSchedulesAdd.UseVisualStyleBackColor = true;
            this.AllSchedulesAdd.Click += new System.EventHandler(this.AllSchedulesAdd_Click);
            // 
            // AllSchedulesDelete
            // 
            this.AllSchedulesDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllSchedulesDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.AllSchedulesDelete.Location = new System.Drawing.Point(21, 469);
            this.AllSchedulesDelete.Name = "AllSchedulesDelete";
            this.AllSchedulesDelete.Size = new System.Drawing.Size(47, 23);
            this.AllSchedulesDelete.TabIndex = 1002;
            this.AllSchedulesDelete.Text = "Delete";
            this.AllSchedulesDelete.UseVisualStyleBackColor = true;
            this.AllSchedulesDelete.Click += new System.EventHandler(this.AllSchedulesDelete_Click);
            // 
            // MainData
            // 
            this.MainData.AllowUserToAddRows = false;
            this.MainData.AllowUserToDeleteRows = false;
            this.MainData.AllowUserToResizeRows = false;
            this.MainData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainData.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.MainData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainData.Location = new System.Drawing.Point(12, 38);
            this.MainData.Name = "MainData";
            this.MainData.ReadOnly = true;
            this.MainData.RowHeadersVisible = false;
            this.MainData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainData.Size = new System.Drawing.Size(754, 425);
            this.MainData.TabIndex = 1001;
            this.MainData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainData_CellClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(506, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1005;
            this.label4.Text = "Search:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(571, 12);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(194, 20);
            this.SearchBox.TabIndex = 1000;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // MaximizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 507);
            this.Controls.Add(this.AllSchedulesView);
            this.Controls.Add(this.AllSchedulesAdd);
            this.Controls.Add(this.AllSchedulesDelete);
            this.Controls.Add(this.MainData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SearchBox);
            this.Name = "MaximizeForm";
            this.Text = "All Schedules";
            this.Activated += new System.EventHandler(this.MaximizeForm_Activated);
            this.Resize += new System.EventHandler(this.MaximizeForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AllSchedulesView;
        private System.Windows.Forms.Button AllSchedulesAdd;
        private System.Windows.Forms.Button AllSchedulesDelete;
        private System.Windows.Forms.DataGridView MainData;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox SearchBox;
    }
}