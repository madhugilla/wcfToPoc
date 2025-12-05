using System.Text.Json.Serialization;

namespace eMedicalService.LegacyJavaWcfService.DeleteCachedHealthCase
{
    /// <summary>
    /// Main request type for deleting a cached health case.
    /// This class can deserialize JSON sent from the WCF service.
    /// </summary>
    public class deleteCachedHealthCaseRequestType
    {
        [JsonPropertyName("CorrelationID")]
        public string? CorrelationID { get; set; }

        [JsonPropertyName("HealthCaseIdentifierMsg")]
        public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }
    }

    /// <summary>
    /// Health case identifier message type
    /// </summary>
    public class healthCaseIdentifierMsgType
    {
        [JsonPropertyName("HealthCaseIdentifier")]
        public healthCaseIdentifierType? HealthCaseIdentifier { get; set; }

        [JsonPropertyName("AssessmentType")]
        public assessmentTypeType? AssessmentType { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("AssessmentTypeSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AssessmentTypeSpecified { get; set; }
    }

    /// <summary>
    /// Health case identifier type
    /// </summary>
    public class healthCaseIdentifierType
    {
        [JsonPropertyName("HealthCaseIdentifierValue")]
        public string? HealthCaseIdentifierValue { get; set; }

        [JsonPropertyName("HealthCaseIdentifierType")]
        public string? HealthCaseIdentifierType { get; set; }
    }

    /// <summary>
    /// Assessment type enumeration
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum assessmentTypeType
    {
        IME,
        DHC,
        ESC,
        PHC
    }
}

