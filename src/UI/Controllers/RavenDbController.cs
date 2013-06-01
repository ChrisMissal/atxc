using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;
using Raven.Client.Document;

namespace UI.Controllers
{
    public abstract class RavenDbController : ApiController
    {
        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            dynamic config = new Formo.Configuration();
            var docStore = new DocumentStore
            {
                Url = config.RavenUrl<string>(),
                ApiKey = config.RavenApiKey<string>(),
            };
            docStore.Initialize();
            return docStore;
        });

        public IDocumentStore Store
        {
            get { return LazyDocStore.Value; }
        }

        public IAsyncDocumentSession Session { get; set; }

        public async override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}