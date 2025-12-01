using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class D2015Day5
    {
        public List<string> ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\D2015Day5\\Example.txt".Trim()
                : "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\D2015Day5\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<char> Vowels = new List<char>
            {
                'a', 'e', 'i', 'o', 'u'
            };
            List<string> Forbidden = new List<string>
            {
                "ab", "cd", "pq", "xy"
            };
            List<string> resultstrings = new List<string>();
            var results = Inputs
                .Where(i => i.Count(c => Vowels.Contains(c)) >= 3)                  
                .Where(i => Doublechar(i))         
                .Where(i => !Forbidden.Any(f => i.Contains(f)))                     
                .ToList();

            Console.WriteLine(results.Count());
        }

        bool Doublechar(string s)
        {
            for (int i = 0; i < s.Length -1; i++)
            {                
                if (s[i] == s[i + 1])
                {
                    return true;
                }
            }
                return false;
        }
    }
}

