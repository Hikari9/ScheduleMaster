using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleMaster.Classes;

namespace ScheduleMaster
{
    internal partial class Viewer : Form
    {

        internal ScheduleDatabase sb
        {
            get { return Program.sb; }
            set { Program.sb = value; }
        }

        internal Viewer()
        {
            InitializeComponent();
        }

        internal void Viewer_Load(object sender, EventArgs e)
        {
            DontUpdateLabels = true;
            /*
            DataTable dt = Methods.ExcelToDataTable();
            sb.AssignFromDataTable(dt);
            */
            DataTable dt = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
            MainData.DataSource = dt;
            ProfessorList.DataSource = sb.AllProfessors.Clone();
            RoomList.DataSource = sb.AllRooms.Clone();
            DontUpdateLabels = false;
            FilterSelections();
            Locked.Checked = false;
        }

        internal int RawTime1, RawTime2;

        internal bool ValidTimeInputs()
        {
            if (ChangingTimeInputs) return true;
            RawTime1 = (int.Parse(StartHour.Text) % 12) * 60 + int.Parse(StartMinute.Text);
            if (StartMeridian.Text == "PM") RawTime1 += 720;
            RawTime2 = (int.Parse(EndHour.Text) % 12) * 60 + int.Parse(EndMinute.Text);
            if (EndMeridian.Text == "PM") RawTime2 += 720;
            return RawTime1 < RawTime2;
        }

        internal void UpdateTimeInputs(int t, ComboBox hr, ComboBox min, ComboBox mer)
        {
            ChangingTimeInputs = true;
            int h = t / 60, m = t % 60;
            if( h >= 12 ){
                mer.Text = "PM";
                h -= 12;
            }
            else mer.Text = "AM";
            if (h == 0) h = 12;
            hr.Text = h.ToString("D2");
            min.Text = m.ToString("D2");
            ChangingTimeInputs = false;
        }

        internal bool ChangingTimeInputs = false;


        internal bool FilterOK(CheckBox cb)
        {
            return cb.Enabled && cb.Visible && cb.Checked;
        }

        internal void EndTimeChanged(object sender, EventArgs e)
        {
            if (!ValidTimeInputs())
            {
                RawTime1 = Math.Max(0, RawTime2 - 30);
                UpdateTimeInputs(RawTime1, StartHour, StartMinute, StartMeridian);
            }
        }


        internal void StartTimeChanged(object sender, EventArgs e)
        {
            if (!ValidTimeInputs())
            {
                RawTime2 = Math.Min(RawTime1 + 30, 1440);
                UpdateTimeInputs(RawTime2, EndHour, EndMinute, EndMeridian);
            }
        }

        internal void UpdateDayRadioButtons(object sender, ItemCheckEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        internal void UpdateDayRadioButtons(object sender, EventArgs e)
        {
            UpdateDayRadioButtons();
        }

        internal void UpdateDayRadioButtons(object sender, MouseEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        internal void DayChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDayRadioButtons();
        }


        internal void ClearRadio(object sender = null, EventArgs e = null)
        {
            for (int i = 0; i < DayChecklist.Items.Count; ++i)
                DayChecklist.SetItemChecked(i, false);
            WeekdaysRadio.Checked = false;
            MWFRadio.Checked = false;
            TThRadio.Checked = false;
        }

        internal void WeekdaysRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool same = (DayChecklist.CheckedItems.Count == 5);
            for (int i = 0; same && i < 3; ++i)
            {
                same &= DayChecklist.GetItemChecked(i);
            }
            ClearRadio();
            if (same)
            {
                ((RadioButton)sender).Checked = false;
                return;
            }
            for (int i = 0; i < 5; ++i)
                DayChecklist.SetItemChecked(i, true);
            WeekdaysRadio.Checked = true;
            if (FilterOK(DayFilter))
            FilterSelections();
        }

