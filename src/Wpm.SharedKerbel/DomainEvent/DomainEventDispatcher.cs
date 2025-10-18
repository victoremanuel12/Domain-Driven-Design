using Wpm.SharedKerbel.Abstract;

namespace Wpm.SharedKerbel.DomainEvent
{
    public class DomainEventDispatcher<T> where T : IDomainEvent
    {
        //lista de ações (Actions) que querem ser notificadas quando um evento específico acontecer.
        private List<Action<T>> Actions { get; } = new();
        public void Subscribe(Action<T> action)
        {
            //Verifica se a ação já está registrada, evita duplicar a mesma assinatura várias vezes.
            if (Actions.Exists(a => a.Method == action.Method))
                return;
            Actions.Add(action);
        }
        //Quando Publish() é chamado, ele executa todas as ações registradas.
        public void Publish(T domainEvent)
        {
            foreach (var action in Actions)
            {
                action.Invoke(domainEvent);
            }
        }
    }
}
