using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using ScheduleMaster.Classes;

namespace ScheduleMaster
{
    internal static class Program
    {
        internal static Viewer v = new Viewer();
        internal static ScheduleViewer sv = new ScheduleViewer();
        internal static ScheduleDatabase sb = new ScheduleDatabase();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            sb.AssignFromDataTable(Methods.ExcelToDataTable());
            Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Viewer());
            Application.Run(v);
            sv.Hide();
        }
    }
}
