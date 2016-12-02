using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseResults
{
    class Program
    {
        static string _filePath = @"\\LQS-HAIZZH-01\BigDataShareFolder\RISSourceFolder";
        static void Main(string[] args)
        {
            ParseHelper ph = new ParseHelper(@"‪Desktop_Th_Redstone.csv");
            CSVParser cp = new CSVParser();

            ph.ParseFileHandle += cp.ParseFile;

            ph.ParseHandle += cp.Parse;
            ph.ParseEachLine();
            // Parse(cp.entryList);
        }


    }
}
