using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
         // -------- ORDER 1 --------
        Address address1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer cust1 = new Customer("James Morgan", address1);
        Order order1 = new Order(cust1);

        order1.AddProduct(new Product("Keyboard", "KB001", 30, 2));
        order1.AddProduct(new Product("Mouse", "MS210", 15, 1));
        order1.AddProduct(new Product("USB Cable", "US900", 5, 3));

        // -------- ORDER 2 --------
        Address address2 = new Address("48 Riverside Rd", "Nairobi", "Nairobi", "Kenya");
        Customer cust2 = new Customer("Eunice Wanjiku", address2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Laptop Stand", "LS333", 25, 1));
        order2.AddProduct(new Product("Webcam", "WC777", 40, 1));

        // -------- DISPLAY RESULTS --------
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost()}\n");
            Console.WriteLine("--------------------------------------------\n");
        }
    }
}