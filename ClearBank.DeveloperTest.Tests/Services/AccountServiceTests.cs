using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class AccountServiceTests
    {
        [Fact]
        public void GivenAccountServiceWhenGetCalledThenReturnAccountCorrectly()
        {
            const string dataStoreType = "randomDataStoreType";
            const string accountNumber = "123abc";
            Mock<IConfigurationService> configurationServiceMock = new Mock<IConfigurationService>();
            Mock<IDataStoreFactory> dataStoreFactoryMock = new Mock<IDataStoreFactory>();
            Mock<IDataStore> dataStoreMock = new Mock<IDataStore>();
            var account = new Account() { Balance = 11m };

            configurationServiceMock.Setup(x => x.DataStoreType).Returns(dataStoreType);
            dataStoreFactoryMock.Setup(x=>x.Get(dataStoreType)).Returns(dataStoreMock.Object);
            dataStoreMock.Setup(x=>x.GetAccount(accountNumber)).Returns(account);

            var sut = new AccountService(configurationServiceMock.Object, dataStoreFactoryMock.Object);
            var result = sut.Get(accountNumber);

            result.Balance.Should().Be(account.Balance);
            dataStoreMock.Verify(x=>x.GetAccount(accountNumber), Times.Once()); 
        }

        [Fact]
        public void GivenAccountServiceWhenUpdateCalledThenUpdateAccount()
        {
            const string dataStoreType = "randomDataStoreType";
            Mock<IConfigurationService> configurationServiceMock = new Mock<IConfigurationService>();
            Mock<IDataStoreFactory> dataStoreFactoryMock = new Mock<IDataStoreFactory>();
            Mock<IDataStore> dataStoreMock = new Mock<IDataStore>();
            var account = new Account() { Balance = 11m };

            configurationServiceMock.Setup(x => x.DataStoreType).Returns(dataStoreType);
            dataStoreFactoryMock.Setup(x => x.Get(dataStoreType)).Returns(dataStoreMock.Object);

            var sut = new AccountService(configurationServiceMock.Object, dataStoreFactoryMock.Object);
            sut.Update(account);

            dataStoreMock.Verify(x => x.UpdateAccount(account), Times.Once());
        }
    }
}
