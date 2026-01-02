using DataGen;
using FormK2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ExcelApp = Microsoft.Office.Interop.Excel;

namespace PreAlertManifestMaker
{
    partial class frmMain
    {
        //K2_Main k2_Main = new K2_Main();

        private void createK2(int parcelCount, int itemsPP)
        {
            string[] nMainShipment = {
                k2_Main.getFormLinkageID(airlineList[cmbAirline.SelectedIndex, 2]),    //Form Linkage ID *
                "AIR TRANSPORT",        //Transport Mode *
                "FULL SHIPMENT",        //Shipment Type *
                "0001 - NORMAL EXPORT", //Declaration Type *
                "W20",                  //Customs Submission Station *
                "KLIAS",                //Terminal Operator ID *
                dtpDeparture.Text,      //Departure Date *
                originList[cmbOrigin.SelectedIndex,0]+originList[cmbOrigin.SelectedIndex,2],                        //Origin Port *
                destinationList[cmbDestination.SelectedIndex,0]+destinationList[cmbDestination.SelectedIndex,2],    //Destination Port *
                originList[cmbVia.SelectedIndex,0]+destinationList[cmbVia.SelectedIndex,2]                          //Via Port
            };


            string[] nMainMawb = {
                clientList[cmbClient.SelectedIndex,0],  //Client Name *
                txtFlight.Text,                         //"Flight No. (AIR TRANSPORT ONLY)"
                "",                                     //"Voyage No (SEA TRANSPORT ONLY)"
                txtMAWB.Text,                           //"MAWB No (AIR TRANSPORT ONLY)"
                "",                                     //"HAWB No(AIR TRANSPORT ONLY)"
                "",                                     //"Booking Ref No (SEA TRANSPORT ONLY)"
                "",                                     //"Ship Call Number (SEA TRANSPORT ONLY)"
                "",                                     //"Vessel ID (SEA TRANSPORT ONLY)"
                "",                                     //"Vessel Name (SEA TRANSPORT ONLY)"
                "",                                     //"Vehicle No. 1 (ROAD TRANSPORT ONLY)"
                "",                                     //"Vehicle No. 2 (ROAD TRANSPORT ONLY)"
                ""                                      //"Shipment Details Invoice No.(ROAD TRANSPORT ONLY)"
            };

            string[] nMarketingLine = k2_Main.getMarketingLine();

            string[] nMainParcel = k2_Main.getMainParcel();

            string[] nMainInvoice = k2_Main.getMainInvoice();

            string[] nMainCharges = k2_Main.getMainCharges();

            string[] nMainConsignor = k2_Main.getMainConsignor();

            string[] nMainConsignee = k2_Main.getMainConsignee();

            string[] nMainForwardingAgent = k2_Main.getMainForwardingAgent();

            string[] nMainShippingAgent = k2_Main.getMainShippingAgent();

            string[] nMainExcemtion = {

            };

            string[] nMainClause = {

            };



            string parcelNo = "";

            for (int i = 0; i < parcelCount; i++)
            {
                parcelNo = addK2Parcels(itemsPP, parcelNo, nMainShipment, nMainMawb);
            }
        }

        private string addK2Parcels(int itemsPP, string parcelNo, string[] nMainShipment, string[] nMainParcel) 
        {
            return "";
        }



    }
}
