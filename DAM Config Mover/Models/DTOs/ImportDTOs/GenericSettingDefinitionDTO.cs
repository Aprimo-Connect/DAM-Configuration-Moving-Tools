using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a generic setting definition for import
    /// and also specific setting definitons that don't have data type specific parameters
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class GenericSettingDefinitionDTO
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

        public GenericSettingDefinitionDTO(SettingDefinitionDTO genericDTO)
        {
            //generic
            this.Id = genericDTO.Id;
            this.DataType = genericDTO.DataType;            
            this.Labels = genericDTO.Labels;
            this.Name = genericDTO.Name;
            this.Tag = genericDTO.Tag;
            this.CategoryId = genericDTO.CategoryId;
            this.AllowSystemSetting = genericDTO.AllowSystemSetting;
            this.AllowUserSetting = genericDTO.AllowUserSetting;
            this.HelpUrl = genericDTO.HelpUrl;
            this.RoleRequiredForChange = genericDTO.RoleRequiredForChange;
            this.UserGroupSettingMode = genericDTO.UserGroupSettingMode;            
        }
    }
}
