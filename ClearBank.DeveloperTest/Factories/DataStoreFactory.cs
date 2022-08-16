using ClearBank.DeveloperTest.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Factories
{
    internal class DataStoreFactory : IDataStoreFactory
    {
        private const string DefaultDataStoreType = "Backup";

        public IDataStore Get(string dataStoreType)
        {
            if (string.Compare(DefaultDataStoreType,dataStoreType) == 0)
            {
                return new BackupAccountDataStore();
            }
            else
            {
                return new AccountDataStore();
            }
        }
    }
}
