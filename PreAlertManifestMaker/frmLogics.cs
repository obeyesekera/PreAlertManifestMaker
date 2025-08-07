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

        private void setValidateTrue() 
        {
            validatefields = true;
        }

        private void initializeControls()
        {
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
            txtSKUs.ReadOnly = true;

            dtpDeparture.CustomFormat = ConfigurationManager.AppSettings["dtFormat"]; //"dd/MM/yyyy hh:mm:ss tt";
            dtpArrival.CustomFormat = ConfigurationManager.AppSettings["dtFormat"]; //"dd/MM/yyyy hh:mm:ss tt";
            dtpDeparture.Value = DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["departOffset"]));
            dtpArrival.Value = DateTime.Now.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["arriveOffset"]));
            txtParcels.Text = ConfigurationManager.AppSettings["parcels"];
            txtItemsPP.Text = ConfigurationManager.AppSettings["itemsPP"];
            txtFiles.Text = ConfigurationManager.AppSettings["files"];

        }

        private void loadConfigurations() 
        {
            fillClientComboBox("client.cfg");
            fillAirlineComboBox("airline.cfg");
            fillDestinationComboBox("destination.cfg");
            fillOriginComboBox("origin.cfg");
            loadCurrency("currency.cfg");
            loadHS("HS.cfg");
            loadRow2("row2.cfg");
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
                int parcels = Convert.ToInt32(txtParcels.Text);
                int itemsPP = Convert.ToInt32(txtItemsPP.Text);
                nSKUs = parcels * itemsPP;
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

        private void generateRaws() 
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

            //int paxCount = Int32.Parse(txtMWAB.Text);
            //addRows(paxCount);

            int parcelCount = Int32.Parse(txtParcels.Text);
            int itemsPP = Int32.Parse(txtItemsPP.Text);
            createManifest(parcelCount,itemsPP);
            
            
            dataGridView1.ReadOnly = false;
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
            dgTable.Rows.Clear();
            dataGridView1.ReadOnly = true;
            btnSave.Enabled = false;
            btnGenerate.Focus();


        }

    }
}
