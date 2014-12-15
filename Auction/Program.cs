using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Auction
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            string input = "", strippedInput = "";
            bool validInput = false, moreThanTen = false;
            double douVal = 0;
            int intVal = 0;


            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please enter how much you would like to bid, minimum bid of $10");
                    Console.WriteLine("Correct formats are 10, 10.5, $10, $10.5, 10 dollars");
                    Console.WriteLine("Enter q to quit");
                    input = Console.ReadLine();

                    if (input == "q" || input == "Q")
                    {
                        quit = true;
                        break;
                    }
                    else if (double.TryParse(input, out douVal))
                    {
                        validInput = true;
                    }
                    else if (input.StartsWith("$") || input.EndsWith(" dollars"))
                    {
                        double test;
                        strippedInput = input;
                        strippedInput = strippedInput.Replace("$", "");
                        strippedInput = strippedInput.Replace(" dollars", "");
                        int sInd1 = input.IndexOf("$");
                        int sInd2 = input.LastIndexOf("$");
                        int dInd1 = input.IndexOf(" dollars");
                        int dInd2 = input.LastIndexOf(" dollars");
                        if ((sInd1 != -1 && sInd1 == sInd2 || dInd1 != -1 && dInd1 == dInd2) && double.TryParse(strippedInput, out test))
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Incorrect Format, Please Try Again");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect Format, Please Try Again");
                        Console.ReadKey();
                    }

                    Console.Clear();

                    if (douVal != 0)
                    {
                        if (douVal % 1 == 0)
                        {
                            intVal = (int)douVal;
                            moreThanTen = bid(intVal);
                        }
                        else
                        {
                            moreThanTen = bid(douVal);
                        }
                    }
                    else
                    {
                        moreThanTen = bid(input);
                    }
                } while (!moreThanTen);
            } while (!quit);

            Console.Clear();
            Console.WriteLine("Thanks for bidding!");
            Console.ReadKey();
        }

        private static bool bid(int num)
        {
            if (num >= 10)
            {
                Console.WriteLine("Your bid of $" + num + " was accepted");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Your bid of $" + num + " was not accepted");
                Console.ReadKey();
                return false;
            }
        }
        private static bool bid(double num)
        {
            if (num >= 10)
            {
                Console.WriteLine("Your bid of $" + num + " was accepted");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Your bid of $" + num + " was not accepted");
                Console.ReadKey();
                return false;
            }
        }
        private static bool bid(string num)
        {
            string strippedNum = num;
            double dNum;
            int iNum;
            strippedNum = strippedNum.Replace("$", "");
            strippedNum = strippedNum.Replace(" dollars", "");

            if (strippedNum.Contains("."))
            {
                dNum = double.Parse(strippedNum);
                if (dNum >= 10)
                {
                    Console.WriteLine("Your bid of " + num + " was accepted");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your bid of " + num + " was not accepted");
                    Console.ReadKey();
                    return false;
                }
            }
            else
            {
                iNum = int.Parse(strippedNum);
                if (iNum >= 10)
                {
                    Console.WriteLine("Your bid of " + num + " was accepted");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your bid of " + num + " was not accepted");
                    Console.ReadKey();
                    return false;
                }
            }
        }
    }
}
