using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{ 
    class challenge1 
    {
        internal static int findCommonItemPriority(string line)
        {
            var lengthOfLine = line.Length;
            var halfOfLine = lengthOfLine / 2;
            var firstCompartment = line.Substring(0, halfOfLine);
            var secondCompartment = line.Substring(halfOfLine);
            var priorityValue = 0;

            foreach (char character in firstCompartment)
            {
                if (secondCompartment.Contains(character))
                {
                    priorityValue = program.getPriority(character);
                    
                    break;
                }
            }
            return priorityValue;
        }
    }
    class challenge2 
    {
        internal static char findCommonItem(string line1, string line2, string line3)
        {
            char badge = '\0';
            List<char> charList = new List<char>();

            foreach(char c in line1)
            {
                if(line2.Contains(c))
                {
                    charList.Add(c);
                }
            }

            foreach(char c in charList)
            {
                if(line3.Contains(c))
                {
                    badge = c;
                }
            }

            return badge;
        }
    }
    class program 
    {
        static void Main(string[] args) 
        {
            var priorityScore = 0;
            var badgePriority = 0;
            List<string> groupOfElves = new List<string>();

            foreach (string line in System.IO.File.ReadLines(AppContext.BaseDirectory + "packingList.txt")) 
            {
                //Challenge1
                priorityScore += challenge1.findCommonItemPriority(line);

                //Challenge2
                groupOfElves.Add(line);
                if(groupOfElves.Count == 3 )
                {
                    var badge = challenge2.findCommonItem(groupOfElves[0], groupOfElves[1], groupOfElves[2]);
                    badgePriority += getPriority(badge);
                    groupOfElves.Clear();
                }
                
            }

            
            Console.WriteLine("Challenge 1 Priority Score: " + priorityScore);
            Console.WriteLine("Challenge 2 Priority Score: " + badgePriority);
            Console.Read();
        }

        public static int getPriority(char c)
        {
            int priority = 0;
            var asciiValue = ((int)c);
            if (asciiValue < 97)
            {
                priority = asciiValue - 38;
            }
            else
            {
                priority = asciiValue - 96;
            }
            return priority;
        }
    }
}