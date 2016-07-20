using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Supports editing values in PropertyGrid.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class StructTypeConverter<T> : TypeConverter where T : struct, ILoadFromString
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            var result = default(T);
            result.Load(value as string);

            return result;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(T);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            object result;
            if (destinationType == typeof(string))
            {
                result = value.ToString();
            }
            else
            {
                result = base.ConvertTo(context, culture, value, destinationType);
            }
            return result;
        }
    }

}
