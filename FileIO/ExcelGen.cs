using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace FileIO
{
    public class ExcelGen
    {
        string[,] row2List;

        ConfigReader configReader = new ConfigReader();

        public string[] saveEpam(string fileName, DataTable dgTable) 
        {
            ExcelApp.Application manifestExcel = new ExcelApp.Application();
            ExcelApp.Workbook manifestWorkbook = manifestExcel.Workbooks.Add(Type.Missing);
            string[] messageArr;

            try
            {
                manifestExcel.Visible = false;
                manifestExcel.DisplayAlerts = false;

                // For example, to set column A to Text format:
                row2List = configReader.readComboCfg("EpamRow2.cfg", 1);

                ExcelApp.Worksheet manifestWorksheet = (ExcelApp.Worksheet)manifestWorkbook.ActiveSheet;
                manifestWorksheet.Name = "ePAM Data";
                //manifestWorksheet.Cells[1, 1] = txtFlight.Text;
                manifestWorksheet.Cells.Font.Size = 11;

                ExcelApp.Range columnHS = manifestWorksheet.Columns["AJ"];
                columnHS.NumberFormat = "@";

                for (int i = 1; i <= dgTable.Columns.Count; i++)
                {
                    manifestWorksheet.Cells[1, i] = dgTable.Columns[i - 1].ColumnName;
                    manifestWorksheet.Cells[2, i] = row2List[i - 1, 0];
                    manifestWorksheet.Cells.Font.Color = System.Drawing.Color.Black;
                }

                int worksheetRow = 2;

                foreach (DataRow datarow in dgTable.Rows)
                {
                    worksheetRow += 1;

                    // Get data as an object array
                    object[] values = datarow.ItemArray;

                    // Get the number of columns
                    int colCount = values.Length;

                    // Define the target range for the row
                    ExcelApp.Range targetRange = manifestWorksheet.Range[
                        manifestWorksheet.Cells[worksheetRow, 1],
                        manifestWorksheet.Cells[worksheetRow, colCount]
                    ];

                    // Assign the array to the range
                    targetRange.Value2 = values;

                }

                manifestWorkbook.SaveAs(fileName);
                manifestWorkbook.Close();

                messageArr = new string[] { "OK", fileName };
                return messageArr;
            }
            catch (Exception ex)
            {
                messageArr = new string[] { "ERR", ex.Message };
                return messageArr;
            }
            finally
            {
                manifestExcel?.Quit();
                Thread.Sleep(5000);
            }
        }


        


    }
}
