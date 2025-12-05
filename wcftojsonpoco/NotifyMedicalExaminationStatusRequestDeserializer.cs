using System.Text.Json.Serialization;

namespace eMedicalService.LegacyJavaWcfService.NotifyMedicalExaminationStatus
{
    /// <summary>
    /// Main request type for notifying medical examination status.
    /// This class can deserialize JSON sent from the WCF service.
    /// </summary>
    public class notifyMedicalExaminationStatusRequestType
    {
        [JsonPropertyName("CorrelationID")]
        public string? CorrelationID { get; set; }

        [JsonPropertyName("HealthCaseIdentifierMsg")]
        public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

        [JsonPropertyName("CachedCreationDate")]
        public cachedUnstructuredDateType? CachedCreationDate { get; set; }

        /// <summary>
        /// Can be HealthCaseStatusUpdate, NotifyMedicalExaminationStatusRequestHealthRequirement (single object or array), or NotifyMedicalStatusRequestHealthClientContext
        /// Use System.Text.Json.JsonElement to deserialize and then check for properties
        /// </summary>
        [JsonPropertyName("Item")]
        public System.Text.Json.JsonElement Item { get; set; }

        /// <summary>
        /// Helper property to get HealthCaseStatusUpdate if Item contains Status property
        /// </summary>
        [JsonIgnore]
        public healthCaseStatusUpdateType? HealthCaseStatusUpdate
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (Item.TryGetProperty("Status", out _))
                    {
                        return System.Text.Json.JsonSerializer.Deserialize<healthCaseStatusUpdateType>(Item.GetRawText());
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get NotifyMedicalExaminationStatusRequestHealthRequirement if Item contains HealthRequirementType property
        /// Handles both single object and array cases
        /// </summary>
        [JsonIgnore]
        public notifyMedicalExaminationStatusRequestHealthRequirementType[]? NotifyMedicalExaminationStatusRequestHealthRequirement
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    return System.Text.Json.JsonSerializer.Deserialize<notifyMedicalExaminationStatusRequestHealthRequirementType[]>(Item.GetRawText());
                }
                else if (Item.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (Item.TryGetProperty("HealthRequirementType", out _))
                    {
                        var single = System.Text.Json.JsonSerializer.Deserialize<notifyMedicalExaminationStatusRequestHealthRequirementType>(Item.GetRawText());
                        return single != null ? new[] { single } : null;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get NotifyMedicalStatusRequestHealthClientContext if Item contains biographical details
        /// </summary>
        [JsonIgnore]
        public notifyMedicalStatusRequestHealthClientContextType? NotifyMedicalStatusRequestHealthClientContext
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (Item.TryGetProperty("GivenName", out _) || Item.TryGetProperty("FamilyName", out _))
                    {
                        // Make sure it's not HealthRequirementType (which would be a requirement)
                        if (!Item.TryGetProperty("HealthRequirementType", out _) && !Item.TryGetProperty("Status", out _))
                        {
                            return System.Text.Json.JsonSerializer.Deserialize<notifyMedicalStatusRequestHealthClientContextType>(Item.GetRawText());
                        }
                    }
                }
                return null;
            }
        }
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
    /// Cached unstructured date type
    /// </summary>
    public class cachedUnstructuredDateType
    {
        [JsonPropertyName("UnstructuredYear")]
        public string? UnstructuredYear { get; set; }

        [JsonPropertyName("UnstructuredMonth")]
        public string? UnstructuredMonth { get; set; }

        [JsonPropertyName("UnstructuredDay")]
        public string? UnstructuredDay { get; set; }
    }

    /// <summary>
    /// Cached expected delivery date type (extends cachedUnstructuredDateType)
    /// </summary>
    public class cachedExpectedDeliveryDateType : cachedUnstructuredDateType
    {
        // Inherits all properties from cachedUnstructuredDateType
    }

    /// <summary>
    /// Cached unstructured date time type
    /// </summary>
    public class cachedUnstructuredDateTimeType
    {
        [JsonPropertyName("UnstructuredYear")]
        public string? UnstructuredYear { get; set; }

        [JsonPropertyName("UnstructuredMonth")]
        public string? UnstructuredMonth { get; set; }

        [JsonPropertyName("UnstructuredDay")]
        public string? UnstructuredDay { get; set; }

        [JsonPropertyName("UnstructuredHour")]
        public string? UnstructuredHour { get; set; }

        [JsonPropertyName("UnstructuredMinute")]
        public string? UnstructuredMinute { get; set; }

        [JsonPropertyName("UnstructuredSecond")]
        public string? UnstructuredSecond { get; set; }
    }

    /// <summary>
    /// Health case status update type
    /// </summary>
    public class healthCaseStatusUpdateType
    {
        [JsonPropertyName("Status")]
        public string? Status { get; set; }

