using System.Text.Json.Serialization;

namespace eMedicalService.LegacyJavaWcfService.RegisterHealthCase
{
    /// <summary>
    /// Main request type for registering a health case.
    /// This class can deserialize JSON sent from the WCF service.
    /// </summary>
    public class registerHealthCaseRequestType
    {
        [JsonPropertyName("CorrelationID")]
        public string? CorrelationID { get; set; }

        [JsonPropertyName("CachedCreationDate")]
        public cachedUnstructuredDateType? CachedCreationDate { get; set; }

        [JsonPropertyName("HealthCaseIdentifierMsg")]
        public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

        [JsonPropertyName("HealthClinicIdentifierMsg")]
        public healthClinicIdentifierMsgType? HealthClinicIdentifierMsg { get; set; }

        [JsonPropertyName("RegisterHealthCaseClientBiographicalDetails")]
        public registerHealthCaseClientBiographicalDetailsType? RegisterHealthCaseClientBiographicalDetails { get; set; }
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
    /// Health clinic identifier message type
    /// </summary>
    public class healthClinicIdentifierMsgType
    {
        [JsonPropertyName("HealthClinicIdentifier")]
        public string? HealthClinicIdentifier { get; set; }

        [JsonPropertyName("HealthClinicIdentifierType")]
        public string? HealthClinicIdentifierType { get; set; }
    }

    /// <summary>
    /// Register health case client biographical details type
    /// </summary>
    public class registerHealthCaseClientBiographicalDetailsType
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

        [JsonPropertyName("HealthClientContactListMsg")]
        public healthClientContactMsgType[]? HealthClientContactListMsg { get; set; }

        [JsonPropertyName("RegisterHealthCaseVisaContext")]
        public registerHealthCaseVisaContextType[]? RegisterHealthCaseVisaContext { get; set; }

        [JsonPropertyName("RegisterHealthCaseRequirementList")]
        public registerHealthCaseRequirementType[]? RegisterHealthCaseRequirementList { get; set; }
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

    /// <summary>
    /// Health client contact message type
    /// Note: In JSON, the Item property can contain EmailAddress (string), HealthLocationMsg, or HealthTelephoneMsg
    /// </summary>
    public class healthClientContactMsgType
    {
        [JsonPropertyName("UsageCode")]
        public string? UsageCode { get; set; }

        [JsonPropertyName("HealthPrimaryContactFlag")]
        public bool? HealthPrimaryContactFlag { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        /// <summary>
        /// Can be EmailAddress (string), HealthLocationMsg, or HealthTelephoneMsg
        /// Use System.Text.Json.JsonElement to deserialize and then check for properties
        /// </summary>
        [JsonPropertyName("Item")]
        public System.Text.Json.JsonElement Item { get; set; }

        /// <summary>
        /// Helper property to get EmailAddress if Item is a string
        /// </summary>
        [JsonIgnore]
        public string? EmailAddress
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    return Item.GetString();
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get HealthLocationMsg if Item contains address properties
        /// </summary>
        [JsonIgnore]
        public healthLocationMsgType? HealthLocationMsg
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (Item.TryGetProperty("AddressLine1", out _) || Item.TryGetProperty("LocalityName", out _))
                    {
                        return System.Text.Json.JsonSerializer.Deserialize<healthLocationMsgType>(Item.GetRawText());
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get HealthTelephoneMsg if Item contains telephone properties
        /// </summary>
        [JsonIgnore]
        public healthTelephoneMsgType? HealthTelephoneMsg
        {
            get
            {
                if (Item.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (Item.TryGetProperty("TelephoneNumber", out _) || Item.TryGetProperty("CountryTelephoneCode", out _))
                    {
                        return System.Text.Json.JsonSerializer.Deserialize<healthTelephoneMsgType>(Item.GetRawText());
                    }
                }
                return null;
            }
        }
    }

    /// <summary>
    /// Health location message type
    /// </summary>
    public class healthLocationMsgType
    {
        [JsonPropertyName("AddressLine1")]
        public string? AddressLine1 { get; set; }

        [JsonPropertyName("AddressLine2")]
        public string? AddressLine2 { get; set; }

        [JsonPropertyName("AddressLine3")]
        public string? AddressLine3 { get; set; }

        [JsonPropertyName("AddressLine4")]
        public string? AddressLine4 { get; set; }

        [JsonPropertyName("LocalityName")]
        public string? LocalityName { get; set; }

        [JsonPropertyName("StateTerritoryName")]
        public string? StateTerritoryName { get; set; }

        [JsonPropertyName("ProvinceName")]
        public string? ProvinceName { get; set; }

        [JsonPropertyName("CountryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("PostalCode")]
        public string? PostalCode { get; set; }
    }

    /// <summary>
    /// Health telephone message type
    /// </summary>
    public class healthTelephoneMsgType
    {
        [JsonPropertyName("CountryTelephoneCode")]
        public string? CountryTelephoneCode { get; set; }

        [JsonPropertyName("AreaCode")]
        public string? AreaCode { get; set; }

        [JsonPropertyName("TelephoneNumber")]
        public string? TelephoneNumber { get; set; }
    }

    /// <summary>
    /// Register health case visa context type
    /// </summary>
    public class registerHealthCaseVisaContextType
    {
        [JsonPropertyName("HealthVisaContextType")]
        public string? HealthVisaContextType { get; set; }

        [JsonPropertyName("HealthVisaContextValue")]
        public string? HealthVisaContextValue { get; set; }
    }

    /// <summary>
    /// Register health case requirement type
    /// </summary>
    public class registerHealthCaseRequirementType
    {
        [JsonPropertyName("HealthRequirementType")]
        public string? HealthRequirementType { get; set; }

        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

        [JsonPropertyName("HealthRequirementStatusCode")]
        public string? HealthRequirementStatusCode { get; set; }

        [JsonPropertyName("CachedStatusTimestamp")]
        public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }
    }
}

