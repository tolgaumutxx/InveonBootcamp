using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootCampWeek1.LSP_Example;

namespace BootCampWeek1.LSP_Example
{
    /*
    public class PaymentMethods
    {
        public virtual void Payment(double amount){
            Console.WriteLine($"Payment of {amount} has been made.");
        }
    }

    public class Cash:PaymentMethods{
        public override void Payment(double amount)
        {
             if (amount > 1000)
        {
            throw new InvalidOperatorException("Cannot take over cash paymenys bigger than 1000");
        }
        Console.WriteLine($"Payment of {amount} has been made.");
            
        }
       
    }

    public class Credit:PaymentMethods{
        public override void Payment(double amount)
        {
            Console.WriteLine($"Payment of {amount} has been made.");
        }
    }
    */
     public abstract class PaymentMethod
    {
        public abstract void ProcessPayment(double amount);
    }
        public class CashPayment : PaymentMethod
    {
        public override void ProcessPayment(double amount)
        {
            if (amount > 1000)
            {
                HandleLargeCashPayment(amount);
                return;
            }
            HandleSmallCashPayment(amount);
        }

        private void HandleLargeCashPayment(double amount)
        {
            Console.WriteLine("Processing multiple cash payments as the total exceeds the single transaction limit.");
        }

        private void HandleSmallCashPayment(double amount)
        {
            Console.WriteLine($"Processing a cash payment of {amount}.");
        }
    }

    // CreditCardPayment adheres to LSP
    public class CreditCardPayment : PaymentMethod
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a credit card payment of {amount}.");
        }
    }

    class LSPProgram
    {
        public static void Main(string[] args)
        {
            var payments = new List<PaymentMethod>
            {
                new CreditCardPayment(),
                new CashPayment()
            };

            foreach (var payment in payments)
            {
                payment.ProcessPayment(1200);
            }
        }
    }
}