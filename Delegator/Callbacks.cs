using System;
using System.IO;
using System.Linq;

namespace Delegator
{
    public delegate void ProcessString(string input);

    public static class Callbacks
    {
        public static void ProcessFile(string filename, ProcessString processor)
        {
            var content = File.ReadAllLines(filename);

            var firstLine = content.First(l => l.Length > 0);


            var line = content[0];

            processor(line);
        }

        public static void PrintCharCount(string input)
        {
            Console.WriteLine($"The input contains {input.Length} characters");
        }

        public static void PrintLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}

