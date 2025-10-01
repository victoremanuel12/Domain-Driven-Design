namespace Wpm.SharedKerbel.Abstract
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}
