using System;

namespace BankingApp.BLL.BusinessModels
{
    public class NewBalance
    {
        private double sum = 0;
        public double Sum { get { return sum; } }
        public NewBalance(double sum)
        {
            if (sum >= 0)
                this.sum = sum;
        }
        public double Deposit(double bal)
        {
            return bal + sum;
        }
        public double Withdraw(double bal)
        {
            return bal - sum;
        }
    }
}
