namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class RecordListFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Field to show in the record link fields related items
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "summaryFieldId")]
        public string SummaryField { get; set; }

        /// <summary>
        /// On Record Link fields indicates whether searching is enabled on linked records
        /// </summary>
        //[System.Runtime.Serialization.DataMemberAttribute(Name = "allowSearchingOnNestedPropertiesAndFields")]
        public bool AllowSearchingOnNestedPropertiesAndFields { get; set; }

        public RecordListFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.SummaryField = genericDTO.SummaryField;
            this.AllowSearchingOnNestedPropertiesAndFields = genericDTO.AllowSearchingOnNestedPropertiesAndFields;
        }

    }
}
