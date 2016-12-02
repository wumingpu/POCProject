using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseResults
{
    public class ParseHelper
    {
        public delegate void ParseFile(
           string currentLineStr, int lineIndex, string lastNotEmptyLines, int lastNotEmptyIndex);

        public delegate void Parse();
        /// <summary>
        /// The event can monitor which node have registered it.
        /// </summary>
        /// <returns></returns>
        public ParseFile ParseFileHandle { get; set; }

        /// <summary>
        ///  event.
        /// </summary>
        public event Parse ParseHandle;

        /// <summary>
        /// the file path which need to be parsed.
        /// </summary>
        public string pathFilePath { get; set; }

        /// <summary>
        /// initial the file path value.
        /// </summary>
        /// <param name="filePath"></param>
        public ParseHelper(string filePath)
        {
            pathFilePath = filePath;
        }

        /// <summary>
        /// Parse each line in the file.
        /// </summary>
        public void ParseEachLine()
        {
            //Read all lines and loop up it.
            string[] parsedFile = File.ReadAllLines(@"\\LQS-HAIZZH-01\BigDataShareFolder\RISSourceFolder\Desktop_TS_Redstone.csv");
            // The current Line index.
            int currentLineIndex = 0;
            // the Lines that have been parsed.
            string lastLineString = string.Empty;
            int lastLineIndex = 0;

            foreach (string currentLineStr in parsedFile)
            {
                Console.WriteLine("The current line " + currentLineIndex + " is parsing.");
                currentLineIndex++;
                if (currentLineIndex == 1)
                {
                    continue;
                }
                // Get the latest parsed ten lines to caller.
                // Invoke all the registed methods.
                ParseFileHandle?.Invoke(currentLineStr.Trim(), currentLineIndex, lastLineString, lastLineIndex);
                // push current line to stack.
                if (!string.IsNullOrEmpty(currentLineStr.Trim()))
                {
                    lastLineString = currentLineStr;
                    lastLineIndex = currentLineIndex;
                }
                if (currentLineIndex % 5000 == 0)
                {
                    ParseHandle?.Invoke();
                }
            }
        }
    }
}
