using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using ScheduleMaster.Classes;

namespace ScheduleMaster
{
    static class Methods
    {

        public static string EMPTY_PROFESSOR = "EMPTY PROFESSOR";
        public static string EMPTY_ROOM = "EMPTY ROOM";

        /// <summary>
        /// Assign Data from DataTable.
        /// </summary>
        /// <param name="data">DataTable to parse.</param>

        public static int AssignFromDataTable(this ScheduleDatabase sb, DataTable data)
        {
            if (data == null) return 0;
            if (data.Rows.Count == 0) return 0;
            int NumInserted = 0;
            foreach (DataRow row in data.Rows)
            {
                try
                {
                    for (int j = 0; j < data.Columns.Count; ++j)
                    {
                        string str = row[j].ToString();
                        if (str == null) row[j] = "";
                    }
                    int i = 0;
                    string subject_title = row[i++].ToString();
                    string last_name = row[i++].ToString();
                    string first_name = row[i++].ToString();
                    if (subject_title == EMPTY_ROOM)
                    {
                        Room r = new Room(last_name, first_name);
                        sb.AddRoom(r);
                        continue;
                    }
                    string department = row[i++].ToString();
                    string id_no = row[i++].ToString();
                    string contact = row[i++].ToString();
                    if (subject_title == EMPTY_PROFESSOR)
                    {
                        Professor p = new Professor(last_name, first_name, department, id_no, contact);
                        sb.AddProfessor(p);
                        continue;
                    }
                    string building = row[i++].ToString();
                    string rnumber = row[i++].ToString();
                    string sday = row[i++].ToString();
                    int stime = 0;
                    int.TryParse(row[i++].ToString(), out stime);
                    string eday = row[i++].ToString();
                    int etime = 0;
                    int.TryParse(row[i++].ToString(), out etime);
                    Professor x = new Professor(last_name, first_name, department, id_no, contact);
                    Room y = new Room(building, rnumber);
                    x = sb.AddProfessor(x);
                    y = sb.AddRoom(y);
                    Subject sub = new Subject(subject_title, x, y);
                    Time st = new Time(sday, stime);
                    Time ed = new Time(eday, etime);
                    Schedule sched = new Schedule(sub, st, ed);
                    if (sb.InsertSchedule(sched)) ++NumInserted;
                }
                catch { }
            }
                
            return NumInserted;
        }

        /// NormalizeWhiteSpaces:
        /// <summary>
        /// Removes contiguous sequences of whitespaces of a string.
        /// </summary>
        /// <param name="s">The string to normalize.</param>

        public static string NormalizeWhiteSpaces(this string s)
        {
            int i, j, k;
            for (i = 0; i < s.Length && s[i] == ' '; ++i) ;
            for (j = s.Length - 1; j > i && s[j] == ' '; --j) ;
            StringBuilder sb = new StringBuilder();
            bool space = false;
            for (k = i; k <= j; ++k)
            {
                if (s[k] == ' ')
                {
                    if (!space)
                    {
                        sb.Append(s[k]);
                        space = true;
                    }
                }
                else
                {
                    sb.Append(s[k]);
                    space = false;
                }
            }
            return sb.ToString();
        }

        public static bool SaveToExcel(this ScheduleDatabase sb, string filedirectory = null, string filename = null)
        {
            try
            {
                DataTable dt = sb.ToArray().ToDataTable(Schedule.GetHeaderArray());
                // empty?
                if (dt.Columns.Count == 0)
                {
                    int count = Schedule.GetHeaderArray().Length;
                    for (int i = 0; i < count; ++i) dt.Columns.Add();
                }
                // get empty professors
                foreach( Professor p in sb.AllProfessors ){
                    if (p.GetSchedules.GetArrayList.Count == 0)
                    {
                        string[] info = p.Information();
                        string[] row = new string[info.Length + 2];
                        for (int i = 0; i < row.Length; ++i) row[i] = EMPTY_PROFESSOR;
                        for (int i = 0; i < info.Length; ++i)
                        {
                            row[i + 2] = info[i];
                        }
                        dt.Rows.Add(row);
                    }
                }
                // get empty rooms
                foreach (Room r in sb.AllRooms)
                {
                    if (r.GetSchedules.GetArrayList.Count == 0)
                    {
                        string[] row = new string[]{
                            "", EMPTY_ROOM, r.Building, r.RoomNumber
                        };
                        dt.Rows.Add(row);
                    }
                }
                // no need for empty subjects
                dt.ExportToExcel(filedirectory, filename);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured:\n" + ex.ToString());
                return false;
            }
        }

