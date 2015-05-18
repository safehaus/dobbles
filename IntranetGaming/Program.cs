using System;
using Microsoft.Owin.Hosting;
using Safehaus.IntranetGaming.Setup;

namespace Safehaus.IntranetGaming
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:80");

            using (WebApp.Start(startOptions, (builder) => new Startup().Configuration(builder, true)))
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
