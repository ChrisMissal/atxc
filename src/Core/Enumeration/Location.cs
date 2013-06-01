namespace Core.Enumeration
{
    public class Location : SlugEnumeration<Location>
    {
        public static readonly Location Austin = new Location("Austin");
        public static readonly Location RoundRock = new Location("Round Rock");
        public static readonly Location CedarPark = new Location("Cedar Park");
        public static readonly Location SanMarcos = new Location("San Marcos");
        public static readonly Location Georgetown = new Location("Georgetown");
        public static readonly Location Pfulgerville = new Location("Pfulgerville");
        public static readonly Location Kyle = new Location("Kyle");
        public static readonly Location Leander = new Location("Leander");

        public Location(string displayName) : base(displayName)
        {
        }
    }
}