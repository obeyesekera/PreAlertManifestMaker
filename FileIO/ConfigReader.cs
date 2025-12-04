using System;
using System.IO;

namespace FileIO
{
    public class ConfigReader
    {
        string[,] cfgList;

        public string[,] readComboCfg(string cfgName, int cfgParam)
        {

            int parmCount = cfgParam;
            string[] lineOfContents = File.ReadAllLines(cfgName);
            string[,] cfgContents = new string[lineOfContents.Length, parmCount];
            int i = 0;
            foreach (var line in lineOfContents)
            {
                string[] parVals = line.Split(',');


                for (int j = 0; j < parmCount; j++)
                {
                    cfgContents[i, j] = parVals[j].Trim();
                }

                i++;
            }

            return cfgContents;
        }

    }
}
