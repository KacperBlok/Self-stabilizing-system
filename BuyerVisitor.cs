namespace Rynek
{
    public class BuyerVisitor : IVisitor
    {
        private double inflationRate;

        public BuyerVisitor(double inflationRate) //Inflation information
        {
            this.inflationRate = inflationRate;
        }

        public void Visit(Buyer buyer)
        {
            //Update buyer parameters based on inflation
            double adjustedMoney = buyer.Money / (1 + inflationRate);
            buyer.UpdateMoney(adjustedMoney);

            //Update of the desired quantity of products depending on inflation
            foreach (var product in buyer.DesiredProducts.Keys)
            {
                int adjustedQuantity = (int)(buyer.DesiredProducts[product] * (1 - inflationRate));
                buyer.UpdateDesiredProduct(product, adjustedQuantity);
            }
        }

        public void Visit(Seller seller)
        {
            
        }
    }
}
