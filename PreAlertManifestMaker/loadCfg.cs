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
        string[,] currencyList;
        string[,] HSList;
        string[,] row2List;


        private void fillClientComboBox(string cfgFile)
        {
            clientList = readComboCfg(cfgFile, 2);

            for (int i = 0; i < clientList.GetLength(0); i++)
            {
                cmbClient.Items.Add(clientList[i, 0]);
            }

            cmbClient.SelectedIndex = 0;
        }

        private void fillAirlineComboBox(string cfgFile)
        {
            airlineList = readComboCfg(cfgFile, 3);

            for (int i = 0; i < airlineList.GetLength(0); i++)
            {
                cmbAirline.Items.Add(airlineList[i, 0]);
            }

            cmbAirline.SelectedIndex = 0;

        }

        private void fillDestinationComboBox(string cfgFile)
        {
            destinationList = readComboCfg(cfgFile, 6);

            for (int i = 0; i < destinationList.GetLength(0); i++)
            {
                cmbDestination.Items.Add(destinationList[i, 3]);
            }

            cmbDestination.SelectedIndex = 0;
        }
        private void fillOriginComboBox(string cfgFile)
        {
            originList = readComboCfg(cfgFile, 6);

            for (int i = 0; i < originList.GetLength(0); i++)
            {
                cmbOrigin.Items.Add(originList[i, 3]);
            }

            cmbOrigin.SelectedIndex = 0;
        }

        private void loadHS(string cfgFile)
        {
            HSList = readComboCfg(cfgFile, 2);
        }

        private void loadCurrency(string cfgFile)
        {
            currencyList = readComboCfg(cfgFile, 1);
        }

        private void loadRow2(string cfgFile)
        {
            row2List = readComboCfg(cfgFile, 1);
        }



        private string[,] readComboCfg(string cfgName, int cfgParam)
        {

            int parmCount = cfgParam;
            string[] lineOfContents = File.ReadAllLines(cfgName);
            string[,] cfgContents = new string[lineOfContents.Length, parmCount];
            int i = 0;
            foreach (var line in lineOfContents)
            {
                string[] parVals = line.Split(',');


                for (int j = 0; j < parmCount; j++)
                {
                    cfgContents[i, j] = parVals[j].Trim();
                }

                i++;
            }

            return cfgContents;
        }
    }
}
