
namespace PreAlertManifestMaker
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            dataGridView1 = new System.Windows.Forms.DataGridView();
            btnGenerate = new System.Windows.Forms.Button();
            lblName = new System.Windows.Forms.Label();
            txtFlight = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtMAWB = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lblRows = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtParcels = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtItemsPP = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            cmbClient = new System.Windows.Forms.ComboBox();
            cmbDestination = new System.Windows.Forms.ComboBox();
            cmbAirline = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            cmbOrigin = new System.Windows.Forms.ComboBox();
            dtpDeparture = new System.Windows.Forms.DateTimePicker();
            dtpArrival = new System.Windows.Forms.DateTimePicker();
            label10 = new System.Windows.Forms.Label();
            txtSKUs = new System.Windows.Forms.TextBox();
            btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(11, 183);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new System.Drawing.Size(1296, 603);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new System.Drawing.Point(1331, 383);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(159, 73);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(266, 72);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(56, 25);
            lblName.TabIndex = 3;
            lblName.Text = "Flight";
            // 
            // txtFlight
            // 
            txtFlight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFlight.Location = new System.Drawing.Point(343, 70);
            txtFlight.Name = "txtFlight";
            txtFlight.Size = new System.Drawing.Size(150, 31);
            txtFlight.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(266, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 25);
            label2.TabIndex = 5;
            label2.Text = "MAWB";
            // 
            // txtMAWB
            // 
            txtMAWB.Location = new System.Drawing.Point(343, 25);
            txtMAWB.Name = "txtMAWB";
            txtMAWB.Size = new System.Drawing.Size(150, 31);
            txtMAWB.TabIndex = 6;
            txtMAWB.KeyPress += txtPaxCount_KeyPress;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(1331, 505);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(159, 73);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(500, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 25);
            label1.TabIndex = 10;
            label1.Text = "Origin";
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new System.Drawing.Point(21, 147);
            lblRows.Name = "lblRows";
            lblRows.Size = new System.Drawing.Size(54, 25);
            lblRows.TabIndex = 12;
            lblRows.Text = "Rows";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(500, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(102, 25);
            label3.TabIndex = 13;
            label3.Text = "Destination";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(769, 72);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 25);
            label4.TabIndex = 17;
            label4.Text = "Arrival";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(769, 23);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(91, 25);
            label5.TabIndex = 15;
            label5.Text = "Departure";
            // 
            // txtParcels
            // 
            txtParcels.Location = new System.Drawing.Point(1270, 20);
            txtParcels.Name = "txtParcels";
            txtParcels.Size = new System.Drawing.Size(74, 31);
            txtParcels.TabIndex = 19;
            txtParcels.TextChanged += txtParcels_TextChanged;
            txtParcels.KeyPress += txtParcels_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(1183, 25);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 25);
            label6.TabIndex = 20;
            label6.Text = "Parcels";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(1183, 77);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(86, 25);
            label7.TabIndex = 22;
            label7.Text = "Items(PP)";
            // 
            // txtItemsPP
            // 
            txtItemsPP.Location = new System.Drawing.Point(1270, 72);
            txtItemsPP.Name = "txtItemsPP";
            txtItemsPP.Size = new System.Drawing.Size(74, 31);
            txtItemsPP.TabIndex = 21;
            txtItemsPP.TextChanged += txtItemsPP_TextChanged;
            txtItemsPP.KeyPress += txtItemsPP_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(14, 18);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 25);
            label8.TabIndex = 23;
            label8.Text = "Client";
            // 
            // cmbClient
            // 
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new System.Drawing.Point(91, 17);
            cmbClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new System.Drawing.Size(150, 33);
            cmbClient.TabIndex = 25;
            cmbClient.SelectedIndexChanged += cmbClient_SelectedIndexChanged;
            // 
            // cmbDestination
            // 
            cmbDestination.FormattingEnabled = true;
            cmbDestination.Location = new System.Drawing.Point(600, 67);
            cmbDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbDestination.Name = "cmbDestination";
            cmbDestination.Size = new System.Drawing.Size(150, 33);
            cmbDestination.TabIndex = 26;
            // 
            // cmbAirline
            // 
            cmbAirline.FormattingEnabled = true;
            cmbAirline.Location = new System.Drawing.Point(91, 67);
            cmbAirline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbAirline.Name = "cmbAirline";
            cmbAirline.Size = new System.Drawing.Size(150, 33);
            cmbAirline.TabIndex = 28;
            cmbAirline.SelectedIndexChanged += cmbAirline_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(14, 68);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(61, 25);
            label9.TabIndex = 27;
            label9.Text = "Airline";
            // 
            // cmbOrigin
            // 
            cmbOrigin.FormattingEnabled = true;
            cmbOrigin.Location = new System.Drawing.Point(600, 20);
            cmbOrigin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbOrigin.Name = "cmbOrigin";
            cmbOrigin.Size = new System.Drawing.Size(150, 33);
            cmbOrigin.TabIndex = 29;
            // 
            // dtpDeparture
            // 
            dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDeparture.Location = new System.Drawing.Point(860, 18);
            dtpDeparture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpDeparture.Name = "dtpDeparture";
            dtpDeparture.Size = new System.Drawing.Size(284, 31);
            dtpDeparture.TabIndex = 30;
            // 
            // dtpArrival
            // 
            dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpArrival.Location = new System.Drawing.Point(860, 63);
            dtpArrival.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpArrival.Name = "dtpArrival";
            dtpArrival.Size = new System.Drawing.Size(284, 31);
            dtpArrival.TabIndex = 31;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(1401, 27);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(52, 25);
            label10.TabIndex = 33;
            label10.Text = "SKUs";
            // 
            // txtSKUs
            // 
            txtSKUs.Location = new System.Drawing.Point(1401, 70);
            txtSKUs.Name = "txtSKUs";
            txtSKUs.Size = new System.Drawing.Size(74, 31);
            txtSKUs.TabIndex = 32;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(1331, 632);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(159, 73);
            btnClear.TabIndex = 34;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1530, 798);
            Controls.Add(btnClear);
            Controls.Add(label10);
            Controls.Add(txtSKUs);
            Controls.Add(dtpArrival);
            Controls.Add(dtpDeparture);
            Controls.Add(cmbOrigin);
            Controls.Add(cmbAirline);
            Controls.Add(label9);
            Controls.Add(cmbDestination);
            Controls.Add(cmbClient);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtItemsPP);
            Controls.Add(label6);
            Controls.Add(txtParcels);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(lblRows);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(txtMAWB);
            Controls.Add(label2);
            Controls.Add(txtFlight);
            Controls.Add(lblName);
            Controls.Add(btnGenerate);
            Controls.Add(dataGridView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            Text = "Pre Alert Manifest Maker v1";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFlight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMAWB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtParcels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtItemsPP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.ComboBox cmbAirline;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbOrigin;
        private System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.DateTimePicker dtpArrival;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSKUs;
        private System.Windows.Forms.Button btnClear;
    }
}

