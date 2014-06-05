namespace DataLoader.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;

    internal class PersonInfoGatherer
    {
        public PersonInfoGatherer()
        {
            var names = Enumerable.Repeat(GetNamePairs(), 5);
            var tuples = names.SelectMany(x => x.Select(t => t)).ToArray();

            FirstNames = tuples.Select(x => x.Item1).ToList();
            LastNames = tuples.Select(x => x.Item2).ToList();
        }

        public IEnumerable<string> FirstNames { get; private set; }
        public IEnumerable<string> LastNames { get; private set; }

        private static IEnumerable<Tuple<string, string>> GetNamePairs()
        {
            var client = new WebClient();
            var response = client.DownloadString(new Uri("http://api.randomuser.me/?results=20"));
            dynamic obj = JsonConvert.DeserializeObject(response);
            foreach (var result in obj.results)
            {
                yield return new Tuple<string, string>(result.user.name.first.Value, result.user.name.last.Value);
            }
        }
    }
}