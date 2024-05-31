using System;
using System.Collections.Generic;

namespace Rynek
{
    public class Buyer
    {
        
        public string Name { get; private set; }
        public double Money { get; private set; }
        public Dictionary<string, int> DesiredProducts { get; private set; }

        
        public Buyer(string name, double money, Dictionary<string, int> desiredProducts)
        {
            Name = name;
            Money = money;
            DesiredProducts = desiredProducts;
        }

        
        public void MakePurchases(List<Seller> sellers)
        {
            double remainingMoney = Money;

            // Iterate through desired products
            foreach (var productType in DesiredProducts.Keys)
            {
                int desiredQuantity = DesiredProducts[productType];

                // Iteration by vendors
                foreach (var seller in sellers)
                {
                    // If the seller has no products, we move on to the next one
                    if (seller.ProductsAvailable <= 0)
                        continue;

                    // Total Cost of Purchase
                    double totalCost = desiredQuantity * seller.ProductPrice;

                    // Calculating the buyer's willingness to buy depending on the price of the product
                    double willingnessToBuy = 1.0 - seller.ProductPrice / 2.0;

                    // If the buyer has enough money and still wants to buy
                    if (totalCost <= remainingMoney && desiredQuantity > 0)
                    {
                        // We calculate the quantity to buy based on the propensity to buy
                        int quantityToBuy = (int)(desiredQuantity * willingnessToBuy);

                        // We check the availability of products at the seller
                        quantityToBuy = Math.Min(quantityToBuy, seller.ProductsAvailable);

                        // We make a purchase
                        seller.SellProduct(quantityToBuy);
                        remainingMoney -= quantityToBuy * seller.ProductPrice;
                        desiredQuantity -= quantityToBuy;

                        //If the buyer has bought enough, we discontinue the
                        if (desiredQuantity <= 0)
                            break;
                    }
                }
            }

            
            Money = remainingMoney;
        }

        
        public void PrintStatus()
        {
            Console.WriteLine($"{Name}: Money = {Money:F2}");
        }

        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        
        public void UpdateMoney(double newMoney)
        {
            Money = newMoney;
        }

        
        public void UpdateDesiredProduct(string product, int newQuantity)
        {
            DesiredProducts[product] = newQuantity;
        }
    }
}
