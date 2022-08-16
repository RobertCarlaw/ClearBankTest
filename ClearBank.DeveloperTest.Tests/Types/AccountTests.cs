using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Types
{
    public class AccountTests
    {
        [Fact]
        public void GivenAcceptWhenCalledThenVisitorCalled()
        {
            Mock<IVisitor> accountVisitorMock = new Mock<IVisitor>();
            var sut = new Account();
            sut.Accept(accountVisitorMock.Object);

            accountVisitorMock.Verify(x=>x.Visit(sut), Times.Once);
        }
    }
}
