using System;
using ClearBank.DeveloperTest.Types;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace ClearBank.DeveloperTest.Factories
{
    internal class AccountVisitorFactory : IAccountVisitorFactory
    {
        public IVisitor Get(AccountUpdate accountUpdate, MakePaymentRequest request)
        {
            if(accountUpdate != AccountUpdate.DeductBalance)
            {
                throw new NotImplementedException("Currently only DeductBalance implemented");
            }

            return new DeductAccountBalance(request.Amount);
        }
    }
}
