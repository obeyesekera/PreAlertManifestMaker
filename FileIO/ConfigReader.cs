using System;
using System.Data;
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

        public DataTable getTableColums(string cfgFile, int paramCount, int paramID)
        {
            var configReader = new ConfigReader();

            string[,] cfgContents = configReader.readComboCfg(cfgFile, paramCount);

            DataTable table = new DataTable();

            // Read contents
            for (int i = 0; i < cfgContents.GetLength(0); i++)
            {
                string colName = cfgContents[i, paramID];
                if (colName.Trim().Length>0) 
                {
                    table.Columns.Add(colName, typeof(string));
                }
                
            }

            return table;
        }

    }
}
