namespace ScheduleMaster
{
    partial class ScheduleViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Weekly = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.DepartmentBox = new System.Windows.Forms.TextBox();
            this.Edit1 = new System.Windows.Forms.Button();
            this.Edit2 = new System.Windows.Forms.Button();
            this.Edit3 = new System.Windows.Forms.Button();
            this.Edit4 = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ProfessorName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartBox = new System.Windows.Forms.MaskedTextBox();
            this.EndBox = new System.Windows.Forms.MaskedTextBox();
            this.OffBox = new System.Windows.Forms.MaskedTextBox();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.OffLabel = new System.Windows.Forms.Label();
            this.StartNum = new System.Windows.Forms.NumericUpDown();
            this.EndNum = new System.Windows.Forms.NumericUpDown();
            this.OffNum = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.professorScheduleViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserterDeleterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPage = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.DeleteProfessor = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Weekly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffNum)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Weekly
            // 
            this.Weekly.AllowUserToAddRows = false;
            this.Weekly.AllowUserToDeleteRows = false;
            this.Weekly.AllowUserToResizeRows = false;
            this.Weekly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Weekly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Weekly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday,
            this.Sunday});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Weekly.DefaultCellStyle = dataGridViewCellStyle1;
            this.Weekly.Location = new System.Drawing.Point(416, 139);
            this.Weekly.MinimumSize = new System.Drawing.Size(348, 281);
            this.Weekly.Name = "Weekly";
            this.Weekly.ReadOnly = true;
            this.Weekly.RowHeadersVisible = false;
            this.Weekly.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Weekly.RowTemplate.Height = 15;
            this.Weekly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Weekly.Size = new System.Drawing.Size(348, 281);
            this.Weekly.TabIndex = 2;
            this.Weekly.TabStop = false;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Time.Frozen = true;
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 40;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 40;
            // 
            // Monday
            // 
            this.Monday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Monday.HeaderText = "Mon";
            this.Monday.MinimumWidth = 40;
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            this.Monday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Monday.Width = 40;
            // 
            // Tuesday
            // 
            this.Tuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Tuesday.HeaderText = "Tue";
            this.Tuesday.MinimumWidth = 40;
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            this.Tuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tuesday.Width = 40;
            // 
            // Wednesday
            // 
            this.Wednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Wednesday.HeaderText = "Wed";
            this.Wednesday.MinimumWidth = 40;
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            this.Wednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Wednesday.Width = 40;
            // 
            // Thursday
            // 
            this.Thursday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Thursday.HeaderText = "Thu";
            this.Thursday.MinimumWidth = 40;
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            this.Thursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Thursday.Width = 40;
            // 
            // Friday
            // 
            this.Friday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Friday.HeaderText = "Fri";
            this.Friday.MinimumWidth = 40;
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            this.Friday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Friday.Width = 40;
            // 
            // Saturday
            // 
            this.Saturday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Saturday.HeaderText = "Sat";
            this.Saturday.MinimumWidth = 40;
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            this.Saturday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Saturday.Width = 40;
            // 
            // Sunday
            // 
            this.Sunday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Sunday.HeaderText = "Sun";
            this.Sunday.MinimumWidth = 40;
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            this.Sunday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sunday.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 231);
            this.label1.MinimumSize = new System.Drawing.Size(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 206);
            this.label2.MinimumSize = new System.Drawing.Size(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 281);
            this.label3.MinimumSize = new System.Drawing.Size(0, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 256);
            this.label4.MinimumSize = new System.Drawing.Size(0, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID Number:";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.AcceptsReturn = true;
            this.FirstNameBox.AcceptsTab = true;
            this.FirstNameBox.Location = new System.Drawing.Point(184, 203);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(127, 20);
            this.FirstNameBox.TabIndex = 1;
            this.FirstNameBox.TextChanged += new System.EventHandler(this.FirstNameBox_TextChanged);
            this.FirstNameBox.Enter += new System.EventHandler(this.FirstNameBox_Enter);
            // 
            // LastNameBox
            // 
            this.LastNameBox.AcceptsReturn = true;
            this.LastNameBox.AcceptsTab = true;
            this.LastNameBox.Location = new System.Drawing.Point(184, 228);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(127, 20);
            this.LastNameBox.TabIndex = 2;
            this.LastNameBox.TextChanged += new System.EventHandler(this.LastNameBox_TextChanged);
            this.LastNameBox.Enter += new System.EventHandler(this.LastNameBox_Enter);
            // 
            // IDBox
            // 
            this.IDBox.AcceptsReturn = true;
            this.IDBox.AcceptsTab = true;
            this.IDBox.Location = new System.Drawing.Point(184, 253);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(127, 20);
            this.IDBox.TabIndex = 3;
            this.IDBox.TextChanged += new System.EventHandler(this.IDBox_TextChanged);
            this.IDBox.Enter += new System.EventHandler(this.IDBox_Enter);
            // 
            // DepartmentBox
            // 
            this.DepartmentBox.AcceptsReturn = true;
            this.DepartmentBox.AcceptsTab = true;
            this.DepartmentBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DepartmentBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.DepartmentBox.Location = new System.Drawing.Point(184, 278);
            this.DepartmentBox.Name = "DepartmentBox";
            this.DepartmentBox.Size = new System.Drawing.Size(127, 20);
            this.DepartmentBox.TabIndex = 4;
            this.DepartmentBox.TextChanged += new System.EventHandler(this.DepartmentBox_TextChanged);
            this.DepartmentBox.Enter += new System.EventHandler(this.DepartmentBox_Enter);
            // 
            // Edit1
            // 
            this.Edit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit1.Enabled = false;
            this.Edit1.Location = new System.Drawing.Point(321, 201);
            this.Edit1.Name = "Edit1";
            this.Edit1.Size = new System.Drawing.Size(52, 23);
            this.Edit1.TabIndex = 12;
            this.Edit1.TabStop = false;
            this.Edit1.Text = "Edit";
            this.Edit1.UseVisualStyleBackColor = true;
            this.Edit1.Click += new System.EventHandler(this.Edit1_Click);
            // 
            // Edit2
            // 
            this.Edit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit2.Enabled = false;
            this.Edit2.Location = new System.Drawing.Point(321, 226);
            this.Edit2.Name = "Edit2";
            this.Edit2.Size = new System.Drawing.Size(52, 23);
            this.Edit2.TabIndex = 13;
            this.Edit2.TabStop = false;
            this.Edit2.Text = "Edit";
            this.Edit2.UseVisualStyleBackColor = true;
            this.Edit2.Click += new System.EventHandler(this.Edit2_Click);
            // 
            // Edit3
            // 
            this.Edit3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit3.Enabled = false;
            this.Edit3.Location = new System.Drawing.Point(321, 251);
            this.Edit3.Name = "Edit3";
            this.Edit3.Size = new System.Drawing.Size(52, 23);
            this.Edit3.TabIndex = 14;
            this.Edit3.TabStop = false;
            this.Edit3.Text = "Edit";
            this.Edit3.UseVisualStyleBackColor = true;
            this.Edit3.Click += new System.EventHandler(this.Edit3_Click);
            // 
            // Edit4
            // 
            this.Edit4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit4.Enabled = false;
            this.Edit4.Location = new System.Drawing.Point(321, 276);
            this.Edit4.Name = "Edit4";
            this.Edit4.Size = new System.Drawing.Size(52, 23);
            this.Edit4.TabIndex = 15;
            this.Edit4.TabStop = false;
            this.Edit4.Text = "Edit";
            this.Edit4.UseVisualStyleBackColor = true;
            this.Edit4.Click += new System.EventHandler(this.Edit4_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetButton.Enabled = false;
            this.ResetButton.Location = new System.Drawing.Point(321, 156);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(52, 23);
            this.ResetButton.TabIndex = 16;
            this.ResetButton.TabStop = false;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ProfessorName
            // 
            this.ProfessorName.AutoSize = true;
            this.ProfessorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfessorName.Location = new System.Drawing.Point(89, 153);
            this.ProfessorName.Name = "ProfessorName";
            this.ProfessorName.Size = new System.Drawing.Size(158, 24);
            this.ProfessorName.TabIndex = 18;
            this.ProfessorName.Text = "Professor\'s Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(278, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Professor Schedule Viewer";
            // 
            // StartBox
            // 
            this.StartBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.StartBox.Location = new System.Drawing.Point(704, 426);
            this.StartBox.Mask = "00:00";
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(45, 18);
            this.StartBox.TabIndex = 6;
            this.StartBox.Text = "0700";
            this.StartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartBox.ValidatingType = typeof(System.DateTime);
            this.StartBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.StartBox_TypeValidationCompleted);
            this.StartBox.TextChanged += new System.EventHandler(this.MakeRows);
            this.StartBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartBox_KeyDown);
            // 
            // EndBox
            // 
            this.EndBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.EndBox.Location = new System.Drawing.Point(704, 447);
            this.EndBox.Mask = "00:00";
            this.EndBox.Name = "EndBox";
            this.EndBox.Size = new System.Drawing.Size(45, 18);
            this.EndBox.TabIndex = 7;
            this.EndBox.Text = "2000";
            this.EndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndBox.ValidatingType = typeof(System.DateTime);
            this.EndBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.EndBox_TypeValidationCompleted);
            this.EndBox.TextChanged += new System.EventHandler(this.MakeRows);
            this.EndBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EndBox_KeyDown);
            // 
            // OffBox
            // 
            this.OffBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OffBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.OffBox.Location = new System.Drawing.Point(704, 468);
            this.OffBox.Mask = "00:00";
            this.OffBox.Name = "OffBox";
            this.OffBox.Size = new System.Drawing.Size(45, 18);
            this.OffBox.TabIndex = 8;
            this.OffBox.Text = "0030";
            this.OffBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OffBox.ValidatingType = typeof(System.DateTime);
            this.OffBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.OffBox_TypeValidationCompleted);
            this.OffBox.TextChanged += new System.EventHandler(this.MakeRows);
            this.OffBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OffBox_KeyDown);
            // 
            // StartLabel
            // 
            this.StartLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartLabel.AutoSize = true;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabel.Location = new System.Drawing.Point(651, 429);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartLabel.Size = new System.Drawing.Size(47, 12);
            this.StartLabel.TabIndex = 26;
            this.StartLabel.Text = "Start Time";
            // 
            // EndLabel
            // 
            this.EndLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EndLabel.AutoSize = true;
            this.EndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndLabel.Location = new System.Drawing.Point(655, 450);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EndLabel.Size = new System.Drawing.Size(43, 12);
            this.EndLabel.TabIndex = 27;
            this.EndLabel.Text = "End Time";
            // 
            // OffLabel
            // 
            this.OffLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OffLabel.AutoSize = true;
            this.OffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffLabel.Location = new System.Drawing.Point(644, 471);
            this.OffLabel.Name = "OffLabel";
            this.OffLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OffLabel.Size = new System.Drawing.Size(54, 12);
            this.OffLabel.TabIndex = 28;
            this.OffLabel.Text = "Offset (min)";
            // 
            // StartNum
            // 
            this.StartNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartNum.Location = new System.Drawing.Point(750, 426);
            this.StartNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.StartNum.Name = "StartNum";
            this.StartNum.Size = new System.Drawing.Size(18, 20);
            this.StartNum.TabIndex = 29;
            this.StartNum.TabStop = false;
            this.StartNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // EndNum
            // 
            this.EndNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EndNum.Location = new System.Drawing.Point(750, 445);
            this.EndNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EndNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.EndNum.Name = "EndNum";
            this.EndNum.Size = new System.Drawing.Size(18, 20);
            this.EndNum.TabIndex = 30;
            this.EndNum.TabStop = false;
            this.EndNum.ValueChanged += new System.EventHandler(this.EndNum_ValueChanged);
            // 
            // OffNum
            // 
            this.OffNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OffNum.Location = new System.Drawing.Point(750, 468);
            this.OffNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OffNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.OffNum.Name = "OffNum";
            this.OffNum.Size = new System.Drawing.Size(18, 20);
            this.OffNum.TabIndex = 31;
            this.OffNum.TabStop = false;
            this.OffNum.ValueChanged += new System.EventHandler(this.OffNum_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.openToolStripMenuItem.ShowShortcutKeys = false;
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem1.ShowShortcutKeys = false;
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveAsToolStripMenuItem.Text = "Export...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.toolStripSeparator2,
            this.professorScheduleViewerToolStripMenuItem,
            this.inserterDeleterToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.insertToolStripMenuItem.Text = "View";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Enabled = false;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // professorScheduleViewerToolStripMenuItem
            // 
            this.professorScheduleViewerToolStripMenuItem.Checked = true;
            this.professorScheduleViewerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.professorScheduleViewerToolStripMenuItem.Name = "professorScheduleViewerToolStripMenuItem";
            this.professorScheduleViewerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.professorScheduleViewerToolStripMenuItem.Text = "Professor Schedule Viewer";
            this.professorScheduleViewerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.professorScheduleViewerToolStripMenuItem_CheckedChanged);
            this.professorScheduleViewerToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuItem);
            // 
            // inserterDeleterToolStripMenuItem
            // 
            this.inserterDeleterToolStripMenuItem.Checked = true;
            this.inserterDeleterToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inserterDeleterToolStripMenuItem.Name = "inserterDeleterToolStripMenuItem";
            this.inserterDeleterToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.inserterDeleterToolStripMenuItem.Text = "Inserter/Deleter";
            this.inserterDeleterToolStripMenuItem.Click += new System.EventHandler(this.inserterDeleterToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // TabPage
            // 
            this.TabPage.Location = new System.Drawing.Point(4, 22);
            this.TabPage.Name = "TabPage";
            this.TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage.Size = new System.Drawing.Size(725, 0);
            this.TabPage.TabIndex = 0;
            this.TabPage.Text = "TabPage";
            this.TabPage.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage);
            this.TabControl.Location = new System.Drawing.Point(35, 84);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(733, 22);
            this.TabControl.TabIndex = 0;
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            this.TabControl.Click += new System.EventHandler(this.TabControl_Click);
            this.TabControl.DoubleClick += new System.EventHandler(this.TabControl_DoubleClick);
            // 
            // DeleteProfessor
            // 
            this.DeleteProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteProfessor.Location = new System.Drawing.Point(93, 309);
            this.DeleteProfessor.Name = "DeleteProfessor";
            this.DeleteProfessor.Size = new System.Drawing.Size(60, 23);
            this.DeleteProfessor.TabIndex = 33;
            this.DeleteProfessor.Text = "Delete";
            this.DeleteProfessor.UseVisualStyleBackColor = true;
            this.DeleteProfessor.Click += new System.EventHandler(this.DeleteProfessor_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(708, 3);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(91, 18);
            this.SearchBox.TabIndex = 9;
            this.SearchBox.Text = "Search...";
            this.SearchBox.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyPress);
            this.SearchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Location = new System.Drawing.Point(93, 350);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(280, 70);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 513);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(811, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // ScheduleViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 535);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.DeleteProfessor);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.OffNum);
            this.Controls.Add(this.EndNum);
            this.Controls.Add(this.StartNum);
            this.Controls.Add(this.OffLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.OffBox);
            this.Controls.Add(this.EndBox);
            this.Controls.Add(this.StartBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ProfessorName);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.Edit4);
            this.Controls.Add(this.Edit3);
            this.Controls.Add(this.Edit2);
            this.Controls.Add(this.Edit1);
            this.Controls.Add(this.DepartmentBox);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Weekly);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.SaveButton);
            this.Name = "ScheduleViewer";
            this.Text = "Schedule Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleViewer_FormClosing);
            this.Load += new System.EventHandler(this.ScheduleViewer_Load);
            this.Enter += new System.EventHandler(this.SelectProfessor);
            this.Resize += new System.EventHandler(this.ScheduleViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Weekly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffNum)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.DataGridView Weekly;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox DepartmentBox;
        private System.Windows.Forms.Button Edit1;
        private System.Windows.Forms.Button Edit2;
        private System.Windows.Forms.Button Edit3;
        private System.Windows.Forms.Button Edit4;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label ProfessorName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox StartBox;
        private System.Windows.Forms.MaskedTextBox EndBox;
        private System.Windows.Forms.MaskedTextBox OffBox;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label OffLabel;
        private System.Windows.Forms.NumericUpDown StartNum;
        private System.Windows.Forms.NumericUpDown EndNum;
        private System.Windows.Forms.NumericUpDown OffNum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.TabPage TabPage;
        private System.Windows.Forms.Button DeleteProfessor;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem professorScheduleViewerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem inserterDeleterToolStripMenuItem;


    }
}