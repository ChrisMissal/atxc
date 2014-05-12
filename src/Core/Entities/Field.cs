namespace Core.Entities
{
    using System;
    using Enumeration;

    public abstract class Field<T> : IField, IEquatable<Field<T>> where T : SlugEnumeration<T>
    {
        public virtual int PersonId { get; set; }

        public virtual string Value { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime? Deleted { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Field<T>)) return false;
            return Equals((Field<T>)obj);
        }

        public virtual bool Equals(Field<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PersonId == other.PersonId && Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (PersonId*397) ^ (Value != null ? Value.GetHashCode() : 0);
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
    }
}