        [JsonPropertyName("StatusTimestamp")]
        public DateTime? StatusTimestamp { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("StatusTimestampSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? StatusTimestampSpecified { get; set; }
    }

    /// <summary>
    /// Notify medical examination status request health requirement type
    /// </summary>
    public class notifyMedicalExaminationStatusRequestHealthRequirementType
    {
        [JsonPropertyName("HealthRequirementType")]
        public string? HealthRequirementType { get; set; }

        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

        [JsonPropertyName("HealthRequirementStatusCode")]
        public string? HealthRequirementStatusCode { get; set; }

        [JsonPropertyName("CachedStatusTimestamp")]
        public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }

        [JsonPropertyName("HealthRequirementIdentifierMsg")]
        public healthRequirementIdentifierMsgType? HealthRequirementIdentifierMsg { get; set; }

        [JsonPropertyName("NotifyMedicalExaminationStatusRequestExamination")]
        public notifyMedicalExaminationStatusRequestExaminationType? NotifyMedicalExaminationStatusRequestExamination { get; set; }
    }

    /// <summary>
    /// Health requirement identifier message type
    /// </summary>
    public class healthRequirementIdentifierMsgType
    {
        [JsonPropertyName("HealthRequirementIdentifier")]
        public string? HealthRequirementIdentifier { get; set; }

        [JsonPropertyName("HealthRequirementIdentifierType")]
        public string? HealthRequirementIdentifierType { get; set; }
    }

    /// <summary>
    /// Notify medical examination status request examination type
    /// </summary>
    public class notifyMedicalExaminationStatusRequestExaminationType
    {
        [JsonPropertyName("ExaminationStatus")]
        public string? ExaminationStatus { get; set; }

        [JsonPropertyName("CachedStatusTimestamp")]
        public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }

        [JsonPropertyName("CachedExpectedDeliveryDate")]
        public cachedExpectedDeliveryDateType? CachedExpectedDeliveryDate { get; set; }

        [JsonPropertyName("ClinicID")]
        public string? ClinicID { get; set; }

        [JsonPropertyName("UserId")]
        public string? UserId { get; set; }

        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }
    }

    /// <summary>
    /// Notify medical status request health client context type
    /// </summary>
    public class notifyMedicalStatusRequestHealthClientContextType
    {
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("GivenName")]
        public string? GivenName { get; set; }

        [JsonPropertyName("FamilyName")]
        public string? FamilyName { get; set; }

        [JsonPropertyName("SexType")]
        public sexTypeType SexType { get; set; } = sexTypeType.Item;

        [JsonPropertyName("CachedBirthYear")]
        public cachedUnstructuredBirthYearType? CachedBirthYear { get; set; }

        [JsonPropertyName("CachedBirthMonth")]
        public cachedUnstructuredBirthMonthType? CachedBirthMonth { get; set; }

        [JsonPropertyName("CachedBirthDay")]
        public cachedUnstructuredBirthDayType? CachedBirthDay { get; set; }

        [JsonPropertyName("BirthCountryCode")]
        public string? BirthCountryCode { get; set; }

        [JsonPropertyName("RelationshipToPrimaryApplicant")]
        public string? RelationshipToPrimaryApplicant { get; set; }

        [JsonPropertyName("HealthIdentityDocumentMsg")]
        public healthIdentityDocumentMsgType? HealthIdentityDocumentMsg { get; set; }
    }

    /// <summary>
    /// Sex type enumeration
    /// Note: In JSON, this can be a number (0=Item, 1=F, 2=M, 3=U, 4=X) or a string
    /// </summary>
    public enum sexTypeType
    {
        Item = 0,  // Represents "-" (unspecified/dash) in the original XML schema
        F = 1,
        M = 2,
        U = 3,
        X = 4
    }

    /// <summary>
    /// Cached unstructured birth year type
    /// </summary>
    public class cachedUnstructuredBirthYearType
    {
        [JsonPropertyName("UnstructuredYear")]
        public string? UnstructuredYear { get; set; }
    }

    /// <summary>
    /// Cached unstructured birth month type
    /// </summary>
    public class cachedUnstructuredBirthMonthType
    {
        [JsonPropertyName("UnstructuredMonth")]
        public string? UnstructuredMonth { get; set; }
    }

    /// <summary>
    /// Cached unstructured birth day type
    /// </summary>
    public class cachedUnstructuredBirthDayType
    {
        [JsonPropertyName("UnstructuredDay")]
        public string? UnstructuredDay { get; set; }
    }

    /// <summary>
    /// Health identity document message type
    /// </summary>
    public class healthIdentityDocumentMsgType
    {
        [JsonPropertyName("DocumentTypeCode")]
        public string? DocumentTypeCode { get; set; }

        [JsonPropertyName("DocumentType")]
        public string? DocumentType { get; set; }

        [JsonPropertyName("DocumentNumber")]
        public string? DocumentNumber { get; set; }

        [JsonPropertyName("IssuingCountryName")]
        public string? IssuingCountryName { get; set; }

        [JsonPropertyName("CachedIssueDate")]
        public cachedUnstructuredDateType? CachedIssueDate { get; set; }

        [JsonPropertyName("CachedExpiryDate")]
        public cachedUnstructuredDateType? CachedExpiryDate { get; set; }
    }
}

