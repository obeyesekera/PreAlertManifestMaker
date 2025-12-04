using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class Consignee
    {
        RandomGen randomGen = new RandomGen();
        NameGen nameGen = new NameGen();
        AddressGen addressGen = new AddressGen();


        string[,] destinationList;

        public Consignee(string[,] nList)
        {
            destinationList = nList;
        }


        private string rndConsigneeType()
        {
            string[] consTypes = { "Sdn Bhd", "Industries", "Technologies" };

            int rNo = randomGen.randomNumber(0, 1000);
            int index = rNo % 3;
            return consTypes[index];
        }

        public string[] rndConsigneeCountry()
        {
            Random r = new Random();
            int i = r.Next(destinationList.GetLength(0) - 1);
            string[] nCountry = { destinationList[i, 0], destinationList[i, 2], destinationList[i, 4] };
            return nCountry;
        }

        public string rndConsigneeName()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndConsigneeType());
            return stringBuilder.ToString();
        }

        public string rndConsigneeAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomGen.randomNumber(10, 99));
            stringBuilder.Append(" Jalan ");
            stringBuilder.Append(nameGen.generateName(5));
            return stringBuilder.ToString();
        }

        public string rndConsigneeAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameGen.generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(nameGen.generateName(6));
            return stringBuilder.ToString();
        }


    }
}
