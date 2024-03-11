using System.Collections.Generic;

namespace Models
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SetClassificationPermissionsRequest
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool breakInheritance;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Permissions permissions;

        // Type created for JSON at <<root>> --> registeredFieldGroups
        [System.Runtime.Serialization.DataContractAttribute(Name = "permissions")]
        public partial class Permissions
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<PermissionsAddOrUpdate> addOrUpdate;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<PermissionsRemove> remove;
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "addOrUpdate")]
        public partial class PermissionsAddOrUpdate
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string userGroupId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string accessRight;
        }

        [System.Runtime.Serialization.DataContractAttribute(Name = "remove")]
        public partial class PermissionsRemove
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string userGroupId;
        }
    }
}
