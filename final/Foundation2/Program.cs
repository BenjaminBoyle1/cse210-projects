using System;

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Cityville", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product product1 = new Product("Product 1", "P1", 10, 2);
        Product product2 = new Product("Product 2", "P2", 15, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculateTotalCost());

        Address address2 = new Address("456 Park Avenue", "Townsville", "NY", "USA");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product3 = new Product("Product 3", "P3", 20, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.CalculateTotalCost());
    }
}
