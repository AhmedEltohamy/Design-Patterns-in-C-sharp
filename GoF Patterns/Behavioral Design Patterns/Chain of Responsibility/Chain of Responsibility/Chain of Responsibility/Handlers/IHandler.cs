namespace Chain_of_Responsibility.Handlers;

internal interface IHandler<T> where T : class
{
    IHandler<T> SetNext(IHandler<T> nextHandler);
    void Handle(T request);
}
