using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core;
using Core.Validation;
using Raven.Client;
using UI.Models;

namespace UI.Controllers
{
    public class PersonController : RavenDbController
    {
        private static readonly PersonalInformationValidator Validator = new PersonalInformationValidator();

        public async Task<IList<Person>> Get()
        {
            return await Session.Query<Person>().ToListAsync();
        }

        public async Task<Person>Get(string id)
        {
            var person = (await Session.Query<Person>().ToListAsync()).FirstOrDefault(p => p.PersonId == id);
            if (person != null)
                person.ImageUrl = person.GetImageUrl();
            return person;
        }

        public async Task<HttpResponseMessage> Post(PersonForm form)
        {
            if (Validator.IsValid(form))
            {
                var person = form.ToPerson();
                await Session.StoreAsync(person);

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}