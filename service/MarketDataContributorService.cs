using System.ServiceModel;
using System;
using MarketDataContributorService;

namespace MarketDataContributorServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MarketDataContributorServer
    {
        public static void Main()
        {
            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(MarketDataContributor)))
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

            }
        }
    }
}
