using System.Collections.Generic;

namespace Models
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SetFunctionalPermissionsRequest
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Permissions permissions;

        // Type created for JSON at <<root>> --> registeredFieldGroups
        [System.Runtime.Serialization.DataContractAttribute(Name = "permissions")]
        public partial class Permissions
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<PermissionsAddOrUpdate> addOrUpdate;
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "addOrUpdate")]
        public partial class PermissionsAddOrUpdate
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string name;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string value;
        }
    }
}
