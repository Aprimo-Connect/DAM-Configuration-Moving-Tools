using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Transfers a FieldGroup to a DTO
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class WatermarkDTO
    {

        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Field group name
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "position")]
        public string Position { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "image")]
        public ImageDTO Image { get; set; }

        /// <summary>
        /// Field group tag
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Action add / delete
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Creates and initializes the fieldgroupdto object
        /// </summary>
        public WatermarkDTO()
        {
            Image = new ImageDTO();
        }

    }
}
