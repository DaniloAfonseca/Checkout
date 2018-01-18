namespace Checkout.App
{
    public interface ICheckout
    {
        void Scan(string sku);
        int GetTotal();
    }
}
