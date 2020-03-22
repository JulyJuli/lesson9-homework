using System;
using System.Collections.Generic;

namespace ConsoleTableLibrary
{
    public class ConsoleTable
    {
        public List<string[]> Rows = new List<string[]> { };
        public List<int> Shifts { get; }
        public List<string> Titles { get; }

        public void Add(string[] row)
        {
            Rows.Add(row);
        }

        public ConsoleTable(List<string> titles, List<int> shifts)
        {
            Titles = titles;
            Shifts = shifts;
        }

        public override string ToString()
        {
            string table = GetLine();
            table += GetTitles();
            table += GetLine();

            foreach (string[] row in Rows)
            {
                table += "|";
                for (int i = 0; i < row.Length; i++)
                {
                    table += string.Format($" {row[i]}{new String(' ', Shifts[i] - row[i].Length)} |");
                }
                table += "\n";
            }
            table += GetLine();

            return table;
        }

        public string GetLine()
        {
            string line = "|";

            for (int i = 0; i < Titles.Count; i++)
            {
                line += string.Format("-{0}-|", new String('-', Shifts[i]));
            }

            line += "\n";

            return line;
        }

        public string GetTitles()
        {
            string line = "|";

            for (int i = 0; i < Titles.Count; i++)
            {
                line += string.Format($" {Titles[i]}{new String(' ', Shifts[i] - Titles[i].Length)} |");
            }

            line += "\n";

            return line;
        }
    }

}