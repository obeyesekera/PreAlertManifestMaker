using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace PreAlertManifestMaker
{
    partial class frmMain
    {

        private System.Data.DataTable getManifestColumsK2Main()
        {
            System.Data.DataTable table = new System.Data.DataTable();

            table.Columns.Add("Client Name *", typeof(string));
            table.Columns.Add("MAWB No. *", typeof(string));
            table.Columns.Add("Flight No. *", typeof(string));
            table.Columns.Add("Origin Port *", typeof(string));
            table.Columns.Add("Destination Port *", typeof(string));
            table.Columns.Add("STD *", typeof(string));
            table.Columns.Add("STA *", typeof(string));

            table.Columns.Add("Parcel No. *", typeof(string));
            table.Columns.Add("Parcel Bag ID", typeof(string));
            table.Columns.Add("Parcel Origin", typeof(string));
            table.Columns.Add("Parcel Destination", typeof(string));
            table.Columns.Add("Parcel Currency", typeof(string));
            table.Columns.Add("Parcel Total Freight Charges *", typeof(string));
            table.Columns.Add("Parcel Total Insurance Charges *", typeof(string));
            table.Columns.Add("Parcel Total Gross Weight *", typeof(string));
            table.Columns.Add("LVG Registration No.", typeof(string));

            table.Columns.Add("Consignor Name *", typeof(string));
            table.Columns.Add("Consignor Address 1 *", typeof(string));
            table.Columns.Add("Consignor Address 2", typeof(string));
            table.Columns.Add("Consignor Postcode ", typeof(string));
            table.Columns.Add("Consignor City ", typeof(string));
            table.Columns.Add("Consignor State ", typeof(string));
            table.Columns.Add("Consignor Country *", typeof(string));

            table.Columns.Add("Consignee Name *", typeof(string));
            table.Columns.Add("Consignee Address 1 *", typeof(string));
            table.Columns.Add("Consignee Address 2", typeof(string));
            table.Columns.Add("Consignee Postcode", typeof(string));
            table.Columns.Add("Consignee City", typeof(string));
            table.Columns.Add("Consignee State", typeof(string));
            table.Columns.Add("Consignee Country *", typeof(string));

            table.Columns.Add("Consignment Note *", typeof(string));
            table.Columns.Add("Goods SKU *", typeof(string));
            table.Columns.Add("Description of Goods *", typeof(string));
            table.Columns.Add("Quantity *", typeof(string));
            table.Columns.Add("Item Value Per Unit *", typeof(string));
            table.Columns.Add("HS Code *", typeof(string));

            return table;
        }

        private void saveManifestK2(string fileName)
        {
            ExcelApp.Application manifestExcel = new ExcelApp.Application();
            ExcelApp.Workbook manifestWorkbook = manifestExcel.Workbooks.Add(Type.Missing);

            try
            {
                manifestExcel.Visible = false;
                manifestExcel.DisplayAlerts = false;

                // For example, to set column A to Text format:
                ExcelApp.Worksheet k2MainWorksheet = (ExcelApp.Worksheet)manifestWorkbook.ActiveSheet;
                k2MainWorksheet.Name = "K2_Main";
                k2MainWorksheet.Cells.Font.Size = 11;

                ExcelApp.Range columnHS = k2MainWorksheet.Columns["AJ"];
                columnHS.NumberFormat = "@";

                for (int i = 1; i <= dgTable.Columns.Count; i++)
                {
                    k2MainWorksheet.Cells[1, i] = dgTable.Columns[i - 1].ColumnName;
                    k2MainWorksheet.Cells[2, i] = row2List[i - 1, 0];
                    k2MainWorksheet.Cells.Font.Color = System.Drawing.Color.Black;
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
                    ExcelApp.Range targetRange = k2MainWorksheet.Range[
                        k2MainWorksheet.Cells[worksheetRow, 1],
                        k2MainWorksheet.Cells[worksheetRow, colCount]
                    ];

                    // Assign the array to the range
                    targetRange.Value2 = values;

                }

                // For example, to set column A to Text format: ______________________________________________
                ExcelApp.Worksheet k2ItemsWorksheet = (ExcelApp.Worksheet)manifestWorkbook.Sheets.Add(After: manifestWorkbook.Sheets[manifestWorkbook.Sheets.Count]);
                k2ItemsWorksheet.Name = "K2_Items";
                k2ItemsWorksheet.Cells.Font.Size = 11;

                ExcelApp.Range columnHS2 = k2ItemsWorksheet.Columns["AJ"];
                columnHS2.NumberFormat = "@";

                for (int i = 1; i <= dgTable.Columns.Count; i++)
                {
                    k2ItemsWorksheet.Cells[1, i] = dgTable.Columns[i - 1].ColumnName;
                    k2ItemsWorksheet.Cells[2, i] = row2List[i - 1, 0];
                    k2ItemsWorksheet.Cells.Font.Color = System.Drawing.Color.Black;
                }

                int worksheetRow2 = 2;

                foreach (DataRow datarow in dgTable.Rows)
                {
                    worksheetRow2 += 1;

                    // Get data as an object array
                    object[] values = datarow.ItemArray;

                    // Get the number of columns
                    int colCount = values.Length;

                    // Define the target range for the row
                    ExcelApp.Range targetRange = k2ItemsWorksheet.Range[
                        k2ItemsWorksheet.Cells[worksheetRow2, 1],
                        k2ItemsWorksheet.Cells[worksheetRow2, colCount]
                    ];

                    // Assign the array to the range
                    targetRange.Value2 = values;

                }

                manifestWorkbook.SaveAs(fileName);
                manifestWorkbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                manifestExcel?.Quit();
                Thread.Sleep(5000);
            }
        }

    }
}
