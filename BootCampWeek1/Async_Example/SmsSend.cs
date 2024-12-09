using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampWeek1.Async_Example
{
    public class SmsSender
    {
        // Synchronous method to send SMS
        public void SendSms(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber} synchronously...");
            Thread.Sleep(3000); 
            Console.WriteLine($"SMS to {phoneNumber}: '{message}' sent successfully (Synchronously).\n");
        }

        // Asynchronous method to send SMS
        public Task SendSmsAsync(string phoneNumber, string message)
        {
            return Task.Run(async () =>
            {
                Console.WriteLine($"Sending SMS to {phoneNumber} asynchronously...");
                await Task.Delay(3000);
             
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    throw new ArgumentException("Phone number cannot be null or empty.");
                }

                Console.WriteLine($"SMS to {phoneNumber}: '{message}' sent successfully (Asynchronously).\n");
            });
        }
    }

    class AsyncProgram
    {
        public static async Task Main(string[] args)
        {
            SmsSender smsSender = new SmsSender();

            smsSender.SendSms("+123456789", "Hello, this is a test SMS!");
            Console.WriteLine("Synchronous SMS method returned control to Main.\n");

          
            var task1 = smsSender.SendSmsAsync("", "This SMS will simulate an error!")
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"Failed to send SMS: {t.Exception?.GetBaseException().Message}\n");
                    }
                });

            var task2 = smsSender.SendSmsAsync("+987654321", "Hello, this is another test SMS!")
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"Failed to send SMS: {t.Exception?.GetBaseException().Message}\n");
                    }
                });

            await Task.WhenAll(task1, task2);

            Console.WriteLine("Asynchronous SMS methods returned control to Main.\n");
        }
    }
}