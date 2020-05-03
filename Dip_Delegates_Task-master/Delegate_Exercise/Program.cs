using System;
using System.Collections.Generic;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            CsvHandler ch = new CsvHandler();
            string readPath = Environment.GetEnvironmentVariable("HOME") + "C:/Users/Holt/Documents/GitHub/delagates_task_Simon_Holt_102570136/datacsv.csv";
            string writePath = Environment.GetEnvironmentVariable("HOME") + "C:/Users/Holt/Documents/GitHub/delagates_task_Simon_Holt_102570136/processed_data.csv";
            Parser p1 = new Parser(RemoveHashes);
            ch.ProcessCsv(readPath, writePath,RemoveHashes);
        }

        
        public static List<List<string>> RemoveHashes(List<List<string>> data) {
            foreach(var row in data) {
                for (var index = 0; index < row.Count; index++) {
                    if(row[index][0] == '#')
                        row[index] = row[index].Remove(0,1);
                }
            }
            return data;
        }
    }
}
