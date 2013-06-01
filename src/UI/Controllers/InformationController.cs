using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Enumeration;
using Raven.Client;

namespace UI.Controllers
{
    public class InformationController : RavenDbController
    {
        public class Information
        {
            public virtual int NumberOfPeople { get; set; }
            public virtual int NumberOfCategories { get; set; }
            public virtual int NumberOfLocations { get; set; }
        }

        public async Task<Information> Get()
        {
            var peopleCount = await Session.Query<Person>()
                .Where(x => x.Approved.HasValue).CountAsync();

            return new Information
            {
                NumberOfPeople = peopleCount,
                NumberOfCategories = Category.GetAll().Count(),
                NumberOfLocations = Location.GetAll().Count(),
            };
        }
    }
}