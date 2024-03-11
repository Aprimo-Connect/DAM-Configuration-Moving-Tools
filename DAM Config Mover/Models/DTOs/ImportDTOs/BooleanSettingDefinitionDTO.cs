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
    public class BooleanSettingDefinitionDTO : GenericSettingDefinitionDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultValue")]
        public bool DefaultValue { get; set; }

        public BooleanSettingDefinitionDTO(SettingDefinitionDTO genericDTO) : base(genericDTO)
        {
            this.DefaultValue =  Convert.ToBoolean(genericDTO.DefaultValue);
        }
    }
}
