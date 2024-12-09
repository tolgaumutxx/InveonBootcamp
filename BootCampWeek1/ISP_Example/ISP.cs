using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampWeek1.ISP_Example
{
    /*
   public interface IPayment
    {
        void ProcessPayment(double amount);
        void GenerateInvoice();
        void ApplyDiscount(double discountPercentage);
        void Refund(double amount);
        void SchedulePayment(DateTime date);
    }

    public class CashPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a cash payment of {amount}.");
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("Generating an invoice for cash payment.");
        }

        public void ApplyDiscount(double discountPercentage)
        {
            
            throw new NotImplementedException("Discounts are not applicable for cash payments.");
        }

        public void Refund(double amount)
        {
            Console.WriteLine($"Refunding {amount} for cash payment.");
        }

        public void SchedulePayment(DateTime date)
        {
           
            throw new NotImplementedException("Scheduling is not applicable for cash payments.");
        }
    }

    
    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a credit card payment of {amount}.");
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("Generating an invoice for credit card payment.");
        }

        public void ApplyDiscount(double discountPercentage)
        {
            Console.WriteLine($"Applying a discount of {discountPercentage}% to the credit card payment.");
        }

        public void Refund(double amount)
        {
            Console.WriteLine($"Refunding {amount} for credit card payment.");
        }

        public void SchedulePayment(DateTime date)
        {
            Console.WriteLine($"Scheduling credit card payment for {date}.");
        }
    }

    class ISPProgram
    {
        static void Main(string[] args)
        {
            IPayment cashPayment = new CashPayment();
            IPayment creditCardPayment = new CreditCardPayment();

            cashPayment.ProcessPayment(500);
            creditCardPayment.ProcessPayment(1200);

            try
            {
                cashPayment.ApplyDiscount(10);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                cashPayment.SchedulePayment(DateTime.Now.AddDays(1));
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    } */
     public interface IPayment
    {
        void ProcessPayment(double amount);
    }

    public interface IInvoice
    {
        void GenerateInvoice();
    }

    public interface IDiscountable
    {
        void ApplyDiscount(double discountPercentage);
    }

    public interface IRefundable
    {
        void Refund(double amount);
    }

    public interface ISchedulable
    {
        void SchedulePayment(DateTime date);
    }

    public class CashPayment : IPayment, IInvoice, IRefundable
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a cash payment of {amount}.");
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("Generating an invoice for cash payment.");
        }

        public void Refund(double amount)
        {
            Console.WriteLine($"Refunding {amount} for cash payment.");
        }
    }

    public class CreditCardPayment : IPayment, IInvoice, IDiscountable, IRefundable, ISchedulable
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a credit card payment of {amount}.");
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("Generating an invoice for credit card payment.");
        }

        public void ApplyDiscount(double discountPercentage)
        {
            Console.WriteLine($"Applying a discount of {discountPercentage}% to the credit card payment.");
        }

        public void Refund(double amount)
        {
            Console.WriteLine($"Refunding {amount} for credit card payment.");
        }

        public void SchedulePayment(DateTime date)
        {
            Console.WriteLine($"Scheduling credit card payment for {date}.");
        }
    }

    class ISPProgram
    {
        public static void Main(string[] args)
        {
            IPayment cashPayment = new CashPayment();
            IPayment creditCardPayment = new CreditCardPayment();

            cashPayment.ProcessPayment(500);
            creditCardPayment.ProcessPayment(1200);

            var creditCard = creditCardPayment as CreditCardPayment;
            creditCard?.ApplyDiscount(10);
            creditCard?.SchedulePayment(DateTime.Now.AddDays(1));
        }
    }
}