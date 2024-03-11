namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute]
    public class LabelDTO //: IEquatable<LabelDTO>
    {
        /// <summary>
        /// The language for this label
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "languageId")]
        public string Language { get; set; }

        /// <summary>
        /// The text value for this label
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "value")]
        public string Text { get; set; }

        //public bool Equals(LabelDTO label)
        //{
        //    if (label == null)
        //        return false;

        //    return
        //        this.Language.Equals(label.Language) &&
        //        this.Text.Equals(label.Text);
        //}
    }
}
