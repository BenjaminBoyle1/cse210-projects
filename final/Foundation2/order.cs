public class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = products.Sum(product => product.CalculateTotalPrice());
        decimal shippingCost = customer.IsInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        Customer customer = this.customer;
        return $"Name: {customer.GetName()}\nAddress: {customer.GetAddress().FormatAddress()}";
    }
}
