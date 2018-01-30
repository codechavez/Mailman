using System;

namespace Core.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Mailman.From(new System.Net.Mail.MailAddress(""))
                .To("")
                .WithSubject("")
                .WithBody("")
                .Deliver();
            
        }
    }
}
