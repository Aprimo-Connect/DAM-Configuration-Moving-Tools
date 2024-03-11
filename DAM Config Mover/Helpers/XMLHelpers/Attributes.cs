using System;
using System.Xml.Linq;

namespace Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers
{
    /// <summary>
    /// Helper class to get the attribute values.
    /// </summary>
    internal static class Attributes
    {
        /// <summary>
        /// Gets the boolean attribuate value
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool ConvertStringToBoolean(XAttribute attribute)
        {
            if (attribute == null)
            {
                return false;
            }

            switch (attribute.Value.Trim().ToLower())
            {
                case "true":
                    return true;
                case "false":
                    return false;
                case "":
                    return false;
                default:
                    throw new ApplicationException(String.Format("The value '{0}' is not valid. Should be empty, 'True' or 'False'", attribute.Value));
            }
        }

        /// <summary>
        /// Gets the attribute string value
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string GetStringValue(XAttribute attribute)
        {
            return attribute == null ? string.Empty : attribute.Value;
        }

        /// <summary>
        /// Gets the attribute string value and decode the Html encoded value.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string GetHtmlDecodedStringValue(XAttribute attribute)
        {
            return attribute == null ? string.Empty : System.Web.HttpUtility.HtmlDecode(attribute.Value);
        }

        /// <summary>
        /// Gets the int value from the attribute
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int ConvertStringToInt(XAttribute attribute)
        {
            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
            {
                return 0;
            }

            return int.Parse(attribute.Value);
        }

    }
}
