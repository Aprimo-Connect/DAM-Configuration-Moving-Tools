namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class DateTimeFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Pattern to use to show the date
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "datePattern")]
        public string DatePattern { get; set; }

        /// <summary>
        /// Pattern to use for date time fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "dateTimePattern")]
        public string DateTimePattern { get; set; }

        /// <summary>
        /// Use UTC on date time fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "useUtc")]
        public bool UseUTC { get; set; }

        public DateTimeFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.DatePattern = genericDTO.DatePattern;
            this.DateTimePattern = genericDTO.DateTimePattern;
            this.UseUTC = genericDTO.UseUTC;
        }

    }
}
