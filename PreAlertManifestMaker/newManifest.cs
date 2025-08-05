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
        private System.Data.DataTable getManifestColums()
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
                parcelNo = rndParcelNo(parcelPrefix);
            }

            int parcelNoSeq = Int32.Parse(parcelNo.Substring(3));

            string[] nTotals = rndParcelTotals();

            string[] nParcel = {
                parcelNo,
                parcelNoSeq.ToString(), //BagID(),
                nMAWB[3], //Origin
                nMAWB[4], //Destination
                rndCurrency(),
                nTotals[0], //TotFreight,
                nTotals[1], //TotInsurance,
                nTotals[2], //TotGrossWeight
                rndLVGReg()
            };

            string[] nConsigner = addConsigner();
            string[] nConsignee = addConsignee();

            for (int i = 0; i < itemsPP; i++)
            {
                
                string[] nItem = addItem();

                addRow(nMAWB,nParcel,nConsigner,nConsignee,nItem);
            }


            string nParcelNo = parcelPrefix + (parcelNoSeq + 1).ToString();

            return nParcelNo;
        }

        private string[] addConsigner()
        {
            string[] nCountry = rndConsignorCountry();
            string[] nConsignor = {
                rndConsignorName(), //"Consignor Name *", 
                rndConsignorAddress1(), //"Consignor Address 1 *",
                rndConsignorAddress2(), //"Consignor Address 2",
                rndPostalCode(), //"Consignor Postcode ",
                nCountry[1], //"Consignor City ",
                nCountry[2], //"Consignor State ",
                nCountry[0] //"Consignor Country *"
            };

            return nConsignor;
        }

        private string[] addConsignee()
        {
            string[] nCountry = rndConsigneeCountry();
            string[] nConsignee = {
                rndConsigneeName(), //"Consignee Name *",
                rndConsigneeAddress1(), //"Consignee Address 1 *",
                rndConsigneeAddress2(), //"Consignee Address 2",
                rndPostalCode(), //"Consignee Postcode",
                nCountry[1], //"Consignee City",
                nCountry[2], //"Consignee State",
                nCountry[0] //"Consignee Country *"
            };

            return nConsignee;
        }

        private string[] addItem()
        {
            string consignmentPrefix = "CN";
            string SKUPrefix = "SKU";

            if (consignmentNo == "")
            {
                consignmentNo = rndConsignmentNo(consignmentPrefix);
                SKUNo = rndSKUNo(SKUPrefix);
            }

            int consignmentNoSeq = Int32.Parse(consignmentNo.Substring(2));
            int SKUNoSeq = Int32.Parse (SKUNo.Substring(3));

            string[] nHS = rndHSCode();

            string[] nItem = {
                consignmentNo, //"Consignment Note *", 
                SKUNo, //"Goods SKU *",
                nHS[1], //"Description of Goods *",
                rndQuantity(), //"Quantity *",
                rndUnitValue(), //"Item Value Per Unit *",
                nHS[0] //"HS Code *"
            };

            consignmentNo = consignmentPrefix + (consignmentNoSeq + 1).ToString();
            SKUNo = SKUPrefix + (SKUNoSeq + 1).ToString();

            return nItem;

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

                    for (int i = 1; i <= dgTable.Columns.Count; i++)
                    {
                        //manifestWorksheet.Cells[worksheetRow, i] = "'" + datarow[i - 1].ToString();

                        manifestWorksheet.Cells[worksheetRow, i] = datarow[i - 1].ToString();

                    }

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
