namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a classification list field definition for import;    
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class ClassificationListFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// Filter for option, classification list, user list or user group list fields fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "filter")]
        public string Filter { get; set; }

        /// <summary>
        /// For classification List fields, determines what default view is Search or Browse
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultSelectionDisplayMode")]
        public string DefaultView { get; set; }

        /// <summary>
        /// For classification List fields, what is the root classification
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "rootId")]
        public string RootClassification { get; set; }

        /// <summary>
        /// for classification list fields indicates if more than one classification can be selected
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "acceptMultipleOptions")]
        public bool MultiValue { get; set; }

        public bool LinkRecordsToSelectedClassifications { get; set; }

        /// <summary>
        /// for classification list fields indicates whether record should be linked to classification 
        /// that corresponds to field value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkRecordToSelectedClassifications", EmitDefaultValue = false)]
        public bool? LinkRecordToSelectedClassificationsSerializable
        {
            get
            {
                if (!IsUpdate) return LinkRecordsToSelectedClassifications;
                return null;
            }
            set { LinkRecordsToSelectedClassifications = value.Value; }
        }

        public ClassificationListFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {

            //singe line text specific
            this.Filter = genericDTO.Filter;
            this.MultiValue = genericDTO.MultiValue;
            this.RootClassification = genericDTO.RootClassification;
            this.DefaultView = genericDTO.DefaultView;
            this.LinkRecordsToSelectedClassifications = genericDTO.LinkRedordsToSelectedClassification;
        }

    }
}
