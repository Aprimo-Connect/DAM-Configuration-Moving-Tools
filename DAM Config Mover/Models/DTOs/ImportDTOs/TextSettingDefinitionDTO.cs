using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a stting definition for text setting
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class TextSettingDefinitionDTO : GenericSettingDefinitionDTO
    {
        /// <summary>
        /// Regular Expression 
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "regularExpression")]
        public string RegularExpression { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultValue")]
        public string DefaultValue { get; set; }

        public TextSettingDefinitionDTO(SettingDefinitionDTO genericDTO) : base(genericDTO)
        {
            this.RegularExpression = genericDTO.RegularExpression;
            this.DefaultValue = genericDTO.DefaultValue.ToString();
        }
    }
}