        internal void MWFRadio_CheckedChanged(object sender, EventArgs e)
        {
            bool same = ( DayChecklist.CheckedItems.Count==3 );
            for (int i = 0; same && i < 3; ++i)
            {
                same &= DayChecklist.GetItemChecked(i << 1);
            }
            ClearRadio();
            if (same)
            {
                ((RadioButton)sender).Checked = false;
                return;
            }
            
            for (int i = 0; i < 3; ++i)
                DayChecklist.SetItemChecked(i << 1, true);
            MWFRadio.Checked = true;
            if (FilterOK(DayFilter))
            FilterSelections();
        }

        internal void TThRadio_CheckedChanged(object sender, EventArgs e)
        {
            bool same = (DayChecklist.CheckedItems.Count == 2);
            for (int i = 0; same && i < 2; ++i)
            {
                same &= DayChecklist.GetItemChecked((i << 1) + 1);
            }
            ClearRadio();
            if (same)
            {
                ((RadioButton)sender).Checked = false;
                return;
            }
            for (int i = 0; i < 2; ++i)
                DayChecklist.SetItemChecked((i << 1) + 1, true);
            TThRadio.Checked = true;
            if (FilterOK(DayFilter))
            FilterSelections();
        }

        internal bool DontUpdateLabels = true;

        internal void UpdateLabels(Schedule s)
        {
            if (!Locked.Checked) return;
            ChangingTimeInputs = true;
            char[] tok = new char[2]{ ':', ' ' };
            string[] t = s.StartTime.ToTimeString().Split(tok);
            StartHour.Text = t[0];
            StartMinute.Text = t[1];
            StartMeridian.Text = t[2];
            t = s.EndTime.ToTimeString().Split(tok);
            EndHour.Text = t[0];
            EndMinute.Text = t[1];
            EndMeridian.Text = t[2];
            ChangingTimeInputs = false;
            int d = s.StartTime.days();
            ClearRadio();
            DayChecklist.SetItemChecked(d, true);
            ProfessorList.SelectedItem = s.GetProfessor;
            RoomList.SelectedItem = s.GetRoom;
            SubjectTitle.Text = s.GetSubject.Title;
        }

        internal void CellSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (!Locked.Checked) return;
            if (DontUpdateLabels) return;
            DontUpdateLabels = true;
            string cell = MainData.Rows[e.RowIndex].Cells[0].Value.ToString();
            Schedule s = sb.GetSchedule(int.Parse(cell) - 1);
            UpdateLabels(s);
            DontUpdateLabels = false;
        }

