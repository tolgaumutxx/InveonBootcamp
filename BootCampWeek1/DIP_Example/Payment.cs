using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampWeek1.DIP_Example
{
    /*
    public class Payment
    {
    private CashPayment _cashPayment;

        public PaymentService()
        {
            _cashPayment = new CashPayment();
        }

        public void ProcessPayment(double amount)
        {
            _cashPayment.ProcessCashPayment(amount);
        }
    }

    public class CashPayment
    {
        public void ProcessCashPayment(double amount)
        {
            Console.WriteLine($"Processing a cash payment of {amount}.");
        }
    }

    class DIPProgram
    {
        public static void Main(string[] args)
        {
            PaymentService paymentService = new PaymentService();
            paymentService.ProcessPayment(500);
        }
    } */
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // High-level module
    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void ProcessPayment(double amount)
        {
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    // Low-level module
    public class CashPayment : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing a cash payment of {amount}.");
        }
    }

    class DIPProgram
    {
        public static void Main(string[] args)
        {
            IPaymentProcessor cashPaymentProcessor = new CashPayment();
            PaymentService paymentService = new PaymentService(cashPaymentProcessor);

            paymentService.ProcessPayment(500);
        }
    }

}