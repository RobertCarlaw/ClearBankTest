using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ClearBank.DeveloperTest.Services;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentMethodProviderTests
    {
        public static IEnumerable<object[]> PaymentMethodTestCases =>

           new List<object[]> {
                new object[] { PaymentScheme.Chaps, typeof(ChapsPaymentMethod)  },
                new object[] { PaymentScheme.FasterPayments, typeof(FasterPaymentsPaymentMethod)},
                new object[] { PaymentScheme.Bacs, typeof(BacsPaymentMethod) }
           };

        [Theory]
        [MemberData(nameof(PaymentMethodTestCases))]
        public void GivenGetPaymentMethodWhenPaymentSchemeProvidedThenShouldReturnCorrectPaymentOffer(PaymentScheme paymentScheme, Type expectedType)
        {
            var sut = new PaymentMethodProvider();
            var result = sut.GetPaymentMethod(paymentScheme);

            result.Should().BeOfType(expectedType);
        }
    }
}
