using System.Collections.Generic;
using Core.Enumeration;

namespace UI.Controllers
{
    public abstract class EnumerationController<T> : BaseController where T : SlugEnumeration<T>
    {
        public virtual IEnumerable<T> Get()
        {
            return SlugEnumeration<T>.GetAll();
        }

        /*public virtual T Get(string id)
        {
            return SlugEnumeration<T>.FromValue(id);
        }*/
    }
}