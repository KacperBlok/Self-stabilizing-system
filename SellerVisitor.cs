namespace Rynek
{
    public class SellerVisitor : IVisitor
    {
        public void Visit(Seller seller)
        {
            // Update your merchant product data
            //increase in product availability by 10%
            int adjustment = (int)(seller.ProductsAvailable * 0.1);
            seller.AdjustAvailability(adjustment);
        }

        public void Visit(Buyer buyer)
        {
            //Not used for buyer
        }
    }
}
