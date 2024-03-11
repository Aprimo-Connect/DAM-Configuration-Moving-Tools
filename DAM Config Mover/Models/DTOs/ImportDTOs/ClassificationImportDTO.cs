using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Exchanges data about a classification
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class ClassificationImportDTO
    {
        /// <summary>
        /// defines whether DTO is used for updating classification
        /// in which case some peroperties might need to be excluded from JSON
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// Parent NamePath
        /// </summary>        
        public string NamePath { get; set; }

        public string ParentPath { get; set; }

        /// <summary>
        /// Parent NamePath
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentNamePath", EmitDefaultValue = false)]
        public string ParentPathSerializable
        {
            get
            {
                if (IsUpdate)
                    return null;
                else return ParentPath;
            }
            set { ParentPath = value; }
        }

        /// <summary>
        /// Name for the classification
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        public bool IsRoot { get; set; }

        /// <summary>
        /// Whether classification is root classification or not
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "isRoot", EmitDefaultValue = false, IsRequired = false)]
        public bool? IsRootSerializable
        {
            get
            {
                if (!IsUpdate) return IsRoot;
                return null;
            }
            set { IsRoot = value.Value; }
        }

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

        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFields")]
        public ListItemsToAddRemove RegisteredFields { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFieldGroups")]
        public ListItemsToAddRemove RegisteredFieldGroups { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "slaveclassifications")]
        public ListItemsToAddRemove Slaveclassifications { get; set; }

        /// <summary>
        /// Action to perform (add/delete)
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Tag for the object
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "fields")]
        public ClassificationFields Fields;

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class ClassificationFields
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<FieldsAddOrUpdate> addOrUpdate;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<FieldsAddOrUpdate> remove;
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class FieldsAddOrUpdate
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string id;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<LocalizedValues> localizedValues;
        }

        /// <summary>
        /// Constructs the new object and initializes the attributes.
        /// </summary>
        //public ClassificationImportDTO(ClassificationDTO clsToImport)
        //{            
        //    RegisteredFields = new ListItemsToAddRemove();
        //    RegisteredFieldGroups = new ListItemsToAddRemove();
        //    Slaveclassifications = new ListItemsToAddRemove();
        //    Labels = new List<LabelDTO>();
        //    Action = "Add";
        //    Fields = new List<FieldValueDTO>();            
        //}

    }
}
