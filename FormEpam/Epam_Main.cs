using DataGen;
using FileIO;
using System;
using System.Data;
using System.Net;

namespace FormEpam
{
    public class Epam_Main
    {
        MawbGen mawbGen = new MawbGen();
        ParcelGen parcelGen = new ParcelGen();
        AddressGen addressGen = new AddressGen();
        OverseasTrader overseasTrader;// = new Consigner(originList);
        LocalTrader localTrader;// = new Consignee();
        Consignment consignment;// = new Consignment();
        
        public Epam_Main()
        {
            
        }


        public Epam_Main(string[,] originList, string[,] destinationList) 
        {
            overseasTrader = new OverseasTrader(originList);
            localTrader = new LocalTrader(destinationList);
            consignment = new Consignment();
        }

        

        public string getMawbNo(string airlineCode)
        {
            string mawbNo = mawbGen.generateMAWB(airlineCode);
            return mawbNo;
        }

        public string getFlightNo(string flightPrefix)
        {
            string flightNo = mawbGen.generateFlight(flightPrefix);
            return flightNo;
        }

        

        public string getParcelNo(string parcelPrefix) 
        { 
            string parcelNo = parcelGen.rndParcelNo(parcelPrefix);
            return parcelNo;
        }

        public string[] getParcel(int parcelNoSeq, string parcelNo, string[] nMAWB, bool cbDR, int drWeight) 
        {
            string[] nTotals = parcelGen.rndParcelTotals(cbDR, drWeight);

            string[] nParcel = {
                parcelNo,
                parcelNoSeq.ToString(), //BagID(),
                nMAWB[3].Substring(0,2), //Origin
                nMAWB[4].Substring(0,2), //Destination
                parcelGen.rndCurrency(),
                nTotals[0], //TotFreight,
                nTotals[1], //TotInsurance,
                nTotals[2], //TotGrossWeight
                parcelGen.rndLVGReg()
            };

            return nParcel;
        }

        public string[] addEpamConsignor()
        {
            string[] nCountry = overseasTrader.rndTraderCountry();
            string[] nConsignor = {
                overseasTrader.rndTraderName(), //"Consignor Name *", 
                overseasTrader.rndTraderAddress1(), //"Consignor Address 1 *",
                overseasTrader.rndTraderAddress2(), //"Consignor Address 2",
                addressGen.rndPostalCode(), //"Consignor Postcode ",
                nCountry[1], //"Consignor City ",
                nCountry[2], //"Consignor State ",
                nCountry[0] //"Consignor Country *"
            };

            return nConsignor;
        }

        public string[] addEpamConsignee()
        {
            string[] nCountry = localTrader.rndTraderCountry();
            string[] nConsignee = {
                localTrader.rndTraderName(), //"Consignee Name *",
                localTrader.rndTraderAddress1(), //"Consignee Address 1 *",
                localTrader.rndTraderAddress2(), //"Consignee Address 2",
                addressGen.rndPostalCode(), //"Consignee Postcode",
                nCountry[1], //"Consignee City",
                nCountry[2], //"Consignee State",
                nCountry[0] //"Consignee Country *"
            };

            return nConsignee;
        }

        public string[] addItem(string consignmentNo, string SKUNo, bool cbDR, int drValue, int itemsPP)
        {
            string consignmentPrefix = "CN";
            string SKUPrefix = "SKU";

            if (consignmentNo == "")
            {
                consignmentNo = consignment.rndConsignmentNo(consignmentPrefix);
                SKUNo = consignment.rndSKUNo(SKUPrefix);
            }

            int consignmentNoSeq = Int32.Parse(consignmentNo.Substring(2));
            int SKUNoSeq = Int32.Parse(SKUNo.Substring(3));

            string[] nHS = consignment.rndHSCode();

            string quantity = consignment.rndQuantity(cbDR);
            string unitValue = consignment.rndUnitValue(quantity, cbDR, drValue, itemsPP);

            string[] nItem = {
                consignmentNo, //"Consignment Note *", 
                SKUNo, //"Goods SKU *",
                nHS[1], //"Description of Goods *",
                quantity, //"Quantity *",
                unitValue, //"Item Value Per Unit *",
                nHS[0] //"HS Code *"
            };

            consignmentNo = consignmentPrefix + (consignmentNoSeq + 1).ToString();
            SKUNo = SKUPrefix + (SKUNoSeq + 1).ToString();

            return nItem;

        }

    }
}
