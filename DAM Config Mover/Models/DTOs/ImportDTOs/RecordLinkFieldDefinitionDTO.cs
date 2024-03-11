using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class RecordLinkFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// If the field is a record link field, it indicates the cardinality
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkType")]
        public string RelationType { get; set; }

        /// <summary>
        /// Parent classifications for Record link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentClassifications")]
        public ListItemsToAddRemove ParentClassifications { get; set; }

        /// <summary>
        /// Parent Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentContentTypes")]
        public ListItemsToAddRemove ParentContentTypes { get; set; }

        //// <summary>
        /// Field label
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentLabel")]
        public string ParentLabel { get; set; }

        /// <summary>
        /// Labels per language
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentLabels")]
        public List<LabelDTO> ParentLabels { get; set; }

        /// <summary>
        /// Child classifications for Record link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "childClassifications")]
        public ListItemsToAddRemove ChildClassifications { get; set; }

        /// <summary>
        /// Child Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "childContentTypes")]
        public ListItemsToAddRemove ChildContentTypes { get; set; }

        //// <summary>
        /// Field label
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "childLabel")]
        public string ChildLabel { get; set; }

        /// <summary>
        /// Labels per language
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "childLabels")]
        public List<LabelDTO> ChildLabels { get; set; }

        /// <summary>
        /// Child classifications for Record link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkClassifications")]
        public ListItemsToAddRemove LinkClassifications { get; set; }

        /// <summary>
        /// Child Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkContentTypes")]
        public ListItemsToAddRemove LinkContentTypes { get; set; }

        /// <summary>
        /// Shows summary image for record link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "showSummaryImage")]
        public bool ShowSummaryImage { get; set; }

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

        public RecordLinkFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.RelationType = genericDTO.RelationType;
            this.ParentClassifications = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.ParentClassifications, Remove = new List<string>() };
            this.ParentContentTypes = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.ParentContentTypes, Remove = new List<string>() };
            this.ParentLabel = genericDTO.ParentLabel;
            this.ParentLabels = genericDTO.ParentLabels;
            this.ChildClassifications = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.ChildClassifications, Remove = new List<string>() };
            this.ChildContentTypes = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.ChildContentTypes, Remove = new List<string>() };
            this.ChildLabel = genericDTO.ChildLabel;
            this.ChildLabels = genericDTO.ChildLabels;
            this.LinkClassifications = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.LinkClassifications, Remove = new List<string>() };
            this.LinkContentTypes = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.LinkContentTypes, Remove = new List<string>() };
            this.ShowSummaryImage = genericDTO.ShowSummaryImage;
            this.SummaryField = genericDTO.SummaryField;
            this.AllowSearchingOnNestedPropertiesAndFields = genericDTO.AllowSearchingOnNestedPropertiesAndFields;
        }
                       
    }
}
