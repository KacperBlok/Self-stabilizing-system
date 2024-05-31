using Xunit;
using System.Collections.Generic;

namespace Rynek.Tests
{
    public class TestMarket
    {
        [Fact]
        public void TestMarketInitialization()
        {
            Market market = new Market();
            CentralBank centralBank = new CentralBank(market);
            market.SetCentralBank(centralBank);
            Assert.NotNull(market);
        }

        [Fact]
        public void TestSellerInflation()
        {
            Seller seller = new Seller("Seller", 100, 1.2, 90);
            seller.ApplyInflation(0.05);

            Assert.Equal(1.26, seller.ProductPrice, 2);
            Assert.Equal(105, seller.GetProductionCost(), 2);
        }

        [Fact]
        public void TestBuyerPurchase()
        {
            Market market = new Market();
            CentralBank centralBank = new CentralBank(market);
            market.SetCentralBank(centralBank);

            Buyer buyer = new Buyer("Buyer", 500, new Dictionary<string, int> { { "necessity", 10 } });
            Seller seller = new Seller("Seller", 100, 10, 90);

            market.AddBuyer(buyer);
            market.AddSeller(seller);

            buyer.MakePurchases(new List<Seller> { seller });

            Assert.Equal(400, buyer.Money, 2);
            Assert.Equal(80, seller.ProductsAvailable);
        }
    }
}
