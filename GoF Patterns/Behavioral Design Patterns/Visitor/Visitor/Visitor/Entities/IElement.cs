using Visitor.Visitors;

namespace Visitor.Entities;

internal interface IElement
{
    void Accept(IVisitor visitor);
}