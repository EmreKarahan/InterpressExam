using System;
using Microsoft.Owin.Hosting;

namespace InterpressExam.Service.Wcf
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:1454";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
