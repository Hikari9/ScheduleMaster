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
    public partial class AddProfessorForm : Form
    {

        AllDataViewer Host = Program.adv;

        public AddProfessorForm()
        {
            InitializeComponent();
        }

        private void AddProfessorForm_Load(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            DepartmentBox.Text = "";
            IDBox.Text = "";
            UpdateButtons();
        }

        protected internal void UpdateButtons()
        {
            AddButton.Enabled = (
                FirstNameBox.Text != "" &&
                LastNameBox.Text != ""
            );
            ClearButton.Enabled = (
                FirstNameBox.Text != "" ||
                LastNameBox.Text != "" ||
                DepartmentBox.Text != "" ||
                IDBox.Text != "" ||
                ContactBox.Text != ""
            );
        }

        protected internal void UpdateButtons(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Professor p = new Professor(LastNameBox.Text, FirstNameBox.Text, DepartmentBox.Text, IDBox.Text, ContactBox.Text);
            Professor check = Program.db.GetProfessor(p);
            if (check == null)
            {
                p = Program.db.AddProfessor(p);
                Host.ProfessorList.DataSource = Program.db.AllProfessors.Clone();
                Host.ProfessorBox2.AutoCompleteCustomSource.Add(p.Name());
                Host.ProfessorList.SelectedItem = p;
                Host.RenewProfessorList();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Professor with that name already exists.");
            }
            
        }

        
    }
}
