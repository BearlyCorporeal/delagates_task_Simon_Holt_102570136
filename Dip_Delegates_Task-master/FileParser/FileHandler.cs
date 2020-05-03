using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace FileParser {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            int counter = 0;
            string newline;
            System.IO.StreamReader textfile = new System.IO.StreamReader(filePath);
            List<string> lines = new List<string>();
            while ((newline = textfile.ReadLine()) != null)
            {
                lines.Add(newline);
                counter++;
            }
            return lines; //-- return result here
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            File.WriteAllText(filePath, String.Empty);
            System.IO.StreamWriter textfile = new System.IO.StreamWriter(filePath);
            string trimmedDelimeter = delimeter.ToString();
            var sb = new StringBuilder();
            foreach (char c in trimmedDelimeter)
            {
                if (c != '"')
                    sb.Append(c);
            }
            trimmedDelimeter = sb.ToString();
            foreach (var row in rows)
            {
                textfile.WriteLine(row[0]+trimmedDelimeter+row[1]+trimmedDelimeter+row[2]);
            }
            textfile.Close();
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) {
            DataParser _dp = new DataParser();
            List<List<string>> result = new List<List<string>>();
            foreach (var line in data)
            {
                string[] items = line.Split(delimiter);
                result.Add(items.ToList());
            }
            return result; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {

            
            List<List<string>> result = new List<List<string>>();
            DataParser _dp = new DataParser();
            foreach (var line in data)
            {
                string[] items = line.Split(',');
                result.Add(items.ToList());
            }
            return result;  //-- return result here
        }
    }
}