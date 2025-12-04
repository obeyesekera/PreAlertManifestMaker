using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class AddressGen
    {
        RandomGen randomGen = new RandomGen();

        public string rndAddress1Type()
        {
            string[] add1Types = { "Hills", "Point", "Drive", "Place" };

            int rNo = randomGen.randomNumber(0, 1000);
            int index = rNo % 4;
            return add1Types[index];
        }

        public string rndPostalCode()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomGen.randomNumber(10000, 99999));
            return stringBuilder.ToString();
        }
    }
}
