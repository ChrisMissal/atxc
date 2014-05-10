namespace Core.Data.Mappings
{
    using System;
    using System.Data;
    using Enumeration;
    using NHibernate.Dialect;
    using NHibernate.SqlTypes;
    using NHibernate.Type;

    public class EnumerationType<T> : PrimitiveType where T : Enumeration<T, string>
    {
        public EnumerationType() : base(new StringSqlType())
        {
        }

        public override string Name
        {
            get { return "Enumeration"; }
        }

        public override Type ReturnedClass
        {
            get { return typeof(T); }
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parameter = (IDataParameter)cmd.Parameters[index];

            var val = (Enumeration<T,string>) value;

            parameter.Value = val.Value;
        }

        public override object Get(IDataReader rs, int index)
        {
            var o = rs[index];
            var value = Convert.ToString(o);
            return Enumeration<T, string>.FromValue(value);
        }

        public override object Get(IDataReader rs, string name)
        {
            var ordinal = rs.GetOrdinal(name);
            return Get(rs, ordinal);
        }

        public override object FromStringValue(string xml)
        {
            return xml;
        }

        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return value.ToString();
        }

        public override Type PrimitiveClass
        {
            get { return typeof(string); }
        }

        public override object DefaultValue
        {
            get { return null; }
        }
    }
}