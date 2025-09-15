namespace Wpm.Management.Application.Handlers
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
