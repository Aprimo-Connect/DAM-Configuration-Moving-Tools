using System;
using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Exchanges data about a content types
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class ContentTypeDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name for the content type
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// File extensions mappings for content type
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "defaultFileExtensions")]
        public List<string> DefaultFileExtensions { get; set; }


        /// <summary>
        /// Indicates what file mode the content type uses. This can be: "UploadFile", "NoFile" or "CreateFromUrl" 
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "fileMode")]
        public string FileMode { get; set; }

        /// <summary>
        /// Gets the content type inheritable fields.
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "inheritableFields")]
        public List<RegisterdField> InheritableFields { get; set; }

        /// <summary>
        /// Gets the content type inheritance configuration.Values: none, parent, custom
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "inheritanceConfiguration")]
        public string InheritanceConfiguration { get; set; }

        /// <summary>
        /// Gets the content type relation field id.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "inheritanceFieldId")]
        public string InheritanceFieldId { get; set; }

        /// <summary>
        /// <summary>
        /// Label for the content type
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        /// <summary>
        /// Gets the ParentId of this content type. Can be null when the content type is a root content type.
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "parentId")]
        public string ParentId { get; set; }

        /// <summary>
        /// Gets the description text of this content type.
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// User registered fields
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFields")]
        public List<RegisterdField> RegisteredFields { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class RegisterdField
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldId")]
            public string FieldId { get; set; }
        }

        /// <summary>
        /// User registered fields
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "fileConfiguration")]
        public FileConfigurationDTO FileConfiguration { get; set; }

        /// <summary>
        /// Gets the content type title configuration.
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "titleConfiguration")]
        public TitleConfigurationDTO TitleConfiguration { get; set; }


        /// <summary>
        /// Action to perform (add/delete)
        /// </summary>
        public string Action { get; set; }


        public ContentTypeDTO()
        {
            Labels = new List<LabelDTO>();
            RegisteredFields = new List<RegisterdField>();
            InheritableFields = new List<RegisterdField>();
            TitleConfiguration = new TitleConfigurationDTO() { Option = "filename" };
        }

    }
}
