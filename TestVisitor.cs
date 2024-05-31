using Xunit;
using System.Collections.Generic;

namespace Rynek.Tests
{
    public class TestVisitor
    {
        [Fact]
        public void TestBuyerVisitor()
        {
            //Buyer initialization
            Buyer buyer = new Buyer("Buyer", 500, new Dictionary<string, int> { { "necessity", 10 } });
            BuyerVisitor visitor = new BuyerVisitor(0.05); 

            buyer.Accept(visitor);

            
            Assert.Equal(476.19, buyer.Money, 2); 
            Assert.Equal(9, buyer.DesiredProducts["necessity"]); 
        }

        [Fact]
        public void TestSellerVisitor()
        {
            //Seller initialization
            Seller seller = new Seller("Seller", 100, 1.2, 90);
            SellerVisitor visitor = new SellerVisitor();

            //acceptance
            seller.Accept(visitor);

            
            Assert.Equal(99, seller.ProductsAvailable); 
        }
    }
}
