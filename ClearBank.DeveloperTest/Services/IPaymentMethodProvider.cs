using ClearBank.DeveloperTest.Services.PaymentMethods;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest
{
    public interface IPaymentMethodProvider
    {
        IPaymentMethod GetPaymentMethod(PaymentScheme paymentType);
    }
}
