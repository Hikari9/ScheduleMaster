using System;
using System.Diagnostics;
using System.IO;
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
    public partial class AllDataViewer : Form
    {

        bool flag;
        internal DataTable MainDataTable;
        internal DataView MainDataView;

        public AllDataViewer()
        {
            InitializeComponent();
            flag = false;
            StartMeridian.SelectedIndex = 0;
            EndMeridian.SelectedIndex = 0;
            MainDataView = new DataView();
            MakeRows();
        }

        public void LoadProfessors()
        {
            try
            {
                ProfessorList.DataSource = Program.db.AllProfessors;
                ProfessorBox2.AutoCompleteCustomSource.Clear();
                foreach (Professor p in Program.db.AllProfessors)
                {
                    ProfessorBox2.AutoCompleteCustomSource.Add(p.Name());
                }
            }
            catch { }
        }

        public void LoadRooms()
        {
            try
            {
                RoomList.DataSource = Program.db.AllRooms.Clone();
                ClassroomBox2.AutoCompleteCustomSource.Clear();
                foreach (Room r in Program.db.AllRooms)
                {
                    ClassroomBox2.AutoCompleteCustomSource.Add(r.ToString());
                }
            }
            catch { }
        }

        public void LoadSubjects()
        {
            try
            {
                SortedSet<string> list = new SortedSet<string>();
                foreach (Professor p in Program.db.AllProfessors)
                {
                    foreach (Schedule s in p.GetSchedules.GetArrayList)
                    {
                        list.Add(s.GetSubject.Title);
                    }
                }
                // list.Sort();
                string[] arr = new string[list.Count];
                list.CopyTo(arr);
                SubjectList.DataSource = arr;
                SubjectBox2.AutoCompleteCustomSource.AddRange(arr);
                SearchBox.AutoCompleteCustomSource.AddRange(arr);

            }
            catch
            {
                MessageBox.Show("Some data are corrupt");
            }
        }

        Professor CurrentlyPainted = null;

        private void UpdateProfessor()
        {
            try
            {
                Professor p = (Professor)ProfessorList.SelectedItem;
                if (EditOnClickCheckbox.Checked) ProfessorBox2.Text = p.Name();
                PaintSchedule();
            }
            catch { }
        }

        private void UpdateClassroom()
        {
            try
            {
                Room r = (Room)RoomList.SelectedItem;
                if (EditOnClickCheckbox.Checked) ClassroomBox2.Text = r.ToString();
            }
            catch { }
        }

        string CurrentlyPaintedSubject = "N/A";

        private void PaintSubject()
        {
            try
            {
                if (SubjectList.SelectedItem == null)
                {
                    CurrentlyPaintedSubject = "N/A";
                    return;
                }
                string CurrentSubject = SubjectList.SelectedItem.ToString();
                if (CurrentSubject == CurrentlyPaintedSubject) return;
                CurrentlyPaintedSubject = CurrentSubject;
                for (int i = 1; i < Weekly.Columns.Count; ++i)
                {
                    for (int j = 0; j < Weekly.Rows.Count; ++j)
                    {
                        object val = Weekly[i, j].Value;
                        if (val == null) continue;
                        string str = val.ToString();
                        if (str == CurrentSubject)
                        {
                            Weekly[i, j].Style = FullProf;
                        }
                        else
                        {
                            Weekly[i, j].Style = Shadowed;
                        }
                    }
                }
            }
            catch { }
        }

        private void UpdateSubject()
        {
            try
            {
                if (EditOnClickCheckbox.Checked) SubjectBox2.Text = (string)SubjectList.SelectedItem;
                PaintSubject();
            }
            catch { }
        }

        

        private void TabulateSchedules()
        {
            try
            {
                MainDataTable = Program.db.ToSmallArray().ToDataTable(Schedule.GetSmallHeaderArray());
                MainDataView.Table = MainDataTable;
                MainData.DataSource = MainDataView;
                MainData.Columns["ID"].Visible = false;
                MainData.Columns["_"].Visible = false;
                //MainData.Columns["Professor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //MainData.Columns["Professor"].Width = 175;
            }
            catch { }
        }

        private void AllDataViewer_Load(object sender, EventArgs e)
        {
            try
            {
                TabulateSchedules();
                LoadProfessors();
                LoadRooms();
                LoadSubjects();
            }
            catch { }
        }

        private void AllDataViewer_Click(object sender, EventArgs e)
        {
            // Search.Focus();
        }

        float initW, initH;

        private void AllDataViewer_ResizeBegin(object sender, EventArgs e)
        {
            initW = Width;
            initH = Height;
        }

        private void AllDataViewer_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                float rw = (float)Width / initW;
                float hw = (float)Height / initH;
                SizeF sc = new SizeF(rw, hw);
                //Scale(sc);
                foreach (Control c in Controls)
                {
                    c.Scale(sc);
                    // float newSize = c.Font.SizeInPoints * hw * rw;
                    // c.Font = new Font(c.Font.FontFamily.Name, newSize);
                }
            }
            catch { }
        }


        private void ClearDayChecklist()
        {
            try
            {
                for (int i = 0; i < DayChecklist.Items.Count; ++i)
                    DayChecklist.SetItemChecked(i, false);
            }
            catch { }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    ClearDayChecklist();
                    DayBox.Text = "";
                    WeekdaysRadio.Checked = false;
                    MWFRadio.Checked = false;
                    TThRadio.Checked = false;
                    ((Button)sender).Enabled = false;
                    flag = false;
                }
            }
            catch { }
        }


        private void DayChecklist_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (!flag)
                {
                    //MessageBox.Show(DayChecklist.CheckedItems.Count.ToString());
                    int i;
                    flag = true;
                    if (DayChecklist.CheckedIndices.Count == 5)
                    {
                        for (i = 0; i < 5; ++i)
                            if (DayChecklist.CheckedIndices[i] != i) break;
                        if (i == 5)
                        {
                            WeekdaysRadio.Checked = true;
                            goto done;
                        }
                    }
                    // MWF
                    else if (DayChecklist.CheckedIndices.Count == 3)
                    {
                        for (i = 0; i < 3; ++i)
                            if (DayChecklist.CheckedIndices[i] != (i << 1)) break;
                        if (i == 3)
                        {
                            MWFRadio.Checked = true;
                            goto done;
                        }
                    }
                    else if (DayChecklist.CheckedIndices.Count == 2)
                    {
                        for (i = 0; i < 2; ++i)
                            if (DayChecklist.CheckedIndices[i] != ((i << 1) + 1)) break;
                        if (i == 2)
                        {
                            TThRadio.Checked = true;
                            goto done;
                        }
                    }
                    WeekdaysRadio.Checked = false;
                    MWFRadio.Checked = false;
                    TThRadio.Checked = false;
                // list
                done:
                    ListDays();
                    flag = false;
                }
            }
            catch { }
        }

        private void WeekdaysRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    ClearDayChecklist();
                    for (int i = 0; i < 5; ++i)
                        DayChecklist.SetItemChecked(i, true);
                    ListDays();
                    flag = false;
                }
            }
            catch { }
        }

        private void MWFRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    ClearDayChecklist();
                    for (int i = 0; i < 3; ++i)
                        DayChecklist.SetItemChecked(i << 1, true);
                    ListDays();
                    flag = false;
                }
            }
            catch { }
        }

        private void TThRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
                ClearDayChecklist();
                for (int i = 0; i < 2; ++i)
                    DayChecklist.SetItemChecked((i << 1) + 1, true);
                ListDays();
                flag = false;
            }
        }

        void ListDays()
        {
            try
            {
                string[] list = new string[DayChecklist.CheckedItems.Count];
                DayChecklist.CheckedItems.CopyTo(list, 0);
                DayBox.Text = string.Join(";", list);
            }
            catch { }
        }

        private void DayChecklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                ClearButton.Enabled = (DayChecklist.CheckedItems.Count != 1 || e.NewValue != CheckState.Unchecked);
            }
            catch { }
        }


        private void DayBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] sp = DayBox.Text.Split(';');
                ClearDayChecklist();
                foreach (string a in sp)
                {
                    StringBuilder sb = new StringBuilder(a.Trim().ToLower());
                    if (sb.Length == 0) continue;
                    sb[0] = char.ToUpper(sb[0]);
                    string s = sb.ToString();
                    if (Time.getDayOfWeek.ContainsKey(s))
                        DayChecklist.SetItemChecked(Time.getDayOfWeek[s], true);
                }
            }
            catch { }
        }

        static int TimeAdd = 60;

        int GetRawTime(string TimeString, string AMPM)
        {
            try
            {
                string[] sp = TimeString.Split(':');
                int hr = int.Parse(sp[0]);
                int min = int.Parse(sp[1]);
                hr %= 12;
                if (AMPM == "PM") hr += 12;
                return hr * Time.MINUTE_MASK + min;
            }
            catch { return 0; }
        }
        void AssignRawTime(int raw, MaskedTextBox TimeString, ComboBox AMPM)
        {
            try
            {
                raw %= Time.HOUR_MASK;
                if (raw >= (Time.HOUR_MASK >> 1))
                {
                    AMPM.Text = "PM";
                    raw -= (Time.HOUR_MASK >> 1);
                }
                else AMPM.Text = "AM";
                if (raw < Time.MINUTE_MASK)
                {
                    raw += (Time.HOUR_MASK >> 1);
                    // AMPM.SelectedIndex ^= 1;
                }
                TimeString.Text = new Time(raw).ToMilitaryTimeString();
            }
            catch { }
        }

        private void StartNum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (StartNum.Value == 0) return;
                int raw = GetRawTime(StartBox.Text, StartMeridian.Text) + (int)StartNum.Value;
                AssignRawTime(raw, StartBox, StartMeridian);
                StartNum.Value = 0;
            }
            catch { }
        }

        private void StartBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up) ++StartNum.Value;
                else if (e.KeyCode == Keys.Down) --StartNum.Value;
                else if (e.KeyCode == Keys.Enter)
                {
                    // revalidate
                    if (StartBox.Text.Length != 5)
                        StartBox.Text = new string('0', 5 - StartBox.Text.Length) + StartBox.Text;
                }
            }
            catch { }
        }


        void ValidateStartTime()
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    if (StartBox.Text.Length == 5)
                    {
                        int nt = GetRawTime(StartBox.Text, StartMeridian.Text);
                        int nt2 = GetRawTime(EndBox.Text, EndMeridian.Text);
                        if (nt > nt2)
                        {
                            nt2 = (nt + TimeAdd) % Time.HOUR_MASK;
                            AssignRawTime(nt2, EndBox, EndMeridian);
                            TimeEndBox.Text = new Time(nt2).ToMilitaryTimeString();
                        }
                        AssignRawTime(nt, StartBox, StartMeridian);
                        TimeStartBox.Text = new Time(nt).ToMilitaryTimeString();
                    }
                    flag = false;
                }
            }
            catch { }
        }

        private void StartBox_TextChanged(object sender, EventArgs e)
        {
            ValidateStartTime();
        }

        private void EndNum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (EndNum.Value == 0) return;
                int raw = GetRawTime(EndBox.Text, EndMeridian.Text) + (int)EndNum.Value;
                AssignRawTime(raw, EndBox, EndMeridian);
                EndNum.Value = 0;
            }
            catch { }
        }

        void ValidateEndTime()
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    if (EndBox.Text.Length == 5)
                    {
                        int nt = GetRawTime(EndBox.Text, EndMeridian.Text);
                        int nt2 = GetRawTime(StartBox.Text, StartMeridian.Text);
                        if (nt < nt2)
                        {
                            nt2 = nt - TimeAdd;
                            if (nt2 < 0) nt2 += (Time.HOUR_MASK >> 1);
                            AssignRawTime(nt2, StartBox, StartMeridian);
                            TimeStartBox.Text = new Time(nt2).ToMilitaryTimeString();
                        }
                        AssignRawTime(nt, EndBox, EndMeridian);
                        TimeEndBox.Text = new Time(nt).ToMilitaryTimeString();
                    }
                    flag = false;
                }
            }
            catch { }
        }

        private void EndBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateEndTime();
            }
            catch { }
        }

        private void EndBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up) ++EndNum.Value;
                else if (e.KeyCode == Keys.Down) --EndNum.Value;
                else if (e.KeyCode == Keys.Enter)
                {
                    if (EndBox.Text.Length != 5)
                        EndBox.Text = new string('0', 5 - EndBox.Text.Length) + EndBox.Text;
                }
            }
            catch { }
        }

        private void EditProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProfessorList.SelectedItem == null) return;
                new EditProfessorForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }

        public void RenewProfessorList()
        {
            try
            {
                string renew = ProfessorBox.Text;
                ProfessorBox.Text = renew + " ";
                ProfessorBox.Text = renew;
            }
            catch { }
        }

        public void RenewRoomList()
        {
            try
            {
                string renew = ClassroomBox.Text;
                ClassroomBox.Text = renew + " ";
                ClassroomBox.Text = renew;
            }
            catch { }
        }

        public void RenewSubjectList()
        {
            try
            {
                string renew = SubjectBox.Text;
                SubjectBox.Text = renew + " ";
                SubjectBox.Text = renew;
            }
            catch { }
        }

        private void DeleteProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProfessorList.SelectedItem == null) return;
                var res = MessageBox.Show("Delete Professor \"" + ((Professor)ProfessorList.SelectedItem).Name() + "\" from Database?\nWARNING: This will erase all schedules affiliated with the Professor.", "Delete Professor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    SearchBox.AutoCompleteCustomSource.Remove(((Professor)ProfessorList.SelectedItem).Name());
                    Program.db.DeleteProfessor(((Professor)ProfessorList.SelectedItem));
                    RenewProfessorList();
                    TabulateSchedules();
                    SaveButton.Enabled = true;
                }
            }
            catch { }
        }

        private void AddProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                new AddProfessorForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }


        private void AddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                new AddRoomForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }


        private void ProfessorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProfessor();
        }

        private void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClassroom();
        }

        private void SubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSubject();
        }

        private void StartMeridian_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateStartTime();
        }

        private void EndMeridian_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateEndTime();
        }

        private void TimeStartBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TimeStartBox.Text.Length == 5)
                {
                    int raw = new Time(0, TimeStartBox.Text).raw();
                    AssignRawTime(raw, StartBox, StartMeridian);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Time Format");
            }
        }

        private void TimeEndBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TimeEndBox.Text.Length == 5)
                {
                    int raw = new Time(0, TimeEndBox.Text).raw();
                    AssignRawTime(raw, EndBox, EndMeridian);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Time Format");
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void EditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomList.SelectedItem == null) return;
                new EditRoomForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }

        private void DeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomList.SelectedItem == null) return;
                var res = MessageBox.Show("Delete Classroom \"" + ((Room)RoomList.SelectedItem).ToString() + "\" from Database?\nWARNING: This will erase all schedules affiliated with the Classroom.", "Delete Classroom", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    ClassroomBox2.AutoCompleteCustomSource.Remove(((Room)RoomList.SelectedItem).ToString());
                    Program.db.DeleteRoom(((Room)RoomList.SelectedItem));
                    RenewRoomList();
                    TabulateSchedules();
                    SaveButton.Enabled = true;
                }
            }
            catch { }
        }

        private void ProfessorList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteProfessor.PerformClick();
                }
            }
            catch { }
        }

        private void RoomList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteRoom.PerformClick();
                }
            }
            catch { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveButton.PerformClick();
        }

        private void saveCopyAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllDataViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (SaveButton.Enabled)
                {
                    var res = MessageBox.Show("Save changes before closing?", "Save", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            Program.db.SaveToExcel();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Data was not successfully saved.\n\nDetails:\n" + ex.ToString());
                        }
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.db.SaveToExcel();
                MessageBox.Show("Data successfully saved!");
                SaveButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Data was not successfully saved.\n\nDetails:\n" + ex.ToString());
            }
            //((Button)sender).Enabled = false;
        }

        private void EditSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (SubjectList.SelectedItem == null) return;
                new EditSubjectForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }

        private void AddSubject_Click(object sender, EventArgs e)
        {
            try
            {
                new AddSubjectForm().ShowDialog();
                SaveButton.Enabled = true;
            }
            catch { }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res;
                if (ProfessorBox2.Text.Length == 0)
                {
                    MessageBox.Show("Professor name is empty");
                    return;
                }
                if (ClassroomBox2.Text.Length == 0)
                {
                    MessageBox.Show("Classroom name is empty");
                    return;
                }
                if (DayChecklist.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please choose day/s");
                    return;
                }
                if (SubjectBox2.Text.Length == 0)
                {
                    res = MessageBox.Show("Continue with empty subject?", "Insert Schedule", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) return;
                    SaveButton.Enabled = true;
                }
                // parse professor
                Professor p = Program.db.GetProfessor(ProfessorBox2.Text);
                if (p == null)
                {
                    res = MessageBox.Show("Professor with name \"" + ProfessorBox2.Text + "\" does not exist.\nAdd new Professor to the database?", "Insert Schedule", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) return;
                    int size = Program.db.AllProfessors.Count;
                    AddProfessorForm f = new AddProfessorForm();
                    p = new Professor(ProfessorBox2.Text, "", "", "");
                    f.LastNameBox.Text = p.LastName;
                    f.FirstNameBox.Text = p.FirstName;
                    f.ShowDialog();
                    if (size == Program.db.AllProfessors.Count) return;
                    p = (Professor)ProfessorList.SelectedItem;
                    SaveButton.Enabled = true;
                }
                Room r = Program.db.GetRoom(ClassroomBox2.Text);
                if (r == null)
                {
                    res = MessageBox.Show("Classroom with name \"" + ClassroomBox2.Text + "\" does not exist.\nAdd new Classroom to the database?", "Insert Schedule", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) return;
                    r = Program.db.AddRoom(new Room(ClassroomBox2.Text));
                    RoomList.DataSource = Program.db.AllRooms.Clone();
                    RenewRoomList();
                    RoomList.SelectedItem = r;
                    SaveButton.Enabled = true;
                }
                Subject s = new Subject(SubjectBox2.Text, p, r);
                // check if subjects exists
                if (SubjectBox2.Text.Length != 0)
                {
                    ArrayList subjects = new ArrayList((string[])SubjectList.DataSource);
                    int id = subjects.BinarySearch(SubjectBox2.Text);
                    if (id < 0)
                    {
                        id = ~id;
                        subjects.Insert(id, SubjectBox2.Text);
                        SubjectBox2.AutoCompleteCustomSource.Add(SubjectBox2.Text);
                        string[] newSubjectList = new string[subjects.Count];
                        subjects.CopyTo(newSubjectList);
                        SubjectList.DataSource = newSubjectList;
                        SubjectList.SelectedIndex = id;
                        SaveButton.Enabled = true;
                    }
                }

                // make schedule/s
                res = MessageBox.Show("You are about to insert Schedule:\n" + s.ToString() + "\n" + TimeStartBox.Text + " to " + TimeEndBox.Text + "\n" + DayBox.Text, "Insert Schedule", MessageBoxButtons.OKCancel);
                if (res == DialogResult.Cancel) return;

                ArrayList Schedules = new ArrayList();
                ArrayList ConflictList = new ArrayList();
                Boolean HasConflict = false;

                foreach (int i in DayChecklist.CheckedIndices)
                {
                    Schedule sched = new Schedule(s, new Time(i, TimeStartBox.Text), new Time(i, TimeEndBox.Text));
                    Schedule conflict = Program.db.GetConflict(sched);
                    Schedules.Add(sched);
                    ConflictList.Add(conflict);
                    if (conflict != null)
                    {
                        HasConflict = true;
                    }
                }
                if (HasConflict)
                {
                    new ShowConflictsForm(Schedules, ConflictList).ShowDialog();
                    return;
                }
                // insert new schedules! xD
                foreach (Schedule sched in Schedules)
                {
                    Program.db.InsertSchedule(sched);
                }
                TabulateSchedules();
                AllTabs.SelectedTab = AllSchedulesTab;
                // Pick le Schedule
                StringBuilder filter = new StringBuilder();
                filter.Append("Professor LIKE '").Append(p.Name()).Append("' AND ");
                filter.Append("Start LIKE '").Append(TimeStartBox.Text.Remove(2, 1)).Append("' AND End LIKE '").Append(TimeEndBox.Text.Remove(2, 1)).Append("' AND Day IN (");
                foreach (var item in DayChecklist.CheckedItems)
                {
                    filter.Append("'").Append(item.ToString()).Append("'");
                }
                filter.Append(")");
                SearchBox.Text = "";
                MainDataView.RowFilter = filter.ToString();
                ProfessorList.SelectedItem = null;
                ProfessorList.SelectedItem = p;
                RoomList.SelectedItem = r;
                SubjectList.SelectedItem = null;
                SubjectList.SelectedItem = SubjectBox2.Text;
                SaveButton.Enabled = true;
            }
            catch { }
        }

        internal int ProfessorBoxLength = 0;

        private void ProfessorBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s = ProfessorBox.Text.ToLower();
                ArrayList filter = new ArrayList();
                if (ProfessorBoxLength > s.Length)
                {
                    // backspaced
                    foreach (Professor p in Program.db.AllProfessors)
                    {
                        if (p.ToCompleteString().ToLower().Contains(s)) filter.Add(p);
                    }
                }
                else
                {
                    foreach (Professor p in (ArrayList)ProfessorList.DataSource)
                    {
                        if (p.ToCompleteString().ToLower().Contains(s)) filter.Add(p);
                    }
                }
                ProfessorList.DataSource = filter;
                ProfessorBoxLength = s.Length;
            }
            catch { }
        }

        int ClassroomBoxLength = 0;

        private void ClassroomBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s = ClassroomBox.Text.ToLower();
                ArrayList filter = new ArrayList();
                if (ClassroomBoxLength > s.Length)
                {
                    // backspaced
                    foreach (Room p in Program.db.AllRooms)
                    {
                        if (p.ToString().ToLower().Contains(s)) filter.Add(p);
                    }
                }
                else
                {
                    foreach (Room p in (ArrayList)RoomList.DataSource)
                    {
                        if (p.ToString().ToLower().Contains(s)) filter.Add(p);
                    }
                }
                RoomList.DataSource = filter;
                ClassroomBoxLength = s.Length;
            }
            catch { }
        }

        int SubjectBoxLength = 0;

        private void SubjectBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s = SubjectBox.Text.ToLower();
                ArrayList filter = new ArrayList();
                if (SubjectBoxLength > s.Length)
                {
                    // backspaced
                    foreach (string p in SubjectBox2.AutoCompleteCustomSource)
                    {
                        if (p.ToLower().Contains(s)) filter.Add(p);
                    }
                }
                else
                {
                    foreach (string p in (string[])SubjectList.DataSource)
                    {
                        if (p.ToLower().Contains(s)) filter.Add(p);
                    }
                }
                string[] n = new string[filter.Count];
                filter.CopyTo(n);
                SubjectList.DataSource = n;
                SubjectBoxLength = s.Length;
            }
            catch { }
        }


        private void ClearButton2_Click(object sender, EventArgs e)
        {
            ProfessorBox2.Text = "";
            ClassroomBox2.Text = "";
            SubjectBox2.Text = "";
            DayBox.Text = "";
        }


        private void EditOnClickCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (EditOnClickCheckbox.Checked == false) ClearButton2.PerformClick();
                else
                {
                    UpdateProfessor();
                    UpdateClassroom();
                    UpdateSubject();
                }
            }
            catch { }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SearchBox.Text == "")
                {
                    MainDataView.RowFilter = "";
                    return;
                }
                string search = SearchBox.Text.ToLower();
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn column in MainDataTable.Columns)
                {
                    sb.AppendFormat("{0} LIKE '%{1}%' OR ", column.ColumnName, search);
                }
                sb.Remove(sb.Length - 3, 3);
                MainDataView.RowFilter = sb.ToString();
            }
            catch { }
        }

        private void DeleteSubject_Click(object sender, EventArgs e)
        {
            try
            {
                var res = MessageBox.Show("Delete Subject \"" + (string)SubjectList.SelectedItem + "\"from database?\nWARNING: This will delete all Schedules that have \"" + (string)SubjectList.SelectedItem + "\" as subject title.", "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    ArrayList toDelete = new ArrayList();
                    foreach (Professor p in Program.db.AllProfessors)
                    {
                        foreach (Schedule s in p.GetSchedules.GetArrayList)
                        {
                            if (s.GetSubject.Title == (string)SubjectList.SelectedItem)
                            {
                                toDelete.Add(s);
                            }
                        }
                    }
                    foreach (Schedule s in toDelete)
                    {
                        Program.db.DeleteSchedule(s);
                    }
                    TabulateSchedules();
                    SubjectBox2.AutoCompleteCustomSource.Remove((string)SubjectList.SelectedItem);
                    string[] n = new string[SubjectBox2.AutoCompleteCustomSource.Count];
                    SubjectBox2.AutoCompleteCustomSource.CopyTo(n, 0);
                    SubjectList.DataSource = n;
                    RenewSubjectList();
                    SaveButton.Enabled = true;
                }
            }
            catch { }
        }

        private void AllSchedulesDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection rows = MainData.SelectedRows;
                ArrayList AllSchedules = Program.db.AllSchedules();
                ArrayList scheds = new ArrayList();
                foreach (DataGridViewRow row in rows)
                {
                    scheds.Add(AllSchedules[int.Parse(row.Cells["_"].Value.ToString()) - 1]);
                }
                StringBuilder message = new StringBuilder();
                foreach (Schedule s in scheds)
                {
                    message.AppendLine(s.ToString());
                }
                var res = MessageBox.Show("You are about to delete these schedules:\n\n" + message.ToString() + "\nContinue?", "Delete Schedules", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Cancel) return;
                foreach (Schedule s in scheds)
                {
                    Program.db.DeleteSchedule(s);
                }
                foreach (DataGridViewRow row in rows)
                {
                    MainDataTable.Rows[row.Index].Delete();
                }
                MainDataTable.AcceptChanges();
                SaveButton.Enabled = true;
                PaintSchedule();
            }
            catch { }
        }


        private void AllSchedulesEdit_Click(object sender, EventArgs e)
        {
        }

        private void AllSchedulesAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AllTabs.SelectedTab = InsertTab;
            }
            catch { }
        }

        private void AllSchedulesView_Click(object sender, EventArgs e)
        {
            /*
                if (MainData.SelectedRows.Count == 0) return;
                ProfessorBox.Text = "";
                ClassroomBox.Text = "";
                SubjectBox.Text = "";
                DataGridViewRow r = MainData.SelectedRows[0];
                ProfessorList.SelectedItem = Program.db.GetProfessor(r.Cells["Professor"].Value.ToString());
                RoomList.SelectedItem = Program.db.GetRoom(new Room(r.Cells["Classroom"].Value.ToString()));
            */
            try
            {
                MaximizeForm mf = new MaximizeForm();
                mf.Show();
            }
            catch { }
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog d = Methods.ExcelSaveFileDialog();
                if (d.ShowDialog() != DialogResult.OK) return;
                string[] s = d.GetDirectoryAndFileName();
                if (File.Exists(s[0] + "\\" + s[1])) File.Delete(s[0] + "\\" + s[1]);
                StreamWriter sw = new StreamWriter("ExcelDirectoryInfo.txt");
                sw.WriteLine(s[0]);
                sw.WriteLine(s[1]);
                sw.Close();
                new ScheduleDatabase().SaveToExcel();
                this.Close();
                Application.Restart();
            }
            catch
            {
                MessageBox.Show("An Error occured!");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog d = Methods.ExcelOpenFileDialog();
                if (d.ShowDialog() != DialogResult.OK) return;
                string[] s = d.GetDirectoryAndFileName();
                StreamWriter sw = new StreamWriter("ExcelDirectoryInfo.txt");
                sw.WriteLine(s[0]);
                sw.WriteLine(s[1]);
                sw.Close();
                this.Close();
                Application.Restart();
            }
            catch
            {
                MessageBox.Show("An Error occured!");
            }
        }

        private void openExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Methods.DefaultExcelFileDirectory + "\\" + Methods.DefaultExcelFileName);
                this.Close();
            }
            catch { }
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog d = Methods.ExcelOpenFileDialog();
                if (d.ShowDialog() != DialogResult.OK) return;
                string[] s = d.GetDirectoryAndFileName();
                Program.db.AssignFromDataTable(Methods.ExcelToDataTable("Sheet1", s[0], s[1]));
                this.OnLoad(new EventArgs());
                SaveButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("An Error occured!");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveButton.PerformClick();
                SaveFileDialog d = Methods.ExcelSaveFileDialog();
                if (d.ShowDialog() != DialogResult.OK) return;
                string[] s = d.GetDirectoryAndFileName();
                StreamWriter sw = new StreamWriter("ExcelDirectoryInfo.txt");
                sw.WriteLine(s[0]);
                sw.WriteLine(s[1]);
                sw.Close();
                Methods.DefaultExcelFileDirectory = s[0];
                Methods.DefaultExcelFileName = s[1];
                Program.db.SaveToExcel();
            }
            catch
            {
                MessageBox.Show("Unknown Error occured");
            }
        }

        private void saveCopyAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveButton.PerformClick();
                SaveFileDialog d = Methods.ExcelSaveFileDialog();
                if (d.ShowDialog() != DialogResult.OK) return;
                string[] s = d.GetDirectoryAndFileName();
                Program.db.SaveToExcel(s[0], s[1]);
            }
            catch
            {
                MessageBox.Show("Unknown Error occured");
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Methods.DefaultExcelFileDirectory);
            }
            catch
            {
                MessageBox.Show("Error: folder does not exist!");
            }
        }

        private void insertNewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AllTabs.SelectedTab = InsertTab;
            }
            catch { }
        }

        private void addNewProfessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProfessor.PerformClick();
        }

        private void editProfessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProfessor.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProfessor.PerformClick();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRoom.PerformClick();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditRoom.PerformClick();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteRoom.PerformClick();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSubject.PerformClick();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditSubject.PerformClick();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteSubject.PerformClick();
        }

        private void MakeRows()
        {
            try
            {
                if (OffBox.Text.Length != 5 || SchedStart.Text.Length != 5 || SchedEnd.Text.Length != 5) return;
                int offset = (new Time(0, OffBox.Text)).raw();
                if (offset == 0) return;
                Weekly.Rows.Clear();
                int start = (new Time(0, SchedStart.Text)).raw();
                int end = (new Time(0, SchedEnd.Text)).raw();
                string[] row = new string[1];
                while (start <= end)
                {
                    row[0] = (new Time(start)).ToTimeString();
                    Weekly.Rows.Add(row);
                    start += offset;
                }
                ClearPaintSchedule();
            }
            catch { }
        }


        

        void ChangeTime(NumericUpDown x, MaskedTextBox y)
        {
            try
            {
                if (x.Value == 0) return;
                Time t = new Time(0, y.Text);
                t.rawMinutes = Math.Min(Classes.Time.HOUR_MASK, Math.Max(0, t.raw() + (int)x.Value));
                y.Text = t.ToMilitaryTimeString();
                x.Value = 0;
            }
            catch { }
        }

        private void OffNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(OffNum, OffBox);
        }

        private void SchedEndNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(SchedEndNum, SchedEnd);
        }

        private void SchedStartNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(SchedStartNum, SchedStart);
        }

        private void OffBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    OffNum.Value += OffNum.Increment;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    OffNum.Value -= OffNum.Increment;
                }
            }
            catch { }
        }

        private void SchedEnd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    SchedEndNum.Value += SchedEndNum.Increment;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    SchedEndNum.Value -= SchedEndNum.Increment;
                }
            }
            catch { }
        }

        private void SchedStart_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    SchedStartNum.Value += SchedStartNum.Increment;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    SchedStartNum.Value -= SchedStartNum.Increment;
                }
            }
            catch { }
        }

        private void ClearPaintSchedule()
        {
            try
            {
                CurrentlyPainted = null;
                foreach (DataGridViewRow row in Weekly.Rows)
                {
                    for (int i = 1; i < Weekly.ColumnCount; ++i)
                    {
                        row.Cells[i].Style = DefaultColor;
                        row.Cells[i].Value = null;
                    }
                }
            }
            catch { }
        }

        static DataGridViewCellStyle DefaultColor = new DataGridViewCellStyle { BackColor = Color.LightGray, SelectionBackColor = Color.SlateGray };
        static DataGridViewCellStyle FullProf = new DataGridViewCellStyle { BackColor = Color.PaleGreen, SelectionBackColor = Color.MediumVioletRed, ForeColor = Color.Black };
        static DataGridViewCellStyle Shadowed = new DataGridViewCellStyle { BackColor = Color.White, SelectionBackColor = Color.PaleVioletRed };

        private void PaintSchedule()
        {
            try
            {
                //Weekly.Visible = false;

                Professor CurrentProfessor = (Professor)ProfessorList.SelectedItem;
                if (CurrentProfessor == null)
                {
                    ClearPaintSchedule();
                    return;
                }
                //MessageBox.Show(CurrentlyPainted == null ? "NULL" : CurrentlyPainted.ToString());
                if (CurrentlyPainted == CurrentProfessor) return;
                ClearPaintSchedule();
                CurrentlyPainted = CurrentProfessor;
                if (CurrentProfessor != null)
                {
                    int DefaultStart = (new Time(0, SchedStart.Text)).raw();
                    int DefaultEnd = (new Time(0, SchedEnd.Text)).raw();
                    int Offset = (new Time(0, OffBox.Text)).raw();
                    int day, start, end, lb = 0, ub = 0;
                    var rows = Weekly.Rows;
                    foreach (Schedule s in CurrentProfessor.GetSchedules.GetArrayList)
                    {
                        day = s.StartTime.days() + 1;
                        start = s.StartTime.raw() % Classes.Time.HOUR_MASK;
                        end = s.EndTime.raw() % Classes.Time.HOUR_MASK;
                        // get bounds
                        if ((end <= DefaultStart) || (start > DefaultEnd)) continue;

                        start = Math.Max(start, DefaultStart);
                        end = Math.Min(end, DefaultEnd + 1);
                        lb = (start - DefaultStart) / Offset;
                        ub = (end - DefaultStart) / Offset + ((end - DefaultStart) % Offset == 0 ? 0 : 1);

                        string title = s.GetSubject.Title;

                        DataGridViewCellStyle half = FullProf;
                        DataGridViewCellStyle full = FullProf;
                        if (SubjectList.SelectedItem == null || title != SubjectList.SelectedItem.ToString())
                        {
                            half = full = Shadowed;
                        }

                        if (DefaultStart + lb * Offset != start)
                        {
                            rows[lb].Cells[day].Style = half;
                        }
                        else
                        {
                            rows[lb].Cells[day].Style = full;
                        }
                        rows[lb].Cells[day].Value = title;

                        while (++lb < ub)
                        {
                            rows[lb].Cells[day].Style = full;
                            rows[lb].Cells[day].Value = title;
                        }
                        if (DefaultStart + ub * Offset != end)
                        {
                            rows[ub - 1].Cells[day].Style = half;
                        }
                    }
                }
                /*
                if (ShowClassroom.Checked)
                {
                    Room CurrentRoom = (Room)RoomList.SelectedItem;
                    if (CurrentRoom != null)
                    {
                        int DefaultStart = (new Time(0, SchedStart.Text)).raw();
                        int DefaultEnd = (new Time(0, SchedEnd.Text)).raw();
                        int Offset = (new Time(0, OffBox.Text)).raw();
                        int day, start, end, lb = 0, ub = 0;
                        var rows = Weekly.Rows;
                        foreach (Schedule s in CurrentRoom.GetSchedules.GetArrayList)
                        {
                            day = s.StartTime.days() + 1;
                            start = s.StartTime.raw() % Classes.Time.HOUR_MASK;
                            end = s.EndTime.raw() % Classes.Time.HOUR_MASK;
                            // get bounds
                            if ((end <= DefaultStart) || (start > DefaultEnd)) continue;

                            start = Math.Max(start, DefaultStart);
                            end = Math.Min(end, DefaultEnd + 1);
                            lb = (start - DefaultStart) / Offset;
                            ub = (end - DefaultStart) / Offset + ((end - DefaultStart) % Offset == 0 ? 0 : 1);
                            if (DefaultStart + lb * Offset != start)
                            {
                                var cell = rows[lb].Cells[day];
                                if (cell.Style != DefaultColor)
                                {
                                    cell.Style = HalfMix;
                                }
                                else
                                {
                                    cell.Style = HalfRoom;
                                }
                            }
                            else
                            {
                                var cell = rows[lb].Cells[day];
                                if (cell.Style == FullProf)
                                {
                                    cell.Style = FullMix;
                                }
                                else if (cell.Style == HalfProf)
                                {
                                    cell.Style = HalfMix;
                                }
                                else
                                {
                                    cell.Style = FullRoom;
                                }
                            }
                            rows[lb].Cells[day].Value = s.GetSubject.Title;

                            while (++lb < ub)
                            {
                                var cell = rows[lb].Cells[day];
                                if (cell.Style == FullProf)
                                {
                                    cell.Style = FullMix;
                                }
                                else if (cell.Style == HalfProf)
                                {
                                    cell.Style = HalfMix;
                                }
                                else
                                {
                                    cell.Style = FullRoom;
                                }
                                cell.Value = s.GetSubject.Title;
                            }
                            if (DefaultStart + ub * Offset != end)
                            {
                                var cell = rows[ub - 1].Cells[day];
                                if (cell.Style != FullRoom)
                                {
                                    cell.Style = HalfMix;
                                }
                                else
                                {
                                    cell.Style = HalfRoom;
                                }
                            }
                        }
                    }
                }
                */
                //Weekly.Visible = true;
            }
            catch { }
        }


        private void EnableChange(object sender, EventArgs e)
        {
            ChangeOffset.Enabled = true;
        }

        private void ChangeOffset_Click(object sender, EventArgs e)
        {
            try
            {
                if (SchedStart.Text.Length != 5 || SchedEnd.Text.Length != 5 || OffBox.Text.Length != 5)
                {
                    MessageBox.Show("Invalid input");
                    ChangeOffset.Enabled = false;
                    return;
                }
                MakeRows();
                PaintSchedule();
                ChangeOffset.Enabled = false;
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new AboutBox().ShowDialog();
            }
            catch { }
        }

        private void InsertAccept(object sender, EventArgs e)
        {
            try
            {
                AcceptButton = InsertButton;
            }
            catch { }
        }

        private void NullAccept(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void MainData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = MainData.SelectedCells[0].OwningRow;
                //MessageBox.Show("NA");
                string prof = r.Cells["Professor"].Value.ToString();
                string room = r.Cells["Classroom"].Value.ToString();
                string subj = r.Cells["Subject"].Value.ToString();
                ProfessorList.SelectedItem = Program.db.GetProfessor(prof);
                RoomList.SelectedItem = Program.db.GetRoom(room);
                SubjectList.SelectedItem = subj;

            }
            catch { }
        }

        private void Weekly_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                object val = Weekly.SelectedCells[0].Value;
                if (val == null) return;
                string str = val.ToString();
                SubjectList.SelectedItem = str;
            }
            catch { }
        }

    }
}
