namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition for multiline, single line fields plain text or HTML fields
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class TextFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Max lenght of the value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "maximumLength")]
        public int MaxLength { get; set; }

        /// <summary>
        /// Min length of the value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "minimumLength")]
        public int MinLength { get; set; }

        /// <summary>
        /// Allow References for TextFields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "allowReferences")]
        public string AllowReferences { get; set; }

        /// <summary>
        /// Regular Expression for TextFields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "regularExpression")]
        public string RegularExpression { get; set; }

        /// <summary>
        /// AI Enabled for TextFields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "aiEnabled")]
        public bool AIEnabled { get; set; }

        public TextFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.AllowReferences = genericDTO.AllowReferences;
            this.MaxLength = genericDTO.MaxLength;
            this.MinLength = genericDTO.MinLength;
            this.RegularExpression = genericDTO.RegularExpression;
            this.AIEnabled = genericDTO.AIEnabled;
        }

    }
}
