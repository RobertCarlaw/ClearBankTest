using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Services
{
    internal class PaymentMethodProvider : IPaymentMethodProvider
    {
        private readonly Dictionary<PaymentScheme, IPaymentMethod> _paymentProviders;

        public PaymentMethodProvider()
        {
            _paymentProviders = new Dictionary<PaymentScheme, IPaymentMethod>()
            {
                {PaymentScheme.Chaps, new ChapsPaymentMethod() },
                {PaymentScheme.FasterPayments, new FasterPaymentsPaymentMethod() },
                {PaymentScheme.Bacs, new BacsPaymentMethod() }
            };
        }
        public IPaymentMethod GetPaymentMethod(PaymentScheme paymentType)
        {
            if (!_paymentProviders.ContainsKey(paymentType))
                throw new NotImplementedException();

            return _paymentProviders[paymentType];
        }
    }
}
