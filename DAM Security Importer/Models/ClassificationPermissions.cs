using System.Collections.Generic;

namespace Models
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class PermissionsForClassification
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool breakInheritance;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public List<Permissions> permissions;

        // Type created for JSON at <<root>> --> registeredFieldGroups
        [System.Runtime.Serialization.DataContractAttribute(Name = "permissions")]
        public partial class Permissions
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string userGroupId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string accessRight;
        }
    }
}
