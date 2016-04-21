using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class GLSwitchTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return base.CanConvertFrom(context, sourceType);

            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            return base.ConvertFrom(context, culture, value);

            if (value is string)
            {
                string s = (string)value;
                return Int32.Parse(s, NumberStyles.AllowThousands, culture);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);

            if (destinationType == typeof(string))
                return ((int)value).ToString("N0", culture);

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}
