using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IShippingProcessor
    {
        void MailProduct(Product product);
    }
    public class ShippingProcessor : IShippingProcessor
    {
        private readonly IProductStockRepository _productStockRepository;

        public ShippingProcessor(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }
        public void MailProduct(Product product)
        {

            _productStockRepository.ReduceStock(product);
            Console.WriteLine("####Call to Shipping API####");
        }
    }
    //public class ShippingProcessor
    //{
    //    public void MailProduct(Product product)
    //    {
    //        var productStockRepository = new ProductStockRepository();
    //        productStockRepository.ReduceStock(product);


    //        Console.WriteLine("####Call to Shipping API####");
    //    }
    //}
}
