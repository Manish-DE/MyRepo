using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{

    public interface IOrderManager
    {
        void Submit(Product product, string creditCardNumber, string expireDate);
    }
    public class OrderManager : IOrderManager
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IShippingProcessor _shippingProcessor;

        public OrderManager(IProductStockRepository productStockRepository,
            IPaymentProcessor paymentProcessor,
            IShippingProcessor shippingProcessor)
        {
            _productStockRepository = productStockRepository;
            _paymentProcessor = paymentProcessor;
            _shippingProcessor = shippingProcessor;
        }
        public void Submit(Product product, string creditCardNumber, string expireDate)
        {
            //Product Stock
            if (!_productStockRepository.IsInStock(product))
                throw new Exception($"{product.ToString()} current not in stock");

            //Payment
            _paymentProcessor.ChargeCreditCard(creditCardNumber, expireDate);

            //Ship the Product
            _shippingProcessor.MailProduct(product);
        }
    }
    //public class OrderManager
    //{
    //    public void Submit(Product product, string creditCardNumber, string expireDate)
    //    {
    //        //Product Stock
    //        var productStockRepository = new ProductStockRepository();
    //        if (!productStockRepository.IsInStock(product))
    //            throw new Exception($"{product.ToString()} current not in stock");

    //        //Payment
    //        var paymentprocessor = new PaymentProcessor();
    //        paymentprocessor.ChargeCreditCard(creditCardNumber, expireDate);

    //        //Ship the Product
    //        var shippingProcessor = new ShippingProcessor();
    //        shippingProcessor.MailProduct(product);
    //    }
    //}
}
