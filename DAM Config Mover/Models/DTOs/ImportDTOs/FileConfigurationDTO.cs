using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute]
    public class FileConfigurationDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "crawlLevelFieldId", EmitDefaultValue = false)]
        public string CrawlLevelFieldId { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "crawlLevelOption")]
        public string CrawlLevelOption { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "crawlLevelValue", EmitDefaultValue = false)]
        public int? CrawlLevelValue { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "maximumNumberOfPages")]
        public int MaximumNumberOfPages { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "urlFieldId")]
        public string UrlFieldId { get; set; }
    }
}
