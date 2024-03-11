namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class TimeFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Pattern to use for time fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "timePattern")]
        public string TimePattern { get; set; }

        public TimeFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.TimePattern = genericDTO.TimePattern;
        }

    }
}
