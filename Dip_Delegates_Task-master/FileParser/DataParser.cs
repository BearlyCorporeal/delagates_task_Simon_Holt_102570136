using System.Collections.Generic;
using System.Text;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            List<List<string>> result = new List<List<string>>();
            string trimed;
            List<string> line = new List<string>();
            foreach (var row in data)
            {
                foreach(var item in row)
                {
                    trimed = item;
                    var sb = new StringBuilder();
                    foreach (char c in trimed)
                    {
                        if (c != ' ')
                            sb.Append(c);
                    }
                    trimed = sb.ToString();
                    line.Add(trimed);
                }
                
                result.Add(line);
                line = new List<string>();
            }
            return result; //-- return result here
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            string trimed;
            List<List<string>> result = new List<List<string>>();
            List<string> line = new List<string>();
            foreach (var row in data)
            {
                foreach(var item in row)
                {
                    trimed = item;
                    var sb = new StringBuilder();
                    foreach (char c in trimed)
                    {
                        if (c != '"')
                            sb.Append(c);
                    }
                    trimed = sb.ToString();
                    line.Add(trimed);
                }
                
                result.Add(line);
                line = new List<string>();
            }
            return result; //-- return result here
        }

    }
}