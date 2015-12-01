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
    public partial class EditSubjectForm : Form
    {

        protected AllDataViewer Host = Program.adv;
        private object CurrentSubject = null;

        public EditSubjectForm()
        {
            InitializeComponent();
            CurrentSubject = Host.SubjectList.SelectedItem;
        }

        protected void EditSubjectForm_Load(object sender, EventArgs e)
        {
            SubjectBox.Text = (string)Host.SubjectList.SelectedItem;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ((string)CurrentSubject == SubjectBox.Text)
            {
                this.Close();
                return;
            }
            //string[] list = (string[])Host.SubjectList.DataSource;
            ArrayList list = new ArrayList((string[])Host.SubjectList.DataSource);
            int id = list.BinarySearch(CurrentSubject);
            list.RemoveAt(id);
            id = list.BinarySearch(SubjectBox.Text);
            if (id >= 0)
            {
                MessageBox.Show("Subject with that name already exists!");
                return;
            }
            id = ~id;
            list.Insert(id, SubjectBox.Text);
            string[] n = new string[list.Count];
            list.CopyTo(n);
            Host.SubjectList.DataSource = n;
            //change all subjects with that name
            foreach (DataRow row in Host.MainDataTable.Rows)
            {
                if (row["Subject"].ToString() == (string)CurrentSubject)
                {
                    row["Subject"] = SubjectBox.Text;
                }
            }
            Host.SubjectBox2.AutoCompleteCustomSource.Remove((string)CurrentSubject);
            Host.SubjectBox2.AutoCompleteCustomSource.Add(SubjectBox.Text);
            Host.RenewSubjectList();
            Host.SubjectList.SelectedItem = SubjectBox.Text;
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            SubjectBox.Text = (string)CurrentSubject;
        }
    }
}
