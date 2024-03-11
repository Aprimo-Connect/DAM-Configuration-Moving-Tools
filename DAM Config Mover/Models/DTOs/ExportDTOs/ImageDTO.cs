using System;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class ImageDTO : IEquatable<ImageDTO>
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "extension")]
        public string Extension { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "height")]
        public int Height { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "width")]
        public int Width { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "size")]
        public int Size { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "uri")]
        public string Uri { get; set; }

        public ImageDTO()
        {
            this.Extension = "";
            this.Height = 0;
            this.Width = 0;
            this.Size = 0;
            this.Uri = "";
        }

        public bool Equals(ImageDTO other)
        {
            if (other == null) return false;

            return this.Extension.Equals(other.Extension, StringComparison.OrdinalIgnoreCase) &&
                Uri.Equals(other.Uri, StringComparison.Ordinal) &&
                Size.Equals(other.Size) &&
                Width.Equals(other.Width) &&
                Height.Equals(other.Height);
        }
    }
}
