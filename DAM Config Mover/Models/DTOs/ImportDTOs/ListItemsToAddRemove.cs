using System.Collections.Generic;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute]
    public class ListItemsToAddRemove
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "addOrUpdate")]
        public List<string> AddOrUpdate { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "remove")]
        public List<string> Remove { get; set; }
    }
}
