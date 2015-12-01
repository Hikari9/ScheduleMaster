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
    public partial class ExcelExport : Form
    {
        public ExcelExport()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            DataTable dt = ExcelViewer.ExcelToDataTable();
            if (dt == null)
            {
                MessageBox.Show("Please type a valid sheet name.");
                return;
            }
            dgrid.DataSource = dt;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Save unsaved changes?","",MessageBoxButtons.YesNoCancel);
            if( res == DialogResult.Yes ){
                ((DataTable)dgrid.DataSource).ExportToExcel();
            }
            else if( res==DialogResult.No ){
                return;
            }
            else{
                e.Cancel = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show(((DataTable)dgrid.DataSource).ExportToExcel().ToString());
            }
        }

    }
}
