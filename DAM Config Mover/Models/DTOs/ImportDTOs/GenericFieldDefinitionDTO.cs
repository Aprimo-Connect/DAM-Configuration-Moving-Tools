using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a geneic field definition for import
    /// and also specific field definitons that don't have data type specific parameters:
    /// duration, language list, json, text list
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class GenericFieldDefinitionDTO
    {
        //// <summary>
        /// Field label
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Labels per language
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        //// <summary>
        /// Field help text
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "helpText")]
        public string HelpText { get; set; }

        /// <summary>
        /// Help Texts per language
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "helpTexts")]
        public List<HelpTextDTO> HelpTexts { get; set; }

        /// <summary>
        /// Field name
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// defines whether DTO is used for updating field definition
        /// in which case some peroperties might need to be excluded from JSON
        /// </summary>
        public bool IsUpdate { get; set; }

        public string Scope { get; set; }
        /// <summary>
        /// Scope for the field
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "scope", EmitDefaultValue = false)]
        public string ScopeSerializable
        {
            get
            {
                if (IsUpdate)
                    return null;
                else return Scope;
            }
            set { Scope = value; }
        }

        /// <summary>
        /// Data type for the field (text, optionlist etc)
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "dataType")]
        public string DataType { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "indexed")]
        public bool EnableSearching { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "isUniqueIdentifier")]
        public bool ContainsUniqueIdentifiers { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "isInheritable")]
        public bool IsInheritable { get; set; }

        /// <summary>
        /// Indicates if the field is readonly
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "isReadOnly")]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Indicates if the field is mandatory
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "isRequired")]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Indicates if the field is mandatory
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "memberships")]
        public ListItemsToAddRemove FieldGroups { get; set; }

        /// <summary>
        /// Default value for the field, can be a code reference.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultValue")]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Indicates the triggers to use to recalculated the default value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "resetToDefaultTriggers")]
        public List<string> DefaultTriggers { get; set; }

        /// <summary>
        /// Fields the reset to default uses as triggers
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "resetToDefaultFields")]
        public List<string> ResetToDefaultFields { get; set; }

        /// <summary>
        /// Check to perform on validation
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "validation")]
        public string ValidationValue { get; set; }

        /// <summary>
        /// Message to display when validation fails
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "validationErrorMessage")]
        public string ValidationMessage { get; set; }

        /// <summary>
        /// Indicates what trigger to use to check on validation
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "validationTrigger")]
        public string ValidationTrigger { get; set; }

        /// <summary>
        /// Indicates how the values are stored
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "storageMode")]
        public string StorageMode { get; set; }

        /// <summary>
        /// For text fields: indicates if the field can hold more than one line
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "languageMode")]
        public string LanguageMode { get; set; }

        /// <summary>
        /// Enabled languages for field values
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "enabledLanguages")]
        public ListItemsToAddRemove EnabledLanguages { get; set; }

        /// <summary>
        /// Value for the tag.
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Indicates the position in the sort order for the fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortIndex")]
        public int SortIndex { get; set; }

        /// <summary>
        /// Indicates the inline style for the field
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "inlineStyle")]
        public string InlineStyle { get; set; }

        /// <summary>
        /// Action add / delete
        /// </summary>
        public string Action { get; set; }


        public GenericFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate)
        {
            //generic

            this.Action = genericDTO.Action;
            this.ContainsUniqueIdentifiers = genericDTO.ContainsUniqueIdentifiers;
            this.DataType = genericDTO.DataType;
            this.DefaultTriggers = genericDTO.DefaultTriggers;
            this.DefaultValue = genericDTO.DefaultValue;
            this.EnabledLanguages = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.EnabledLanguages, Remove = new List<string>() };
            this.EnableSearching = genericDTO.EnableSearching;
            this.FieldGroups = new ListItemsToAddRemove() { AddOrUpdate = genericDTO.FieldGroups, Remove = new List<string>() };
            this.InlineStyle = genericDTO.InlineStyle;
            this.IsInheritable = genericDTO.IsInheritable;
            this.IsRequired = genericDTO.IsRequired;
            this.Label = genericDTO.Label;
            this.Labels = genericDTO.Labels;
            this.HelpText = genericDTO.HelpText;
            this.HelpTexts = genericDTO.HelpTexts;
            this.LanguageMode = genericDTO.LanguageMode;
            this.Name = genericDTO.Name;
            this.ReadOnly = genericDTO.ReadOnly;
            this.ResetToDefaultFields = genericDTO.ResetToDefaultFields;
            this.Scope = genericDTO.Scope;
            this.SortIndex = genericDTO.SortIndex;
            this.StorageMode = genericDTO.StorageMode;
            this.Tag = genericDTO.Tag;
            this.ValidationMessage = genericDTO.ValidationMessage;
            this.ValidationTrigger = genericDTO.ValidationTrigger;
            this.ValidationValue = genericDTO.ValidationValue;
            this.IsUpdate = isUpdate;
        }

    }
}
