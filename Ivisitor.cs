namespace Rynek
{
    public interface IVisitor
    {
        void Visit(Buyer buyer);
        void Visit(Seller seller);
    }
}
