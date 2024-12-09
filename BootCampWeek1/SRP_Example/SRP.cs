using System;

namespace BootCampWeek1.SRP_Example
{
    /*  SRP Violation Example
    public class Order{
        public int OrderID{get;set;}
        public double TotalAmount{get;set;}
    

        public double Discount(){
            if (TotalAmount > 100){
                return TotalAmount * 0.1;
            }
            return 0;
        }
        public string Invoice(){
            return $"Invoice:\nOrder ID: {OrderID}\nTotal Amount: {TotalAmount}\nDiscount: {Discount()} Net Amount:{TotalAmount-Discount()}";
        }
    }
    public class Email(){
        public string Customer{get;set;}
        public Order Order{get;set;}
        public void SendEmail(){
            string Mail = Order.Invoice();
            Console.WriteLine($"Sending Mail to: {Customer}\n Mail: {Mail}");
        }
    }


   class SRPProgram
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                OrderID = 1,
                TotalAmount = 150
            };

            Email emailService = new Email
            {
                Customer = "Umut",
                Order = order
            };

            emailService.SendEmail();
        }
    }
    */
    public class Order{
        public int OrderID{get;set;}
        public double TotalAmount{get;set;}

        public double Discount(){
            if (TotalAmount > 100){
                return TotalAmount *0.1;
            }
            return 0;
        }
         public double NetAmount()
        {
            return TotalAmount - Discount();
        }

    }
    public class Invoice_Service{
        public string Invoice(int orderID,double totalAmount,double discount,double netAmount){
            return $"Invoice:\nOrder ID: {orderID}\nTotal Amount: {totalAmount}\nDiscount: {discount}\nNet Amount: {netAmount}";

        }
    }

    public class Email_Service{
        public void Email(string customer, string Mail){
            Console.WriteLine($"Sending mail to : {customer}\n Mail : {Mail} ");
        }
    }

    class SRPProgram(){
        public static void Main(string[] args){
            Order order = new Order{
                OrderID = 1,
                TotalAmount = 160
            };
            int orderId = order.OrderID;
            double totalAmount = order.TotalAmount;
            double discount = order.Discount();
            double netAmount = order.NetAmount();

            
            Invoice_Service invoiceService = new Invoice_Service();
            string invoice = invoiceService.Invoice(orderId, totalAmount, discount, netAmount);

            
            Email_Service emailService = new Email_Service();
            emailService.Email("customer@example.com", invoice);
        }
    }
}


