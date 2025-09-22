namespace Wpm.SharedKerbel.CommandHandler
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
