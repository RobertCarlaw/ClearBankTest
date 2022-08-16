using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace ClearBank.DeveloperTest.Tests.Services.Payments
{
    public class ChapsPaymentMethodTests
    {
        public static IEnumerable<object[]> PaymentMethodTestCases =>

            new List<object[]> {
                new object[] { null , false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Status=AccountStatus.Live }, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status=AccountStatus.Disabled }, false },
                new object[] { new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status=AccountStatus.Live }, true }
            };

        [Theory]
        [MemberData(nameof(PaymentMethodTestCases))]
        public void GivenIsValidPaymentMethodWhenAccountProvidedThenIsValidShouldBeCalculatedCorrectly(Account account, bool expectedIsValidResult)
        {
            var sut = new ChapsPaymentMethod();
            var result = sut.IsValidPaymentMethod(account, 11m);

            result.Should().Be(expectedIsValidResult);
        }
    }
}
