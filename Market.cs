using System;
using System.Collections.Generic;

namespace Rynek
{
    public class Market
    {
        private List<Seller> sellers;
        private List<Buyer> buyers;
        private CentralBank? centralBank;
        private double currentInflation; // Field for storing inflation values

        public Market()
        {
            sellers = new List<Seller>();
            buyers = new List<Buyer>();
        }

        public void SetCentralBank(CentralBank centralBank)
        {
            this.centralBank = centralBank;
        }

        public void AddSeller(Seller seller)
        {
            sellers.Add(seller);
        }

        public void AddBuyer(Buyer buyer)
        {
            buyers.Add(buyer);
        }

        public void UpdateMarketStatus()
        {
            foreach (var buyer in buyers)
            {
                buyer.MakePurchases(sellers);
            }
            ApplyStabilizationAlgorithm(); //Feedback occurs here
        }

        public void ApplyInflation(double inflationRate)
        {
            foreach (var seller in sellers)
            {
                seller.ApplyInflation(inflationRate);
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine("Current market status:");
            Console.WriteLine("Sellers:");
            foreach (var seller in sellers)
            {
                seller.PrintStatus();
            }

            Console.WriteLine("Buyers:");
            foreach (var buyer in buyers)
            {
                buyer.PrintStatus();
            }

            //Adding an inflation printout
            Console.WriteLine($"Current inflation rate: {currentInflation:P2}");
        }

        private void ApplyStabilizationAlgorithm()

        {
            double totalRevenue = 0;

            // Calculate total revenue for sellers
            foreach (var seller in sellers)
            {
                double revenue = seller.ProductPrice * (seller.ProductsAvailable + 1);
                totalRevenue += revenue;
            }

            // Calculation of the required inflation based on the Bank's stabilization coefficient
            double requiredInflation = (centralBank?.StabilizationFactor ?? 0) / totalRevenue;
            currentInflation = requiredInflation; // Recording the inflation value

            //Application of inflation to products
            foreach (var seller in sellers)
            {
                double newPrice = seller.ProductPrice * (1 + requiredInflation);
                seller.ProductPrice = newPrice;
            }

            centralBank?.UpdateTaxRevenue(totalRevenue);
        }
        // The feedback loop is between the calculation of inflation and the update of prices and tax revenues

        // Inflation affects the update of product prices, which closes the feedback loop.
        // This allows the algorithm to adjust itself product prices according to current market conditions,
        // striving to maintain stability.


        // UpdateMarketStatus metod

        public void AcceptVisitor(IVisitor visitor)
        {
            foreach (var buyer in buyers)
            {
                buyer.Accept(visitor);
            }

            foreach (var seller in sellers)
            {
                seller.Accept(visitor);
            }
        }
    }
}
