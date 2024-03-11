using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents a field definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(Name = "items")]
    public class OptionListFieldDefinitionDTO : GenericFieldDefinitionDTO
    {
        /// <summary>
        /// For optionlist fields: indicates if more than one value can be selected
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "acceptMultipleOptions")]
        public bool MultiValue { get; set; }

        /// <summary>
        /// Sortorder of options in the list
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortOrder")]
        public string SortOrder { get; set; }

        /// <summary>
        /// If the field is an optionlist, it indicates the possible options.
        /// </summary>  
        [System.Runtime.Serialization.DataMemberAttribute(Name = "items")]
        public OptionItems Options { get; set; }

        /// <summary>
        /// Filter for option, classification list, user list or user group list fields fields
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "filter")]
        public string Filter { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class OptionItems
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "addOrUpdate")]
            public List<OptionImportDTO> AddOrUpdateOptions { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "remove")]
            public List<OptionImportDTO> RemoveOptions { get; set; }
        }

        public OptionListFieldDefinitionDTO(FieldDefinitionDTO genericDTO, bool isUpdate) : base(genericDTO, isUpdate)
        {
            this.MultiValue = genericDTO.MultiValue;
            this.SortOrder = genericDTO.SortOrder;
            this.Options = new OptionItems() { RemoveOptions = new List<OptionImportDTO>() };
            this.Options.AddOrUpdateOptions = new List<OptionImportDTO>();
            foreach(var item in genericDTO.Options)
            {
                this.Options.AddOrUpdateOptions.Add(new OptionImportDTO(item));
            }
            this.Filter = genericDTO.Filter;
        }

    }
}
