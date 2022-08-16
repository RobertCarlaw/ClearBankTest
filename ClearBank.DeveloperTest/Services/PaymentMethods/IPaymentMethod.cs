using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services.PaymentMethods
{
    public interface IPaymentMethod
    {
        bool IsValidPaymentMethod(Account account, decimal amount);
    }
}
