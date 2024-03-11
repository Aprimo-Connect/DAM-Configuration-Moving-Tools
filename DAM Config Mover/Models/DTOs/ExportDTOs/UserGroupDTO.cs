namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class UserGroupDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "id")]
        public string Id { get; set; }
    }
}
