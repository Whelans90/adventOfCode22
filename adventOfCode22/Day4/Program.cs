using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class challenge1 
    {
        public static int[] splitAssignments(string line)
        {
            int[] assigmentRanges = new int[4];

            string[] assignments = line.Split(new char[] { '-', ',' });
            for (int i=0; i<assignments.Length; i++)
            {
                assigmentRanges[i] = Int32.Parse(assignments[i]);
            }

            return assigmentRanges;
        }

        public static int findBiggerAssignment(int[] assignments)
        {
            int result = 1;
            if((assignments[3]-assignments[2]) >= (assignments[1] - assignments[0])) 
            {
                result = 2;
            }
            return result;
        }

        public static bool isCompleteOverlap(int[] assignments, int biggerAssignment)
        {
            bool result = false;

            switch (biggerAssignment)
            {
                case 1:
                    {
                        if (assignments[0] <= assignments[2] && assignments[1] >= assignments[3])
                        {
                            result = true;
                        }
                        break;
                    }
                case 2:
                    {
                        if (assignments[2] <= assignments[0] && assignments[3] >= assignments[1])
                        {
                            result = true;
                        }
                        break;
                    }
            }
            return result;
        }
    }
    public static class challenge2 
    {
        public static bool isPartialOverlap(int[] assignments, int biggerAssignment)    
        {
            bool result = false;

            if ((assignments[0] >= assignments[2] && assignments[0] <= assignments[3]) 
                || (assignments[1] >= assignments[2] && assignments[1] <= assignments[3]) 
                || (assignments[2] >= assignments[0] && assignments[2] <= assignments[1]) 
                || (assignments[2] >= assignments[0] && assignments[2] <= assignments[1]))
            {
                return true;
            }
                return result;
        }
    }
    public static class program 
    {
        static void Main(string[] args)
        {
            int numberOfOverlaps = 0;
            int partialOverlaps = 0;
            int[] test = new int[] { 1, 4, 5, 20 };

            foreach (string line in System.IO.File.ReadLines(AppContext.BaseDirectory + "cleaninglist.txt"))
            {
                var assignments = challenge1.splitAssignments(line);
                var biggerAssignment = challenge1.findBiggerAssignment(assignments);
                if (challenge1.isCompleteOverlap(assignments, biggerAssignment)) { numberOfOverlaps++; }
                if(challenge2.isPartialOverlap(assignments, biggerAssignment)) { partialOverlaps++; }
            }
            Console.WriteLine("Complete Overlaps: " + numberOfOverlaps);
            Console.WriteLine("Partial Overlaps: " + partialOverlaps);
            Console.Read();
        }
    }
}