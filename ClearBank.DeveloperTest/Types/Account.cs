namespace ClearBank.DeveloperTest.Types
{
    public class Account : IElement
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get;  set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
