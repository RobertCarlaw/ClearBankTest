using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        Account Get(string accountNumber);
        void Update(Account account);
    }
}
