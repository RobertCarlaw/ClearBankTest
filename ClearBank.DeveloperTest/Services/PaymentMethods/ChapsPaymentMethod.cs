using ClearBank.DeveloperTest.Types;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Services.PaymentMethods
{
    internal class ChapsPaymentMethod : IPaymentMethod
    {
        public bool IsValidPaymentMethod(Account account, decimal amount)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                return false;
            }
            else if (account.Status != AccountStatus.Live)
            {
                return false;
            }

            return true;
        }
    }
}
