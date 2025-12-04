using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        string consignmentNo = "";
        string SKUNo = "";

        private void createManifest(int parcelCount, int itemsPP) 
        {
            string[] nMAWB = {
                clientList[cmbClient.SelectedIndex,0],
                txtMAWB.Text,
                txtFlight.Text,
                originList[cmbOrigin.SelectedIndex,0]+originList[cmbOrigin.SelectedIndex,2],
                destinationList[cmbDestination.SelectedIndex,0]+destinationList[cmbDestination.SelectedIndex,2],
                dtpDeparture.Text,
                dtpArrival.Text
            };

            string parcelNo = "";

            for (int i = 0; i < parcelCount; i++) 
            {
                parcelNo = addParcels(itemsPP,parcelNo, nMAWB);
            }
        }

        private string addParcels(int itemsPP,string parcelNo, string[] nMAWB) 
        {
            string parcelPrefix = clientList[cmbClient.SelectedIndex, 1];

            if (parcelNo=="") 
            {
                parcelNo = ePam_Main.getParcelNo(parcelPrefix);
            }

            int parcelNoSeq = Int32.Parse(parcelNo.Substring(3));

            string[] nParcel = ePam_Main.getParcel(parcelNoSeq, parcelNo, nMAWB, cbDR.Checked, drWeight);

            string[] nConsigner = ePam_Main.addConsignor();

            string[] nConsignee = ePam_Main.addConsignee();

            for (int i = 0; i < itemsPP; i++)
            {
                string[] nItem = ePam_Main.addItem(consignmentNo, SKUNo, cbDR.Checked, drValue, itemsPP);

                addRow(nMAWB,nParcel,nConsigner,nConsignee,nItem);
            }

            string nParcelNo = parcelPrefix + (parcelNoSeq + 1).ToString();

            return nParcelNo;
        }

        


        private void addRow(string[] nMAWB, string[] nParcel, string[] nConsigner, string[] nConsignee, string[] nItem)
        {
            dgTable.Rows.Add(
                nMAWB[0], nMAWB[1], nMAWB[2], nMAWB[3], nMAWB[4], nMAWB[5], nMAWB[6], //7
                nParcel[0], nParcel[1], nParcel[2], nParcel[3], nParcel[4], nParcel[5], nParcel[6], nParcel[7], nParcel[8], //9
                nConsigner[0], nConsigner[1], nConsigner[2], nConsigner[3], nConsigner[4], nConsigner[5], nConsigner[6], //7
                nConsignee[0], nConsignee[1], nConsignee[2], nConsignee[3], nConsignee[4], nConsignee[5], nConsignee[6], //7
                nItem[0], nItem[1], nItem[2], nItem[3], nItem[4], nItem[5] //6
                );
        }

        private void saveManifest(string fileName)
        {
            ExcelApp.Application manifestExcel = new ExcelApp.Application();
            ExcelApp.Workbook manifestWorkbook = manifestExcel.Workbooks.Add(Type.Missing);

            try
            {
                manifestExcel.Visible = false;
                manifestExcel.DisplayAlerts = false;

                // For example, to set column A to Text format:
                

                ExcelApp.Worksheet manifestWorksheet = (ExcelApp.Worksheet)manifestWorkbook.ActiveSheet;
                manifestWorksheet.Name = "ePAM Data";
                //manifestWorksheet.Cells[1, 1] = txtFlight.Text;
                manifestWorksheet.Cells.Font.Size = 11;

                ExcelApp.Range columnHS = manifestWorksheet.Columns["AJ"];
                columnHS.NumberFormat = "@";

                for (int i = 1; i <= dgTable.Columns.Count; i++)
                {
                    manifestWorksheet.Cells[1, i] = dgTable.Columns[i - 1].ColumnName;
                    manifestWorksheet.Cells[2, i] = row2List[i-1,0];
                    manifestWorksheet.Cells.Font.Color = System.Drawing.Color.Black;
                }

                int worksheetRow = 2;

                foreach (DataRow datarow in dgTable.Rows)
                {
                    worksheetRow += 1;

                    //for (int i = 1; i <= dgTable.Columns.Count; i++)
                    //{
                    //    manifestWorksheet.Cells[worksheetRow, i] = datarow[i - 1].ToString();
                    //}


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


        




        private void updatePaxCount()
        {
            gridRaws = (dataGridView1.Rows.Count - 1);

            lblRows.Text = gridRaws.ToString() + " rows to save";

            if (gridRaws > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }

        }

    }
}
