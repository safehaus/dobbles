using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using IntranetGaming.Setup;
using Owin;

namespace IntranetGaming
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:80");

            using (WebApp.Start(startOptions, new Startup().Configuration))
            {
                Console.WriteLine("Service Started");
                var input = String.Empty;
                while (String.Equals(input, "exit") == false)
                {
                    input = Console.ReadLine();
                }
            }
        }
    }
}
