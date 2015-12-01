using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE_21_Project
{
    public partial class Inserter : Form
    {

        Classes.ScheduleDatabase data = new Classes.ScheduleDatabase();
        string ExcelFilePath = @"C:\Users\Rico\Documents\Visual Studio 2012\Projects\CE 21 Project\CE 21 Project\data\data.xls";

        public Inserter()
        {
            //data.LoadExcelFile(ExcelFilePath);
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            log.Text = "START OF TEST\n\n";

            Classes.Professor x = new Classes.Professor(last.Text, first.Text, department.Text);
            x = data.AddProfessor(x);
            Classes.Room y = new Classes.Room(classroom.Text);

            Classes.Time start = new Classes.Time(day.Text, from.Text);
            Classes.Time end = new Classes.Time(day.Text, to.Text);

            Classes.Subject sub = new Classes.Subject(subj.Text, x, y);

            MessageBox.Show(sub.professor.ToString());

            //MessageBox.Show(sub.Title);
            //MessageBox.Show(sub.GetProfessor.ToString());
            //MessageBox.Show(sub.GetRoom.ToString());

            Classes.Schedule s = new Classes.Schedule(sub, start, end);

            //MessageBox.Show(s.ToString());
            log.AppendText("Schedule to be inserted:\n\n" + s.ToString() + "\n");
            Classes.Schedule s2 = data.GetConflict(s);
            // MessageBox.Show(s2 == null ? "null" : s2.ToString());
            
            if (!data.InsertSchedule(s))
            {
                MessageBox.Show("Conflicting Schedule:\n\n" + data.GetConflict(s).ToString() + "\n");
                log.AppendText("Data conflict with:\n" + data.GetConflict(s).ToString() + "\n");
            }
            else
            {
                log.AppendText("Data successfully inserted!\n\n");
            }
             

            log.AppendText("END OF TEST\n\n");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // data.SaveExcelFile(ExcelFilePath);
        }
    }
}
