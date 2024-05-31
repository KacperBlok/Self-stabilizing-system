using System;

namespace Rynek
{
    public class CentralBank
    {
        private Market market;
        public double StabilizationFactor { get; private set; }

        public CentralBank(Market market)
        {
            this.market = market;
            StabilizationFactor = 0.05; 
        }

        public void UpdateInflation(double inflationRate)
        {
            market.ApplyInflation(inflationRate);
        }

        public void UpdateTaxRevenue(double totalRevenue)
        {
            double currentTaxRevenue = StabilizationFactor * totalRevenue;
            Console.WriteLine($"Current tax revenue: {currentTaxRevenue:F2}");
        }
    }
}
