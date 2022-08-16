
namespace ClearBank.DeveloperTest.Types
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}
