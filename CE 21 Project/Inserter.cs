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

        ScheduleDatabase data = new ScheduleDatabase();

        public Inserter()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            log.Text = "START OF TEST\n\n";

            Professor x = data.AddProfessor(last.Text, first.Text, department.Text);
            Room y = data.AddRoom(classroom.Text);

            Time start = new Time(day.Text, from.Text);
            Time end = new Time(day.Text, to.Text);

            Schedule s = new Schedule(x, y, start, end);

            log.AppendText("Schedule to be inserted:\n\n" + s.ToString() + "\n");

            Schedule s2 = data.GetConflict(s);
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
    }
}
