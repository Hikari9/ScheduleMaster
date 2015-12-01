namespace ScheduleMaster
{
    partial class Viewer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unavailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.professorScheduleViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unavailableToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unavailableToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainData = new System.Windows.Forms.DataGridView();
            this.ProfessorList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddProfessorButton = new System.Windows.Forms.Button();
            this.AddRoomButton = new System.Windows.Forms.Button();
            this.DayChecklist = new System.Windows.Forms.CheckedListBox();
            this.MWFRadio = new System.Windows.Forms.RadioButton();
            this.TThRadio = new System.Windows.Forms.RadioButton();
            this.DayGroup = new System.Windows.Forms.GroupBox();
            this.DayFilter = new System.Windows.Forms.CheckBox();
            this.WeekdaysRadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartGroup = new System.Windows.Forms.Panel();
            this.StartMeridian = new System.Windows.Forms.ComboBox();
            this.StartMinute = new System.Windows.Forms.ComboBox();
            this.StartHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EndGroup = new System.Windows.Forms.Panel();
            this.EndMeridian = new System.Windows.Forms.ComboBox();
            this.EndMinute = new System.Windows.Forms.ComboBox();
            this.EndHour = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SubjectTitle = new System.Windows.Forms.TextBox();
            this.Filter = new System.Windows.Forms.CheckBox();
            this.Locked = new System.Windows.Forms.CheckBox();
            this.ProfFilter = new System.Windows.Forms.CheckBox();
            this.RoomFilter = new System.Windows.Forms.CheckBox();
            this.SubjectFilter = new System.Windows.Forms.CheckBox();
            this.FilterAll = new System.Windows.Forms.CheckBox();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.FilterSelectAll = new System.Windows.Forms.CheckBox();
            this.EditProfessor = new System.Windows.Forms.Button();
            this.DeleteProfessor = new System.Windows.Forms.Button();
            this.DeleteRoom = new System.Windows.Forms.Button();
            this.EditRoom = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).BeginInit();
            this.DayGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.StartGroup.SuspendLayout();
            this.EndGroup.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip1.TabIndex = 0;
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
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unavailableToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // unavailableToolStripMenuItem
            // 
            this.unavailableToolStripMenuItem.Name = "unavailableToolStripMenuItem";
            this.unavailableToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.unavailableToolStripMenuItem.Text = "Unavailable";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.toolStripSeparator2,
            this.professorScheduleViewerToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.insertToolStripMenuItem.Text = "View";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.CheckedChanged += new System.EventHandler(this.filterToolStripMenuItem_CheckedChanged);
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // professorScheduleViewerToolStripMenuItem
            // 
            this.professorScheduleViewerToolStripMenuItem.Name = "professorScheduleViewerToolStripMenuItem";
            this.professorScheduleViewerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.professorScheduleViewerToolStripMenuItem.Text = "Professor Schedule Viewer";
            this.professorScheduleViewerToolStripMenuItem.Click += new System.EventHandler(this.professorScheduleViewerToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.viewToolStripMenuItem.Text = "Insert";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unavailableToolStripMenuItem3});
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // unavailableToolStripMenuItem3
            // 
            this.unavailableToolStripMenuItem3.Name = "unavailableToolStripMenuItem3";
            this.unavailableToolStripMenuItem3.Size = new System.Drawing.Size(135, 22);
            this.unavailableToolStripMenuItem3.Text = "Unavailable";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unavailableToolStripMenuItem4});
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // unavailableToolStripMenuItem4
            // 
            this.unavailableToolStripMenuItem4.Name = "unavailableToolStripMenuItem4";
            this.unavailableToolStripMenuItem4.Size = new System.Drawing.Size(135, 22);
            this.unavailableToolStripMenuItem4.Text = "Unavailable";
            // 
            // MainData
            // 
            this.MainData.AllowUserToAddRows = false;
            this.MainData.AllowUserToDeleteRows = false;
            this.MainData.AllowUserToResizeRows = false;
            this.MainData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.MainData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainData.Location = new System.Drawing.Point(418, 44);
            this.MainData.Name = "MainData";
            this.MainData.ReadOnly = true;
            this.MainData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainData.Size = new System.Drawing.Size(554, 371);
            this.MainData.TabIndex = 1;
            this.MainData.DataSourceChanged += new System.EventHandler(this.MainData_DataSourceChanged);
            this.MainData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellSelected);
            this.MainData.Leave += new System.EventHandler(this.EnableSave);
            // 
            // ProfessorList
            // 
            this.ProfessorList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProfessorList.Location = new System.Drawing.Point(41, 288);
            this.ProfessorList.Name = "ProfessorList";
            this.ProfessorList.Size = new System.Drawing.Size(166, 199);
            this.ProfessorList.TabIndex = 2;
            this.ProfessorList.SelectedIndexChanged += new System.EventHandler(this.ProfessorList_SelectedIndexChanged);
            this.ProfessorList.Leave += new System.EventHandler(this.EnableSave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Professors";
            this.label1.Leave += new System.EventHandler(this.EnableSave);
            // 
            // RoomList
            // 
            this.RoomList.Cursor = System.Windows.Forms.Cursors.Default;
            this.RoomList.Location = new System.Drawing.Point(225, 288);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(166, 199);
            this.RoomList.TabIndex = 4;
            this.RoomList.SelectedIndexChanged += new System.EventHandler(this.RoomList_SelectedIndexChanged);
            this.RoomList.Leave += new System.EventHandler(this.EnableSave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rooms";
            this.label2.Leave += new System.EventHandler(this.EnableSave);
            // 
            // AddProfessorButton
            // 
            this.AddProfessorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProfessorButton.Location = new System.Drawing.Point(142, 464);
            this.AddProfessorButton.Name = "AddProfessorButton";
            this.AddProfessorButton.Size = new System.Drawing.Size(65, 23);
            this.AddProfessorButton.TabIndex = 6;
            this.AddProfessorButton.Text = "Add New";
            this.AddProfessorButton.UseVisualStyleBackColor = true;
            this.AddProfessorButton.Click += new System.EventHandler(this.AddProfessorButton_Click);
            this.AddProfessorButton.Leave += new System.EventHandler(this.EnableSave);
            // 
            // AddRoomButton
            // 
            this.AddRoomButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRoomButton.Location = new System.Drawing.Point(328, 464);
            this.AddRoomButton.Name = "AddRoomButton";
            this.AddRoomButton.Size = new System.Drawing.Size(63, 23);
            this.AddRoomButton.TabIndex = 7;
            this.AddRoomButton.Text = "Add New";
            this.AddRoomButton.UseVisualStyleBackColor = true;
            this.AddRoomButton.Click += new System.EventHandler(this.AddRoomButton_Click);
            this.AddRoomButton.Leave += new System.EventHandler(this.EnableSave);
            // 
            // DayChecklist
            // 
            this.DayChecklist.BackColor = System.Drawing.SystemColors.Control;
            this.DayChecklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DayChecklist.CheckOnClick = true;
            this.DayChecklist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DayChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayChecklist.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.DayChecklist.Location = new System.Drawing.Point(27, 44);
            this.DayChecklist.Name = "DayChecklist";
            this.DayChecklist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DayChecklist.Size = new System.Drawing.Size(144, 90);
            this.DayChecklist.TabIndex = 8;
            this.DayChecklist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpdateDayRadioButtons);
            // 
            // MWFRadio
            // 
            this.MWFRadio.AutoSize = true;
            this.MWFRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MWFRadio.Location = new System.Drawing.Point(43, 141);
            this.MWFRadio.Name = "MWFRadio";
            this.MWFRadio.Size = new System.Drawing.Size(51, 17);
            this.MWFRadio.TabIndex = 9;
            this.MWFRadio.TabStop = true;
            this.MWFRadio.Text = "MWF";
            this.MWFRadio.UseVisualStyleBackColor = true;
            this.MWFRadio.Click += new System.EventHandler(this.MWFRadio_CheckedChanged);
            // 
            // TThRadio
            // 
            this.TThRadio.AutoSize = true;
            this.TThRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TThRadio.Location = new System.Drawing.Point(107, 142);
            this.TThRadio.Name = "TThRadio";
            this.TThRadio.Size = new System.Drawing.Size(45, 17);
            this.TThRadio.TabIndex = 10;
            this.TThRadio.TabStop = true;
            this.TThRadio.Text = "TTh";
            this.TThRadio.UseVisualStyleBackColor = true;
            this.TThRadio.Click += new System.EventHandler(this.TThRadio_CheckedChanged);
            // 
            // DayGroup
            // 
            this.DayGroup.Controls.Add(this.DayFilter);
            this.DayGroup.Controls.Add(this.WeekdaysRadio);
            this.DayGroup.Controls.Add(this.TThRadio);
            this.DayGroup.Controls.Add(this.DayChecklist);
            this.DayGroup.Controls.Add(this.MWFRadio);
            this.DayGroup.Location = new System.Drawing.Point(29, 81);
            this.DayGroup.Name = "DayGroup";
            this.DayGroup.Size = new System.Drawing.Size(200, 168);
            this.DayGroup.TabIndex = 11;
            this.DayGroup.TabStop = false;
            this.DayGroup.Text = "Days";
            this.DayGroup.Leave += new System.EventHandler(this.EnableSave);
            // 
            // DayFilter
            // 
            this.DayFilter.AutoSize = true;
            this.DayFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DayFilter.Enabled = false;
            this.DayFilter.Location = new System.Drawing.Point(130, 21);
            this.DayFilter.Name = "DayFilter";
            this.DayFilter.Size = new System.Drawing.Size(48, 17);
            this.DayFilter.TabIndex = 23;
            this.DayFilter.Text = "Filter";
            this.DayFilter.UseVisualStyleBackColor = true;
            this.DayFilter.Visible = false;
            this.DayFilter.CheckedChanged += new System.EventHandler(this.FilterObject_CheckedChanged);
            // 
            // WeekdaysRadio
            // 
            this.WeekdaysRadio.AutoSize = true;
            this.WeekdaysRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WeekdaysRadio.Location = new System.Drawing.Point(27, 20);
            this.WeekdaysRadio.Name = "WeekdaysRadio";
            this.WeekdaysRadio.Size = new System.Drawing.Size(76, 17);
            this.WeekdaysRadio.TabIndex = 11;
            this.WeekdaysRadio.TabStop = true;
            this.WeekdaysRadio.Text = "Weekdays";
            this.WeekdaysRadio.UseVisualStyleBackColor = true;
            this.WeekdaysRadio.Click += new System.EventHandler(this.WeekdaysRadioButton_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Start Time";
            this.label3.Leave += new System.EventHandler(this.EnableSave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // StartGroup
            // 
            this.StartGroup.Controls.Add(this.StartMeridian);
            this.StartGroup.Controls.Add(this.StartMinute);
            this.StartGroup.Controls.Add(this.StartHour);
            this.StartGroup.Location = new System.Drawing.Point(244, 102);
            this.StartGroup.Name = "StartGroup";
            this.StartGroup.Size = new System.Drawing.Size(154, 66);
            this.StartGroup.TabIndex = 14;
            this.StartGroup.Leave += new System.EventHandler(this.EnableSave);
            // 
            // StartMeridian
            // 
            this.StartMeridian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartMeridian.FormattingEnabled = true;
            this.StartMeridian.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.StartMeridian.Location = new System.Drawing.Point(99, 37);
            this.StartMeridian.Name = "StartMeridian";
            this.StartMeridian.Size = new System.Drawing.Size(38, 21);
            this.StartMeridian.TabIndex = 15;
            this.StartMeridian.Text = "PM";
            this.StartMeridian.TextChanged += new System.EventHandler(this.StartTimeChanged);
            // 
            // StartMinute
            // 
            this.StartMinute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.StartMinute.Location = new System.Drawing.Point(55, 37);
            this.StartMinute.Name = "StartMinute";
            this.StartMinute.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartMinute.Size = new System.Drawing.Size(38, 21);
            this.StartMinute.TabIndex = 15;
            this.StartMinute.Text = "00";
            this.StartMinute.TextChanged += new System.EventHandler(this.StartTimeChanged);
            // 
            // StartHour
            // 
            this.StartHour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.StartHour.Location = new System.Drawing.Point(11, 37);
            this.StartHour.Name = "StartHour";
            this.StartHour.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartHour.Size = new System.Drawing.Size(38, 21);
            this.StartHour.TabIndex = 0;
            this.StartHour.Text = "01";
            this.StartHour.TextChanged += new System.EventHandler(this.StartTimeChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "End Time";
            this.label4.Leave += new System.EventHandler(this.EnableSave);
            // 
            // EndGroup
            // 
            this.EndGroup.Controls.Add(this.EndMeridian);
            this.EndGroup.Controls.Add(this.EndMinute);
            this.EndGroup.Controls.Add(this.EndHour);
            this.EndGroup.Location = new System.Drawing.Point(244, 174);
            this.EndGroup.Name = "EndGroup";
            this.EndGroup.Size = new System.Drawing.Size(154, 66);
            this.EndGroup.TabIndex = 16;
            this.EndGroup.Leave += new System.EventHandler(this.EnableSave);
            // 
            // EndMeridian
            // 
            this.EndMeridian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndMeridian.FormattingEnabled = true;
            this.EndMeridian.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.EndMeridian.Location = new System.Drawing.Point(99, 37);
            this.EndMeridian.Name = "EndMeridian";
            this.EndMeridian.Size = new System.Drawing.Size(38, 21);
            this.EndMeridian.TabIndex = 15;
            this.EndMeridian.Text = "PM";
            this.EndMeridian.TextChanged += new System.EventHandler(this.EndTimeChanged);
            // 
            // EndMinute
            // 
            this.EndMinute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.EndMinute.Location = new System.Drawing.Point(55, 37);
            this.EndMinute.Name = "EndMinute";
            this.EndMinute.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EndMinute.Size = new System.Drawing.Size(38, 21);
            this.EndMinute.TabIndex = 15;
            this.EndMinute.Text = "30";
            this.EndMinute.TextChanged += new System.EventHandler(this.EndTimeChanged);
            // 
            // EndHour
            // 
            this.EndHour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.EndHour.Location = new System.Drawing.Point(11, 37);
            this.EndHour.Name = "EndHour";
            this.EndHour.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EndHour.Size = new System.Drawing.Size(38, 21);
            this.EndHour.TabIndex = 0;
            this.EndHour.Text = "01";
            this.EndHour.TextChanged += new System.EventHandler(this.EndTimeChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Subject:";
            this.label5.Leave += new System.EventHandler(this.EnableSave);
            // 
            // SubjectTitle
            // 
            this.SubjectTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SubjectTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SubjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectTitle.Location = new System.Drawing.Point(147, 46);
            this.SubjectTitle.Name = "SubjectTitle";
            this.SubjectTitle.Size = new System.Drawing.Size(204, 26);
            this.SubjectTitle.TabIndex = 18;
            this.SubjectTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SubjectTitle_KeyUp);
            this.SubjectTitle.Leave += new System.EventHandler(this.EnableSave);
            // 
            // Filter
            // 
            this.Filter.AutoSize = true;
            this.Filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Filter.Location = new System.Drawing.Point(418, 421);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(88, 17);
            this.Filter.TabIndex = 19;
            this.Filter.Text = "Turn on Filter";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Visible = false;
            this.Filter.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            this.Filter.Leave += new System.EventHandler(this.EnableSave);
            // 
            // Locked
            // 
            this.Locked.AutoSize = true;
            this.Locked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Locked.Location = new System.Drawing.Point(687, 421);
            this.Locked.Name = "Locked";
            this.Locked.Size = new System.Drawing.Size(50, 17);
            this.Locked.TabIndex = 20;
            this.Locked.Text = "Lock";
            this.Locked.UseVisualStyleBackColor = true;
            this.Locked.CheckedChanged += new System.EventHandler(this.Locked_CheckedChanged);
            this.Locked.Leave += new System.EventHandler(this.EnableSave);
            // 
            // ProfFilter
            // 
            this.ProfFilter.AutoSize = true;
            this.ProfFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProfFilter.Enabled = false;
            this.ProfFilter.Location = new System.Drawing.Point(143, 263);
            this.ProfFilter.Name = "ProfFilter";
            this.ProfFilter.Size = new System.Drawing.Size(48, 17);
            this.ProfFilter.TabIndex = 21;
            this.ProfFilter.Text = "Filter";
            this.ProfFilter.UseVisualStyleBackColor = true;
            this.ProfFilter.Visible = false;
            this.ProfFilter.CheckedChanged += new System.EventHandler(this.FilterObject_CheckedChanged);
            this.ProfFilter.Leave += new System.EventHandler(this.EnableSave);
            // 
            // RoomFilter
            // 
            this.RoomFilter.AutoSize = true;
            this.RoomFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RoomFilter.Enabled = false;
            this.RoomFilter.Location = new System.Drawing.Point(333, 262);
            this.RoomFilter.Name = "RoomFilter";
            this.RoomFilter.Size = new System.Drawing.Size(48, 17);
            this.RoomFilter.TabIndex = 22;
            this.RoomFilter.Text = "Filter";
            this.RoomFilter.UseVisualStyleBackColor = true;
            this.RoomFilter.Visible = false;
            this.RoomFilter.CheckedChanged += new System.EventHandler(this.FilterObject_CheckedChanged);
            this.RoomFilter.Leave += new System.EventHandler(this.EnableSave);
            // 
            // SubjectFilter
            // 
            this.SubjectFilter.AutoSize = true;
            this.SubjectFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubjectFilter.Enabled = false;
            this.SubjectFilter.Location = new System.Drawing.Point(357, 53);
            this.SubjectFilter.Name = "SubjectFilter";
            this.SubjectFilter.Size = new System.Drawing.Size(48, 17);
            this.SubjectFilter.TabIndex = 23;
            this.SubjectFilter.Text = "Filter";
            this.SubjectFilter.UseVisualStyleBackColor = true;
            this.SubjectFilter.Visible = false;
            this.SubjectFilter.CheckedChanged += new System.EventHandler(this.FilterObject_CheckedChanged);
            this.SubjectFilter.Leave += new System.EventHandler(this.EnableSave);
            // 
            // FilterAll
            // 
            this.FilterAll.AutoSize = true;
            this.FilterAll.Checked = true;
            this.FilterAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilterAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterAll.Enabled = false;
            this.FilterAll.Location = new System.Drawing.Point(9, 4);
            this.FilterAll.Name = "FilterAll";
            this.FilterAll.Size = new System.Drawing.Size(54, 17);
            this.FilterAll.TabIndex = 24;
            this.FilterAll.Text = "Union";
            this.FilterAll.UseVisualStyleBackColor = true;
            this.FilterAll.CheckedChanged += new System.EventHandler(this.FilterObject_CheckedChanged);
            // 
            // FilterPanel
            // 
            this.FilterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterPanel.Controls.Add(this.FilterAll);
            this.FilterPanel.Controls.Add(this.FilterSelectAll);
            this.FilterPanel.Location = new System.Drawing.Point(512, 417);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(145, 23);
            this.FilterPanel.TabIndex = 25;
            this.FilterPanel.Visible = false;
            this.FilterPanel.Leave += new System.EventHandler(this.EnableSave);
            // 
            // FilterSelectAll
            // 
            this.FilterSelectAll.AutoSize = true;
            this.FilterSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterSelectAll.Enabled = false;
            this.FilterSelectAll.Location = new System.Drawing.Point(69, 4);
            this.FilterSelectAll.Name = "FilterSelectAll";
            this.FilterSelectAll.Size = new System.Drawing.Size(70, 17);
            this.FilterSelectAll.TabIndex = 26;
            this.FilterSelectAll.Text = "Select All";
            this.FilterSelectAll.UseVisualStyleBackColor = true;
            this.FilterSelectAll.CheckedChanged += new System.EventHandler(this.SelectAll_CheckedChanged);
            this.FilterSelectAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll_CheckedChanged);
            // 
            // EditProfessor
            // 
            this.EditProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditProfessor.Location = new System.Drawing.Point(41, 464);
            this.EditProfessor.Name = "EditProfessor";
            this.EditProfessor.Size = new System.Drawing.Size(53, 23);
            this.EditProfessor.TabIndex = 26;
            this.EditProfessor.Text = "Edit";
            this.EditProfessor.UseVisualStyleBackColor = true;
            this.EditProfessor.Click += new System.EventHandler(this.EditProfessor_Click);
            this.EditProfessor.Leave += new System.EventHandler(this.EnableSave);
            // 
            // DeleteProfessor
            // 
            this.DeleteProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteProfessor.Location = new System.Drawing.Point(94, 464);
            this.DeleteProfessor.Name = "DeleteProfessor";
            this.DeleteProfessor.Size = new System.Drawing.Size(47, 23);
            this.DeleteProfessor.TabIndex = 27;
            this.DeleteProfessor.Text = "Delete";
            this.DeleteProfessor.UseVisualStyleBackColor = true;
            this.DeleteProfessor.Click += new System.EventHandler(this.DeleteProfessor_Click);
            this.DeleteProfessor.Leave += new System.EventHandler(this.EnableSave);
            // 
            // DeleteRoom
            // 
            this.DeleteRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteRoom.Location = new System.Drawing.Point(280, 464);
            this.DeleteRoom.Name = "DeleteRoom";
            this.DeleteRoom.Size = new System.Drawing.Size(47, 23);
            this.DeleteRoom.TabIndex = 28;
            this.DeleteRoom.Text = "Delete";
            this.DeleteRoom.UseVisualStyleBackColor = true;
            this.DeleteRoom.Click += new System.EventHandler(this.DeleteRoom_Click);
            this.DeleteRoom.Leave += new System.EventHandler(this.EnableSave);
            // 
            // EditRoom
            // 
            this.EditRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditRoom.Location = new System.Drawing.Point(225, 464);
            this.EditRoom.Name = "EditRoom";
            this.EditRoom.Size = new System.Drawing.Size(53, 23);
            this.EditRoom.TabIndex = 30;
            this.EditRoom.Text = "Edit";
            this.EditRoom.UseVisualStyleBackColor = true;
            this.EditRoom.Click += new System.EventHandler(this.EditRoom_Click);
            this.EditRoom.Leave += new System.EventHandler(this.EnableSave);
            // 
            // InsertButton
            // 
            this.InsertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InsertButton.Location = new System.Drawing.Point(418, 446);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(157, 43);
            this.InsertButton.TabIndex = 31;
            this.InsertButton.Text = "Insert New Schedule";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            this.InsertButton.Leave += new System.EventHandler(this.EnableSave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(580, 446);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(157, 43);
            this.DeleteButton.TabIndex = 32;
            this.DeleteButton.Text = "Delete Schedule";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.Leave += new System.EventHandler(this.EnableSave);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Enabled = false;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SaveButton.Location = new System.Drawing.Point(759, 421);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(201, 68);
            this.SaveButton.TabIndex = 33;
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Start Time";
            this.label6.Leave += new System.EventHandler(this.EnableSave);
            // 
            // Viewer
            // 
            this.AcceptButton = this.InsertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 526);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.EditRoom);
            this.Controls.Add(this.DeleteRoom);
            this.Controls.Add(this.DeleteProfessor);
            this.Controls.Add(this.EditProfessor);
            this.Controls.Add(this.SubjectFilter);
            this.Controls.Add(this.RoomFilter);
            this.Controls.Add(this.ProfFilter);
            this.Controls.Add(this.Locked);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.SubjectTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EndGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddRoomButton);
            this.Controls.Add(this.AddProfessorButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoomList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfessorList);
            this.Controls.Add(this.MainData);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DayGroup);
            this.Controls.Add(this.StartGroup);
            this.Controls.Add(this.FilterPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Viewer";
            this.Text = "Schedule Inserter/Deleter";
            this.Activated += new System.EventHandler(this.Viewer_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewer_FormClosing);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).EndInit();
            this.DayGroup.ResumeLayout(false);
            this.DayGroup.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.StartGroup.ResumeLayout(false);
            this.EndGroup.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddProfessorButton;
        private System.Windows.Forms.Button AddRoomButton;
        private System.Windows.Forms.CheckedListBox DayChecklist;
        private System.Windows.Forms.RadioButton MWFRadio;
        private System.Windows.Forms.RadioButton TThRadio;
        private System.Windows.Forms.GroupBox DayGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel StartGroup;
        private System.Windows.Forms.ComboBox StartMeridian;
        private System.Windows.Forms.ComboBox StartMinute;
        private System.Windows.Forms.ComboBox StartHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel EndGroup;
        private System.Windows.Forms.ComboBox EndMeridian;
        private System.Windows.Forms.ComboBox EndMinute;
        private System.Windows.Forms.ComboBox EndHour;
        private System.Windows.Forms.RadioButton WeekdaysRadio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SubjectTitle;
        private System.Windows.Forms.CheckBox Filter;
        private System.Windows.Forms.CheckBox ProfFilter;
        private System.Windows.Forms.CheckBox RoomFilter;
        private System.Windows.Forms.CheckBox DayFilter;
        private System.Windows.Forms.CheckBox SubjectFilter;
        private System.Windows.Forms.CheckBox FilterAll;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.CheckBox FilterSelectAll;
        internal System.Windows.Forms.ListBox ProfessorList;
        internal System.Windows.Forms.ListBox RoomList;
        private System.Windows.Forms.Button EditProfessor;
        private System.Windows.Forms.Button DeleteProfessor;
        private System.Windows.Forms.Button DeleteRoom;
        private System.Windows.Forms.Button EditRoom;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unavailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unavailableToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem unavailableToolStripMenuItem4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        internal System.Windows.Forms.DataGridView MainData;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        internal System.Windows.Forms.CheckBox Locked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem professorScheduleViewerToolStripMenuItem;
    }
}