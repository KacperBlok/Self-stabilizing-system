# Self-Stabilizing System - README

## Project Description

The "Self-Stabilizing System" project is a market simulation that models interactions between buyers, sellers, and a central bank. The project demonstrates how various factors, such as inflation and price stabilization, affect the market and consumer purchasing decisions. The program runs a simulation for 10 turns to observe market behaviors under different conditions.

## Project Structure

- **Buyer.cs**: Defines the Buyer class representing a buyer in the market.
- **BuyerVisitor.cs**: Implements the Visitor pattern, adjusting the buyer's state based on inflation.
- **CentralBank.cs**: Manages the market and calculates tax revenues.
- **IVisitor.cs**: Interface for the Visitor pattern.
- **Market.cs**: Manages sellers, buyers, and the central bank, and applies inflation to the market.
- **Program.cs**: Main program file that initializes and runs the market simulation for 10 turns.
- **Seller.cs**: Defines the Seller class representing a seller in the market.
- **SellerVisitor.cs**: Implements the Visitor pattern, adjusting the seller's state.
- **TestMarket.cs**: Contains unit tests for the `Market` class.
- **TestVisitor.cs**: Contains unit tests for the Visitor pattern.

## How to Run the Project

1. **Clone the repository**
   ```sh
   git clone <repository_url>
   cd SelfStabilizingSystem
   ```

2. **Build and run the project**
   Use any C#-supported IDE, such as Visual Studio, to build and run the project. Alternatively, you can use the `dotnet` command:
   ```sh
   dotnet build
   dotnet run --project SelfStabilizingSystem
   ```

3. **Run the unit tests**
   ```sh
   dotnet test
   ```

## Classes and Methods

### Buyer.cs
- **Buyer**: Constructor initializing the buyer with a name, money, and desired products.
- **MakePurchases(List<Seller> sellers)**: Makes purchases from a list of sellers.
- **PrintStatus()**: Displays the buyer's current money status.
- **Accept(IVisitor visitor)**: Implements the Visitor pattern by accepting an `IVisitor` object.
- **UpdateMoney(double newMoney)**: Updates the buyer's money.
- **UpdateDesiredProduct(string product, int newQuantity)**: Updates the desired quantity of a specific product.

### BuyerVisitor.cs
- **BuyerVisitor**: Constructor initializing the visitor with an inflation rate.
- **Visit(Buyer buyer)**: Adjusts the buyer's money and desired products based on inflation.
- **Visit(Seller seller)**: Unused in this class, focuses on buyers.

### CentralBank.cs
- **CentralBank**: Constructor initializing the central bank with a market.
- **UpdateInflation(double inflationRate)**: Updates market inflation by calling `ApplyInflation` on the market object.
- **UpdateTaxRevenue(double totalRevenue)**: Calculates and prints tax revenue based on the total revenue and a stabilization factor.

### IVisitor.cs
- **Visit(Buyer buyer)**: Visitor method for buyers.
- **Visit(Seller seller)**: Visitor method for sellers.

### Market.cs
- **Market**: Constructor initializing the market with lists of sellers and buyers.
- **SetCentralBank(CentralBank centralBank)**: Sets the central bank for the market.
- **AddSeller(Seller seller)**: Adds a seller to the market.
- **AddBuyer(Buyer buyer)**: Adds a buyer to the market.
- **UpdateMarketStatus()**: Updates the market status by making purchases and applying a stabilization algorithm.
- **ApplyInflation(double inflationRate)**: Applies inflation to the prices of products for each seller.
- **PrintStatus()**: Displays the current status of the market, including sellers, buyers, and inflation.
- **AcceptVisitor(IVisitor visitor)**: Accepts a visitor for each buyer and seller.

### Seller.cs
- **Seller**: Constructor initializing the seller with a name, production cost, product price, and available products.
- **SellProduct(int quantity)**: Sells a specified quantity of products.
- **ApplyInflation(double inflationRate)**: Applies inflation to the product price and production cost.
- **GetProductionCost()**: Returns the production cost.
- **PrintStatus()**: Displays the current product price and availability.
- **AdjustAvailability(int adjustment)**: Adjusts the availability of products.
- **Accept(IVisitor visitor)**: Implements the Visitor pattern by accepting an `IVisitor` object.

### SellerVisitor.cs
- **SellerVisitor**: Implements the Visitor pattern, increasing product availability by 10% for sellers.
- **Visit(Seller seller)**: Increases the seller's product availability by 10%.
- **Visit(Buyer buyer)**: Unused in this class, focuses on sellers.

### TestMarket.cs
- **TestMarketInitialization()**: Tests market and central bank initialization.
- **TestSellerInflation()**: Tests the application of inflation on the seller's product price and production cost.
- **TestBuyerPurchase()**: Tests the buyer's purchase process, checking changes in the buyer's money and product availability.

### TestVisitor.cs
- **TestBuyerVisitor()**: Tests the BuyerVisitor, checking changes in the buyer's money and desired products based on inflation.
- **TestSellerVisitor()**: Tests the SellerVisitor, checking the increase in product availability for the seller.

## Simulation

The program simulates 10 turns of market activity. In each turn, the market status is updated, and the stabilization algorithm is applied to ensure market stability.

```csharp
// Run the simulation for 10 turns
for (int turn = 1; turn <= 10; turn++)
{
    Console.WriteLine($"Turn {turn}:");
    market.UpdateMarketStatus();
    market.PrintStatus();
    Console.WriteLine();
}
```

## Analysis and Summary

- **Market Functionality**: The simulation results indicate that the market operates as expected, with buyers and sellers reacting to changing market conditions, such as product prices and availability.
- **Algorithm Functionality**: Algorithms for price stabilization and income tax calculation work correctly. Tax income is calculated based on sales revenues, demonstrating effective turnover monitoring.
- **Inflation Changes**: The simulation shows changes in inflation over time, affecting product prices and buyer purchasing power. Different inflation levels across turns confirm correct inflation mechanisms.
- **Market Stability Simulation**: The simulation illustrates how markets respond to changes in conditions like inflation and taxes. The self-stabilizing algorithm involving sellers, buyers, and the central bank appears to function correctly.
- **Expectation Confirmation**: Simulation results confirm expectations regarding market behavior in response to various factors, validating the implementation of the market simulation.

In summary, the simulation results suggest that the tests work well and confirm the correctness of the market simulation implementation. All core functionalities, such as trading between buyers and sellers, income tax calculation, and responses to inflation changes, appear to work as intended.

