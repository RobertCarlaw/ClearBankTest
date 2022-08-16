using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Services.PaymentMethods;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentServiceTests
    {
        [Fact]
        public void GivenMakePaymentWhenCalledAndPaymentMethodIsInvalidThenReturnCorrectly()
        {
            MakePaymentRequest request = new MakePaymentRequest() { Amount = 5 };
            const string accountNumber = "1234567890";
            const bool expectedResult = false;

            Mock<IAccountService> accountServiceMock = new Mock<IAccountService>();
            Mock<IPaymentMethodProvider> paymentMethodProviderMock = new Mock<IPaymentMethodProvider>();
            Mock<IAccountVisitorFactory> accountVisitorFactoryMock = new Mock<IAccountVisitorFactory>();
            Mock<IPaymentMethod> paymentMethodMock = new Mock<IPaymentMethod>();
            var account = new Account() {  Balance = 10 };

            accountServiceMock.Setup(x => x.Get(accountNumber)).Returns(account);
            paymentMethodMock.Setup(x=>x.IsValidPaymentMethod(account, request.Amount)).Returns(expectedResult);
            paymentMethodProviderMock.Setup(a => a.GetPaymentMethod(It.IsAny<PaymentScheme>())).Returns(paymentMethodMock.Object);
      
            var sut = new PaymentService(accountServiceMock.Object, paymentMethodProviderMock.Object, accountVisitorFactoryMock.Object);

            var result = sut.MakePayment(request);

            result.Success.Should().Be(expectedResult);
            accountServiceMock.Verify(x=>x.Update(It.IsAny<Account>()),Times.Never);
        }

        [Fact]
        public void GivenMakePaymentWhenCalledAndPaymentMethodIsVvalidThenReturnCorrectly()
        {
            const string accountNumber = "1234567890";
            MakePaymentRequest request = new MakePaymentRequest() { Amount = 5, DebtorAccountNumber = accountNumber };
            
            const bool expectedResult = true;
            const decimal expectedBalance = 10m;

            Mock<IAccountService> accountServiceMock = new Mock<IAccountService>();
            Mock<IPaymentMethodProvider> paymentMethodProviderMock = new Mock<IPaymentMethodProvider>();
            Mock<IAccountVisitorFactory> accountVisitorFactoryMock = new Mock<IAccountVisitorFactory>();
            Mock<IPaymentMethod> paymentMethodMock = new Mock<IPaymentMethod>();
            var account = new Account() { Balance = 15 };

            accountServiceMock.Setup(x => x.Get(accountNumber)).Returns(account);
            paymentMethodMock.Setup(x => x.IsValidPaymentMethod(account, request.Amount)).Returns(expectedResult);
            paymentMethodProviderMock.Setup(a => a.GetPaymentMethod(It.IsAny<PaymentScheme>())).Returns(paymentMethodMock.Object);
            accountVisitorFactoryMock.Setup(x=>x.Get(It.IsAny<AccountUpdate>(), It.IsAny<MakePaymentRequest>())).Returns(new DeductAccountBalance(request.Amount));
            var sut = new PaymentService(accountServiceMock.Object, paymentMethodProviderMock.Object, accountVisitorFactoryMock.Object);

            var result = sut.MakePayment(request);

            result.Success.Should().Be(expectedResult);
            accountServiceMock.Verify(x => x.Update(account), Times.Once);
            accountServiceMock.Verify(x => x.Update(It.Is<Account>(a=>a.Balance == expectedBalance)), Times.Once);
        }
    }
}
