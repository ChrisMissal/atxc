namespace Core
{
    using System;

    public interface IDeletable
    {
        DateTime? Deleted { get; }
    }
}