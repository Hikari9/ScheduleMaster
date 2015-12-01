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
using CE_21_Project.Classes;

namespace CE_21_Project
{
    internal partial class Viewer : Form
    {

        internal ScheduleDatabase sb;

        internal Viewer()
        {
            sb = new ScheduleDatabase();
            InitializeComponent();
        }

        internal void Viewer_Load(object sender, EventArgs e)
        {
            DontUpdateLabels = true;
            DataTable dt = Methods.ExcelToDataTable();
            sb.AssignFromDataTable(dt);
            string[][] arr = sb.ToSmallArray();
            StringBuilder s = new StringBuilder();
            foreach (var row in arr)
            {
                s.Append(String.Join("; ", row)).Append("\n");
            }
            dt = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
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

        internal void EndTimeChanged(object sender, EventArgs e)
        {
            if (!ValidTimeInputs())
            {
                RawTime1 = Math.Max(0, RawTime2 - 30);
                UpdateTimeInputs(RawTime1, StartHour, StartMinute, StartMeridian);
            }
            if (EndFilter.Enabled && EndFilter.Checked)
                FilterSelections();
        }

        internal void StartTimeChanged(object sender, EventArgs e)
        {
            if (!ValidTimeInputs())
            {
                RawTime2 = Math.Min(RawTime1 + 30, 1440);
                UpdateTimeInputs(RawTime2, EndHour, EndMinute, EndMeridian);
            }
            if (StartFilter.Enabled && StartFilter.Checked)
                FilterSelections();
        }

        internal void UpdateDayRadioButtons(object sender, ItemCheckEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        internal void UpdateDayRadioButtons(object sender, EventArgs e)
        {
            UpdateDayRadioButtons();
        }

        private void UpdateDayRadioButtons(object sender, MouseEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        private void DayChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDayRadioButtons();
        }


        internal void ClearRadio()
        {
            for (int i = 0; i < DayChecklist.Items.Count; ++i)
                DayChecklist.SetItemChecked(i, false);
            WeekdaysRadio.Checked = false;
            MWFRadio.Checked = false;
            TThRadio.Checked = false;
        }

        internal void WeekdaysRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ClearRadio();
            for (int i = 0; i < 5; ++i)
                DayChecklist.SetItemChecked(i, true);
            WeekdaysRadio.Checked = true;
            if( DayFilter.Enabled && DayFilter.Checked )
            FilterSelections();
        }

        internal void MWFRadio_CheckedChanged(object sender, EventArgs e)
        {
            ClearRadio();
            for (int i = 0; i < 3; ++i)
                DayChecklist.SetItemChecked(i << 1, true);
            MWFRadio.Checked = true;
            if (DayFilter.Enabled && DayFilter.Checked)
            FilterSelections();
        }

        internal void TThRadio_CheckedChanged(object sender, EventArgs e)
        {
            ClearRadio();
            for (int i = 0; i < 2; ++i)
                DayChecklist.SetItemChecked((i << 1) + 1, true);
            TThRadio.Checked = true;
            if( DayFilter.Enabled && DayFilter.Checked )
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
            if (ProfFilter.Enabled && ProfFilter.Checked)
            FilterSelections();
        }

        internal void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoomFilter.Enabled && RoomFilter.Checked)
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
            
            if (StartFilter.Checked)
            {
                int h = int.Parse(StartHour.Text);
                if( h==12 ) h = 0;
                if (StartMeridian.Text == "PM") h += 12;
                filters.Add(h.ToString("D2") + StartMinute.Text);
                indices.Add(4);
            }
            if (EndFilter.Checked)
            {
                int h = int.Parse(EndHour.Text);
                if (h == 12) h = 0;
                if (EndMeridian.Text == "PM") h += 12;
                filters.Add(h.ToString("D2") + EndMinute.Text);
                indices.Add(5);
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
            StartFilter.Enabled = Filter.Checked;
            EndFilter.Enabled = Filter.Checked;
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

        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ProfFilter.Checked = FilterSelectAll.Checked;
            RoomFilter.Checked = FilterSelectAll.Checked;
            StartFilter.Checked = FilterSelectAll.Checked;
            EndFilter.Checked = FilterSelectAll.Checked;
            DayFilter.Checked = FilterSelectAll.Checked;
            SubjectFilter.Checked = FilterSelectAll.Checked;
            FilterAll.Checked = FilterSelectAll.Checked;
            FilterSelectAll.Checked = FilterSelectAll.Checked;
            FilterSelections();
        }

        internal void SubjectTitle_KeyUp(object sender, KeyEventArgs e)
        {
            if (SubjectFilter.Enabled && SubjectFilter.Checked)
                FilterSelections();
        }

        internal void AddProfessorButton_Click(object sender, EventArgs e)
        {
            AddProfessorForm adder = new AddProfessorForm();
            adder.Host = this;
            adder.Show();
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            AddRoomForm adder = new AddRoomForm();
            adder.Host = this;
            adder.Show();
        }

        private void EditProfessor_Click(object sender, EventArgs e)
        {
            EditProfessorForm editor = new EditProfessorForm();
            editor.Host = this;
            editor.Show();
        }

        private void DeleteProfessor_Click(object sender, EventArgs e)
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

        private void DeleteRoom_Click(object sender, EventArgs e)
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

        private void Locked_CheckedChanged(object sender, EventArgs e)
        {
            InsertButton.Enabled = !Locked.Checked;
            ProfessorList.Enabled = !Locked.Checked;
            RoomList.Enabled = !Locked.Checked;
            EditProfessor.Enabled = !Locked.Checked;
            // EditRoom.Enabled = !Locked.Checked;
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

        private bool SaveToExcel()
        {
            try
            {
                sb.ToArray().ToDataTable(Schedule.GetHeaderArray()).ExportToExcel();
                SaveButton.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured:\n" + ex.ToString());
                return false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void EnableSave(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (SubjectTitle.Text.Trim() == "" && DayChecklist.CheckedItems.Count != 0)
            {
                DialogResult res = MessageBox.Show("Continue with empty subject title?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            Professor p = (Professor)ProfessorList.SelectedItem;
            Room r = (Room)RoomList.SelectedItem;
            Subject s = new Subject(SubjectTitle.Text, p, r);
            ValidTimeInputs();
            foreach (string day in DayChecklist.CheckedItems)
            {
                
                Time start = new Time(day, RawTime1/60, RawTime1%60);
                Time end = new Time(day, RawTime2/60, RawTime2%60);
                Schedule sched = new Schedule(s, start, end);
                if (sb.InsertSchedule(sched))
                {
                    //MessageBox.Show("New Schedule successfully inserted:\n\n" + sched.ToString());
                }
                else
                {
                    MessageBox.Show("Error: Conflicting Schedule with:\n\n" + sb.GetConflict(sched));
                }
            }
            MainData.DataSource = sb.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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

        private void Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveButton.Enabled)
            {
                DialogResult res = MessageBox.Show("Save File first before closing?", "Save File", MessageBoxButtons.YesNoCancel);
                if (res != DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void UpdateDayRadioButton(object sender, MouseEventArgs e)
        {
            UpdateDayRadioButtons();
        }

        private void UpdateDayRadioButtons()
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
            if (DayFilter.Enabled && DayFilter.Checked)
                FilterSelections();
        }

        

    }
}
