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
    public partial class ShowConflictsForm : Form
    {
        ArrayList Schedules, Conflicts;
        public ShowConflictsForm(ArrayList Schedules, ArrayList Conflicts)
        {
            InitializeComponent();
            this.Schedules = Schedules;
            this.Conflicts = Conflicts;
        }

        private void ShowConflictsForm_Load(object sender, EventArgs e)
        {
            string[][] data = new string[Schedules.Count][];
            int i = 0;
            foreach (Schedule s in Schedules)
            {
                data[i++] = s.ToSmallArray();
            }
            DataGrid1.DataSource = data.ToDataTable(Schedule.GetSmallHeaderArray());
            i = 0;
            foreach (Schedule s in Conflicts)
            {
                if (s == null)
                {
                    data[i] = new string[DataGrid2.Columns.Count];
                    for (int j = 0; j < data[i].Length; ++j) data[i][j] = "";
                    ++i;
                }
                else data[i++] = s.ToSmallArray();
            }
            DataGrid2.DataSource = data.ToDataTable(Schedule.GetSmallHeaderArray());
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
