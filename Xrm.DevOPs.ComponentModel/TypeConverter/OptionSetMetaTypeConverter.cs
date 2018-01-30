using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Xrm.DevOPs.ComponentModel.TypeConverter
{
    public class OptionSetMetaTypeConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return new OptionSetMetadata();
            }

            if (value is Label)
            {
                return ((Label)value).UserLocalizedLabel?.Label;

            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context,CultureInfo culture, object value, Type destinationType)
        {
            if (value != null)
            {
                if (!(value is OptionSetMetadata))
                {
                    throw new ArgumentException("Invalid Author", "value");
                }
            }

            //if (destinationType == typeof(string))
            //{
            //    if (value == null)
            //    {
            //        return string.Empty;
            //    }

            //    OptionSetMetadata option = (OptionMetadata)value;

            //    if (auth.middlename != string.empty)
            //    {
            //        return string.format("{0} {1} {2}",
            //            auth.firstname,
            //            auth.middlename,
            //            auth.lastname);
            //    }
            //    else
            //    {
            //        return string.format("{0} {1}",
            //             auth.firstname,
            //            auth.lastname);
            //    }
            //}

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
