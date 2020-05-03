using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParser;


namespace Delegate_Exercise {
    
    
    public class CsvHandler {
     
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            DataParser dp = new DataParser();
            FileHandler fh = new FileHandler();
            List<string> lines = fh.ReadFile(readFile);
            List<List<string>> data;
            data = fh.ParseCsv(lines);
            data = dp.StripQuotes(data);
            data = dp.StripWhiteSpace(data);
            data = dataHandler(data);
            fh.WriteFile(writeFile, ',', data);
            
        }
        
    }
}