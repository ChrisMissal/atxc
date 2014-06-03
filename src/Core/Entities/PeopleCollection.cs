namespace Core.Entities
{
    using System.Collections.Generic;
    using Enumeration;

    public class PeopleCollection<T> where T : Enumeration<T, string>
    {
        public PeopleCollection(Enumeration<T, string> category)
        {
            DisplayName = category.DisplayName;
        }

        public string DisplayName { get; private set; }

        public IList<PersonSummary> People { get; set; }
    }
}