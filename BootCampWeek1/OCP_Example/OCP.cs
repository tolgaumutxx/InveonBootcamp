using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BootCampWeek1.OCP_Example
{
    /* OCP Violation
    public class CustomerDiscount
    {
        public required string CustomerType{get;set;}
        public double TotalPrice{get;set;}
       

        public double FinalPrice(){
            if (CustomerType == "Premium"){
                return TotalPrice * 0.9;
            }
            else if(CustomerType == "Deluxe"){
                return TotalPrice * 0.8;
            }
            return TotalPrice;

        }
    }
    class OCPProgram(){
        public static void Main(string[] args){
            CustomerDiscount Premium = new CustomerDiscount
            {
                CustomerType = "Premium",
                TotalPrice = 100
            };

            CustomerDiscount Deluxe = new CustomerDiscount
            {
                CustomerType = "Deluxe",
                TotalPrice = 200,
               
            };

            CustomerDiscount Regular = new CustomerDiscount
            {
                CustomerType = "Regular",
                TotalPrice = 300,
            };

            Console.WriteLine($"Final Price of Regular Cart: {Premium.FinalPrice()}");
            Console.WriteLine($"Final Price of Premium Cart: {Deluxe.FinalPrice()}");
            Console.WriteLine($"Fianl Price of Regular Cart: {Regular.FinalPrice()}");
        }
    } */

    public abstract class ShoppingCart{
        public double TotalPrice{get;set;}
        public abstract double CalculateFinalPraice();
    }
    public class RegularCustomer:ShoppingCart{
        public override double CalculateFinalPraice()
        {
            return TotalPrice;
        }
    }
    public class PremiumCustomer:ShoppingCart{
 
        public override double CalculateFinalPraice()
        {
            return TotalPrice * 0.9;
        }
    }
    public class DeluxeCustomer:ShoppingCart{
        public override double CalculateFinalPraice()
        {
            return TotalPrice*0.8;
        }
    }
    
    /* Adding a new class will not change any code but still work */
    class OCPProgram
    {
        public static void Main(string[] args)
        {
            var carts = new List<ShoppingCart>
            {
                new RegularCustomer { TotalPrice = 100 },
                new PremiumCustomer { TotalPrice = 200},
                new DeluxeCustomer {TotalPrice=300},
            };

            foreach (var cart in carts)
            {
                double finalPrice = cart.CalculateFinalPraice();
                Console.WriteLine($"Final Price of {cart.GetType().Name}: {finalPrice}");
            }
        }
    }

}