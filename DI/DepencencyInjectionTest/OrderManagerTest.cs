using DependencyInjection;
using Moq;
using System;
using Xunit;

namespace DepencencyInjectionTest
{
    public class OrderManagerTest
    {
        [Fact]
        public void Test1()
        {
            var productStockRepositoryMock = new Mock<IProductStockRepository>();
            productStockRepositoryMock
                .Setup(m => m.IsInStock(It.IsAny<Product>()))
                .Returns(false);

            var paymentProcessorMock = new Mock<IPaymentProcessor>();
            var shippingProcessorMock = new Mock<IShippingProcessor>();

            var orderManager = new OrderManager(productStockRepositoryMock.Object, paymentProcessorMock.Object, shippingProcessorMock.Object);
            Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyword, "1234123412341234", "0210"));
            //var orderManager = new OrderManager();
            //orderManager.Submit(Product.Keyword, "1234123412341234", "0210");
            //Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyword, "1234123412341234", "0210"));



            //var orderManager = new OrderManager();
            //orderManager.Submit(Product.Keyword, "1234123412341234", "0210");
            //Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyword, "1234123412341234", "0210"));


        }
    }
}
