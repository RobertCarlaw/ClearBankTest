using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Types
{
    public class DeductAccountBalanceTests
    {
        public static IEnumerable<object[]> DeductAccountBalanceTestCases =>

            new List<object[]> {
                new object[] { 1m, 2m, -1m  },
                new object[] { 10.99m, 10.99m, 0m },
                new object[] { 13.52m, 3.51m, 10.01m }
            };

        [Theory]
        [MemberData(nameof(DeductAccountBalanceTestCases))]
        public void GivenDeductAccountBalanceWhenVisitCalledThenAccountBalanceCalculatedCorrectly(Decimal currentAmount, Decimal deductableAmount, Decimal expectedAccountBalance)
        {
            var account = new Account()
            {
                Balance = currentAmount
            };

            var sut = new DeductAccountBalance(deductableAmount);

            sut.Visit(account);

            account.Balance.Should().Be(expectedAccountBalance);
        }
    }
}
