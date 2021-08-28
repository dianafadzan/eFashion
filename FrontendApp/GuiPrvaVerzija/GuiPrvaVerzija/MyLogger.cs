using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;


namespace GuiPrvaVerzija
{
    public class MyLogger
    {
        private static string filePath = "MyLogs.txt";
        public static void log(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("-----------------------------------------------\n");
            sb.Append("                 New Log                       \n");
            sb.Append("-----------------------------------------------\n");
            sb.Append(ex.ToString()+"/n");
           
            File.AppendAllText(filePath , sb.ToString());
            sb.Clear();
        }
    }
}
