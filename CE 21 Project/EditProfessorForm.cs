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

        AllDataViewer Host = Program.adv;
        Professor CurrentProfessor = null;

        public EditProfessorForm()
        {
            InitializeComponent();
        }

        private void UpdateButtons()
        {
            ClearButton.Enabled = (
                FirstNameBox.Text != "" ||
                LastNameBox.Text != "" ||
                DepartmentBox.Text != "" ||
                IDBox.Text != "" ||
                ContactBox.Text != ""
            );
        }

        private void UpdateButtons(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void EditProfessorForm_Load(object sender, EventArgs e)
        {
            CurrentProfessor = (Professor)Host.ProfessorList.SelectedItem;
            if (CurrentProfessor == null)
            {
                MessageBox.Show("Cannot edit empty professor");
                this.Close();
                return;
            }
            LastNameBox.Text = CurrentProfessor.LastName;
            FirstNameBox.Text = CurrentProfessor.FirstName;
            DepartmentBox.Text = CurrentProfessor.Department;
            IDBox.Text = CurrentProfessor.ID;
            ContactBox.Text = CurrentProfessor.Contact;
            UpdateButtons();
            //Host.ProfessorBox.Text = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            Professor p = new Professor(LastNameBox.Text, FirstNameBox.Text, DepartmentBox.Text, IDBox.Text, ContactBox.Text);
            if (CurrentProfessor == null)
            {
                res = MessageBox.Show("Unknown Error: Professor is missing from database!\n Would you like to add professor to database?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    p = Program.db.AddProfessor(p);
                    Host.ProfessorBox.Text = "";
                    this.Close();
                }
                return;
            }
            string name = CurrentProfessor.Name();
            string newname = p.Name();
            foreach (DataRow r in Host.MainDataTable.Rows)
            {
                if (r["Professor"].ToString() == name)
                {
                    r["Professor"] = newname;
                    r["ID"] = p.ID;
                }
            }
            Host.ProfessorBox2.AutoCompleteCustomSource.Remove(name);
            Host.ProfessorBox2.AutoCompleteCustomSource.Add(newname);
            CurrentProfessor.LastName = p.LastName;
            CurrentProfessor.FirstName = p.FirstName;
            CurrentProfessor.Department = p.Department;
            CurrentProfessor.ID = p.ID;
            CurrentProfessor.Contact = p.Contact;
            Host.RenewProfessorList();
            Host.ProfessorList.SelectedItem = CurrentProfessor;
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (CurrentProfessor == null)
            {
                MessageBox.Show("Unknown Error: Professor is missing from the database.");
                return;
            }
            DepartmentBox.Text = CurrentProfessor.Department;
            IDBox.Text = CurrentProfessor.ID;
            ContactBox.Text = CurrentProfessor.Contact;
        }

        
    }
}
