using FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    public class Consignment
    {
        RandomGen randomGen = new RandomGen();
        ConfigReader configReader = new ConfigReader();

        string[,] HSList;
        
        public Consignment() 
        {
            loadHS("HS.cfg");
        }

        private void loadHS(string cfgFile)
        {
            HSList = configReader.readComboCfg(cfgFile, 2);
        }

        public string rndConsignmentNo(string preFix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("10");
            stringBuilder.Append(randomGen.randomNumber(100000, 999999));
            return stringBuilder.ToString();
        }

        public string rndSKUNo(string preFix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("10");
            stringBuilder.Append(randomGen.randomNumber(100000, 999999));
            return stringBuilder.ToString();
        }

        public string[] rndHSCode()
        {
            Random r = new Random();
            int i = r.Next(HSList.GetLength(0) - 1);
            string[] nHS = { HSList[i, 0], HSList[i, 1] };
            return nHS;
        }

        public string rndQuantity(bool cbDR)
        {
            var stringBuilder = new StringBuilder();
            if (cbDR)
            {
                stringBuilder.Append(randomGen.randomNumber(1, 5));
            }
            else
            {
                stringBuilder.Append(randomGen.randomNumber(10, 99));
            }

            return stringBuilder.ToString();
        }
        public string rndUnitValue(string quantity,bool cbDR, int drValue, int itemsPP)
        {
            var stringBuilder = new StringBuilder();
            if (cbDR)
            {
                int totParcelValue = drValue - 50;
                int maxItemTotal = totParcelValue / itemsPP;
                int maxItemValue = maxItemTotal / Int32.Parse(quantity);
                if (maxItemValue <= 1)
                {
                    stringBuilder.Append(1);
                }
                else
                {
                    stringBuilder.Append(randomGen.randomNumber(1, maxItemValue));
                }

            }
            else
            {
                stringBuilder.Append(randomGen.randomNumber(100, 999));
            }

            return stringBuilder.ToString();
        }
    }
}
