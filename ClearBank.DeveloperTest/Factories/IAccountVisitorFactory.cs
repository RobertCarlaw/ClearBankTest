using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Factories
{
    public interface IAccountVisitorFactory
    {
        IVisitor Get(AccountUpdate accountUpdate, MakePaymentRequest request);
    }
}
