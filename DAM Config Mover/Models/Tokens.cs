namespace Models
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class Tokens
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string accessToken;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string refreshToken;
    }
}