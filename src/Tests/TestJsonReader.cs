using System;
using Newtonsoft.Json;

namespace Tests
{
    public class TestJsonReader : JsonReader
    {
        private readonly object _testValue;

        public TestJsonReader(object value)
        {
            _testValue = value;
        }

        public override object Value
        {
            get
            {
                return _testValue;
            }
        }

        public override bool Read()
        {
            throw new NotImplementedException();
        }

        public override int? ReadAsInt32()
        {
            throw new NotImplementedException();
        }

        public override string ReadAsString()
        {
            throw new NotImplementedException();
        }

        public override byte[] ReadAsBytes()
        {
            throw new NotImplementedException();
        }

        public override decimal? ReadAsDecimal()
        {
            throw new NotImplementedException();
        }

        public override DateTime? ReadAsDateTime()
        {
            throw new NotImplementedException();
        }

        public override DateTimeOffset? ReadAsDateTimeOffset()
        {
            throw new NotImplementedException();
        }
    }
}