using Core;
using Core.Enumeration;
using Newtonsoft.Json;
using Shouldly;
using UI.Converters;

namespace Tests
{
    public class LocationConverterTests
    {
        private readonly JsonConverter _locationConverter;

        public LocationConverterTests()
        {
            _locationConverter = new LocationConverter();
        }

        public void Can_format_generic_enumerations()
        {
            _locationConverter.CanConvert(typeof (Location)).ShouldBe(true);
            _locationConverter.CanConvert(typeof (Category)).ShouldBe(false);
            _locationConverter.CanConvert(typeof (Link)).ShouldBe(false);
        }

        public void Cannot_format_non_Enumeration()
        {
            _locationConverter.CanConvert(typeof (Person)).ShouldBe(false);
        }

        public void Can_convert_strings_into_Locations()
        {
            _locationConverter.ReadJson(new TestJsonReader("austin"), typeof (Location), null, null).ShouldBe(Location.Austin);
            _locationConverter.ReadJson(new TestJsonReader("san-marcos"), typeof (Location), null, null).ShouldBe(Location.SanMarcos);
        }
    }
}