using System;
using System.Data;
using FileIO;

namespace FormK2
{
    public class K2_Main
    {
        string[,] row1List;
        string[,] row2List;

        private void loadRow2(string cfgFile)
        {
            //row2List = readComboCfg(cfgFile, 1);
        }

        public DataTable getTableColumsK2Main()
        {
            var configReader = new ConfigReader();

            string cfgFile = "K2MainRow1.cfg"; // file path
            int paramCount = 1; // parameter count

            string[,] cfgContents = configReader.readComboCfg(cfgFile, paramCount);

            DataTable table = new DataTable();

            // Read contents
            for (int i = 0; i < cfgContents.GetLength(0); i++)
            {
                table.Columns.Add(cfgContents[i,0], typeof(string));
            }

            return table;
        }
    }
}
