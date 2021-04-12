using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IProductStockRepository
    {
        void AddStock(Product product);
        bool IsInStock(Product product);
        void ReduceStock(Product product);
    }

    public class ProductStockRepository : IProductStockRepository
    {
        public static Dictionary<Product, int> _productStockDatabase = Setup();

        private static Dictionary<Product, int> Setup()
        {
            var productStockDatabase = new Dictionary<Product, int>();
            productStockDatabase.Add(Product.Keyword, 1);
            productStockDatabase.Add(Product.Mic, 1);
            productStockDatabase.Add(Product.Mouse, 1);
            productStockDatabase.Add(Product.Speaker, 1);
            return productStockDatabase;
        }

        public bool IsInStock(Product product)
        {
            Console.WriteLine("Call Get On Database");
            return _productStockDatabase[product] > 0;

        }

        public void ReduceStock(Product product)
        {
            Console.WriteLine("Call Update On Database");
            _productStockDatabase[product]--;

        }
        public void AddStock(Product product)
        {
            Console.WriteLine("Call Update On Database");
            _productStockDatabase[product]++;

        }
    }
    //public class ProductStockRepository
    //{
    //    public static Dictionary<Product, int> _productStockDatabase = Setup();

    //    private static Dictionary<Product, int> Setup()
    //    {
    //        var productStockDatabase = new Dictionary<Product, int>();
    //        productStockDatabase.Add(Product.Keyword, 1);
    //        productStockDatabase.Add(Product.Mic, 1);
    //        productStockDatabase.Add(Product.Mouse, 1);
    //        productStockDatabase.Add(Product.Speaker, 1);
    //        return productStockDatabase;
    //    }

    //    public bool IsInStock(Product product)
    //    {
    //        Console.WriteLine("Call Get On Database");
    //        return _productStockDatabase[product] > 0;

    //    }

    //    public void ReduceStock(Product product)
    //    {
    //        Console.WriteLine("Call Update On Database");
    //        _productStockDatabase[product]--;

    //    }
    //    public void AddStock(Product product)
    //    {
    //        Console.WriteLine("Call Update On Database");
    //        _productStockDatabase[product]++;

    //    }
    //}
}
