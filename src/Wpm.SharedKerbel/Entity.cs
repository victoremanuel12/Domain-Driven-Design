namespace Wpm.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            if (other is null)
                return false;

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return Id!.GetHashCode();
        }

        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return EqualityComparer<TId>.Default.Equals(left.Id, right.Id);
        }

        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !(left == right);
        }
    }
}