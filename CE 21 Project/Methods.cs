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

namespace CE_21_Project
{
    public static class Methods
    {
        public static DataTable ToDataTable(this string[][] arr, string[] headers = null)
        {
            DataTable dt = new DataTable();
            if (arr == null || arr.Length == 0) return dt;
            // no headers
            if (headers == null)
            {
                dt.Columns.Add("ID");
                for (int j = 0; j < arr[0].Length; ++j)
                    dt.Columns.Add();
            }
            else
            {
                dt.Columns.Add("ID");
                foreach (string s in headers)
                    dt.Columns.Add(s);
            }
            for (int i = 0; i < arr.Length; ++i)
            {
 
                string[] row = new string[arr[i].Length + 1];
                row[0] = ((i + 1).ToString());
                arr[i].CopyTo(row, 1);
                dt.Rows.Add(row);
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

        public static string DefaultExcelFileDirectory = Directory.GetCurrentDirectory() + @"\data";
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
                Excel.Application app = new Excel.Application();
                app.Workbooks.Add();
                Excel._Worksheet sheet = app.ActiveSheet;
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
            catch (Exception ex)
            {
                return -1; // exception thrown
            }

        }

    }
}
