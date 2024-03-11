namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition for user or user group lists
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class UserGroupListFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Filter for option, classification list, user list or user group list fields fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "filter")]
        public string Filter { get; set; }

        public UserGroupListFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.Filter = genericDTO.Filter;
        }

    }
}
