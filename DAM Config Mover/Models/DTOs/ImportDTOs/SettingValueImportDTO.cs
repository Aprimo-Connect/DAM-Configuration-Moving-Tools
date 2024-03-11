namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class SettingValueImportDTO
    {
        /// <summary>
        /// Name for the setting
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// value for setting that would be set based on scope/scope id
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Scope: either system or usergroup for this tool
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Scope id necessary if scope is user group, defines user group id to apply setting for
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "scopeId")]
        public string ScopeId { get; set; }
    }
}
