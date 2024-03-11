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
    public class FieldDefinitionDTO //: IEquatable<FieldDefinitionDTO>
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

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

        [System.Runtime.Serialization.DataMemberAttribute(Name = "helpText")]
        public string HelpText { get; set; }

        /// <summary>
        /// Labels per language
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "helpTexts")]
        public List<HelpTextDTO> HelpTexts { get; set; }

        /// <summary>
        /// Field name
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Scope for the field
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "scope")]
        public string Scope { get; set; }

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

        [System.Runtime.Serialization.DataMemberAttribute(Name = "aiEnabled")]
        public bool AIEnabled { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "memberships")]
        public List<string> FieldGroups { get; set; }

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
        public List<string> EnabledLanguages { get; set; }

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
        /// If the field is an optionlist, it indicates the possible options.
        /// </summary>  
        [System.Runtime.Serialization.DataMemberAttribute(Name = "items")]
        public List<OptionDTO> Options { get; set; }

        /// <summary>
        /// If the field is a record link field, it indicates the cardinality
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkType")]
        public string RelationType { get; set; }

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
        /// For text fields: indicates if it is a rich text field
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// For optionlist fields: indicates if more than one value can be selected
        /// for classification list fields indicates if more than one classification can be selected
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "acceptMultipleOptions")]
        public bool MultiValue { get; set; }      

        /// <summary>
        /// for optionslists: indicates if this is a dynamic optionlist
        /// </summary>
        public bool IsDynamicOptionList { get; set; }

        /// <summary>
        /// for numeric fields: indicates the accuracy for the field.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "accuracy")]
        public decimal Accuracy { get; set; }

        /// <summary>
        /// Action add / delete
        /// </summary>
        public string Action { get; set; }            

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
        /// Inheritance for Classification dependent fields
        /// </summary>
        public string Inheritance { get; set; }

        /// <summary>
        /// Sortorder of options in the list
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortOrder")]
        public string SortOrder { get; set; }

        /// <summary>
        /// Range for Numeric field types
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "range")]
        public string Range { get; set; }

        /// <summary>
        /// Parent classifications for Record link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentClassifications")]
        public List<string> ParentClassifications { get; set; }

        /// <summary>
        /// Parent Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentContentTypes")]
        public List<string> ParentContentTypes { get; set; }

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
        public List<string> ChildClassifications { get; set; }

        /// <summary>
        /// Child Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "childContentTypes")]
        public List<string> ChildContentTypes { get; set; }

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
        public List<string> LinkClassifications { get; set; }

        /// <summary>
        /// Child Search Expression for Record Link fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkContentTypes")]
        public List<string> LinkContentTypes { get; set; }

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
        /// Pattern to use to show the date
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "datePattern")]
        public string DatePattern { get; set; }

        /// <summary>
        /// Pattern to show the year and month
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "yearMonthPattern")]
        public string YearMonthPattern { get; set; }

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

        /// <summary>
        /// Pattern to use for time fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "timePattern")]
        public string TimePattern { get; set; }

        /// <summary>
        /// List source for dynamic option list
        /// </summary>
        public string ListSource { get; set; }

        /// <summary>
        /// Filter for option, classification list, user list or user group list fields fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "filter")]
        public string Filter { get; set; }

        /// <summary>
        /// On Record Link fields indicates whether searching is enabled on linked records
        /// </summary>
        //[System.Runtime.Serialization.DataMemberAttribute(Name = "allowSearchingOnNestedPropertiesAndFields")]
        public bool AllowSearchingOnNestedPropertiesAndFields { get; set; }

        /// <summary>
        /// for classification list fields indicates whether record should be linked to classification 
        /// that corresponds to field value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "linkRecordToSelectedClassifications")]
        public bool LinkRedordsToSelectedClassification { get; set; }

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
        /// For text fields, indicates if the field is single or multiline
        /// </summary>
        public bool MultiLine;


        public void SetDefaults()
        {
            FieldGroups = FieldGroups != null ? FieldGroups : new List<string>();
            Options = Options != null ? Options : new List<OptionDTO>();
            DefaultTriggers = DefaultTriggers != null ? DefaultTriggers : new List<string>();
            ResetToDefaultFields = ResetToDefaultFields != null ? ResetToDefaultFields : new List<string>();
            ParentClassifications = ParentClassifications != null ? ParentClassifications : new List<string>();
            ParentContentTypes = ParentContentTypes != null ? ParentContentTypes : new List<string>();
            ParentLabels = ParentLabels != null ? ParentLabels : new List<LabelDTO>();
            ChildClassifications = ChildClassifications != null ? ChildClassifications : new List<string>();
            ChildContentTypes = ChildContentTypes != null ? ChildContentTypes : new List<string>();
            ChildLabels = ChildLabels != null ? ChildLabels : new List<LabelDTO>();
            LinkClassifications = LinkClassifications != null ? LinkClassifications : new List<string>();
            LinkContentTypes = LinkContentTypes != null ? LinkContentTypes : new List<string>();
            Labels = Labels != null ? Labels : new List<LabelDTO>();
            HelpTexts = HelpTexts != null ? HelpTexts : new List<HelpTextDTO>();
            ContentType = DataType.Equals("html") ? "Html" : "Text";
            MultiLine = DataType.Equals("multilinetext") ? true : false;
            IsDynamicOptionList = DataType.Equals("dynamicoptionlist") ? true : false;
            EnabledLanguages = EnabledLanguages != null ? EnabledLanguages : new List<string>();
        }

        /// <summary>
        /// Creates the new object and sets the default values.
        /// </summary>
        //public FieldDefinitionDTO()
        //{
        //    FieldGroups = new List<string>();
        //    Options = new List<OptionDTO>();
        //    DefaultTriggers = new List<string>();
        //    RestToDefaultFields = new List<string>();
        //    Labels = new List<LabelDTO>();
        //    LanguageMode = "";
        //    MultiValue = false;
        //    ReadOnly = false;
        //    IsRequired = false;
        //    ContainsUniqueIdentifiers = false;
        //    EnableSearching = false;
        //    IsInheritable = false;
        //    ContainsUniqueIdentifiers = false;
        //    IsDynamicOptionList = DataType.Equals("dynamicoptionlist") ? true : false;
        //    Accuracy = "";
        //    MaxLength = 3800;
        //    MinLength = 0;
        //    Action = "Add";
        //    SortIndex = 999;
        //    InlineStyle = "";
        //    AllowReferences = "None";
        //    RegularExpression = "";
        //    Inheritance = "Definition";
        //    SortOrder = "Label";
        //    Range = "";
        //    ParentClassifications = new List<string>();
        //    ParentSearchExpression = "";
        //    ChildClassifications = new List<string>();
        //    ChildSearchExpression = "";
        //    ShowSummaryImage = false;
        //    SummaryField = "";
        //    DatePattern = "";
        //    YearMonthPattern = "";
        //    DateTimePattern = "";
        //    UseUTC = false;
        //    TimePattern = "";
        //    ListSource = "";
        //    Filter = "";
        //    AllowSearchingOnNestedPropertiesAndFields = false;
        //    LinkRedordsToSelectedClassification = false;
        //    DefaultView = "Browse";
        //    RootClassification = "";
        //    AllowCharacterStyling = false;
        //    AllowEmojis = false;
        //    AllowHashtags = false;
        //    AllowHyperLinks = false;
        //    AllowInsertAssets = false;
        //    ContentType = DataType.Equals("html") ? "Html" : "Text";
        //    MultiLine = DataType.Equals("multilinetext") ? true : false;
        //    SortOrder = "";
        //    StorageMode = "";
        //    SummaryField = "";
        //    Tag = "";
        //    TimePattern = "";
        //    ValidationMessage = "";
        //    ValidationTrigger = "";
        //    ValidationValue = "";
        //    YearMonthPattern = "";
        //}

        //public bool Equals(FieldDefinitionDTO definition)
        //{
        //    if (definition == null)
        //        return false;
        //    return
        //        this.Name.Equals(definition.Name) &&
        //        this.Accuracy.Equals(definition.Accuracy) &&
        //        this.ContainsUniqueIdentifiers.Equals(definition.ContainsUniqueIdentifiers) &&
        //        this.DataType.Equals(definition.DataType) &&
        //        this.DefaultValue.Equals(definition.DefaultValue) &&
        //        this.DefaultTriggers.Count == definition.DefaultTriggers.Count && this.DefaultTriggers.All(k => definition.DefaultTriggers.Contains(k)) &&
        //        this.RestToDefaultFields.Count == definition.RestToDefaultFields.Count && this.RestToDefaultFields.All(k => definition.RestToDefaultFields.Contains(k)) &&
        //        this.FieldGroups.Count == definition.FieldGroups.Count && this.FieldGroups.All(k => definition.FieldGroups.Contains(k)) &&
        //        this.ContainsUniqueIdentifiers.Equals(definition.ContainsUniqueIdentifiers) &&
        //        this.EnableSearching.Equals(definition.EnableSearching) &&
        //        this.IsInheritable.Equals(definition.IsInheritable) &&
        //        this.ContentType.Equals(definition.ContentType) &&
        //        this.InlineStyle.Equals(definition.InlineStyle) &&
        //        this.IsDynamicOptionList.Equals(definition.IsDynamicOptionList) &&
        //        this.IsRequired.Equals(definition.IsRequired) &&
        //        this.Label.Equals(definition.Label) &&
        //        this.Labels.Count == definition.Labels.Count && this.Labels.All(k => k.Equals(definition.Labels.FirstOrDefault(l => l.Language.Equals(k.Language)))) &&
        //        this.MaxLength.Equals(definition.MaxLength) &&
        //        this.MinLength.Equals(definition.MinLength) &&
        //        this.LanguageMode.Equals(definition.LanguageMode) &&
        //        this.MultiValue.Equals(definition.MultiValue) &&
        //        this.Options.Count == definition.Options.Count && this.Options.All(o => o.Equals(definition.Options.FirstOrDefault(l => l.Name.Equals(o.Name)))) &&
        //        this.ReadOnly.Equals(definition.ReadOnly) &&
        //        this.RelationType.Equals(definition.RelationType) &&
        //        this.Scope.Equals(definition.Scope) &&
        //        this.SortIndex.Equals(definition.SortIndex) &&
        //        this.StorageMode.Equals(definition.StorageMode) &&
        //        this.ValidationMessage.Equals(definition.ValidationMessage) &&
        //        this.ValidationTriggers.Count == definition.ValidationTriggers.Count && this.ValidationTriggers.All(v => definition.ValidationTriggers.Contains(v)) &&
        //        this.ValidationValue.Equals(definition.ValidationValue) &&
        //        this.Tag.Equals(definition.Tag) &&
        //        this.AllowReferences.Equals(definition.AllowReferences) &&
        //        this.RegularExpression.Equals(definition.RegularExpression) &&
        //        this.Inheritance.Equals(definition.Inheritance) &&
        //        this.SortOrder.Equals(definition.SortOrder) &&
        //        this.Range.Equals(definition.Range) &&
        //        this.ParentClassifications.Count == definition.ParentClassifications.Count && this.ParentClassifications.All(k => definition.ParentClassifications.Contains(k)) &&
        //        this.ParentSearchExpression.Equals(definition.ParentSearchExpression) &&
        //        this.ChildClassifications.Count == definition.ChildClassifications.Count && this.ChildClassifications.All(k => definition.ChildClassifications.Contains(k)) &&
        //        this.ChildSearchExpression.Equals(definition.ChildSearchExpression) &&
        //        this.ShowSummaryImage.Equals(definition.ShowSummaryImage) &&
        //        this.SummaryField.Equals(definition.SummaryField) &&
        //        this.DatePattern.Equals(definition.DatePattern) &&
        //        this.YearMonthPattern.Equals(definition.YearMonthPattern) &&
        //        this.DateTimePattern.Equals(definition.DateTimePattern) &&
        //        this.UseUTC.Equals(definition.UseUTC) &&
        //        this.TimePattern.Equals(definition.TimePattern) &&
        //        this.ListSource.Equals(definition.ListSource) &&
        //        this.Filter.Equals(definition.Filter) &&
        //        this.AllowSearchingOnNestedPropertiesAndFields.Equals(definition.AllowSearchingOnNestedPropertiesAndFields) &&
        //        this.LinkRedordsToSelectedClassification.Equals(definition.LinkRedordsToSelectedClassification) &&
        //        this.DefaultView.Equals(definition.DefaultView) &&
        //        this.RootClassification.Equals(definition.RootClassification) &&
        //        this.AllowInsertAssets.Equals(definition.AllowInsertAssets) &&
        //        this.AllowHyperLinks.Equals(definition.AllowHyperLinks) &&
        //        this.AllowCharacterStyling.Equals(definition.AllowCharacterStyling) &&
        //        this.AllowEmojis.Equals(definition.AllowEmojis) &&
        //        this.AllowHashtags.Equals(definition.AllowHashtags) &&
        //        this.MultiLine.Equals(definition.MultiLine);
        //}
    }
}
