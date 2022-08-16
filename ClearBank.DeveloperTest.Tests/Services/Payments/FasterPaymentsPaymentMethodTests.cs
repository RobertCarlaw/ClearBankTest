using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace ClearBank.DeveloperTest.Tests.Services.Payments
{
    public class FasterPaymentMethodTests
    {
        public static IEnumerable<object[]> PaymentMethodTestCases =>

            new List<object[]> {
                new object[] { null ,10m, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Balance = 10.01m }, 10m, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 9.99m }, 10m, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 10.01m }, 10m, true }
            };

        [Theory]
        [MemberData(nameof(PaymentMethodTestCases))]
        public void GivenIsValidPaymentMethodWhenAccountProvidedThenIsValidShouldBeCalculatedCorrectly(Account account, decimal amount, bool expectedIsValidResult)
        {
            var sut = new FasterPaymentsPaymentMethod();
            var result = sut.IsValidPaymentMethod(account, amount);

            result.Should().Be(expectedIsValidResult);
        }
    }
}
