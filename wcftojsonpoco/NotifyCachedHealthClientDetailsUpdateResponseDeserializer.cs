using System.Text.Json.Serialization;

namespace eMedicalService.LegacyJavaWcfService.NotifyCachedHealthClientDetailsUpdateResponse
{
    /// <summary>
    /// Main response type for notifying cached health client details update.
    /// This class can deserialize JSON sent from the WCF service.
    /// </summary>
    public class notifyCachedHealthClientDetailsUpdateResponseType
    {
        [JsonPropertyName("CorrelationID")]
        public string? CorrelationID { get; set; }

        [JsonPropertyName("HealthCaseIdentifierListResponseMsg")]
        public healthCaseIdentifierMsgType[]? HealthCaseIdentifierListResponseMsg { get; set; }

        [JsonPropertyName("SuccessFlag")]
        public bool? SuccessFlag { get; set; }

        [JsonPropertyName("HealtheMedicalErrorResponseMsg")]
        public healtheMedicalErrorResponseMsgType? HealtheMedicalErrorResponseMsg { get; set; }
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

    /// <summary>
    /// Health eMedical error response message type
    /// </summary>
    public class healtheMedicalErrorResponseMsgType
    {
        [JsonPropertyName("eMedicalErrorCode")]
        public string? eMedicalErrorCode { get; set; }

        [JsonPropertyName("eMedicalErrorMessage")]
        public string? eMedicalErrorMessage { get; set; }
    }
}

