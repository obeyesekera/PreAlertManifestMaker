using FileIO;
using System;
using System.Text;

namespace DataGen
{
    public class ParcelGen
    {
        string[,] currencyList;

        RandomGen randomGen = new RandomGen();

        ConfigReader configReader = new ConfigReader();

        public ParcelGen()
        {
            loadCurrency("currency.cfg");
        }

        private void loadCurrency(string cfgFile)
        {
            currencyList = configReader.readComboCfg(cfgFile, 1);
        }

        public string rndCurrency()
        {
            Random r = new Random();
            string nCurrency = currencyList[r.Next(currencyList.Length), 0];
            return nCurrency;
        }

        public string rndParcelNo(string preFix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("1000");
            stringBuilder.Append(randomGen.randomNumber(1000, 9999));
            return stringBuilder.ToString();
        }


        public string[] rndParcelTotals(bool cbDR, int drWeight)
        {
            string[] nTotals;

            if (cbDR)
            {
                nTotals = new string[]{
                    randomGen.randomNumber(10, 25).ToString(), //TotFreight,
                    randomGen.randomNumber(10, 25).ToString(), //TotInsurance,
                    randomGen.randomNumber(10, drWeight).ToString() //TotGrossWeight
                };
            }
            else
            {
                nTotals = new string[]{
                    randomGen.randomNumber(10, 99).ToString(), //TotFreight,
                    randomGen.randomNumber(10, 99).ToString(), //TotInsurance,
                    randomGen.randomNumber(10, 99).ToString() //TotGrossWeight
                };
            }

            return nTotals;
        }

        public string rndLVGReg()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("LGV");
            stringBuilder.Append("000");
            stringBuilder.Append(randomGen.randomNumber(1000, 9999));
            return stringBuilder.ToString();
        }
    }
}
