using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;

namespace CE_21_Project
{

    public static class ExcelViewer
    {
        public const string DefaultExcelFilePath = @"C:\Users\Rico\Documents\Visual Studio 2012\Projects\CE 21 Project\CE 21 Project\data\data.xlsx";
        public static string GetProviderXLSX(string path) {  return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", path); }
        public static string GetProviderXLS(string path) { return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", path); }
        

        public static DataTable ExcelToDataTable(string sheetname = "Sheet1", string filepath = DefaultExcelFilePath)
        {

            filepath = filepath.Trim();

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

        
        
    }

    /*
    class ExcelLoader
    {

        public Application application;
        public Workbook workbook;
        public Worksheet worksheet;

        public ExcelLoader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Excel File \"" + path + "\" not found");
            application = new Application();
            workbook = application.Workbooks.Open(path);
            worksheet = workbook.ActiveSheet;
        }

        public void Close()
        {
            workbook.Close();
        }

    }
    */
}
/*

        public static string ExcelStartCell = "A3";
        public static string ExcelEndColumn = "I";
        public static string ExcelColumnCountID = "L3";

        public void LoadExcelFile(string path)
        {
            Application a = null;
            Workbook w = null;
            Worksheet s = null;
            try
            {
                if (!System.IO.File.Exists(path))
                    throw new FileNotFoundException("Excel File \"" + path + "\" not found");
                object x = Type.Missing;
                a = new Application();
                w = a.Workbooks.Open(path,
                    x, //updatelinks
                    false, //readonly
                    x, //format
                    x, //Password
                    x, //writeResPassword
                    true, //ignoreReadOnly
                    x, //origin
                    x, //delimiter
                    true, //editable
                    x, //Notify
                    x, //converter
                    x, //AddToMru
                    x, //Local
                    x); //corrupted
                s = w.ActiveSheet;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }

            Range rng = s.get_Range(ExcelColumnCountID);
            string ExcelEndRow = (int.Parse(rng.Value.ToString()) + 2).ToString();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
            if (ExcelEndRow == "2") return;
            rng = s.get_Range(ExcelStartCell, ExcelEndColumn + ExcelEndRow);

            string[] info = new string[9];
            Range Rows = rng.Rows;
            foreach (Range row in Rows)
            {
                int i = 0;
                foreach (var cell in row.Cells.Value2)
                {
                    info[i++] = cell.ToString();
                }
                Time start = new Time(info[2], info[0]);
                Time end = new Time(info[3], info[1]);
                Professor x = AddProfessor(info[4], info[5], info[6]);
                Room y = AddRoom(info[7], info[8]);
                InsertSchedule(x, y, start, end);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(row);
            }
            try
            {
                object x = Type.Missing;
                string tmpname = Path.GetTempFileName();
                File.Delete(tmpname);
                w.SaveAs(tmpname, x, x, x, x, x, XlSaveAsAccessMode.xlExclusive, x, x, x, x, x);
                w.Close(false, x, x);
                a.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(a);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(w);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(s);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Rows);
                File.Delete(path);
                File.Move(tmpname, path);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }

        }

        public void SaveExcelFile(string path)
        {
            Application a = null;
            Workbook w = null;
            Worksheet s = null;
            try
            {
                if (!System.IO.File.Exists(path))
                    throw new FileNotFoundException("Excel File \"" + path + "\" not found");
                object x = Type.Missing;
                a = new Application();
                w = a.Workbooks.Open(path,
                    x, //updatelinks
                    false, //readonly
                    x, //format
                    x, //Password
                    x, //writeResPassword
                    true, //ignoreReadOnly
                    x, //origin
                    x, //delimiter
                    true, //editable
                    x, //Notify
                    x, //converter
                    x, //AddToMru
                    x, //Local
                    x); //corrupted
                s = w.ActiveSheet;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
            string[,] data = DataGrid();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    sb.Append(data[i, j]).Append(' ');
                }
                sb.Append('\n');
            }
            System.Windows.Forms.MessageBox.Show(sb.ToString());
            Range rng = s.get_Range(ExcelStartCell, ExcelEndColumn + (data.GetLength(0) + 2).ToString());
            rng.Value = data;
            s.get_Range(ExcelColumnCountID).Value = data.GetLength(0).ToString();
            try
            {
                object x = Type.Missing;
                string tmpname = Path.GetTempFileName();
                File.Delete(tmpname);
                w.SaveAs(tmpname, x, x, x, x, x, XlSaveAsAccessMode.xlExclusive, x, x, x, x, x);
                w.Close(false, x, x);
                a.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(a);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(w);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(s);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
                File.Delete(path);
                File.Move(tmpname, path);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }

*/