
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace MarketDataContributorApp
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void PrintUsage()
        {
            Console.WriteLine("Help, print this usage");
            Console.WriteLine("AddQuote <pair> <bid> <ask>, e.g. AddQuote EUR/USD 1.20001 1.20002");
            Console.WriteLine("GetQuote <pair>            , e.g. GetQuote EUR/USD");
            Console.WriteLine("Press <ENTER> to terminate client.");
        }

        static void Main()
        {
            PrintUsage();

            // Create a client
            var client = new MarketDataContributorConnection.MarketDataContributorClient();

            while (true)
            {
                var s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    break;
                }

                var token = s.Split(' ');
                if (token[0].ToLower() == "addquote")
                {
                    if (token.Length < 4)
                    {
                        Console.WriteLine($"Invalid number of arguments");
                        Console.WriteLine();
                        continue;
                    }
                    if (!double.TryParse(token[2], out double bid))
                    {
                        Console.WriteLine($"Invalid bid price");
                        Console.WriteLine();
                        continue;
                    }
                    if (!double.TryParse(token[3], out double ask))
                    {
                        Console.WriteLine($"Invalid ask price");
                        Console.WriteLine();
                        continue;
                    }

                    var result = client.AddFxQuote(token[1], bid, ask);
                    Console.WriteLine($"Result: {result.Result} Message: {result.Message}");
                    Console.WriteLine();
                }
                else if (token[0].ToLower() == "getquote")
                {
                    if (token.Length < 2)
                    {
                        Console.WriteLine($"Invalid number of arguments");
                        Console.WriteLine();
                        continue;
                    }
                    var result = client.GetFxQuote(token[1]);
                    Console.WriteLine($"Result: type={result.DataType} name={result.Name} bid={result.Bid} ask={result.Ask}");
                    Console.WriteLine();
                }
                else if (token[0].ToLower() == "help")
                {
                    PrintUsage();
                }
                else
                {
                    Console.WriteLine("Unknown command");
                    Console.WriteLine();
                }

            }

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
            Console.WriteLine("Bye!");
        }
    }
}

