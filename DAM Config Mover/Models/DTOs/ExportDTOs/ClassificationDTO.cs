using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Exchanges data about a classification
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class ClassificationDTO // : IEquatable<ClassificationDTO>
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Full NamePath
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "namePath")]
        public string NamePath { get; set; }

        /// <summary>
        /// Name for the classification
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Label for the classification
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        /// <summary>
        /// Sort index for the classification
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortIndex")]
        public int SortIndex { get; set; }

        /// <summary>
        /// Sort order for the classification children
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortOrder")]
        public string SortOrder { get; set; }

        /// <summary>
        /// Identifier, if present must be unique
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Whether classification is root classification or not
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "isRoot")]
        public bool IsRoot { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "hasChildren")]
        public bool HasChildren { get; set; }

        /// <summary>
        /// User registered fields
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFields")]
        public List<RegisterdField> RegisteredFields { get; set; }

        /// <summary>
        /// User registered field groups
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFieldGroups")]
        public List<RegisterdFieldGroup> RegisteredFieldGroups { get; set; }

        /// <summary>
        /// Action to perform (add/delete)
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Tag for the object
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Embedded section containing image, fields, mappings
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "_embedded")]
        public EmbeddedClassificationContent Embedded { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class RegisterdField
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldId")]
            public string FieldId { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class RegisterdFieldGroup
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldGroupId")]
            public string FieldGroupId { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "_embedded")]
        public partial class EmbeddedClassificationContent
        {
            /// <summary>
            /// Automatic mapping to child classifications, will need to extract these separatelly (list of namepaths only)
            /// </summary>      
            [System.Runtime.Serialization.DataMemberAttribute(Name = "slaveclassifications")]
            public SlaveClassifications SlaveClassifications { get; set; }

            /// <summary>
            /// Contains the image that is assigned to the classification
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "image")]
            public ImageDTO Image { get; set; }

            /// <summary>
            /// Contains fields populated on classification
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "fields")]
            public ClassificationFields Fields { get; set; }

        }
        [System.Runtime.Serialization.DataContractAttribute]
        public partial class SlaveClassifications
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "items")]
            public List<SlaveItem> SlaveItems { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class SlaveItem
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "namePath")]
            public string NamePath { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "fields")]
        public partial class ClassificationFields
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "items")]
            public List<FieldItems> FieldItems { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
        public partial class FieldItems
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "dataType")]
            public string DataType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldName")]
            public string FieldName { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "localizedValues")]
            public List<LocalizedValues> LocalizedValues { get; set; }
        }

        public void SetDefaults()
        {
            Labels = new List<LabelDTO>();
            RegisteredFields = new List<RegisterdField>();
            RegisteredFieldGroups = new List<RegisterdFieldGroup>();
            Embedded = Embedded != null ? Embedded : new EmbeddedClassificationContent();
        }

        /// <summary>
        /// Constructs the new object and initializes the attributes.
        /// </summary>
        //public ClassificationDTO()
        //{
        //    Mappings = new List<string>();
        //    RegisteredFields = new List<string>();
        //    RegisteredFieldGroups = new List<string>();
        //    Labels = new List<LabelDTO>();
        //    Action = "Add";
        //    Fields = new List<FieldValueDTO>();
        //    Image = new ImageDTO();
        //}

        //public bool Equals(ClassificationDTO classification)
        //{
        //    if (classification == null)
        //        return false;
        //    return
        //        this.Fields.Count == classification.Fields.Count && this.Fields.All(f => f.Equals(classification.Fields.FirstOrDefault(ff => ff.FieldName.Equals(f.FieldName)))) &&
        //        this.Identifier.Equals(classification.Identifier) &&
        //        this.Label.Equals(classification.Label) &&
        //        this.SortIndex.Equals(classification.SortIndex) &&
        //        this.Labels.Count == classification.Labels.Count && this.Labels.All(k => k.Equals(classification.Labels.FirstOrDefault(l => l.Language.Equals(k.Language)))) &&
        //        this.Mappings.Count == classification.Mappings.Count && this.Mappings.All(m => classification.Mappings.Contains(m)) &&
        //        this.Name.Equals(classification.Name) &&
        //        this.NamePath.Equals(classification.NamePath) &&
        //        this.RegisteredFieldGroups.Count == classification.RegisteredFieldGroups.Count && this.RegisteredFieldGroups.All(rfg => classification.RegisteredFieldGroups.Contains(rfg)) &&
        //        this.RegisteredFields.Count == classification.RegisteredFields.Count && this.RegisteredFields.All(rf => classification.RegisteredFields.Contains(rf)) &&
        //        this.Tag.Equals(classification.Tag) &&
        //        this.Image.Equals(classification.Image);
        //}
    }
}
