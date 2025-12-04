using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class Consignor
    {
        RandomGen randomGen = new RandomGen();
        NameGen nameGen = new NameGen();
        AddressGen addressGen = new AddressGen();
        
        string[,] originList;

        public Consignor(string[,] nList) 
        {
            originList = nList;
        }

        private string rndConsignorType()
        {
            string[] consTypes = { "(PVT) Ltd", "Industries" };

            int rNo = randomGen.randomNumber(0, 1000);
            int index = rNo % 2;
            return consTypes[index];
        }

        public string[] rndConsignorCountry()
        {
            Random r = new Random();
            int i = r.Next(originList.GetLength(0) - 1);
            string[] nCountry = { originList[i, 0], originList[i, 2], originList[i, 4] };
            return nCountry;
        }

        public string rndConsignorName()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndConsignorType());
            return stringBuilder.ToString();
        }

        public string rndConsignorAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomGen.randomNumber(10, 99));
            stringBuilder.Append(" ");
            stringBuilder.Append(nameGen.generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(addressGen.rndAddress1Type());
            return stringBuilder.ToString();
        }

        public string rndConsignorAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(7));
            return stringBuilder.ToString();
        }

        


    }
}
