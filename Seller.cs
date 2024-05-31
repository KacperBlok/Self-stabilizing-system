using System;

namespace Rynek
{
    public class Seller
    {
        public string Name { get; private set; }
        public double ProductPrice { get; set; }
        public int ProductsAvailable { get; private set; }
        private double productionCost;

        public Seller(string name, double productionCost, double productPrice, int productsAvailable)
        {
            Name = name;
            this.productionCost = productionCost;
            ProductPrice = productPrice;
            ProductsAvailable = productsAvailable;
        }

        public void SellProduct(int quantity)
        {
            if (ProductsAvailable >= quantity)
            {
                ProductsAvailable -= quantity;
            }
        }

        public void ApplyInflation(double inflationRate)
        {
            ProductPrice *= (1 + inflationRate);
            productionCost *= (1 + inflationRate);
        }

        public double GetProductionCost()
        {
            return productionCost;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"{Name}: Price = {ProductPrice:F2}, Stock = {ProductsAvailable}");
        }

        public void AdjustAvailability(int adjustment)
        {
            ProductsAvailable += adjustment;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
