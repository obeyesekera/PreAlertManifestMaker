using FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreAlertManifestMaker
{
    partial class frmMain 
    {
        string[,] clientList;
        string[,] airlineList;
        string[,] destinationList;
        string[,] originList;
        string[,] viaList;
        //string[,] currencyList;
        //string[,] HSList;
        string[,] row2List;
        string[,] formList;

        ConfigReader configReader = new ConfigReader();

        


        private void fillFormsComboBox(string cfgFile)
        {
            formList = configReader.readComboCfg(cfgFile, 1);

            for (int i = 0; i < formList.GetLength(0); i++)
            {
                cmbForm.Items.Add(formList[i, 0]);
            }

            cmbForm.SelectedIndex = 0;
        }


        private void fillClientComboBox(string cfgFile)
        {
            clientList = configReader.readComboCfg(cfgFile, 2);
            
            for (int i = 0; i < clientList.GetLength(0); i++)
            {
                cmbClient.Items.Add(clientList[i, 0]);
            }

            cmbClient.SelectedIndex = 0;
        }

        private void fillAirlineComboBox(string cfgFile)
        {
            airlineList = configReader.readComboCfg(cfgFile, 3);
            
            for (int i = 0; i < airlineList.GetLength(0); i++)
            {
                cmbAirline.Items.Add(airlineList[i, 0]);
            }

            cmbAirline.SelectedIndex = 0;

        }

        private void fillDestinationComboBox(string cfgFile)
        {
            destinationList = configReader.readComboCfg(cfgFile, 6);

            cmbDestination.Items.Clear();

            for (int i = 0; i < destinationList.GetLength(0); i++)
            {
                cmbDestination.Items.Add(destinationList[i, 3]);
            }

            cmbDestination.SelectedIndex = 0;
        }
        private void fillOriginComboBox(string cfgFile)
        {
            originList = configReader.readComboCfg(cfgFile, 6);

            cmbOrigin.Items.Clear();

            for (int i = 0; i < originList.GetLength(0); i++)
            {
                cmbOrigin.Items.Add(originList[i, 3]);
            }

            cmbOrigin.SelectedIndex = 0;
        }

        private void fillViaComboBox(string cfgFile)
        {
            viaList = configReader.readComboCfg(cfgFile, 6);

            cmbVia.Items.Clear();

            for (int i = 0; i < viaList.GetLength(0); i++)
            {
                cmbVia.Items.Add(viaList[i, 3]);
            }

            cmbVia.SelectedIndex = 0;
        }



        //private void loadCurrency(string cfgFile)
        //{
        //    currencyList = configReader.readComboCfg(cfgFile, 1);
        //}

        private void loadRow2(string cfgFile)
        {
            row2List = configReader.readComboCfg(cfgFile, 1);
        }

    }
}
