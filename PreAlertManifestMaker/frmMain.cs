using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace PreAlertManifestMaker
{
    public partial class frmMain : Form
    {
        DataTable dgTable;


        public frmMain()
        {
            InitializeComponent();
        }

        private DataTable dtCountry;
        private DataTable dtDocType;

        string localNat;
        int gridRaws = 0;

        private void frmMain_Load(object sender, EventArgs e)
        {
            initializeControls();

            loadConfigurations();

            setValidateTrue();

            txtSKUs.Text = updateSKUs();

            dgTable = getManifestColums();

            dataGridView1.DataSource = dgTable;

            //set version info
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "Pre Alert Manifest Maker " + version;
        }



        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateRaws();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            dataGridView1.ReadOnly = true;

            string fileName;


            fileName = "ePAM_";


            fileName += txtMAWB.Text + "_";
            fileName += DateTime.Now.ToString("yyyyMMddHHmmss");

            saveManifest(fileName);
            MessageBox.Show(fileName + " Saved !");

            btnSave.Enabled = true;
            btnClear.Enabled = true;
            dataGridView1.ReadOnly = false;
        }





        private void txtShipFlight_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
        }

        private void txtPaxCount_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
        }

        private int getNameLength()
        {
            return txtFlight.Text.Length;
        }

        private int getPaxCount()
        {
            if (txtMAWB.Text.Length > 0)
            {
                //return Int32.Parse(txtMWAB.Text);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private void txtChanged()
        {
            if ((getNameLength() > 2) && (getPaxCount() > 0))
            {
                btnGenerate.Enabled = true;
            }
            else
            {
                btnGenerate.Enabled = false;
            }
        }

        private void txtPaxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }









        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }



        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updatePaxCount();
        }

        private void cmbAirline_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMAWB.Text = generateMAWB(airlineList[cmbAirline.SelectedIndex, 2]);
            txtFlight.Text = generateFlight(airlineList[cmbAirline.SelectedIndex, 1]);
        }

        private void txtParcels_TextChanged(object sender, EventArgs e)
        {
            txtSKUs.Text = updateSKUs();
        }

        private void txtItemsPP_TextChanged(object sender, EventArgs e)
        {
            txtSKUs.Text = updateSKUs();
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtParcels_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateNumbers(e);
        }

        private void txtItemsPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateNumbers(e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
