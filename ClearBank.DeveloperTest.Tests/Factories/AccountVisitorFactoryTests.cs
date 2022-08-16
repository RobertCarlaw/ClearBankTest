using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Factories
{
    public class AccountVisitorFactoryTests
    {
        [Fact]
        public void GivenAccountVisitorFactoryWhenGetThenReturnCorrectly()
        {
            var sut = new AccountVisitorFactory();

            var result = sut.Get(AccountUpdate.DeductBalance, new MakePaymentRequest());

            result.Should().BeOfType<DeductAccountBalance>();
        }
    }
}
