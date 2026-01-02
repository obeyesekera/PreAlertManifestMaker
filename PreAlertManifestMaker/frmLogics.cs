using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreAlertManifestMaker
{
    partial class frmMain
    {
        private bool validatefields = false;

        private int drWeight = 0;
        private int drValue = 0;
        int parcelCount = 0;
        int itemsPP = 0;

        private void setValidateTrue() 
        {
            validatefields = true;
        }

        private void initializeControls()
        {
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
            txtSKUs.ReadOnly = true;
            //cmbForm.Enabled = false;

            dtpDeparture.CustomFormat = ConfigurationManager.AppSettings["dtFormat"]; //"dd/MM/yyyy hh:mm:ss tt";
            dtpArrival.CustomFormat = ConfigurationManager.AppSettings["dtFormat"]; //"dd/MM/yyyy hh:mm:ss tt";
            dtpDeparture.Value = DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["departOffset"]));
            dtpArrival.Value = DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["arriveOffset"]));
            txtParcels.Text = ConfigurationManager.AppSettings["parcels"];
            txtItemsPP.Text = ConfigurationManager.AppSettings["itemsPP"];
            txtFiles.Text = ConfigurationManager.AppSettings["files"];
            drWeight = int.Parse(ConfigurationManager.AppSettings["drWeight"]);
            drValue = int.Parse(ConfigurationManager.AppSettings["drValue"]);

        }

        private void loadConfigurations()
        {
            fillFormsComboBox("form.cfg");
            fillClientComboBox("client.cfg");
            fillAirlineComboBox("airline.cfg");
            fillDestinationComboBox("PortsLocal.cfg");
            fillOriginComboBox("PortsForeign.cfg");
            //loadCurrency("currency.cfg");
            //loadHS("HS.cfg");
            loadRow2("EpamRow2.cfg");
        }

        private void validateNumbers(KeyPressEventArgs e)
        {
            // Check if the entered character is not a control character and not an alphanumeric character
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                // If it's not, set e.Handled to true to prevent the character from being entered
                e.Handled = true;
                MessageBox.Show("Please enter only numbers (0-9).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private string updateSKUs()
        {
            int nSKUs = 0;

            int proLenght = txtParcels.Text.Length * txtItemsPP.Text.Length;

            if (validatefields && proLenght>0)
            {
                parcelCount = Convert.ToInt32(txtParcels.Text);
                itemsPP = Convert.ToInt32(txtItemsPP.Text);
                nSKUs = parcelCount * itemsPP;
            }

            if (nSKUs>0) 
            {
                btnGenerate.Enabled = true;
                //btnGenerate.Focus();
            }
            else
            {
                btnGenerate.Enabled = false;
            }

            return nSKUs.ToString();
        }

        private void generateEpamRaws() 
        {
            txtFlight.ReadOnly = true;
            txtMAWB.ReadOnly = true;
            btnGenerate.Enabled = false;
            cmbAirline.Enabled = false;
            cmbClient.Enabled = false;
            cmbOrigin.Enabled = false;
            cmbDestination.Enabled = false;
            dtpArrival.Enabled = false;
            dtpDeparture.Enabled = false;
            txtParcels.ReadOnly = true;
            txtItemsPP.ReadOnly = true;
            cbDR.Enabled = false;
            cmbForm.Enabled = false;

            //int paxCount = Int32.Parse(txtMWAB.Text);
            //addRows(paxCount);

            parcelCount = Int32.Parse(txtParcels.Text);
            itemsPP = Int32.Parse(txtItemsPP.Text);
            createEpam(parcelCount,itemsPP);
            
            
            dataGridView1.ReadOnly = false;
            btnSave.Enabled = true;
            btnSave.Focus();
        }

        private void generateK2Raws()
        {
            txtFlight.ReadOnly = true;
            txtMAWB.ReadOnly = true;
            btnGenerate.Enabled = false;
            cmbAirline.Enabled = false;
            cmbClient.Enabled = false;
            cmbOrigin.Enabled = false;
            cmbDestination.Enabled = false;
            dtpArrival.Enabled = false;
            dtpDeparture.Enabled = false;
            txtParcels.ReadOnly = true;
            txtItemsPP.ReadOnly = true;
            cbDR.Enabled = false;
            cmbForm.Enabled = false;

            //int paxCount = Int32.Parse(txtMWAB.Text);
            //addRows(paxCount);

            parcelCount = Int32.Parse(txtParcels.Text);
            itemsPP = Int32.Parse(txtItemsPP.Text);
            createK2(parcelCount, itemsPP);


            dataGridView1.ReadOnly = false;
            dataGridView2.ReadOnly = false;
            dataGridView3.ReadOnly = false;
            dataGridView4.ReadOnly = false;
            btnSave.Enabled = true;
            btnSave.Focus();
        }

        private void clearForm() 
        {
            txtFlight.ReadOnly = false;
            txtMAWB.ReadOnly = false;
            btnGenerate.Enabled = true;
            cmbAirline.Enabled = true;
            cmbClient.Enabled = true;
            cmbOrigin.Enabled = true;
            cmbDestination.Enabled = true;
            dtpArrival.Enabled = true;
            dtpDeparture.Enabled = true;
            txtParcels.ReadOnly = false;
            txtItemsPP.ReadOnly = false;
            cbDR.Enabled = true;
            dgTable1.Rows.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            dataGridView4.ReadOnly = true;
            btnSave.Enabled = false;
            btnGenerate.Focus();
            cmbForm.Enabled = true;

        }

        private void setForm()
        {
            tabCon.TabPages.Clear();

            switch (cmbForm.SelectedIndex)
            {
                case 0:
                    tabCon.TabPages.Add(tabPage1);
                    tabPage1.Text = "ePam";
                    dgTable1 = configReader.getTableColums("HeadersEpam.cfg", 2, 0);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dgTable1;
                    cbDR.Enabled = true;
                    fillDestinationComboBox("PortsLocal.cfg");
                    fillOriginComboBox("PortsForeign.cfg");
                    cmbVia.Visible = false;
                    lblVia.Visible = false;
                    break;
                case 1:
                    tabCon.TabPages.Add(tabPage1);
                    tabCon.TabPages.Add(tabPage2);
                    tabCon.TabPages.Add(tabPage3);
                    tabCon.TabPages.Add(tabPage4);
                    tabPage1.Text = "K2_Main";
                    tabPage2.Text = "K2_Items";
                    tabPage3.Text = "K2_ContainerDetails";
                    tabPage4.Text = "K2_SupportingDocuments";
                    dgTable1 = configReader.getTableColums("HeadersK2.cfg", 8, 0);
                    dgTable2 = configReader.getTableColums("HeadersK2.cfg", 8, 2);
                    dgTable3 = configReader.getTableColums("HeadersK2.cfg", 8, 4);
                    dgTable4 = configReader.getTableColums("HeadersK2.cfg", 8, 6);
                    dataGridView1.Columns.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView3.Columns.Clear();
                    dataGridView4.Columns.Clear();
                    dataGridView1.DataSource = dgTable1;
                    dataGridView2.DataSource = dgTable2;
                    dataGridView3.DataSource = dgTable3;
                    dataGridView4.DataSource = dgTable4;
                    cbDR.Enabled = false;
                    fillDestinationComboBox("PortsForeign.cfg");
                    fillOriginComboBox("PortsLocal.cfg");
                    fillViaComboBox("PortsLocal.cfg");
                    cmbVia.Visible = true;
                    lblVia.Visible = true;
                    break;

            }


        }



    }
}
