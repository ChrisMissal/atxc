using System.Collections.Generic;
using Core.Enumeration;

namespace UI.Controllers
{
    public abstract class EnumerationController<T> : BaseController where T : SlugEnumeration<T>
    {
        public IEnumerable<T> Get()
        {
            return SlugEnumeration<T>.GetAll();
        }

        public T Get(string id)
        {
            return SlugEnumeration<T>.FromValue(id);
        }
    }
}