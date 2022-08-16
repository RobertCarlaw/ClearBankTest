using ClearBank.DeveloperTest.Types;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Services.PaymentMethods
{
    internal class FasterPaymentsPaymentMethod : IPaymentMethod
    {
        public bool IsValidPaymentMethod(Account account, decimal amount)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return false;
            }
            else if (account.Balance < amount)
            {
                return false;
            }

            return true;
        }
    }
}
