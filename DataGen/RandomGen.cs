using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen
{
    internal class RandomGen
    {
        private readonly Random _random = new Random();

        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
