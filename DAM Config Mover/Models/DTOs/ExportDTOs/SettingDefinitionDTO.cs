using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute]
    public class SettingDefinitionDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "categoryId")]
        public string CategoryId { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "dataType")]
        public string DataType { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "roleRequiredForChange")]
        public string RoleRequiredForChange { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "userGroupSettingMode")]
        public string UserGroupSettingMode { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "helpUrl")]
        public string HelpUrl { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "allowSystemSetting")]
        public bool AllowSystemSetting { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "allowUserSetting")]
        public bool AllowUserSetting { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultValue")]
        public object DefaultValue { get; set; }

        /// <summary>
        /// Range for numeric settings
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "range")]
        public string Range { get; set; }

        /// <summary>
        /// RegularExpression for text settings
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "regularExpression")]
        public string RegularExpression { get; set; }

        /// <summary>
        /// Schema for xml settings
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "schema")]
        public string Schema { get; set; }


    }
}
