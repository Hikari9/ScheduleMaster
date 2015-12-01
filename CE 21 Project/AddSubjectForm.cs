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

namespace ScheduleMaster
{
    public partial class AddSubjectForm : Form
    {

        AllDataViewer Host = Program.adv;

        public AddSubjectForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SubjectBox.Text.Length == 0)
            {
                MessageBox.Show("Cannot proceed with empty name");
                return;
            }
            ArrayList list = new ArrayList((string[])Host.SubjectList.DataSource);
            list.Sort();
            int id = list.BinarySearch(SubjectBox.Text);
            if (id >= 0)
            {
                MessageBox.Show("Subject with that name already exists!");
                return;
            }
            id = ~id;
            list.Insert(id, SubjectBox.Text);
            string[] n = new string[list.Count];
            list.CopyTo(n);
            Host.SubjectBox2.AutoCompleteCustomSource.Add(SubjectBox.Text);
            Host.SubjectList.DataSource = n;
            Host.RenewSubjectList();
            Host.SubjectList.SelectedItem = SubjectBox.Text;
            this.Close();
        }

        private void AddSubjectForm_Load(object sender, EventArgs e)
        {
            // make subject!
            //Host.SubjectBox2.AutoCompleteCustomSource = 
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Host.SubjectBox.Text = "";
        }

    }
}
