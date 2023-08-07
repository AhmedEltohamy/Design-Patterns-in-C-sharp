using Visitor.Entities;

namespace Visitor.Visitors;

internal interface IVisitor
{
    void Visit(Customer customer);

    void Visit(Employee employee);
}