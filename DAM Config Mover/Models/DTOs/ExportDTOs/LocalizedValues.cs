using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute(Name = "localizedValues")]
    public class LocalizedValues
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "values")]
        public List<string> Values { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "value")]
        public string Value { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "languageId")]
        public string Language { get; set; }
    }
}
