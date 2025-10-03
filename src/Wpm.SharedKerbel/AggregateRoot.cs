using Wpm.SharedKerbel.Abstract;

namespace Wpm.SharedKernel
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> changes = new();
        public int Version { get; private set; }
        public IReadOnlyCollection<IDomainEvent> GetChanges() => changes.AsReadOnly();
        public void ClearChanges() => changes.Clear();

        // Novo evento -> aplica no estado + registra para persistência
        protected void ApplyNewEvent(IDomainEvent domainEvent)
        {
            ChangeStateByUsinDomainEvent(domainEvent);
            changes.Add(domainEvent);
            Version++;
        }

        // Replay de eventos antigos -> aplica só no estado
        private void ApplyHistoryEvent(IDomainEvent domainEvent)
        {
            ChangeStateByUsinDomainEvent(domainEvent);
            Version++;
        }
        public void Load(IEnumerable<IDomainEvent> history)
        {
            foreach (var domainEvent in history)
            {
                ApplyHistoryEvent(domainEvent);
                Version++;
            }
        }
        protected abstract void ChangeStateByUsinDomainEvent(IDomainEvent domainEvent);
    }
}
