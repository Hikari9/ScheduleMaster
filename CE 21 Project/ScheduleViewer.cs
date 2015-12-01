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
    
    public partial class ScheduleViewer : Form
    {

        internal ScheduleDatabase sb
        {
            get { return Program.sb; }
            set { Program.sb = value; }
        }
        Professor CurrentProfessor = null;
        TextBox[] TextBoxes;
        Button[] EditButtons;
        string StartBoxDefault;
        string EndBoxDefault;
        string OffBoxDefault;
        static DataGridViewCellStyle DefaultColor = new DataGridViewCellStyle { BackColor = Color.LightGray, SelectionBackColor = Color.SlateGray };
        static DataGridViewCellStyle FullColor = new DataGridViewCellStyle { BackColor = Color.Aqua, SelectionBackColor = Color.MediumVioletRed };
        static DataGridViewCellStyle HalfColor = new DataGridViewCellStyle { BackColor = Color.Turquoise, SelectionBackColor = Color.PaleVioletRed };
        
        public ScheduleViewer()
        {
            InitializeComponent();
        }

        private void ScheduleViewer_Load(object sender, EventArgs e)
        {
            // sb.AssignFromDataTable(Methods.ExcelToDataTable());
            TextBoxes = new TextBox[]{ LastNameBox, FirstNameBox, DepartmentBox, IDBox };
            EditButtons = new Button[]{ Edit2, Edit1, Edit4, Edit3 };
            MakeProfessorTabs();
            MakeRows();
            SelectProfessor();
            UpdateDepartmentList();
            StartBoxDefault = StartBox.Text;
            EndBoxDefault = EndBox.Text;
            OffBoxDefault = OffBox.Text;
        }

        private void ScheduleViewer_Resize(object sender, EventArgs e)
        {
            Weekly.Height = this.Height - 293;

        }

        void UpdateDepartmentList()
        {
            SortedSet<string> deps = new SortedSet<string>();
            foreach (Professor p in sb.AllProfessors)
            {
                deps.Add(p.Department);
            }
            string[] data = new string[deps.Count];
            deps.CopyTo(data);
            DepartmentBox.AutoCompleteCustomSource.Clear();
            DepartmentBox.AutoCompleteCustomSource.AddRange(data);
        }

        void MakeRows(object sender = null, EventArgs e = null)
        {
            if (OffBox.Text.Length != 5 || StartBox.Text.Length != 5 || EndBox.Text.Length != 5) return;
            int offset = (new Time(0, OffBox.Text)).raw();
            if (offset == 0) return;
            Weekly.Rows.Clear();
            int start = (new Time(0, StartBox.Text)).raw();
            int end = (new Time(0, EndBox.Text)).raw();
            string[] row = new string[1];
            while (start <= end)
            {
                row[0] = (new Time(start)).ToTimeString();
                Weekly.Rows.Add(row);
                start += offset;
            }
            PaintSchedule();
        }

        void PaintSchedule()
        {
            foreach (DataGridViewRow row in Weekly.Rows)
            {
                for (int i = 1; i < Weekly.ColumnCount; ++i)
                {
                    row.Cells[i].Style = DefaultColor;
                    row.Cells[i].Value = null;
                }
            }
            if (CurrentProfessor != null)
            {
                int DefaultStart = (new Time(0, StartBox.Text)).raw();
                int DefaultEnd = (new Time(0, EndBox.Text)).raw();
                int Offset = (new Time(0, OffBox.Text)).raw();
                int day, start, end, lb=0, ub=0;
                var rows = Weekly.Rows;
                foreach (Schedule s in CurrentProfessor.GetSchedules.GetArrayList)
                {
                    day = s.StartTime.days() + 1;
                    start = s.StartTime.raw() % Classes.Time.HOUR_MASK;
                    end = s.EndTime.raw() % Classes.Time.HOUR_MASK;
                    // get bounds
                    if( (end <= DefaultStart) || (start > DefaultEnd) ) continue;
                    
                    start = Math.Max(start, DefaultStart);
                    end = Math.Min(end, DefaultEnd+1);
                    lb = (start - DefaultStart) / Offset;
                    ub = (end - DefaultStart) / Offset + ((end - DefaultStart) % Offset == 0 ? 0 : 1);
                    if (DefaultStart + lb * Offset != start)
                    {
                        rows[lb].Cells[day].Style = HalfColor;
                    } 
                    else
                    {
                        rows[lb].Cells[day].Style = FullColor;
                    }
                    rows[lb].Cells[day].Value = s.GetSubject.Title;
                    
                    while (++lb < ub)
                    {
                        rows[lb].Cells[day].Style = FullColor;
                        rows[lb].Cells[day].Value = s.GetSubject.Title;
                    }
                    if (DefaultStart + ub * Offset != end)
                    {
                        rows[ub - 1].Cells[day].Style = HalfColor;
                    }
                    
                    
                }
                Weekly.Refresh();
            }
        }

        internal void SelectProfessor(object sender = null, EventArgs e = null)
        {
            if (sender != null)
            {
                professorScheduleViewerToolStripMenuItem.Checked = Program.sv.Visible;
                inserterDeleterToolStripMenuItem.Checked = Program.v.Visible;
            }
            var tab = TabControl.SelectedTab;
            if (tab == null) return;
            if (tab.Text == "Add...")
            {
                CurrentProfessor = null;
                ProfessorName.Text = "Add New Professor...";
                for (int i = 0; i < TextBoxes.Length; ++i)
                {
                    TextBoxes[i].Text = "";
                    EditButtons[i].Enabled = false;
                }
                DeleteProfessor.Visible = false;
                ResetButton.Enabled = false;
                SaveButton.Text = "Save";
                PaintSchedule();
                this.AcceptButton = SaveButton;
                return;
            }
            this.AcceptButton = ResetButton;
            ProfessorName.Text = tab.Text;
            CurrentProfessor = sb.GetProfessor(tab.Text);
            if (CurrentProfessor == null) return;
            string[] DefaultInfo = CurrentProfessor.Information();
            for (int i = 0; i < DefaultInfo.Length; ++i)
            {
                TextBoxes[i].Text = DefaultInfo[i];
            }
            DeleteProfessor.Visible = ResetButton.Visible = true;
            SaveButton.Text = "Insert a Schedule";
            PaintSchedule();
            CheckEdits();
        }

        private void TabControl_Selected(object sender, EventArgs e)
        {
            SelectProfessor();
        }

        public void MakeProfessorTabs()
        {
            TabControl.TabPages.Clear();
            foreach (Professor p in sb.AllProfessors)
            {
                TabControl.TabPages.Add(p.Name(),p.Name());
            }
            TabControl.TabPages.Add("Add...");
        }


        public void CheckEdits()
        {
            if (CurrentProfessor == null) return;
            ResetButton.Enabled = false;
            string[] DefaultInfo = CurrentProfessor.Information();
            for (int i = 0; i < DefaultInfo.Length; ++i)
            {
                EditButtons[i].Enabled = (TextBoxes[i].Text != DefaultInfo[i]);
                ResetButton.Enabled |= EditButtons[i].Enabled;
            }
        }

        private void FirstNameBox_TextChanged(object sender, EventArgs e)
        {
            CheckEdits();
        }

        private void LastNameBox_TextChanged(object sender, EventArgs e)
        {
            CheckEdits();
        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {
            CheckEdits();
        }

        private void DepartmentBox_TextChanged(object sender, EventArgs e)
        {
            CheckEdits();
        }

        private void Edit1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Change the name of the Professor?", "Confirmation", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string tempkey = CurrentProfessor.FirstName = FirstNameBox.Text.NormalizeWhiteSpaces();
                ProfessorName.Text = TabControl.SelectedTab.Text = CurrentProfessor.Name();
                sb.AllProfessors.Sort(new Professor.CompareByName());
                // MakeProfessorTabs();
                CheckEdits();
            }
            
        }

        private void Edit2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Change the name of the Professor?", "Confirmation", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string tempkey = CurrentProfessor.LastName = LastNameBox.Text.NormalizeWhiteSpaces();
                ProfessorName.Text = TabControl.SelectedTab.Text = CurrentProfessor.Name();
                sb.AllProfessors.Sort(new Professor.CompareByName());
                // MakeProfessorTabs();
                CheckEdits();
            }
        }

        private void Edit3_Click(object sender, EventArgs e)
        {
            try {
                string s = IDBox.Text.TrimStart('0');
                if (s == "") s = "0";
                CurrentProfessor.ID = int.Parse(s);
            }
            catch
            {
                MessageBox.Show("Error: Invalid ID Number. Please enter (up to ten) digits from 0-9 only.");
                return;
            }
            CheckEdits();
        }

        private void Edit4_Click(object sender, EventArgs e)
        {
            CurrentProfessor.Department = DepartmentBox.Text.NormalizeWhiteSpaces();
            CheckEdits();
            UpdateDepartmentList();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string[] DefaultInfo = CurrentProfessor.Information();
            for (int i = 0; i < DefaultInfo.Length; ++i)
            {
                TextBoxes[i].Text = DefaultInfo[i];
            }
            CheckEdits();
        }

        void ChangeTime(NumericUpDown x, MaskedTextBox y)
        {
            if (x.Value == 0) return;
            Time t = new Time(0, y.Text);
            t.rawMinutes = Math.Min(Classes.Time.HOUR_MASK, Math.Max(0, t.raw() + 15 * (int)x.Value));
            y.Text = t.ToMilitaryTimeString();
            x.Value = 0;
        }

        private void OffNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(OffNum, OffBox);
        }

        private void EndNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(EndNum, EndBox);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ChangeTime(StartNum, StartBox);
        }

        private void OffBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ++OffNum.Value;
            }
            else if (e.KeyCode == Keys.Down)
            {
                --OffNum.Value;
            }
        }

        private void EndBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ++EndNum.Value;
            }
            else if (e.KeyCode == Keys.Down)
            {
                --EndNum.Value;
            }
        }

        private void StartBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ++StartNum.Value;
            }
            else if (e.KeyCode == Keys.Down)
            {
                --StartNum.Value;
            }
        }

        private void OffBox_TextChanged(object sender, EventArgs e)
        {
            MakeRows();
        }

        private void StartBox_TextChanged(object sender, EventArgs e)
        {
            MakeRows();
        }

        private void StartBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput) StartBox.Text = StartBoxDefault;
        }

        private void EndBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput) EndBox.Text = EndBoxDefault;
        }

        private void OffBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput) OffBox.Text = OffBoxDefault;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sb.SaveToExcel();
            saveToolStripMenuItem.Enabled = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = false;
        }

        private void TabControl_DoubleClick(object sender, EventArgs e)
        {
            TabControl.SelectedIndex = TabControl.TabCount - 1;
        }

        private void DeleteProfessor_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete " + CurrentProfessor.Name() + "?", "Delete Professor", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                res = MessageBox.Show("WARNING: This will erase all Schedules associated with the Professor. Do you want to continue?", "Delete Professor", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    sb.DeleteProfessor(CurrentProfessor);
                    MakeProfessorTabs();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveButton.Text == "Save")
            {
                foreach (TextBox x in TextBoxes)
                {
                    if (x.Text.Trim() == "")
                    {
                        MessageBox.Show("Error: Data cannot be empty");
                        return;
                    }
                }
                try
                {
                    string s = IDBox.Text.TrimStart('0');
                    if (s == "") s = "0";
                    CurrentProfessor = new Professor(LastNameBox.Text, FirstNameBox.Text, DepartmentBox.Text, int.Parse(s));
                }
                catch
                {
                    MessageBox.Show("Error: Invalid ID Number. Please enter (up to ten) digits from 0-9 only.");
                    return;
                }
                if (sb.GetProfessor(CurrentProfessor) != null)
                {
                    MessageBox.Show("Professor name already exists!");
                    return;
                }
                sb.AddProfessor(CurrentProfessor);
                TabControl.SelectedTab.Text = CurrentProfessor.Name();
                SelectProfessor();
                TabControl.TabPages.Add("Add...");
            }
            else
            {
                inserterDeleterToolStripMenuItem.PerformClick();
            }

        }

        private void textBox1_Changed(object sender, EventArgs e)
        {
        }

        string DefaultSearchBoxText = "Search...";

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (SearchBox.Text == DefaultSearchBoxText)
            {
                SearchBox.Text = "";
            }
        }

        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = DefaultSearchBoxText;
            }
        }

        private void SearchBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back) return;
            int i = 0, I = TabControl.TabCount - 1;
            string low = SearchBox.Text.ToUpper();
            if (e.KeyData == Keys.Enter)
            {
                i = TabControl.SelectedIndex + 1;
            }
            else low += e.KeyCode;
            while( i < I )
            {
                if (TabControl.TabPages[i].Text.ToUpper().IndexOf(low) >= 0)
                {
                    break;
                }
                ++i;
            }
            TabControl.SelectedIndex = i;
            SelectProfessor();
            SearchBox.Select();
            // e.SuppressKeyPress = true;
        }

        private void FirstNameBox_Enter(object sender, EventArgs e)
        {
            if (SaveButton.Text != "Save") this.AcceptButton = Edit1;
        }

        private void LastNameBox_Enter(object sender, EventArgs e)
        {
            if (SaveButton.Text != "Save") this.AcceptButton = Edit2;
        }

        private void IDBox_Enter(object sender, EventArgs e)
        {
            if (SaveButton.Text != "Save") this.AcceptButton = Edit3;
        }

        private void DepartmentBox_Enter(object sender, EventArgs e)
        {
            if (SaveButton.Text != "Save") this.AcceptButton = Edit4;
        }

        private void TabControl_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Text == "Add...")
            {
                FirstNameBox.Select();
            }
        }

        private void ScheduleViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.v.Visible)
            {
                saveToolStripMenuItem.PerformClick();
                Application.ExitThread();
            }
            Program.v.professorScheduleViewerToolStripMenuItem.Checked = false;
            this.Visible = false;
            e.Cancel = true;
        }

        private void professorScheduleViewerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (!((ToolStripMenuItem)sender).Checked)
            {
                ((ToolStripMenuItem)sender).Checked = true;
            }
        }

        private void inserterDeleterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked ^= true;
            Program.v.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void ToggleMenuItem(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked ^= true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
            Application.ExitThread();
        }



    }
}
