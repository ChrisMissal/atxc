namespace DataLoader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LoaderConfig
    {
        public LoaderConfig(string[] args)
        {
            Delete = Found("/delete", args);
            NoLoad = Found("/noload", args);
        }

        public bool Delete { get; private set; }
        public bool NoLoad { get; private set; }

        private static bool Found(string key, IEnumerable<string> args)
        {
            return args.Any(a => string.Equals(a, key, StringComparison.OrdinalIgnoreCase));
        }
    }
}