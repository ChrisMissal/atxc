namespace Core
{
    using System;
    using Entities;

    public interface IDeletable
    {
        DateTime? Deleted { get; }
    }

    public interface IField : IDeletable
    {
        Person Person { get; set; }
        string Value { get; set; }
        DateTime? Created { get; set; }
    }
}