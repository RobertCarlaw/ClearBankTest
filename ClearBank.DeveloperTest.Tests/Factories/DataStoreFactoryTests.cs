using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Factories
{
    public class DataStoreFactoryTests
    {
        [Theory]
        [InlineData("Backup")]
        [InlineData("")]
        [InlineData("Account")]
        [InlineData("Anything")]
        public void GivenDataStoreFactoryWhenDataStoreIsProvidedThenCorrectDataStoreIsReturned(string dataStoreFactoryType)
        {
            var sut = new DataStoreFactory();

            var result = sut.Get(dataStoreFactoryType);

            if(dataStoreFactoryType == "Backup")
            {
                result.Should().BeOfType<BackupAccountDataStore>();
            }
            else
            {
                result.Should().BeOfType<AccountDataStore>();
            }
        }
    }
}
