using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Factories
{
    public interface IDataStoreFactory
    {
        IDataStore Get(string dataStoreType);
    }
}
