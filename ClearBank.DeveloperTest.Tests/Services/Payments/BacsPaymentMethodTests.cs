using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace ClearBank.DeveloperTest.Tests.Services.Payments
{
    public class BacsPaymentMethodTests
    {
        public static IEnumerable<object[]> PaymentMethodTestCases =>

            new List<object[]> {
                new object[] { null , false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments }, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs }, true },
            };

        [Theory]
        [MemberData(nameof(PaymentMethodTestCases))]
        public void GivenIsValidPaymentMethodWhenAccountProvidedThenIsValidShouldBeCalculatedCorrectly(Account account, bool expectedIsValidResult)
        {
            var sut = new BacsPaymentMethod();
            var result = sut.IsValidPaymentMethod(account, 11m);

            result.Should().Be(expectedIsValidResult);
        }
    }
}
