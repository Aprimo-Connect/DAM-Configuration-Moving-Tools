using System.Collections.Generic;

namespace Models
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class DomainRights
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _total;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public EmbeddedDomainRights _embedded;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public DomainRightLinks _links;

        // Type created for JSON at <<root>> --> _embedded
        [System.Runtime.Serialization.DataContractAttribute(Name = "_embedded")]
        public partial class EmbeddedDomainRights
        {

            [System.Runtime.Serialization.DataMemberAttribute(Name = "domain-rights")]
            public List<DomainRight> domainRight;
        }

        // Type created for JSON at <<root>> --> group
        [System.Runtime.Serialization.DataContractAttribute()]
        public partial class DomainRight
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string name;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string functionID;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string description;
        }


        // Type created for JSON at <<root>> --> _embedded
        [System.Runtime.Serialization.DataContractAttribute(Name = "_links")]
        public partial class DomainRightLinks
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Link self;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Link first;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Link last;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Link next;
        }

        // Type created for JSON at <<root>> --> group
        [System.Runtime.Serialization.DataContractAttribute()]
        public partial class Link
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string href;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string type;
        }
    }
}
