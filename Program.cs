using System;
using System.Collections.Generic;

namespace Rynek
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            CentralBank centralBank = new CentralBank(market);
            market.SetCentralBank(centralBank);

            Buyer buyer1 = new Buyer("Buyer1", 500, new Dictionary<string, int> { { "luxury", 2 }, { "necessity", 10 } });
            Buyer buyer2 = new Buyer("Buyer2", 300, new Dictionary<string, int> { { "luxury", 1 }, { "necessity", 5 } });

            //ProductionCost,ProductPrice,ProductAvailabe
            market.AddSeller(new Seller("Seller1", 1.35, 1.37, 97));
            market.AddSeller(new Seller("Seller2", 1.29, 1.32, 100));

            market.AddBuyer(buyer1);
            market.AddBuyer(buyer2);

            // Display buyers' balances before starting the simulation
            Console.WriteLine("Buyers' balances before starting the simulation:");
            buyer1.PrintStatus();
            buyer2.PrintStatus();
            Console.WriteLine();

            // Run the simulation for 10 turns
            for (int turn = 1; turn <= 10; turn++)
            {
                Console.WriteLine($"Turn {turn}:");
                market.UpdateMarketStatus();
                market.PrintStatus();
                Console.WriteLine();
            }

            // Example of using visitors with a sample inflation rate
            double inflationRate = 0.05;
            BuyerVisitor buyerVisitor = new BuyerVisitor(inflationRate);
            SellerVisitor sellerVisitor = new SellerVisitor();

            market.AcceptVisitor(buyerVisitor);
            market.AcceptVisitor(sellerVisitor);
        }
    }
}
