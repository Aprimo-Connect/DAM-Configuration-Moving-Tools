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
    public class NumericSettingDefinitionDTO : GenericSettingDefinitionDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultValue")]
        public int DefaultValue { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "range")]
        public string Range { get; set; }

        public NumericSettingDefinitionDTO(SettingDefinitionDTO genericDTO) : base(genericDTO)
        {
            this.DefaultValue =  Convert.ToInt32(genericDTO.DefaultValue);
            this.Range = genericDTO.Range;
        }
    }
}
