using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    class Mat3TypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            string str = value as string;
            if (!string.IsNullOrEmpty(str))
            {
                return mat3.Parse(str);
            }
            else
            { return new mat3(); }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(mat3);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            { return value.ToString(); }
            else
            { return base.ConvertTo(context, culture, value, destinationType); }
        }
    }

}
