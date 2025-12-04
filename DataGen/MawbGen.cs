using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class MawbGen
    {
        RandomGen randomGen = new RandomGen();

        public string generateMAWB(string airlineCode)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(airlineCode);
            stringBuilder.Append("-");
            int serial = randomGen.randomNumber(1000000, 9999999);
            stringBuilder.Append(serial); //7 dgit serial
            int chkDigit = serial % 7;
            stringBuilder.Append(chkDigit); //1 dgit chk digit
            return stringBuilder.ToString();
        }

        public string generateFlight(string flightPrefix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(flightPrefix);
            stringBuilder.Append(randomGen.randomNumber(100, 999)); //3 dgit serial
            return stringBuilder.ToString();
        }
    }
}
