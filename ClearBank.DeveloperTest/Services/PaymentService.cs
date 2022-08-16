using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;
        private readonly IPaymentMethodProvider _paymentMethodProvider;
        private readonly IAccountVisitorFactory _accountVisitorFactory;
        public PaymentService(IAccountService accountService, IPaymentMethodProvider paymentMethodProvider, IAccountVisitorFactory accountVisitorFactory)
        {
            _accountService = accountService;
            _paymentMethodProvider = paymentMethodProvider;
            _accountVisitorFactory = accountVisitorFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = _accountService.Get(request.DebtorAccountNumber);
            var model = new MakePaymentResult();

            var paymentMethod = _paymentMethodProvider.GetPaymentMethod(request.PaymentScheme);
            model.Success = paymentMethod.IsValidPaymentMethod(account, request.Amount);

            if (model.Success)
            {
                var deductAccountBalance = _accountVisitorFactory.Get(AccountUpdate.DeductBalance, request);
                account.Accept(deductAccountBalance);
                _accountService.Update(account);
            }

            return model;
        }
    }
}
