using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAlertManifestMaker
{
    partial class frmMain
    {
        private string generateMAWB(string airlineCode)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(airlineCode);
            stringBuilder.Append("-");
            stringBuilder.Append(randomNumber(1000000, 9999999)); //7 dgit serial
            stringBuilder.Append("9"); //1 dgit chk digit
            return stringBuilder.ToString();
        }

        private string generateFlight(string flightPrefix) 
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(flightPrefix);
            stringBuilder.Append(randomNumber(100, 999)); //3 dgit serial
            return stringBuilder.ToString();
        }

        private string rndParcelNo(string preFix) 
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("1000");
            stringBuilder.Append(randomNumber(1000, 9999)); 
            return stringBuilder.ToString();
        }

        private string rndBagID() 
        {
            return "";
        }

        private string rndCurrency() 
        {
            Random r = new Random();
            string nCurrency = currencyList[r.Next(currencyList.Length),0];
            return nCurrency;
        }

        private string[] rndParcelTotals() 
        {
            string[] nTotals = {
                randomNumber(10, 99).ToString(), //TotFreight,
                randomNumber(10, 99).ToString(), //TotInsurance,
                randomNumber(0, 99).ToString() //TotGrossWeight
            };

            return nTotals;
        }

        private string rndLVGReg() 
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("LGV");
            stringBuilder.Append("000");
            stringBuilder.Append(randomNumber(1000, 9999));
            return stringBuilder.ToString();
        }

        private string rndConsignorName() 
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndConsignorType());
            return stringBuilder.ToString();
        }

        private string rndConsignorType() 
        {
            string[] consTypes = { "(PVT) Ltd", "Industries" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;
            return consTypes[index];
        }

        private string rndConsignorAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomNumber(10, 99));
            stringBuilder.Append(" ");
            stringBuilder.Append(generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndAddress1Type());
            return stringBuilder.ToString();
        }

        private string rndAddress1Type()
        {
            string[] add1Types = { "Hills", "Point", "Drive", "Place" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 4;
            return add1Types[index];
        }

        private string rndConsignorAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(generateName(7));
            return stringBuilder.ToString();
        }

        private string rndPostalCode()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomNumber(100000, 999999));
            return stringBuilder.ToString();
        }

        private string[] rndConsignorCountry()
        {
            Random r = new Random();
            int i = r.Next(originList.GetLength(0) - 1);
            string[] nCountry = { originList[i, 0], originList[i, 2], originList[i, 4] };
            return nCountry;
        }

        private string[] rndConsigneeCountry()
        {
            Random r = new Random();
            int i = r.Next(destinationList.GetLength(0) - 1);
            string[] nCountry = { destinationList[i, 0], destinationList[i, 2], destinationList[i, 4] };
            return nCountry;
        }

        private string rndConsigneeName()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(generateName(6));
            stringBuilder.Append(" ");
            stringBuilder.Append(rndConsigneeType());
            return stringBuilder.ToString();
        }

        private string rndConsigneeType()
        {
            string[] consTypes = { "Sdn Bhd", "Industries", "Technologies" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 3;
            return consTypes[index];
        }

        private string rndConsigneeAddress1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomNumber(10, 99));
            stringBuilder.Append(" Jalan ");
            stringBuilder.Append(generateName(5));
            return stringBuilder.ToString();
        }


        private string rndConsigneeAddress2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(generateName(5));
            stringBuilder.Append(" ");
            stringBuilder.Append(generateName(6));
            return stringBuilder.ToString();
        }

        private string rndConsignmentNo(string preFix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("10");
            stringBuilder.Append(randomNumber(100000, 999999));
            return stringBuilder.ToString();
        }

        private string rndSKUNo(string preFix)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(preFix);
            stringBuilder.Append("10");
            stringBuilder.Append(randomNumber(100000, 999999));
            return stringBuilder.ToString();
        }

        private string[] rndHSCode()
        {
            Random r = new Random();
            int i = r.Next(HSList.GetLength(0) - 1);
            string[] nHS = { HSList[i, 0], HSList[i, 1] };
            return nHS;
        }

        private string rndQuantity()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomNumber(10, 99));
            return stringBuilder.ToString();
        }
        private string rndUnitValue()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(randomNumber(100, 999));
            return stringBuilder.ToString();
        }


        public static string generateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        private string rndGender()
        {
            string[] genders = { "M", "F" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;
            return genders[index];
        }

        private string rndDOB()
        {
            DateTime start = new DateTime(1945, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndExpiryDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private Random gen = new Random();

        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private readonly Random _random = new Random();


        private string rndTravelDoc(string prefix)
        {
            var tdBuilder = new StringBuilder();
            tdBuilder.Append(prefix);
            tdBuilder.Append(randomNumber(10000, 99999));

            return tdBuilder.ToString();
        }

        private DataRow rndCountry()
        {

            Random r = new Random();
            int rInt = r.Next(1, dtCountry.Rows.Count);

            DataRow countryRow = dtCountry.Rows[rInt];

            return countryRow;
        }



        private DataRow rndDocType()
        {

            Random r = new Random();
            int rInt = r.Next(1, dtDocType.Rows.Count);

            DataRow docTypeRow = dtDocType.Rows[rInt];

            return docTypeRow;
        }
    }
}
