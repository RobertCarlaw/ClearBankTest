using System.Configuration;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Services
{
    public class ConfigurationService : IConfigurationService
    {
        string IConfigurationService.DataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}
