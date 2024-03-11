using System.Collections.Generic;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.ClassificationDTO;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class FileTypeDTO //: IEquatable<FileTypeDTO>
    {

        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }

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
        public List<FileTypeAction> CatalogActions { get; set; }

        /// <summary>
        /// File Type media engines
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "mediaEngines")]
        public List<string> MediaEngines { get; set; }

        /// <summary>
        /// File Type preview players
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "previewPlayers")]
        public List<string> PreviewPlayers { get; set; }

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
        /// Action (add/delete)
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// File Type tag
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class FileTypeAction
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "isCritical")]
            public bool IsCritical { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
            public string Name { get; set; }
        }

        /// <summary>
        /// Constructs a new object and initializes it
        /// </summary>
        public FileTypeDTO()
        {
            Labels = new List<LabelDTO>();
            CatalogActions = new List<FileTypeAction>(); Labels = new List<LabelDTO>();
            RegisteredFields = new List<RegisterdField>();
            RegisteredFieldGroups = new List<RegisterdFieldGroup>();
            PreviewPlayers = new List<string>();
            MediaEngines = new List<string>();
        }

        //public bool Equals(FileTypeDTO fileType)
        //{
        //    if (fileType == null)
        //        return false;

        //    return
        //        this.AllowOrderResizeSource.Equals(fileType.AllowOrderResizeSource) &&
        //        this.CatalogActions.Count == fileType.CatalogActions.Count && this.CatalogActions.All(c => fileType.CatalogActions.ContainsKey(c.Key) && fileType.CatalogActions[c.Key].Equals(c.Value)) &&
        //        this.CatalogActions.SequenceEqual(fileType.CatalogActions) &&
        //        this.EngineFormat.Equals(fileType.EngineFormat) &&
        //        this.Extension.Equals(fileType.Extension) &&
        //        this.IsCatalogable.Equals(fileType.IsCatalogable) &&
        //        this.KeepDocumentDimensions.Equals(fileType.KeepDocumentDimensions) &&
        //        this.Kind.Equals(fileType.Kind) &&
        //        this.Label.Equals(fileType.Label) &&
        //        this.Labels.Count == fileType.Labels.Count && this.Labels.All(l => l.Equals(fileType.Labels.FirstOrDefault(ll => ll.Language.Equals(l.Language)))) &&
        //        this.MacCreator.Equals(fileType.MacCreator) &&
        //        this.MacType.Equals(fileType.MacType) &&
        //        this.MediaEngines.Count == fileType.MediaEngines.Count && this.MediaEngines.All(m => fileType.MediaEngines.Contains(m)) && this.MediaEngines.SequenceEqual(fileType.MediaEngines) &&
        //        this.MimeType.Equals(fileType.MimeType) &&
        //        this.Name.Equals(fileType.Name) &&
        //        this.PreferredExtension.Equals(fileType.PreferredExtension) &&
        //        this.PreferredMacType.Equals(fileType.PreferredMacType) &&
        //        this.PreviewFormat.Equals(fileType.PreviewFormat) &&
        //        this.PreviewPlayers.Count == fileType.PreviewPlayers.Count && this.PreviewPlayers.All(p => fileType.PreviewPlayers.Contains(p)) &&
        //        this.PreviewRequired.Equals(fileType.PreviewRequired) &&
        //        this.RegisteredFieldGroups.Count == fileType.RegisteredFieldGroups.Count && this.RegisteredFieldGroups.All(r => fileType.RegisteredFieldGroups.Contains(r)) &&
        //        this.RegisteredFields.Count == fileType.RegisteredFields.Count && this.RegisteredFields.All(r => fileType.RegisteredFields.Contains(r)) &&
        //        this.SupportsWatermarking.Equals(fileType.SupportsWatermarking) &&
        //        this.SmallImage.Equals(fileType.SmallImage) &&
        //        this.LargeImage.Equals(fileType.LargeImage);
        //}
    }
}
