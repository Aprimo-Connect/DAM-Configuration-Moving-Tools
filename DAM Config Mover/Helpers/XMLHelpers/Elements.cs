using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers
{
    /// <summary>
    /// Helper class to read values from the elements
    /// </summary>
    internal static class Elements
    {
        /// <summary>
        /// Gets the boolean value from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool ConvertStringToBoolean(XElement element)
        {
            if (element == null)
            {
                return false;
            }

            switch (element.Value.Trim().ToLower())
            {
                case "true":
                    return true;
                case "false":
                    return false;
                case "":
                    return false;
                default:
                    throw new ApplicationException(String.Format("The value '{0}' is not valid. Should be empty, 'True' or 'False'", element.Value));
            }
        }

        /// <summary>
        /// Gets the int value from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int ConvertStringToInt(XElement element)
        {
            if (element == null || string.IsNullOrEmpty(element.Value))
            {
                return 0;
            }

            return int.Parse(element.Value);
        }

        /// <summary>
        /// Gets the decimal value from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static decimal ConvertStringToDecimal(XElement element)
        {
            if (element == null || string.IsNullOrEmpty(element.Value) || element.Value.Equals("0"))
            {
                return 0;
            }

            return Convert.ToDecimal(element.Value);
        }

        /// <summary>
        /// Gets the bye value from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static byte ConvertStringToByte(XElement element)
        {
            if (element == null || string.IsNullOrEmpty(element.Value))
            {
                return 0;
            }

            return byte.Parse(element.Value);
        }

        // <summary>
        /// Gets the TimeSpan value from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TimeSpan ConvertStringToTimeSpan(XElement element)
        {

            return TimeSpan.Parse(element.Value);
        }

        /// <summary>
        /// gets the string from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetStringValue(XElement element)
        {
            return element == null ? string.Empty : element.Value;
        }

        /// <summary>
        /// gets the string from the element providing a default value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetStringValue(XElement element, string defaultValue)
        {
            return element == null ? defaultValue : element.Value;
        }

        /// <summary>
        /// gets the string from the element and decodes the Html encoded value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetHtmlDecodedStringValue(XElement element)
        {
            return element == null ? string.Empty : System.Web.HttpUtility.HtmlDecode(element.Value);
        }

        /// <summary>
        /// gets the string from the element providing a default value and decodes the Html encoded value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetHtmlEncodedStringValue(XElement element, string defaultValue)
        {
            return element == null ? defaultValue : System.Web.HttpUtility.HtmlDecode(element.Value);
        }

        /// <summary>
        /// Gets a list of strings from the array.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        internal static List<string> GetStringListValue(XElement parentElement)
        {
            List<string> items = new List<string>();

            if (parentElement != null)
            {
                foreach (XElement item in parentElement.Elements())
                {
                    if (item != null)
                    {
                        items.Add(item.Value);
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// Gets the fields from the xml with values per language.
        /// </summary>
        /// <param name="parentElement"></param>
        /// <returns></returns>
        //internal static List<FieldValueDTO> GetFieldsList(XElement parentElement)
        //{
        //    var items = new List<FieldValueDTO>();

        //    if (parentElement == null) return items;

        //    foreach (var item in parentElement.Elements())
        //    {
        //        if (item == null) continue;

        //        var fieldValue = System.Web.HttpUtility.HtmlDecode(item.Value);
        //        var fieldName = item.Attribute("name").Value;
        //        var languageName = item.Attribute("language").Value;
        //        var dataType = item.Attribute("dataType").Value;

        //        if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(languageName))
        //        {
        //            items.Add(new FieldValueDTO() 
        //            { 
        //                FieldName = fieldName, 
        //                LanguageName = languageName,
        //                //FieldDataType = (Adam.Core.Fields.DataType) Enum.Parse(typeof(Adam.Core.Fields.DataType), dataType), 
        //                Value = fieldValue
        //            });
        //        }
        //    }

        //    return items;
        //}

        public static Guid? GetNullableGuidValue(XElement element)
        {
            if (element == null || element.Value == null || string.IsNullOrEmpty(element.Value))
                return null;
            else
            {
                try
                {
                    return new Guid(element.Value);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static Guid GetGuidValue(XElement element)
        {
            try
            {
                return new Guid(element.Value);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Gets list of RuleExecutables for rule defintions from xml
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        //public static List<RuleExecutable> GetRuleExecutable(XElement element)
        //{
        //    var items = new List<RuleExecutable>();

        //    if (element == null) return items;

        //    foreach (var item in element.Elements())
        //    {
        //        if (item == null) continue;
        //        RuleExecutable executable = new RuleExecutable();
        //        executable.Name = item.Attribute("Name").Value;

        //        foreach(var propertyItem in item.Elements())
        //        {
        //            if (propertyItem == null) continue;

        //            executable.Properties.Add(propertyItem.Attribute("Name").Value, System.Web.HttpUtility.HtmlDecode(propertyItem.Value));
        //        }
        //        items.Add(executable);                
        //    }

        //    return items;
        //}

        /// <summary>
        /// Gets the list of file selection patterns for indexer definition from xml
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        //public static List<FileSelectionPattern> GetFileSelectionPatterns(XElement element)
        //{
        //    var items = new List<FileSelectionPattern>();

        //    if (element == null) return items;

        //    foreach (var item in element.Elements())
        //    {
        //        if (item == null) continue;
        //        FileSelectionPattern pattern = new FileSelectionPattern(Attributes.GetHtmlEncodedStringValue(item.Attribute("Extension")), item.Attribute("Mode").Value);                
        //        items.Add(pattern);
        //    }


        //    return items;
        //}

        //internal static List<MCMPermission> GetPermissionListValue(IEnumerable<XElement> elements)
        //{
        //    List<MCMPermission> permissions = new List<MCMPermission>();

        //    foreach (XElement element in elements)
        //    {
        //        if (element != null)
        //        {
        //            MCMPermission permission = new MCMPermission()
        //            {
        //                ClassificationRights = Attributes.GetStringValue(element.Attribute("ClassificationRights")),
        //                RecordRights = Attributes.GetStringValue(element.Attribute("RecordRights")),
        //                Visibility = Attributes.GetStringValue(element.Attribute("Visibility"))
        //            };

        //            permissions.Add(permission);
        //        }
        //    }

        //    return permissions;
        //}

        //internal static List<ClassificationPermission> GetClassificationPermissionListValue(XElement classificationPermissions)
        //{
        //    List<ClassificationPermission> permissions = new List<ClassificationPermission>();
        //    if (classificationPermissions != null)
        //    {
        //        foreach (XElement element in classificationPermissions.Elements("classification"))
        //        {
        //            if (element != null)
        //            {
        //                ClassificationPermission permission = new ClassificationPermission()
        //                {
        //                    ClassificationAccess = Attributes.GetStringValue(element.Attribute("ClassificationAccess")),
        //                    RecordAccess = Attributes.GetStringValue(element.Attribute("RecordAccess")),
        //                    Path = Attributes.GetStringValue(element.Attribute("Path"))
        //                };

        //                permissions.Add(permission);
        //            }
        //        }
        //    }
        //    return permissions;
        //}

        //internal static List<AdamRole> GetAdamRoleListValue(XElement adamRoles)
        //{
        //    List<AdamRole> permissions = new List<AdamRole>();

        //    foreach (XElement element in adamRoles.Elements("role"))
        //    {
        //        if (element != null)
        //        {
        //            AdamRole permission = new AdamRole()
        //            {
        //                Name = Attributes.GetStringValue(element.Attribute("Name")),
        //                Permission = Attributes.GetStringValue(element.Attribute("Permission"))
        //            };

        //            permissions.Add(permission);
        //        }
        //    }

        //    return permissions;
        //}
    }
}
