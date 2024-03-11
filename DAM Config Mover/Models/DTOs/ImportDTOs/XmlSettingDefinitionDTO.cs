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
    public class XmlSettingDefinitionDTO : TextSettingDefinitionDTO
    {                               
        public string Schema { get; set; }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "schema", EmitDefaultValue = false)]
        public string SchemaSerializable
        {
            get
            {
                if (string.IsNullOrEmpty(Schema))
                    return null;
                else return Schema;
            }
            set { Schema = value; }
        }
        public XmlSettingDefinitionDTO(SettingDefinitionDTO genericDTO) : base(genericDTO)
        {
            this.Schema = genericDTO.Schema;
        }
    }
}
