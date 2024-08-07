using CrudEf.Data;
using CrudEf.Models;

namespace CrudEf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            //create
            Product product1 = new Product { Name = "Product1", Price = 10.00 };
            Product product2 = new Product { Name = "Product2", Price = 20.00 };
            Product product3 = new Product { Name = "Product3", Price = 30.00 };
            context.Products.AddRange(product1, product2, product3);
            context.SaveChanges();

            Order order1 = new Order { Address = "Address1", CreatedAt = DateTime.Now };
            Order order2 = new Order { Address = "Address2", CreatedAt = DateTime.Now };
            Order order3 = new Order { Address = "Address3", CreatedAt = DateTime.Now };
            context.Orders.AddRange(order1, order2, order3);
            context.SaveChanges();

            //read
            var products = context.Products.ToList();
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
            }
            var orders = context.Orders.ToList();
            Console.WriteLine("Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Id} - {order.Address} - {order.CreatedAt}");
            }

            //Update
            var productToUpdate = context.Products.First(p => p.Id == 1);
            productToUpdate.Name = "New Product";
            context.SaveChanges();
            var orderToUpdate = context.Orders.First(o => o.Id == 1);
            orderToUpdate.CreatedAt = DateTime.Now.AddDays(1);
            context.SaveChanges();

            //delete
            var productToRemove = context.Products.First(p => p.Id == 2);
            context.Products.Remove(productToRemove);
            context.SaveChanges();
            var orderToRemove = context.Orders.FirstOrDefault(o => o.Id == 3);
            context.Orders.Remove(orderToRemove);
            context.SaveChanges();
        }
    }
}
