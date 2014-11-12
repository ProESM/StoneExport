using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public static class DisplayNameHelper
    {
        public static string GetDisplayName(object obj, string propertyName)
        {
            if (obj == null) return null;
            return GetDisplayName(obj.GetType(), propertyName);

        }

        public static string GetDisplayName(Type type, string propertyOrFieldName)
        {
            var property = type.GetProperty(propertyOrFieldName);
            if (property == null)
            {
                var field = type.GetField(propertyOrFieldName);
                if (field == null)
                {
                    return null;
                }
                return GetDisplayName(field);
            }            

            return GetDisplayName(property);
        }
        
        public static string GetDisplayName(PropertyInfo property)
        {
            var attrName = GetAttributeDisplayName(property);
            if (!string.IsNullOrEmpty(attrName))
                return attrName;

            var metaName = GetMetaDisplayName(property);
            if (!string.IsNullOrEmpty(metaName))
                return metaName;

            return property.Name.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetDisplayName(FieldInfo field)
        {
            var attrName = GetAttributeDisplayName(field);
            if (!string.IsNullOrEmpty(attrName))
                return attrName;

            var metaName = GetMetaDisplayName(field);
            if (!string.IsNullOrEmpty(metaName))
                return metaName;

            return field.Name.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(
                typeof(DisplayNameAttribute), true);
            if (atts.Length == 0)
                return null;
            var displayNameAttribute = atts[0] as DisplayNameAttribute;
            return displayNameAttribute != null ? displayNameAttribute.DisplayName : null;
        }

        private static string GetAttributeDisplayName(FieldInfo field)
        {
            var atts = field.GetCustomAttributes(
                typeof(DisplayAttribute), true);            
            if (atts.Length == 0)
                return null;
            var displayNameAttribute = atts[0] as DisplayAttribute;
            return displayNameAttribute != null ? displayNameAttribute.Name : null;
        }

        private static string GetMetaDisplayName(PropertyInfo property)
        {
            if (property.DeclaringType != null)
            {
                var atts = property.DeclaringType.GetCustomAttributes(
                    typeof(MetadataTypeAttribute), true);
                if (atts.Length == 0)
                    return null;

                var metaAttr = atts[0] as MetadataTypeAttribute;
                if (metaAttr != null)
                {
                    var metaProperty =
                        metaAttr.MetadataClassType.GetProperty(property.Name);
                    return metaProperty == null ? null : GetAttributeDisplayName(metaProperty);
                }
            }
            return null;
        }

        private static string GetMetaDisplayName(FieldInfo field)
        {
            if (field.DeclaringType != null)
            {
                var atts = field.DeclaringType.GetCustomAttributes(
                    typeof(MetadataTypeAttribute), true);
                if (atts.Length == 0)
                    return null;

                var metaAttr = atts[0] as MetadataTypeAttribute;
                if (metaAttr != null)
                {
                    var metaProperty =
                        metaAttr.MetadataClassType.GetProperty(field.Name);
                    return metaProperty == null ? null : GetAttributeDisplayName(metaProperty);
                }
            }
            return null;
        }
    }
}
