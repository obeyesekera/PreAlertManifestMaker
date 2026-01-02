using System;
using System.Data;
using DataGen;
using FileIO;

namespace FormK2
{
    public class K2_Main
    {
        MawbGen mawbGen = new MawbGen();
        ParcelGen parcelGen = new ParcelGen();
        AddressGen addressGen = new AddressGen();
        OverseasTrader overseasTrader;
        LocalTrader localTrader;
        ForwardingAgent forwardingAgent;

        public K2_Main()
        {

        }

        
        string[,] row1List;
        string[,] row2List;

        public string getFormLinkageID(string airlineCode)
        {
            string formLinkageID = mawbGen.generateFormLinkageID(airlineCode);
            return formLinkageID;
        }

        public string getHawbNo(string airlineCode)
        {
            string hawbNo = parcelGen.rndParcelNo(airlineCode);
            return hawbNo;
        }

        public string[] getMarketingLine() 
        {
            string[] nMarketingLine = {
                "GATEWAY",                              //Marking Line 1
                "",                                     //Marking Line 2
                "",                                     //Marking Line 3
                "",                                     //Marking Line 4
                "",                                     //Marking Line 5
                "",                                     //Marking Line 6
                "",                                     //Marking Line 7
                "",                                     //Marking Line 8
                "",                                     //Marking Line 9
                "",                                     //Marking Line 10
            };

            return nMarketingLine;
        }

        public string[] getMainParcel() 
        {
            string[] nMainParcel = {
                "2.75",                                 //Gross Weight *
                "KGM - KILOGRAM",                       //Weight Unit *
                "0.000",                                //"Volume"
                "KGM - KILOGRAM",                       //"Volume Unit"
                "1",                                    //Number of Package *
                "CT - CARTON",                          //Packaging Type *
                "PAPER AND FIBERBOARD",                 //Packing Material *
                "O - OTHERS",                           //Cargo Class *
                "PERSONAL PURCHASES",                   //Cargo Description 1 *
                ""                                      //Cargo Description 2
            };

            return nMainParcel;
        }

        public string[] getMainInvoice() 
        {
            string[] nMainInvoice = {
                "32851115065",	                        //Invoice No *
                "22/10/2025",	                        //"Invoice Date *
                "150",	                                //"Invoice Value *
                "MYR",	                                //Invoice Currency *
                "1.0000",	                                //Exchange Rate *
                "",	                                    //Invoice Value in MYR
                "150",	                                //Amount Received *
                "MYR",	                                //Amount Received Currency *
                "FOB",	                                //Inco Term *
                "MY",	                                //Country To Pay *
                "SG"	                                //Final Destination *
            };

            return nMainInvoice;
        }


        public string[] getMainCharges() 
        {
            string[] nMainCharges = {
                "",	//Terminal Charges
                "180",	//Freight Charges *
                "MYR",	//Freight Currency *
                "1.0000",	//Freight Exchange Rate *
                "",	//Insurance Charges *
                "MYR",	//Insurance Currency *
                "1.0000",	//Insurance Exchange Rate *
                "",	//Other Charges 
                "",	//Other Charges Currency
                ""	//Other Charges Exchange Rate
            };

            return nMainCharges;
        }

        public string[] getMainConsignor() {

            string[] nCountry = localTrader.rndTraderCountry();
            string[] nMainConsignor = {
                localTrader.rndTraderName(), //Consignor Name *
                localTrader.rndTraderAddress1(), //Consignor Address 1 *
                localTrader.rndTraderAddress2(), //Consignor Address 2
                addressGen.rndPostalCode(), //Consignor Postcode
                nCountry[1], //Consignor City
                nCountry[2], //Consignor State
                nCountry[0] //Consignor Country *
            };

            return nMainConsignor;
        }

        public string[] getMainConsignee()
        {
            string[] nCountry = overseasTrader.rndTraderCountry();
            string[] nMainConsignee = {
                overseasTrader.rndTraderName(), //Consignee Name *
                overseasTrader.rndTraderAddress1(), //Consignee Address 1 *
                overseasTrader.rndTraderAddress2(), //Consignee Address 2
                addressGen.rndPostalCode(), //Consignee Postcode
                nCountry[1], //Consignee City
                nCountry[2], //Consignee State
                nCountry[0], //Consignee Country *
                overseasTrader.rndOrganizationType(), //Consignee Organisation Type *
                "1271940-D", //Consignee Reg. No. *
                "W24-1901-32000008" //Consignee SST Reg. No. *

            };
            return nMainConsignee;
        }

        public string[] getMainForwardingAgent() 
        {
            string[] nCountry = forwardingAgent.rndAgentCountry();
            string[] nMainForwardingAgent = {
                forwardingAgent.rndAgentName(), //Forwarding Agent Name *
                forwardingAgent.rndAgentAddress1(), //Forwarding Agent Address 1 *
                forwardingAgent.rndAgentAddress2(), //Forwarding Agent Address 2
                addressGen.rndPostalCode(), //Forwarding Agent Postcode *
                nCountry[1], //Forwarding Agent City *
                nCountry[2], //Forwarding Agent State *
                nCountry[0], //Forwarding Agent Country *
                forwardingAgent.rndOrganizationType(), //Forwarding Agent Organization Type *
                "1271940-D", //Forwarding Agent Organization Reg. No. *
                "WF0824", //Forwarding Agent Customs Reg. Code *
                "W24-1901-32000008" //Forwarding Agent SST Reg. No. *
            };

            return nMainForwardingAgent;
        }

        public string[] getMainShippingAgent() 
        { 
            string[] nMainShippingAgent = {
                "", //Shipping Agent Name(SEA TRANSPORT ONLY)
                "", //Shipping Agent Address 1(SEA TRANSPORT ONLY)
                "", //Shipping Agent Address 2(SEA TRANSPORT ONLY)
                "", //Shipping Agent Postcode(SEA TRANSPORT ONLY)
                "", //Shipping Agent City(SEA TRANSPORT ONLY)
                "", //Shipping Agent State(SEA TRANSPORT ONLY)
                "", //Shipping Agent Country(SEA TRANSPORT ONLY)
                "", //Shipping Agent Customs Reg No(SEA TRANSPORT ONLY)
            };
            return nMainShippingAgent;

        }


    }
}
