public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public decimal CalculateTotalPrice()
    {
        return price * quantity;
    }
}
