using System;
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
    public partial class EditProfessorForm : Form
    {

        internal Viewer Host;

        public EditProfessorForm()
        {
            InitializeComponent();
        }

        private void UpdateButtons()
        {
            AddButton.Enabled = (
                FirstNameBox.Text != "" &&
                LastNameBox.Text != "" &&
                DepartmentBox.Text != "" &&
                IDBox.Text != ""
            );
            ClearButton.Enabled = (
                FirstNameBox.Text != "" ||
                LastNameBox.Text != "" ||
                DepartmentBox.Text != "" ||
                IDBox.Text != ""
            );
        }

        private void UpdateButtons(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void EditProfessorForm_Load(object sender, EventArgs e)
        {
            Professor p = (Professor)Host.ProfessorList.SelectedItem;
            LastNameBox.Text = p.LastName;
            FirstNameBox.Text = p.FirstName;
            DepartmentBox.Text = p.Department;
            IDBox.Text = p.ID.ToString();
            UpdateButtons();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            Professor p = null;
            try
            {
                string id = IDBox.Text.TrimStart('0');
                if (id == "") id = "0";
                p = new Professor(LastNameBox.Text, FirstNameBox.Text, DepartmentBox.Text, int.Parse(id));
            }
            catch
            {
                MessageBox.Show("Invalid contact number. Please only enter values from 0-9.");
                return;
            }
            Professor old = Host.sb.GetProfessor(p);
            if (old == null)
            {
                res = MessageBox.Show("Unknown Error: Professor is missing from database!\n Would you like to add professor to database?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    p = Host.sb.AddProfessor(p);
                    MessageBox.Show("Professor successfully added!");
                    Host.ProfessorList.DataSource = Host.sb.AllProfessors.Clone();
                    this.Close();
                }
                return;
            }
            old.Department = p.Department;
            old.ID = p.ID;
            MessageBox.Show("Information successfully saved.");
            Host.ProfessorList.DataSource = Host.sb.AllProfessors.Clone();
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Professor old = Host.sb.GetProfessor(LastNameBox.Text, FirstNameBox.Text);
            if (old == null)
            {
                MessageBox.Show("Unknown Error: Professor is missing from the database.");
                return;
            }
            DepartmentBox.Text = old.Department;
            IDBox.Text = old.ID.ToString();
        }

        
    }
}
