using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    class EntityReferenceTypeConverter : TypeConverter
    {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return ((EntityReference)value).Id + "," + ((EntityReference)value).Name;
                }

                return base.ConvertTo(context, culture, value, destinationType);
            }

            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                return TypeDescriptor.GetProperties(typeof(EntityReference), attributes).Sort(new string[] { "Id", "Name" });
            }


            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

        
    }
}
