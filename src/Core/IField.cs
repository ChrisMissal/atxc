namespace Core
{
    using System;
    using Entities;

    public interface IField : ITenanted
    {
        int Id { get; }
        Person Person { get; set; }
        string Value { get; set; }
        DateTime? Created { get; set; }
    }
}