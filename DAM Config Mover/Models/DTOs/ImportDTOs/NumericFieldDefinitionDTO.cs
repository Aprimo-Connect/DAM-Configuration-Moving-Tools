namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class NumericFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Range for Numeric field types
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "range")]
        public string Range { get; set; }

        /// <summary>
        /// for numeric fields: indicates the accuracy for the field.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "accuracy")]
        public decimal Accuracy { get; set; }

        public NumericFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.Range = genericDTO.Range;
            this.Accuracy = genericDTO.Accuracy;
        }

    }
}
