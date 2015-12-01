using System;
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
    public partial class MaximizeForm : Form
    {
        internal DataTable MainDataTable = Program.adv.MainDataTable;
        internal DataView MainDataView = Program.adv.MainDataView;
        public MaximizeForm()
        {
            InitializeComponent();
            SearchBox.Text = Program.adv.SearchBox.Text;
            MainData.DataSource = Program.adv.MainData.DataSource;
            try
            {
                MainData.Columns["ID"].Visible = false;
                MainData.Columns["_"].Visible = false;
            }
            catch { }
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            Program.adv.SearchBox.Text = SearchBox.Text;
        }

        private void MaximizeForm_Activated(object sender, EventArgs e)
        {
            SearchBox.Text = Program.adv.SearchBox.Text;
            MainData.DataSource = Program.adv.MainData.DataSource;
            try
            {
                MainData.Columns["ID"].Visible = false;
                MainData.Columns["_"].Visible = false;
            }
            catch { }
        }

        private void AllSchedulesDelete_Click(object sender, EventArgs e)
        {
            Program.adv.AllSchedulesDelete.PerformClick();
        }

        private void AllSchedulesAdd_Click(object sender, EventArgs e)
        {
            Program.adv.Focus();
            Program.adv.AllSchedulesAdd.PerformClick();
        }

        private void AllSchedulesView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainData_CellClick(object sender, MouseEventArgs e)
        {
            Program.adv.MainData.ClearSelection();
            foreach (DataGridViewRow row in MainData.SelectedRows)
            {
                Program.adv.MainData.Rows[row.Index].Selected = true;
            }
        }

        private void MaximizeForm_Resize(object sender, EventArgs e)
        {
            MainData.Width = Width - 40;
            MainData.Height = Height - 121;
        }
    }
}
