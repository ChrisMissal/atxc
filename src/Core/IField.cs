namespace Core
{
    using System;
    using Entities;

    public interface IField : IDeletable, ITenanted
    {
        Person Person { get; set; }
        string Value { get; set; }
        DateTime? Created { get; set; }
    }
}