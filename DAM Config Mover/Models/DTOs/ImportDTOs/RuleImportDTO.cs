using System.Collections.Generic;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.ClassificationDTO;

namespace Aprimo.DAM.ConfigurationMover.Models.DTOs
{
    [System.Runtime.Serialization.DataContractAttribute()]
    public class RuleImportDTO
    {

        [System.Runtime.Serialization.DataMemberAttribute(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Is rule enabled
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "enabled")]
        public bool Enabled { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "includeDraftRecords")]
        public bool IncludeDraftRecords { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Type of object that the rule triggers on
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "target")]
        public string Target { get; set; }

        /// <summary>
        /// Trigger for the rule, daily or whensavedordeleted
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = "trigger")]
        public string Trigger { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "version")]
        public int Version { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "conditions")]
        public ListConditionsToAddRemove Conditions { get; set; }

        [System.Runtime.Serialization.DataMemberAttribute(Name = "actions")]
        public ListActionsToAddRemove Actions { get; set; }

        /// <summary>
        /// Action (add/delete)
        /// </summary>
        public string Action { get; set; }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class ListConditionsToAddRemove
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "addOrUpdate")]
            public List<RuleDTO.RuleCondition> AddOrUpdate { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "remove")]
            public List<string> Remove { get; set; }
        }

        [System.Runtime.Serialization.DataContractAttribute]
        public partial class ListActionsToAddRemove
        {
            [System.Runtime.Serialization.DataMemberAttribute(Name = "addOrUpdate")]
            public List<RuleDTO.RuleAction> AddOrUpdate { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "remove")]
            public List<string> Remove { get; set; }
        }

        /// <summary>
        /// Generalized condition export class
        /// </summary>
        [System.Runtime.Serialization.DataContractAttribute]
        public partial class RuleCondition
        {
            /// <summary>
            /// Data type of the condition
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "conditionType")]
            public string ConditionType { get; set; }

            /// <summary>
            /// Condition index
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "index")]
            public int Index { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldDefinitionId")]
            public string FieldDefinitionId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "classificationId")]
            public string ClassificationId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "directLinkOnly")]
            public bool DirectLinkOnly { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "userId")]
            public string UserId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "isUser")]
            public bool IsUser { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "moviePreviewExtension")]
            public string MoviePreviewExtension { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "reference")]
            public string Reference { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "expression")]
            public string Expression { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "contentType")]
            public string ContentType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "status")]
            public string Status { get; set; }
        }

        /// <summary>
        /// Generalized action export class
        /// </summary>
        [System.Runtime.Serialization.DataContractAttribute]
        public partial class RuleAction
        {
            /// <summary>
            /// Action data type
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "actionType")]
            public string ActionType { get; set; }

            /// <summary>
            /// Action index
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "index")]
            public int Index { get; set; }

            /// <summary>
            /// Delay or execute immediatelly
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "executionTime")]
            public string ExecutionTime { get; set; }

            /// <summary>
            /// Which AI features to run for AprimoAIRuleAction
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "options")]
            public string Options { get; set; }

            /// <summary>
            /// For CreateRenditionsRuleAction which presets will be used
            /// </summary>
            [System.Runtime.Serialization.DataMemberAttribute(Name = "renditionPresets")]
            public List<string> RenditionPresets { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "presets")]
            public List<PublicURIPreset> Presets { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "classificationId")]
            public string ClassificationId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "classificationIds")]
            public List<string> ClassificationIds { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "unlinkTarget")]
            public string UnlinkTarget { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "gettingType")]
            public string GettingType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "identifierType")]
            public string IdentifierType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "reference")]
            public string Reference { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "fieldDefinitionId")]
            public string FieldDefinitionId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "watermarkId")]
            public string WatermarkId { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "watermarkType")]
            public string WatermarkType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "contentType")]
            public string ContentType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "status")]
            public string Status { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "targetType")]
            public string TargetType { get; set; }

            [System.Runtime.Serialization.DataMemberAttribute(Name = "subscribersList")]
            public string SubscribersList { get; set; }

            public RuleAction()
            {
                RenditionPresets = new List<string>(); //these are for resize rendition creation rules
                Presets = new List<PublicURIPreset>(); //these are for public URLs
                ClassificationIds = new List<string>();
            }
        }

        /// <summary>
        /// Constructs a new object and initializes it
        /// </summary>
        public RuleImportDTO()
        {
            Actions = new ListActionsToAddRemove() { AddOrUpdate = new List<RuleDTO.RuleAction>(), Remove = new List<string>() };
            Conditions = new ListConditionsToAddRemove() { AddOrUpdate = new List<RuleDTO.RuleCondition>(), Remove = new List<string>() };
        }

    }
}
