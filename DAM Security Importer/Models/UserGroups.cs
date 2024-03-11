using System.Collections.Generic;

namespace Models
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UserGroups
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _total;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public EmbeddedGroups _embedded;

        // Type created for JSON at <<root>> --> _embedded
        [System.Runtime.Serialization.DataContractAttribute(Name = "_embedded")]
        public partial class EmbeddedGroups
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<Group> group;
        }

        // Type created for JSON at <<root>> --> group
        [System.Runtime.Serialization.DataContractAttribute]
        public partial class Group
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string groupId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string name;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string status;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string adamUserId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string financeGroup;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string description;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string modifiedBy;


            [System.Runtime.Serialization.DataMemberAttribute()]
            public string createdBy;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<User> users;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<Role> roles;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<DomainRight> domainRights;
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class User
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string userId;
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class Role
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string roleId;
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class DomainRight
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string domainId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<Right> rights;
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class Right
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public string functionID;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string functionName;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string domainID;
        }
    }
}
