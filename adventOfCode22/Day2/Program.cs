using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class challenge1
    {
        public static string Outcome(char opponentChoice, char myChoice)
        {
            string result = "";
            switch (opponentChoice)
            {
                case 'A':
                    switch (myChoice)
                    {
                        case 'X':
                            result = "draw";
                            break;
                        case 'Y':
                            result = "win";
                            break;
                        case 'Z':
                            result = "loss";
                            break;
                    }
                    break;
                case 'B':
                    switch (myChoice)
                    {
                        case 'X':
                            result = "loss";
                            break;
                        case 'Y':
                            result = "draw";
                            break;
                        case 'Z':
                            result = "win";
                            break;
                    }
                    break;
                case 'C':
                    switch (myChoice)
                    {
                        case 'X':
                            result = "win";
                            break;
                        case 'Y':
                            result = "loss";
                            break;
                        case 'Z':
                            result = "draw";
                            break;
                    }
                    break;
            }
            return result;
        }

        public static string convertChoice(char choice)
        {
            string myChoice = "";

            switch (choice)
            {
                case 'X': myChoice = "rock"; break;
                case 'Y': myChoice = "paper"; break;
                case 'Z': myChoice = "scissors"; break;
            }
            return myChoice;
        }
    }

    class challenge2
    {
        public static string MyChoice(char opponentChoice, char myResult)
        {
            string result = "";

            switch(myResult)
            {
                case 'X':
                    switch(opponentChoice)
                    {
                        case 'A':
                            result = "scissors";
                            break;
                        case 'B':
                            result = "rock";
                            break;
                        case 'C':
                            result = "paper";
                            break;
                    }
                    break;
                case 'Y':
                    switch (opponentChoice)
                    {
                        case 'A':
                            result = "rock";
                            break;
                        case 'B':
                            result = "paper";
                            break;
                        case 'C':
                            result = "scissors";
                            break;
                    }
                    break;
                case 'Z':
                    switch (opponentChoice)
                    {
                        case 'A':
                            result = "paper";
                            break;
                        case 'B':
                            result = "scissors";
                            break;
                        case 'C':
                            result = "rock";
                            break;
                    }
                    break;
            }

            return result;
        }

        public static string convertOutcome(char outcome)
        {
            string result = "";

            switch (outcome)
            {
                case 'X': result = "loss"; break;
                case 'Y': result = "draw"; break;
                case 'Z': result = "win"; break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, int> outcomePoints = new Dictionary<string, int>();
            outcomePoints.Add("win", 6);
            outcomePoints.Add("loss", 0);
            outcomePoints.Add("draw", 3);

            IDictionary<string, int> choicePoints = new Dictionary<string, int>();
            choicePoints.Add("rock", 1);
            choicePoints.Add("paper", 2);
            choicePoints.Add("scissors", 3);

            int challenge1Score = 0;
            int challenge2Score = 0;

            foreach (string line in System.IO.File.ReadLines(AppContext.BaseDirectory + "strat.txt"))
            {
                var opponentChoice = line[0];
                var myChoice = line[2];

                var result1 = challenge1.Outcome(opponentChoice, myChoice);
                var choice1 = challenge1.convertChoice(myChoice);

                challenge1Score += outcomePoints[result1];
                challenge1Score += choicePoints[choice1];

                var result2 = challenge2.convertOutcome(myChoice);
                var choice2 = challenge2.MyChoice(opponentChoice, myChoice);

                challenge2Score += outcomePoints[result2];
                challenge2Score += choicePoints[choice2];


            }

            Console.WriteLine("Challenge 1: " + challenge1Score);
            Console.WriteLine("Challenge 2: " + challenge2Score);

            Console.ReadKey();

        }

    }
}
