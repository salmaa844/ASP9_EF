using session6.Context;
using session6.Model;
using System.Diagnostics;

namespace session6
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ApplicationdbContext dbcontext = new ApplicationdbContext();

            //add data to product table
            Product product1 = new Product()
            {
                Name = "Laptop",
                Price = 2000,
                Description = "Predator300"
            };
            Product product2 = new Product
            {
                Name = "Desktop",
                Price = 1500,
                Description = "Gaming Tower"
            };
            Product product3 = new Product
            {
                Name = "Tablet",
                Price = 500,
                Description = "iPad Air"
            };
            //add data to order table
            Order order1 = new Order
            {
                createdAt = DateTime.Now
            };
            Order order2 = new Order
            {
                createdAt = DateTime.Now.AddDays(1)
            };
            Order order3 = new Order
            {
                createdAt = DateTime.Now.AddDays(2)
            };

            /*dbcontext.Products.Add(product3);
            dbcontext.SaveChanges();
            Console.WriteLine("done");

            dbcontext.Orders.Add(order1);
            dbcontext.SaveChanges();
            Console.WriteLine("done1");*/


            //get all products 
            var products = dbcontext.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
            }
            Console.WriteLine("==============");
            //get all orders
            var orders = dbcontext.Orders.ToList();
            foreach(var order in orders)
            {
                Console.WriteLine(order.createdAt);

            }
            Console.WriteLine("==============");
            //update product name
            var prod = dbcontext.Products.First(pro => pro.Id == 1);
            prod.Name = "flask";
            dbcontext.SaveChanges();
            Console.WriteLine($"=> id:"+prod.Id+",name:"+ prod.Name + ",des:" + prod.Description);
            //update order created at
            var ord = dbcontext.Orders.First(order => order.Id == 1);
            ord.createdAt = DateTime.Now.AddDays(4);
            dbcontext.SaveChanges();
            Console.WriteLine($"=> id:" + ord.Id + ",createAt:" + ord.createdAt);
            Console.WriteLine("==============");
            //remove product with id 2
            var remproduct = dbcontext.Products.First(p => p.Id == 2);
            dbcontext.Products.Remove(remproduct);
            dbcontext.SaveChanges();
            Console.WriteLine("Done remove product");
            var remorder = dbcontext.Orders.First(p => p.Id == 3);
            dbcontext.Orders.Remove(remorder);
            dbcontext.SaveChanges();
            Console.WriteLine("Done remove order");
        }
    }
}
