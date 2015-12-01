using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using ScheduleMaster.Classes;

namespace ScheduleMaster
{
    static class Program
    {

        public static ScheduleDatabase db = new ScheduleDatabase();
        public static AllDataViewer adv = new AllDataViewer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                StreamReader sr = new StreamReader("ExcelDirectoryInfo.txt");
                string dir = sr.ReadLine();
                string name = sr.ReadLine();
                sr.Close();
                if (dir == null || name == null || dir == "" || name == "")
                {
                    SaveFileDialog d = Methods.ExcelSaveFileDialog();
                    var res = d.ShowDialog();
                    if (res != DialogResult.OK) return;
                    string[] s = d.GetDirectoryAndFileName();
                    dir = s[0];
                    name = s[1];
                    if (File.Exists(dir + "\\" + name)) File.Delete(dir + "\\" + name);
                    StreamWriter sw = new StreamWriter("ExcelDirectoryInfo.txt");
                    sw.WriteLine(s[0]);
                    sw.WriteLine(s[1]);
                    sw.Close();
                }
                Methods.DefaultExcelFileDirectory = dir;
                Methods.DefaultExcelFileName = name;
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occured. Application will close.\n" + e.ToString());
                return;
            }
            db.AssignFromDataTable(Methods.ExcelToDataTable());
            Application.EnableVisualStyles();
            Application.Run(adv);
            adv.Focus();
        }
    }
}
