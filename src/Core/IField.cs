namespace Core
{
    using System;

    public interface IDeletable
    {
        DateTime? Deleted { get; }
    }

    public interface IField : IDeletable
    {
        int PersonId { get; }
        string Value { get; }
        DateTime Created { get; }
    }
}