using FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class OverseasTrader
    {
        RandomGen randomGen = new RandomGen();
        NameGen nameGen = new NameGen();
        AddressGen addressGen = new AddressGen();
        ConfigReader configReader = new ConfigReader();

        string[,] originList;
        string[,] OrgTypesList;


        public OverseasTrader(string[,] nList) 
        {
            originList = nList;
            loadOrganizationTypes("OrganizationTypes.cfg");
        }

        private void loadOrganizationTypes(string cfgFile)
        {
            OrgTypesList = configReader.readComboCfg(cfgFile, 1);
        }

        private string rndTraderType()
        {
            string[] consTypes = { "(PVT) Ltd", "Industries" };

            int rNo = randomGen.randomNumber(0, 1000);
            int index = rNo % 2;
            return consTypes[index];
        }

        public string[] rndTraderCountry()
        {
            Random r = new Random();
            int i = r.Next(originList.GetLength(0) - 1);
            string[] nCountry = { originList[i, 0], originList[i, 2], originList[i, 4] };
            return nCountry;
        }

        public string rndTraderName()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndTraderType());
            return stringBuilder.ToString();
        }

        public string rndTraderAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomGen.randomNumber(10, 99));
            stringBuilder.Append(" ");
            stringBuilder.Append(nameGen.generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(addressGen.rndAddress1Type());
            return stringBuilder.ToString();
        }

        public string rndTraderAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(7));
            return stringBuilder.ToString();
        }

        public string rndOrganizationType() 
        {
            Random r = new Random();
            string nOrgType = OrgTypesList[r.Next(OrgTypesList.Length), 0];
            return nOrgType;
        }


    }
}
