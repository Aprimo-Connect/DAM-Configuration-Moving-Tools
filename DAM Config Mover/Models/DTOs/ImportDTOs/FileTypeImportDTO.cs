using System.Collections.Generic;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.FileTypeDTO;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class FileTypeImportDTO
    {
        /// <summary>
        /// defines whether DTO is used for updating classification
        /// in which case some peroperties might need to be excluded from JSON
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// File Type name
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// File Type kind
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// File Type extension
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "extension")]
        public string Extension { get; set; }

        /// <summary>
        /// File Type mime type
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "mimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// File Type labels
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        /// <summary>
        /// File Type engine formate
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "engineFormat")]
        public string EngineFormat { get; set; }

        /// <summary>
        /// File Type preview format
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "previewFormat")]
        public string PreviewFormat { get; set; }

        /// <summary>
        /// File Type processing options - is catalogable
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "isCatalogable")]
        public bool IsCatalogable { get; set; }

        /// <summary>
        /// File Type processing options - preview required
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "previewRequired")]
        public bool PreviewRequired { get; set; }

        /// <summary>
        /// File Type processing options - keep document dimensions
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "previewKeepDimensions")]
        public bool PreviewKeepDimensions { get; set; }

        /// <summary>
        /// File Type processing options - allow resize source
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "supportAssetResize")]
        public bool SupportAssetResize { get; set; }

        /// <summary>
        /// File Type processing options - supports watermarking
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "supportAssetWatermark")]
        public bool SupportAssetWatermark { get; set; }

        /// <summary>
        /// File Type processing options - preferred extension
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "preferredExtension")]
        public bool PreferredExtension { get; set; }

        /// <summary>
        /// File Type catalog actions
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "catalogActions")]
        public ListCatalogActionsToAddRemove CatalogActions { get; set; }

        /// <summary>
        /// File Type media engines
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "mediaEngines")]
        public ListItemsToAddRemove MediaEngines { get; set; }

        /// <summary>
        /// File Type preview players
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "previewPlayers")]
        public ListItemsToAddRemove PreviewPlayers { get; set; }

        /// <summary>
        /// User registered fields
        /// </summary>      
        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFields")]
        public ListItemsToAddRemove RegisteredFields { get; set; }

        /// <summary>
        /// User registered field groups
        /// </summary>        
        [System.Runtime.Serialization.DataMemberAttribute(Name = "registeredFieldGroups")]
        public ListItemsToAddRemove RegisteredFieldGroups { get; set; }

        /// <summary>
        /// Action (add/delete)
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// File Type tag
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public class ListCatalogActionsToAddRemove
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "addOrUpdate")]
            public List<FileTypeAction> AddOrUpdate { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "remove")]
            public List<FileTypeAction> Remove { get; set; }
        }
        public FileTypeImportDTO() { }
        public FileTypeImportDTO(FileTypeImportDTO original)
        {
            this.CatalogActions = new ListCatalogActionsToAddRemove();
            this.CatalogActions.AddOrUpdate = new List<FileTypeAction>();
            if (original.CatalogActions.AddOrUpdate != null)
            {
                this.CatalogActions.AddOrUpdate.AddRange(original.CatalogActions.AddOrUpdate);
            }
            this.CatalogActions.Remove = new List<FileTypeAction>();
            this.EngineFormat = original.EngineFormat;
            this.Extension = original.Extension;
            this.IsCatalogable = original.IsCatalogable;
            this.IsUpdate = original.IsUpdate;
            this.Kind = original.Kind;
            this.Labels = new List<LabelDTO>();
            this.Labels.AddRange(original.Labels);
            this.MediaEngines = new ListItemsToAddRemove();
            this.MediaEngines.AddOrUpdate = new List<string>();
            if (original.MediaEngines.AddOrUpdate != null)
            {
                this.MediaEngines.AddOrUpdate.AddRange(original.MediaEngines.AddOrUpdate);
            }
            this.MediaEngines.Remove = new List<string>();
            this.MimeType = original.MimeType;
            this.Name = original.Name;
            this.PreferredExtension = original.PreferredExtension;
            this.PreviewFormat = original.PreviewFormat;
            this.PreviewKeepDimensions = original.PreviewKeepDimensions;
            this.PreviewPlayers = new ListItemsToAddRemove();
            this.PreviewPlayers.AddOrUpdate = new List<string>();
            if (original.PreviewPlayers.AddOrUpdate != null)
            {
                this.PreviewPlayers.AddOrUpdate.AddRange(original.PreviewPlayers.AddOrUpdate);
            }
            this.PreviewPlayers.Remove = new List<string>();
            this.PreviewRequired = original.PreviewRequired;
            this.RegisteredFieldGroups = new ListItemsToAddRemove();
            this.RegisteredFieldGroups.AddOrUpdate = new List<string>();
            if (original.RegisteredFieldGroups.AddOrUpdate != null)
            {
                this.RegisteredFieldGroups.AddOrUpdate.AddRange(original.RegisteredFieldGroups.AddOrUpdate);
            }
            this.RegisteredFieldGroups.Remove = new List<string>();
            this.RegisteredFields = new ListItemsToAddRemove();
            this.RegisteredFields.AddOrUpdate = new List<string>();
            if (original.RegisteredFields.AddOrUpdate != null)
            {
                this.RegisteredFields.AddOrUpdate.AddRange(original.RegisteredFields.AddOrUpdate);
            }
            this.RegisteredFields.Remove = new List<string>();
            this.SupportAssetResize = original.SupportAssetResize;
            this.SupportAssetWatermark = original.SupportAssetWatermark;
            this.Tag = original.Tag;
        }

        /// <summary>
        /// Constructs a new object and initializes it
        /// </summary>
        //public FileTypeImportDTO()
        //{
        //    Labels = new List<LabelDTO>();
        //    RegisteredFields = new List<RegisterdField>();
        //    RegisteredFieldGroups = new List<RegisterdFieldGroup>();
        //    CatalogActions = new List<FileTypeAction>(); Labels = new List<LabelDTO>();
        //    RegisteredFields = new List<RegisterdField>();
        //    RegisteredFieldGroups = new List<RegisterdFieldGroup>();
        //    PreviewPlayers = new List<string>();
        //    MediaEngines = new List<string>();
        //}        
    }
}
