using System;
using System.Collections.Generic;

namespace EMICalculator
{
    public class Loan
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public decimal Principal { get; set; }
        public decimal Years { get; set; }
        public decimal ROI { get; set; }
        public decimal EmiAmount { get; set; }
        public decimal TotalPayable { get; set; }
        public List<decimal> EMIs = new List<decimal>()
        {
            0 // Starting with 0th Index as a 0th Month Lump Sum payment
        };

        // Creating a Loan
        public Loan(string _bank, string _borrower, decimal _principal, decimal _years, decimal _roi)
        {
            this.BankName = _bank;
            this.BorrowerName = _borrower;
            this.Principal = _principal;
            this.Years = _years;
            this.ROI = _roi;
            this.TotalPayable = this.Principal + (this.Principal * this.Years * this.ROI)/100;
            this.EmiAmount = Math.Ceiling(this.TotalPayable / (12 * this.Years));

            for(int i=1; i <= 12*this.Years; i++)
            {
                EMIs.Add(Math.Ceiling(this.EmiAmount));
            }
        }

        // Making a Payment
        public void Payment(decimal _amount, int _month)
        {
            EMIs[_month] += _amount;
        }

        
        // Getting Balance as a String Output
        public string getBalance(int _month)
        {
            //Console.WriteLine(this.ShowArray());
            if(_month > this.EMIs.Count)
            {
                return " Not Valid ";
            }else if( _month == 0)
            {
                return this.BankName + " " + this.BorrowerName + " " + this.EMIs[0] + " " + Math.Ceiling(((this.TotalPayable - this.EMIs[0]) / this.EmiAmount));
            }
            else
            {
                decimal Sum = 0;
                for(int i = 0; i<= _month; i++)
                {
                    Sum += this.EMIs[i];
                }
                if(Sum == _month * this.EmiAmount)
                {
                    return this.BankName + " " + this.BorrowerName + " " + Sum + " " + (12 * this.Years - _month);
                }
                else
                {
                    return this.BankName + " " + this.BorrowerName + " " + Sum + " " + Math.Ceiling(((this.TotalPayable - Sum) / this.EmiAmount));

                }
            }
        }

        // Debug Helper Methods
        public override string ToString()
        {
            return BankName + " " + BorrowerName + " " + Principal.ToString() + " " + Years.ToString() + " " + ROI.ToString() + " " + this.TotalPayable + " " + this.EmiAmount;
        }

        public string ShowArray()
        {
            string res = "";
            foreach (decimal e in this.EMIs)
            {
                res += "," + e.ToString();
            }
            return res;
        }
    }
}
