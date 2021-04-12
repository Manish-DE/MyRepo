using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
     public interface IPaymentProcessor
    {
        void ChargeCreditCard(string creditCard, string expiryDate);
    }
    public class PaymentProcessor : IPaymentProcessor
    {

        public void ChargeCreditCard(string creditCard, string expiryDate)
        {
            if (string.IsNullOrEmpty(creditCard))
            {
                throw new ArgumentException("Invlid Credit Card", nameof(creditCard));
            }

            if (string.IsNullOrEmpty(expiryDate))
            {
                throw new ArgumentException("Invliad Expire Date", nameof(expiryDate));
            }

            Console.WriteLine("####Call to Creadit Card API###");
        }
    }
    //public class PaymentProcessor
    //{
    //    public void ChargeCreditCard(string creditCard, string expiryDate)
    //    {
    //        if (string.IsNullOrEmpty(creditCard))
    //        {
    //            throw new ArgumentException("Invlid Credit Card", nameof(creditCard));
    //        }

    //        if (string.IsNullOrEmpty(expiryDate))
    //        {
    //            throw new ArgumentException("Invliad Expire Date", nameof(expiryDate));
    //        }

    //        Console.WriteLine("####Call to Creadit Card API###");
    //    }
    //}
}
