using FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class ForwardingAgent
    {

        RandomGen randomGen = new RandomGen();
        NameGen nameGen = new NameGen();
        AddressGen addressGen = new AddressGen();
        ConfigReader configReader = new ConfigReader();

        string[,] destinationList;
        string[,] OrgTypesList;

        public ForwardingAgent(string[,] nList)
        {
            destinationList = nList;
            loadOrganizationTypes("OrganizationTypes.cfg");
        }

        private void loadOrganizationTypes(string cfgFile)
        {
            OrgTypesList = configReader.readComboCfg(cfgFile, 1);
        }


        private string rndAgentType()
        {
            string[] agentTypes = { "Sdn Bhd", "Industries" };

            int rNo = randomGen.randomNumber(0, 1000);
            int index = rNo % 2;
            return agentTypes[index];
        }

        public string[] rndAgentCountry()
        {
            Random r = new Random();
            int i = r.Next(destinationList.GetLength(0) - 1);
            string[] nCountry = { destinationList[i, 0], destinationList[i, 2], destinationList[i, 4] };
            return nCountry;
        }

        public string rndAgentName()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndAgentType());
            return stringBuilder.ToString();
        }

        public string rndAgentAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomGen.randomNumber(10, 99));
            stringBuilder.Append(" Jalan ");
            stringBuilder.Append(nameGen.generateName(5));
            return stringBuilder.ToString();
        }

        public string rndAgentAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(nameGen.generateName(6));
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
