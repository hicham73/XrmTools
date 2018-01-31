
using System;
using System.ComponentModel;
using System.Globalization;

namespace Xrm.DevOPs.Manager.ComponentModel.Property
{
    internal class AttributeMetadataCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is AttributeMetadataCollection)
            {
                var item = (AttributeMetadataCollection)value;
                if (item.Count > 0)
                    return "Expand to see items";

                return "Empty";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    

    internal class LabelCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is LabelCollection)
            {
                var item = (LabelCollection)value;
                if (item.Count > 0)
                    return "Expand to see items";

                return "Empty";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    internal class LocalizedLabelCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is LocalizedLabelCollection)
            {
                var item = (LocalizedLabelCollection)value;
                if (item.Count > 0)
                    return "Expand to see items";

                return "Empty";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    

   

    internal class OptionMetadataCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is OptionMetadataCollection)
            {
                var item = (OptionMetadataCollection)value;
                if (item.Count > 0)
                    return "Expand to see items";

                return "Empty";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    internal class OptionSetMetadataCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is OptionSetMetadataCollection)
            {
                var item = (OptionSetMetadataCollection)value;
                if (item.Count > 0)
                    return "Expand to see items";

                return "Empty";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    
}