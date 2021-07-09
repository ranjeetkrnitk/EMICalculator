using System;
using System.Collections.Generic;
using System.Linq;

namespace EMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string filePath = args[0];
            //string filePath = "/Users/ranjeetkumar/Desktop/input.txt";

            string[] commands = System.IO.File.ReadAllLines(filePath);
            List<Loan> Loans = new List<Loan>();

            foreach(string co in commands)
            {
                string[] attributes = co.Split();

                switch (attributes[0].ToUpperInvariant())
                {
                    case "LOAN":
                        // Creating Loan
                        Loan newLoan = new Loan(attributes[1], attributes[2], decimal.Parse(attributes[3]),
                            decimal.Parse(attributes[4]), decimal.Parse(attributes[5]));
                        Loans.Add(newLoan);
                        break;
                    case "PAYMENT":
                        // Finding the Loan
                        Loan l = FindLoan(Loans, attributes[1], attributes[2]);
                        if (l != null)
                        {
                            // Making the Payment
                            l.Payment(decimal.Parse(attributes[3]), int.Parse(attributes[4]));
                        }
                        break;
                    case "BALANCE":
                        // Finding the Loan
                        Loan L = FindLoan(Loans, attributes[1], attributes[2]);
                        if( L != null)
                        {
                            // Getting Balance as a string and Printing in Console.
                            Console.WriteLine(L.getBalance(int.Parse(attributes[3])));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        static Loan FindLoan(List<Loan> Loans, string _bank, string _borrower)
        {
            foreach (Loan l in Loans)
            {
                if (l.BankName == _bank && l.BorrowerName == _borrower)
                {
                    return l;
                }
            }
            return null;
        }

    }
}
