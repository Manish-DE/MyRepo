using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();
        static void Main(string[] args)
        {
            var product = string.Empty;
            var productStockReposity = new ProductStockRepository();
            //var orderManager = new OrderManager(
            //    productStockReposity,
            //    new PaymentProcessor(),
            //    new ShippingProcessor(productStockReposity)
            //    ) ;
            var orderManager = Container.GetService<IOrderManager>();
            while (product != "exit")
            {
                Console.WriteLine(@"Enter a Product:
                    Keyword = 0,
                    Mouse   = 1,
                    Mic = 2,
                    Speaker = 3
                    ");
                product = Console.ReadLine();
                try 
                { 
                    if(Enum.TryParse(product,out Product productEnum))
                    {

                        Console.WriteLine("Please Enter a Valid Credait Card Details: XXXX XXXX XXXX XXXX; MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(';').Length != 2)
                            throw new Exception("Invalid Payment Method");
                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been shipped");


                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);


            }
        }
    }
}