        internal void ProfessorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterOK(ProfFilter))
            FilterSelections();
        }

        internal void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterOK(RoomFilter))
            FilterSelections();
        }

        internal void FilterSelections()
        {
            if (!Filter.Checked) return;
            if (DontUpdateLabels) return;
            DontUpdateLabels = true;
            ArrayList filters = new ArrayList();
            ArrayList indices = new ArrayList();
            if (ProfFilter.Checked)
            {
                filters.Add(((Professor)ProfessorList.SelectedItem).Name());
                indices.Add(1);
            }
            if (RoomFilter.Checked)
            {
                filters.Add(((Room)RoomList.SelectedItem).ToString());
                indices.Add(2);
            }
            if (SubjectFilter.Checked)
            {
                filters.Add(SubjectTitle.Text);
                indices.Add(6);
            }
            if (FilterAll.Checked)
            {
                if (DayFilter.Checked)
                {
                    foreach (string s in DayChecklist.CheckedItems)
                    {
                        filters.Add(s);
                        indices.Add(3);
                    }
                }
                foreach (DataGridViewRow row in MainData.Rows)
                {
                    row.Selected = false;
                    for (int i = 0; i < filters.Count; ++i)
                    {
                        if (row.Cells[(int)indices[i]].Value.ToString().Equals((string)filters[i]))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in MainData.Rows)
                {
                    row.Selected = true;
                    for (int i = 0; i < filters.Count; ++i)
                    {
                        if (!row.Cells[(int)indices[i]].Value.ToString().Equals((string)filters[i]))
                        {
                            row.Selected = false;
                            break;
                        }
                    }
                    if (row.Selected && DayFilter.Checked && DayChecklist.CheckedItems.Count != 0)
                    {
                        // union for day, even if FilterAll.Checked == false
                        row.Selected = false;
                        foreach (string s in DayChecklist.SelectedItems)
                        {
                            if (row.Cells[3].Value.ToString().Equals(s))
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            DontUpdateLabels = false;
        }

        internal void Filter_CheckedChanged(object sender, EventArgs e)
        {
            ProfFilter.Enabled = Filter.Checked;
            RoomFilter.Enabled = Filter.Checked;
            DayFilter.Enabled = Filter.Checked;
            SubjectFilter.Enabled = Filter.Checked;
            FilterAll.Enabled = Filter.Checked;
            FilterSelectAll.Enabled = Filter.Checked;
            FilterSelections();
        }

        internal void FilterObject_CheckedChanged(object sender, EventArgs e)
        {
            FilterSelections();
        }

        internal void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ProfFilter.Checked = FilterSelectAll.Checked;
            RoomFilter.Checked = FilterSelectAll.Checked;
            DayFilter.Checked = FilterSelectAll.Checked;
            SubjectFilter.Checked = FilterSelectAll.Checked;
            FilterAll.Checked = FilterSelectAll.Checked;
            FilterSelectAll.Checked = FilterSelectAll.Checked;
            FilterSelections();
        }

        internal void SubjectTitle_KeyUp(object sender, KeyEventArgs e)
        {
            if (FilterOK(SubjectFilter))
                FilterSelections();
        }

        internal void AddProfessorButton_Click(object sender, EventArgs e)
        {
            AddProfessorForm adder = new AddProfessorForm();
            adder.Host = this;
            adder.Show();
        }

        internal void AddRoomButton_Click(object sender, EventArgs e)
        {
            AddRoomForm adder = new AddRoomForm();
            adder.Host = this;
            adder.Show();
        }

        internal void EditProfessor_Click(object sender, EventArgs e)
        {
            EditProfessorForm editor = new EditProfessorForm();
            editor.Host = this;
            editor.Show();
        }

        internal void DeleteProfessor_Click(object sender, EventArgs e)
        {
            Professor prof = (Professor)ProfessorList.SelectedItem;
            if (prof == null) return;
            DialogResult res = MessageBox.Show("Are you sure you want to delete \"" + prof.ToString() + "\"?", "Delete Professor", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                res = MessageBox.Show("WARNING: This will erase all associated Schedules with the Professor.", "Delete Professor", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    if (sb.DeleteProfessor(prof))
                    {
                        ProfessorList.DataSource = sb.AllProfessors.Clone();
                        MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
                        //MessageBox.Show("Professor successfully deleted.","Success");
                    }
                    else
                    {
                        MessageBox.Show("Unknown Error: could not delete Professor","ERROR");
                    }
                }
            }
        }

        internal void DeleteRoom_Click(object sender, EventArgs e)
        {
            Room room = (Room) RoomList.SelectedItem;
            if (room == null) return;
            DialogResult res = MessageBox.Show("Are you sure you want to delete \"" + room.ToString() + "\"?", "Delete Room", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                res = MessageBox.Show("WARNING: This will erase all associated Schedules with the Room.", "Delete Room", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    if (sb.DeleteRoom(room))
                    {
                        RoomList.DataSource = sb.AllRooms.Clone();
                        MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
                        //MessageBox.Show("Room successfully deleted.","Success");
                    }
                    else
                    {
                        MessageBox.Show("Unknown Error: could not delete Room","ERROR");
                    }
                }
            }
        }

        internal void Locked_CheckedChanged(object sender, EventArgs e)
        {
            InsertButton.Enabled = !Locked.Checked;
            ProfessorList.Enabled = !Locked.Checked;
            RoomList.Enabled = !Locked.Checked;
            EditProfessor.Enabled = !Locked.Checked;
            EditRoom.Enabled = !Locked.Checked;
            DeleteProfessor.Enabled = !Locked.Checked;
            DeleteRoom.Enabled = !Locked.Checked;
            AddProfessorButton.Enabled = !Locked.Checked;
            AddRoomButton.Enabled = !Locked.Checked;
            DayGroup.Enabled = !Locked.Checked;
            StartGroup.Enabled = !Locked.Checked;
            EndGroup.Enabled = !Locked.Checked;
            SubjectTitle.Enabled = !Locked.Checked;
            InsertButton.Enabled = !Locked.Checked;
            DeleteButton.Enabled = Locked.Checked;
        }

        

        internal void SaveButton_Click(object sender, EventArgs e)
        {
            sb.SaveToExcel();
            SaveButton.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        internal void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sb.SaveToExcel();
            SaveButton.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        internal void EnableSave()
        {
            SaveButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        internal void EnableSave(object sender, EventArgs e)
        {
            EnableSave();
        }

        internal void InsertButton_Click(object sender, EventArgs e)
        {
            if (DayChecklist.CheckedItems.Count == 0)
            {
                MessageBox.Show("Choose a day");
                return;
            }
            DialogResult res;
            if (SubjectTitle.Text.Trim() == "" && DayChecklist.CheckedItems.Count != 0)
            {
                res = MessageBox.Show("Continue with empty subject title?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            Professor p = (Professor)ProfessorList.SelectedItem;
            Room r = (Room)RoomList.SelectedItem;
            Subject s = new Subject(SubjectTitle.Text, p, r);
            ValidTimeInputs();
            ArrayList toInsert = new ArrayList();
            StringBuilder notif = new StringBuilder();
            int count = 0;
            foreach (string day in DayChecklist.CheckedItems)
            {
                Time start = new Time(day, RawTime1/60, RawTime1%60);
                Time end = new Time(day, RawTime2/60, RawTime2%60);
                Schedule sched = new Schedule(s, start, end);
                toInsert.Add(sched);
                notif.AppendLine((++count).ToString() + ":\n" + sched.ToString());
            }
            res = MessageBox.Show("You are about to insert these schedules:\n\n" + notif.ToString(), "Insert Schedule/s", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                notif.Clear();
                StringBuilder conflicts = new StringBuilder();
                count = 0;
                int count2 = 0;
                foreach( Schedule sched in toInsert ){
                    if (sb.InsertSchedule(sched))
                    {
                        notif.AppendLine((++count).ToString() + ":\n" + sched.ToString());
                    }
                    else
                    {
                        conflicts.AppendLine((++count2).ToString() + ":\n" + sched.ToString() + "\n(CONFLICTED WITH)\n" + sb.GetConflict(sched).ToString());
                    }
                }
                if( notif.Length==0 ) notif.AppendLine("NONE");
                if( conflicts.Length==0 ) conflicts.AppendLine("NONE");
                MessageBox.Show("SUCCESSFUL:\n\n" + notif.ToString() + "\n\nUNSUCCESSFUL:\n\n" + conflicts.ToString());
                MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
            }
            
        }

        internal void DeleteButton_Click(object sender, EventArgs e)
        {
            DontUpdateLabels = true;
            DialogResult res = MessageBox.Show("Are you sure you want to delete selected Schedule/s?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                ArrayList scheds = new ArrayList(MainData.SelectedRows.Count);
                foreach (DataGridViewRow row in MainData.SelectedRows)
                {
                    int ind = int.Parse(row.Cells[0].Value.ToString());
                    scheds.Add(sb.GetSchedule(ind - 1));
                }
                foreach (Schedule s in scheds)
                {
                    try
                    {
                        sb.DeleteSchedule(s);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Unknown Error Occured:\n" + ex.ToString());
                    }
                }
            }
            MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
            DontUpdateLabels = false;
        }

        internal void Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.sv.Visible)
            {
                if (SaveButton.Enabled)
                {
                    DialogResult res = MessageBox.Show("Save File first before closing?", "Save File", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else if (res == DialogResult.Yes)
                    {
                        sb.SaveToExcel();
                        SaveButton.Enabled = false;
                        saveToolStripMenuItem.Enabled = false;
                    }
                }
                Application.ExitThread();
            }
            Program.sv.inserterDeleterToolStripMenuItem.PerformClick();
            e.Cancel = true;
        }

        internal void UpdateDayRadioButton(object sender, MouseEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        internal void UpdateDayRadioButtons()
        {
            var ind = DayChecklist.CheckedIndices;
            if (ind.Count == 5 && ind.Contains(0) && ind.Contains(1) && ind.Contains(2) && ind.Contains(3) && ind.Contains(4))
            {
                WeekdaysRadio.Checked = true;
                MWFRadio.Checked = false;
                TThRadio.Checked = false;
            }
            else if (ind.Count == 3 && ind.Contains(0) && ind.Contains(2) && ind.Contains(4))
            {
                WeekdaysRadio.Checked = false;
                MWFRadio.Checked = true;
                TThRadio.Checked = false;
            }
            else if (ind.Count == 2 && ind.Contains(1) && ind.Contains(3))
            {
                WeekdaysRadio.Checked = false;
                MWFRadio.Checked = false;
                TThRadio.Checked = true;
            }
            else
            {
                WeekdaysRadio.Checked = false;
                MWFRadio.Checked = false;
                TThRadio.Checked = false;
            }
            if (FilterOK(DayFilter))
                FilterSelections();
        }

        internal void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog
            {
                Title = "Save As Excel File",
                OverwritePrompt = true,
                FileName = "data.xlsx",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel Workbook 97-03 (*.xls)|*.xls|All files (*.*)|*.*",
                FilterIndex = 0,
                DefaultExt = "*.xlsx"
            };
            DialogResult res = d.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filepath = d.FileName;
                int sep = filepath.LastIndexOf('\\');
                string dir = filepath.Substring(0,sep);
                string name = filepath.Substring(sep+1);
                sb.ToArray().ToDataTable(Schedule.GetHeaderArray()).ExportToExcel(dir, name);
            }
        }

        internal void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog
            {
                Title = "Save As Excel File",
                FileName = "data.xlsx",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel Workbook 97-03 (*.xls)|*.xls",
                FilterIndex = 0,
                DefaultExt = "*.xlsx"
            };
            DialogResult res = d.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filepath = d.FileName;
                int sep = filepath.LastIndexOf('\\');
                string dir = filepath.Substring(0, sep);
                string name = filepath.Substring(sep + 1);
                sb.AssignFromDataTable(Methods.ExcelToDataTable("Sheet1", dir, name));
                MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
                EnableSave();
            }
        }

        internal void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void EditRoom_Click(object sender, EventArgs e)
        {
            EditRoomForm x = new EditRoomForm();
            x.r = (Room)RoomList.SelectedItem;
            x.Host = this;
            x.Show();
        }

        internal void unavailableToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        internal void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterToolStripMenuItem.Checked = !filterToolStripMenuItem.Checked;
        }

        internal void filterToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            bool c = filterToolStripMenuItem.Checked;
            Filter.Visible = c;
            DayFilter.Visible = c;
            FilterPanel.Visible = c;
            ProfFilter.Visible = c;
            RoomFilter.Visible = c;
            SubjectFilter.Visible = c;
        }

        internal void MainData_DataSourceChanged(object sender, EventArgs e)
        {
                
                SubjectTitle.AutoCompleteCustomSource.Clear();
                int col;
                try
                {
                    col = MainData.Columns["Subject"].Index;
                } catch{
                    col = 6;
                }
                foreach (DataGridViewRow row in MainData.Rows)
                {
                    SubjectTitle.AutoCompleteCustomSource.Add(row.Cells[col].Value.ToString());
                }
        }

        private void Viewer_Enter(object sender, EventArgs e)
        {
            ProfessorList.DataSource = sb.AllProfessors.Clone();
            professorScheduleViewerToolStripMenuItem.Checked = Program.sv.Visible;
            inserterDeleterToolStripMenuItem.Checked = Program.v.Visible;
        }

        private void ToggleMenuItem(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked ^= true;
        }

        private void professorScheduleViewerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Program.sv.Visible = ((ToolStripMenuItem)sender).Checked;
                string name = ((Professor)(ProfessorList.SelectedItem)).ToString().ToUpper();
                foreach (TabPage tab in Program.sv.TabControl.TabPages)
                {
                    if (tab.ToString().ToUpper() == name)
                    {
                        Program.sv.TabControl.SelectedTab = tab;
                        Program.sv.SelectProfessor();
                    }
                }
            }
            catch { }
        }

        private void inserterDeleterToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if( !((ToolStripMenuItem)sender).Checked )
                ((ToolStripMenuItem)sender).Checked = true;
        }

       

        

    }
}
