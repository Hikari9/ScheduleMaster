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

        internal Viewer Host;

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

        protected internal void UpdateButtons(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Add Professor to the Database?", "", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
                return;
            // try to add professor to database
            Professor p;
            try
            {
                string id = IDBox.Text.TrimStart('0');
                if (id == "") id = "0";
                p = new Professor(LastNameBox.Text, FirstNameBox.Text, DepartmentBox.Text, int.Parse(id));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Invalid contact number. Please only enter values from 0-9.");
                return;
            }
            Professor check = Host.sb.GetProfessor(p);
            if (check == null)
            {
                p = Host.sb.AddProfessor(p);
                MessageBox.Show("Professor successfully added!");
                Host.ProfessorList.DataSource = Host.sb.AllProfessors.Clone();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Professor with that name already exists.");
            }
            
        }

        
    }
}
