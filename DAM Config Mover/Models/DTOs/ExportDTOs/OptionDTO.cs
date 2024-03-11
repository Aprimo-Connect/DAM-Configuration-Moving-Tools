using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    /// <summary>
    /// Represents an option item definition
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    public class OptionDTO //: IEquatable<OptionDTO>
    {
        /// <summary>
        /// Name for the options, equals the value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Name for the options, equals the value
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Label for the option (user friendly)
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "label")]
        public string Label { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "labels")]
        public List<LabelDTO> Labels { get; set; }

        /// <summary>
        /// Action: add or delete
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Image assigned to the option
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "image")]
        public ImageDTO Image { get; set; }

        /// <summary>
        /// Tag for this option.
        /// </summary>       
        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Tag for this option.
        /// </summary>       
        [System.Runtime.Serialization.DataMemberAttribute(Name = "sortIndex")]
        public string SortIndex { get; set; }

        public OptionDTO()
        {
            Labels = new List<LabelDTO>();
            Image = new ImageDTO();
        }

        //public bool Equals(OptionDTO option)
        //{
        //    if (option == null)
        //        return false;

        //    return
        //        this.Label.Equals(option.Label) &&
        //        this.Labels.Count == option.Labels.Count && this.Labels.All(k => k.Equals(option.Labels.FirstOrDefault(l => l.Language.Equals(k.Language)))) &&
        //        this.Name.Equals(option.Name) &&
        //        this.Image.Equals(option.Image) &&
        //        this.SortIndex.Equals(option.SortIndex);                           
        //}
    }
}
