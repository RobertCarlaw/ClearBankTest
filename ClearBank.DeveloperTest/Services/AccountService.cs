using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IDataStoreFactory _dataStoreFactory;
        private readonly string _dataStoreType;

        public AccountService(IConfigurationService configurationService, IDataStoreFactory dataStoreFactory)
        {
            _configurationService = configurationService;
            _dataStoreFactory = dataStoreFactory;
            _dataStoreType = _configurationService.DataStoreType;
        }

        public Account Get(string accountNumber)
        {
            var dataStore = _dataStoreFactory.Get(_dataStoreType);
            return dataStore.GetAccount(accountNumber);
        }

        public void Update(Account account)
        {
            var dataStore = _dataStoreFactory.Get(_dataStoreType);
            dataStore.UpdateAccount(account);
        }
    }
}
