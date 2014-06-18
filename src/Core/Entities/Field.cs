namespace Core.Entities
{
    using System;

    public abstract class Field<T> : IField, IEquatable<Field<T>>
    {
        public virtual int Id { get; protected set; }

        public virtual Guid TenantId { get; set; }

        public virtual Person Person { get; set; }

        public virtual string Value { get; set; }

        public virtual DateTime? Created { get; set; }

        public virtual bool Equals(Field<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (string.Equals(Value, other.Value))
            {
                if (Person != null && other.Person != null)
                {
                    return Person.Id == other.Person.Id;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Person != null ? Person.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Field<T> left, Field<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Field<T> left, Field<T> right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Field<T>) obj);
        }
    }
}