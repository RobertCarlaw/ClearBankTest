
namespace ClearBank.DeveloperTest.Types
{
    public class DeductAccountBalance : IVisitor
    {
        private readonly decimal _amount;
        public DeductAccountBalance(decimal amount)
        {
            _amount = amount;
        }

        public void Visit(IElement element)
        {
            var account = (Account)element;
            account.Balance -= _amount;
        }
    }
}
