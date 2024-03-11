using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Transfers a FieldGroup to a DTO
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class FieldGroupDTO
    {

        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Field group name
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Field group tag
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Action add / delete
        /// </summary>
        public string Action { get; set; }

        public List<FieldDefinitionDTO> Fields { get; set; }

        /// <summary>
        /// Creates and initializes the fieldgroupdto object
        /// </summary>
        public FieldGroupDTO()
        {
            Action = "Add";
            Fields = new List<FieldDefinitionDTO>();
        }

        public bool Equals(FieldGroupDTO group, bool compareTags = true)
        {
            if (group == null)
                return false;
            return
                this.Name.Equals(group.Name) &&
                (compareTags) ? this.Tag.Equals(group.Tag) : true;
        }
    }
}
