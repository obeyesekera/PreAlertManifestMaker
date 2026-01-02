using FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PreAlertManifestMaker
{
    partial class frmMain
    {
        ExcelGen excelGen = new ExcelGen();

        string consignmentNo = "";
        string SKUNo = "";

        private void createEpam(int parcelCount, int itemsPP) 
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
                parcelNo = addEpamParcels(itemsPP,parcelNo, nMAWB);
            }
        }

        private string addEpamParcels(int itemsPP,string parcelNo, string[] nMAWB) 
        {
            string parcelPrefix = clientList[cmbClient.SelectedIndex, 1];

            if (parcelNo=="") 
            {
                parcelNo = ePam_Main.getParcelNo(parcelPrefix);
            }

            int parcelNoSeq = Int32.Parse(parcelNo.Substring(3));

            string[] nParcel = ePam_Main.getParcel(parcelNoSeq, parcelNo, nMAWB, cbDR.Checked, drWeight);

            string[] nConsigner = ePam_Main.addEpamConsignor();

            string[] nConsignee = ePam_Main.addEpamConsignee();

            for (int i = 0; i < itemsPP; i++)
            {
                string[] nItem = ePam_Main.addItem(consignmentNo, SKUNo, cbDR.Checked, drValue, itemsPP);

                addEpamRow(nMAWB,nParcel,nConsigner,nConsignee,nItem);
            }

            string nParcelNo = parcelPrefix + (parcelNoSeq + 1).ToString();

            return nParcelNo;
        }

        


        private void addEpamRow(string[] nMAWB, string[] nParcel, string[] nConsigner, string[] nConsignee, string[] nItem)
        {
            dgTable1.Rows.Add(
                nMAWB[0], nMAWB[1], nMAWB[2], nMAWB[3], nMAWB[4], nMAWB[5], nMAWB[6], //7
                nParcel[0], nParcel[1], nParcel[2], nParcel[3], nParcel[4], nParcel[5], nParcel[6], nParcel[7], nParcel[8], //9
                nConsigner[0], nConsigner[1], nConsigner[2], nConsigner[3], nConsigner[4], nConsigner[5], nConsigner[6], //7
                nConsignee[0], nConsignee[1], nConsignee[2], nConsignee[3], nConsignee[4], nConsignee[5], nConsignee[6], //7
                nItem[0], nItem[1], nItem[2], nItem[3], nItem[4], nItem[5] //6
                );
        }


        private void saveEpam()
        {
            
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            dataGridView1.ReadOnly = true;

            string fileName;


            fileName = "ePAM_";


            fileName += txtMAWB.Text + "_";
            fileName += DateTime.Now.ToString("yyyyMMddHHmmss");
            fileName += txtParcels.Text.Length > 0 ? ("_" + txtParcels.Text + "P") : "";
            fileName += txtSKUs.Text.Length > 0 ? ("_" + txtSKUs.Text + "SKU") : "";


            string[] messageArr = excelGen.saveEpam(fileName, dgTable1);

            if (messageArr[0] == "OK")
            {
                MessageBox.Show(messageArr[1] + " Saved !");
            }
            else
            {
                MessageBox.Show("Error: " + messageArr[1]);
            }

            btnSave.Enabled = true;
            btnClear.Enabled = true;
            dataGridView1.ReadOnly = false;
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