        public static DataTable ToDataTable(this string[][] arr, string[] headers = null)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Schedules";
            // no headers
            if (headers == null)
            {
                dt.Columns.Add("_");
                for (int j = 0; j < arr[0].Length; ++j)
                    dt.Columns.Add();
            }
            else
            {
                dt.Columns.Add("_");
                foreach (string s in headers)
                    dt.Columns.Add(s);
            }
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; ++i)
                {

                    string[] row = new string[arr[i].Length + 1];
                    row[0] = ((i + 1).ToString());
                    arr[i].CopyTo(row, 1);
                    dt.Rows.Add(row);
                }
            }
            
            return dt;
        }

        public static string[][] ToArray(this DataTable dt)
        {
            string[][] arr = new string[dt.Rows.Count][];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = (string[])dt.Rows[i].ItemArray;
            }
            return arr;
        }

        // public static string DefaultExcelFileDirectory = Directory.GetCurrentDirectory() + @"\data";
        // public static string DefaultExcelFileName = "data.xlsx";
        public static string DefaultExcelFileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DefaultExcelFileName = "data.xlsx";
        public static string GetProviderXLSX(string path) { return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", path); }
        public static string GetProviderXLS(string path) { return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", path); }

        public static DataTable ExcelToDataTable(string sheetname = "Sheet1", string filedirectory = null, string filename = null)
        {
            if (filedirectory == null)
                filedirectory = DefaultExcelFileDirectory;
            if (filename == null)
                filename = DefaultExcelFileName;

            if (!Directory.Exists(filedirectory))
            {
                Directory.CreateDirectory(filedirectory);
            }

            string filepath = filedirectory + "\\" + filename;

            if (!File.Exists(filepath))
            {
                // make initial data
                Excel.Application app = new Excel.Application();
                app.Workbooks.Add();
                Excel._Worksheet sheet = app.ActiveSheet;
                string[] headers = Schedule.GetHeaderArray();
                for (int i = 0; i < headers.Length; ++i)
                {
                    sheet.Cells[1, i + 1] = headers[i];
                }
                sheet.SaveAs(filepath);
                app.Quit();
            }


            string connection;

            if (filepath.EndsWith(".xlsx")) connection = GetProviderXLSX(filepath);
            else if (filepath.EndsWith(".xls")) connection = GetProviderXLS(filepath);
            else return null;

            try
            {
                OleDbConnection conn = new OleDbConnection(connection);
                OleDbDataAdapter data = new OleDbDataAdapter();
                OleDbCommand select = new OleDbCommand(@"SELECT * FROM [" + sheetname + "$]", conn);
                data.SelectCommand = select;
                DataTable dt = new DataTable();
                data.Fill(dt);
                dt.TableName = "Schedules";
                // close connection
                conn.Close();
                data = null;
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }

        public static int ExportToExcel(this DataTable dt, string filedirectory = null, string filename = null)
        {
            if (filedirectory == null)
                filedirectory = DefaultExcelFileDirectory;
            if (filename == null)
                filename = DefaultExcelFileName;

            if (!Directory.Exists(filedirectory))
            {
                Directory.CreateDirectory(filedirectory);
            }
            string filepath = filedirectory + "\\" + filename;
            try
            {
                dt.AcceptChanges();
                if (dt == null || dt.Columns.Count == 0)
                {
                    return -2; // not saved, data null
                }

                Excel.Application app = new Excel.Application();
                app.Workbooks.Add();
                Excel._Worksheet sheet = app.ActiveSheet;

                // headings

                var cols = dt.Columns;

                for (int i = 1; i < cols.Count; ++i)
                {
                    sheet.Cells[1, i] = cols[i].ColumnName;
                }

                // rows


                var rows = dt.Rows;

                for (int i = 0; i < rows.Count; ++i)
                {
                    for (int j = 1; j < cols.Count; ++j)
                    {
                        sheet.Cells[(i + 2), j] = rows[i][j];
                    }
                }

                if (filepath != null && filepath != "")
                {
                    try
                    {
                        File.Delete(filepath);
                        sheet.SaveAs(filepath);
                        app.Quit();
                        return 0; // file saved
                    }
                    catch
                    {
                        return 1; // not saved, error with file path
                    }
                }
                else
                {

                    app.Visible = true;
                    return 2; // empty filepath
                }
            }
            catch
            {
                return -1; // exception thrown
            }

        }

        public static SaveFileDialog ExcelSaveFileDialog()
        {
            return new SaveFileDialog{
                FileName = DefaultExcelFileName,
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel Workbook 97-03 (*.xls)|*.xls",
                FilterIndex = 0,
                InitialDirectory = DefaultExcelFileDirectory,
                OverwritePrompt = true
            };
        }
        public static OpenFileDialog ExcelOpenFileDialog()
        {
            return new OpenFileDialog{
                FileName = DefaultExcelFileName,
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel Workbook 97-03 (*.xls)|*.xls",
                FilterIndex = 0,
                InitialDirectory = DefaultExcelFileDirectory
            };
        }

        public static string[] GetDirectoryAndFileName(this FileDialog f)
        {
            int slash = f.FileName.LastIndexOf('\\');
            if (slash < 0)
            {
               return new string[]{ "", f.FileName }; 
            }
            string dir = f.FileName.Substring(0, slash);
            string name = f.FileName.Substring(slash + 1);
            return new string[]{ dir, name };
        }


    }
}
