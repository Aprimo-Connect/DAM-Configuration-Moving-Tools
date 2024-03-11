using System;
using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    public class SettingValueDTO //: IEquatable<SettingValueDTO>
    {
        public string SettingName { get; set; }
        /// <summary>
        /// Setting values for system
        /// </summary>
        public string SystemLevelValue { get; set; }

        /// <summary>
        /// Setting values for all user groups
        /// </summary>
        public Dictionary<String, String> UserGroupLevelValues { get; set; }

        /// <summary>
        /// Setting values for all users
        /// </summary>
        public Dictionary<String, String> UserLevelValues { get; set; }

        /// <summary>
        /// Initializes dictionary properties
        /// </summary>        
        public SettingValueDTO()
        {
            this.SystemLevelValue = string.Empty;
            this.UserGroupLevelValues = new Dictionary<string, string>();
            this.UserLevelValues = new Dictionary<string, string>();
        }

        //public bool Equals(SettingValueDTO value)
        //{
        //    if (value == null)
        //        return false;
        //    return
        //        this.SystemLevelValue.Equals(value.SystemLevelValue) &&
        //        Equals(this.SiteLevelValues, value.SiteLevelValues) &&
        //        Equals(this.UserGroupLevelValues, value.UserGroupLevelValues) &&
        //        Equals(this.UserLevelValues, value.UserLevelValues);

        //}

        //public bool Equals(Dictionary<String, String> x, Dictionary<String, String> y)
        //{
        //    bool dictionariesEqual =
        //        x.Keys.Count == y.Keys.Count &&
        //        x.Keys.All(k => y.ContainsKey(k) && object.Equals(y[k], x[k]));
        //    return dictionariesEqual;
        //}

    }
}