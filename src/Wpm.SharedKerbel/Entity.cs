namespace Wpm.SharedKernel
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; protected set; }


        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Id == right.Id;
        }
        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }

        public bool Equals(Entity? obj)
        {
            if (obj is null) return false;
            if (obj is not Entity entity) return false;
            return Id == entity.Id;
        }
    }
}
