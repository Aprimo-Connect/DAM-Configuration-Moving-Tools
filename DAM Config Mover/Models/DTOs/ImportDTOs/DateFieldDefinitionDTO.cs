namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class DateFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Pattern to use to show the date
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "datePattern")]
        public string DatePattern { get; set; }

        /// <summary>
        /// Pattern to show the year and month
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "yearMonthPattern")]
        public string YearMonthPattern { get; set; }

        public DateFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.DatePattern = genericDTO.DatePattern;
            this.YearMonthPattern = genericDTO.YearMonthPattern;
        }

    }
}
