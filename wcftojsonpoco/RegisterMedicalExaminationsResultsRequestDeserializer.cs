using System.Text.Json.Serialization;

namespace eMedicalService.LegacyJavaWcfService
{
    /// <summary>
    /// Main request type for registering medical examination results.
    /// This class can deserialize JSON sent from the WCF service.
    /// </summary>
    public partial class registerMedicalExaminationsResultsRequestType
    {
        [JsonPropertyName("CorrelationID")]
        public string? CorrelationID { get; set; }

        [JsonPropertyName("HealthCaseIdentifierMsg")]
        public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

        [JsonPropertyName("RegisterMedicalExaminationsResultsRequestIdentityDocument")]
        public registerMedicalExaminationsResultsRequestIdentityDocumentType? RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

        [JsonPropertyName("HealthFacialImageMsg")]
        public healthFacialImageMsgType? HealthFacialImageMsg { get; set; }

        [JsonPropertyName("HealthCaseDetailForm")]
        public healthCaseDetailFormType? HealthCaseDetailForm { get; set; }

        [JsonPropertyName("HealthCaseAttachmentMsg")]
        public healthCaseAttachmentMsgType[]? HealthCaseAttachmentMsg { get; set; }

        [JsonPropertyName("RegisterMedicalExaminationsResultsRequestHealthRequirement")]
        public registerMedicalExaminationsResultsRequestHealthRequirementType[]? RegisterMedicalExaminationsResultsRequestHealthRequirement { get; set; }

        [JsonPropertyName("ProcessingUnit")]
        public string? ProcessingUnit { get; set; }
    }

    /// <summary>
    /// Health case identifier message type
    /// </summary>
    public partial class healthCaseIdentifierMsgType
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
    public partial class healthCaseIdentifierType
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
    /// Register medical examinations results request identity document type
    /// </summary>
    public partial class registerMedicalExaminationsResultsRequestIdentityDocumentType
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

        [JsonPropertyName("IdentityDocumentedPresentedFlag")]
        public bool? IdentityDocumentedPresentedFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("IdentityDocumentedPresentedFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IdentityDocumentedPresentedFlagSpecified { get; set; }

        [JsonPropertyName("IdentityConcernsFlag")]
        public bool? IdentityConcernsFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("IdentityConcernsFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IdentityConcernsFlagSpecified { get; set; }

        [JsonPropertyName("IdentityConcernsComment")]
        public string? IdentityConcernsComment { get; set; }

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
    }

    /// <summary>
    /// Sex type enumeration
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum sexTypeType
    {
        Item,  // Represents "-" (unspecified/dash) in the original XML schema
        F,
        M,
        U,
        X
    }

    /// <summary>
    /// Cached unstructured date type
    /// </summary>
    public partial class cachedUnstructuredDateType
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
    public partial class cachedUnstructuredBirthYearType
    {
        [JsonPropertyName("UnstructuredYear")]
        public string? UnstructuredYear { get; set; }
    }

    /// <summary>
    /// Cached unstructured birth month type
    /// </summary>
    public partial class cachedUnstructuredBirthMonthType
    {
        [JsonPropertyName("UnstructuredMonth")]
        public string? UnstructuredMonth { get; set; }
    }

    /// <summary>
    /// Cached unstructured birth day type
    /// </summary>
    public partial class cachedUnstructuredBirthDayType
    {
        [JsonPropertyName("UnstructuredDay")]
        public string? UnstructuredDay { get; set; }
    }

    /// <summary>
    /// Cached unstructured date time type
    /// </summary>
    public partial class cachedUnstructuredDateTimeType
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
    /// Health facial image message type
    /// Note: In JSON, this can contain either HealthPhotoAttachedMsg or HealthPhotoNotAttachedMsg as "Item"
    /// The Item property can be deserialized as either healthPhotoAttachedMsgType (if PersonImage is present)
    /// or healthPhotoNotAttachedMsgType (if CannotAttachReason is present)
    /// </summary>
    public partial class healthFacialImageMsgType
    {
        /// <summary>
        /// Can be healthPhotoAttachedMsgType or healthPhotoNotAttachedMsgType
        /// Use System.Text.Json.JsonElement to deserialize and then check for PersonImage or CannotAttachReason
        /// </summary>
        [JsonPropertyName("Item")]
        public System.Text.Json.JsonElement Item { get; set; }

        /// <summary>
        /// Helper property to get the attached photo message if PersonImage is present
        /// </summary>
        [JsonIgnore]
        public healthPhotoAttachedMsgType? HealthPhotoAttachedMsg
        {
            get
            {
                if (Item.ValueKind != System.Text.Json.JsonValueKind.Null && Item.ValueKind != System.Text.Json.JsonValueKind.Undefined && Item.TryGetProperty("PersonImage", out _))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<healthPhotoAttachedMsgType>(Item.GetRawText());
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get the not attached photo message if CannotAttachReason is present
        /// </summary>
        [JsonIgnore]
        public healthPhotoNotAttachedMsgType? HealthPhotoNotAttachedMsg
        {
            get
            {
                if (Item.ValueKind != System.Text.Json.JsonValueKind.Null && Item.ValueKind != System.Text.Json.JsonValueKind.Undefined && Item.TryGetProperty("CannotAttachReason", out _))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<healthPhotoNotAttachedMsgType>(Item.GetRawText());
                }
                return null;
            }
        }
    }

    /// <summary>
    /// Health photo attached message type
    /// </summary>
    public partial class healthPhotoAttachedMsgType
    {
        [JsonPropertyName("PersonImage")]
        public byte[]? PersonImage { get; set; }
    }

    /// <summary>
    /// Health photo not attached message type
    /// </summary>
    public partial class healthPhotoNotAttachedMsgType
    {
        [JsonPropertyName("CannotAttachReason")]
        public string? CannotAttachReason { get; set; }

        [JsonPropertyName("CannotAttachDetails")]
        public string? CannotAttachDetails { get; set; }
    }

    /// <summary>
    /// Health case detail form type
    /// </summary>
    public partial class healthCaseDetailFormType
    {
        [JsonPropertyName("HealthFormMsg")]
        public healthFormMsgType? HealthFormMsg { get; set; }
    }

    /// <summary>
    /// Health form message type
    /// Note: In JSON, this can contain either HealthFormExcDCMsg or HealthFormIncDCMsg as "Item"
    /// The Item property can be deserialized as either healthFormExcDCMsgType (if HealthSectionExcDCMsg is present)
    /// or healthFormIncDCMsgType (if HealthSectionIncDCMsg is present)
    /// </summary>
    public partial class healthFormMsgType
    {
        /// <summary>
        /// Can be healthFormExcDCMsgType or healthFormIncDCMsgType
        /// Use System.Text.Json.JsonElement to deserialize and then check for HealthSectionExcDCMsg or HealthSectionIncDCMsg
        /// </summary>
        [JsonPropertyName("Item")]
        public System.Text.Json.JsonElement Item { get; set; }

        /// <summary>
        /// Helper property to get the excluding DC form message if HealthSectionExcDCMsg is present
        /// </summary>
        [JsonIgnore]
        public healthFormExcDCMsgType? HealthFormExcDCMsg
        {
            get
            {
                if (Item.ValueKind != System.Text.Json.JsonValueKind.Null && Item.ValueKind != System.Text.Json.JsonValueKind.Undefined && Item.TryGetProperty("HealthSectionExcDCMsg", out _))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<healthFormExcDCMsgType>(Item.GetRawText());
                }
                return null;
            }
        }

        /// <summary>
        /// Helper property to get the including DC form message if HealthSectionIncDCMsg is present
        /// </summary>
        [JsonIgnore]
        public healthFormIncDCMsgType? HealthFormIncDCMsg
        {
            get
            {
                if (Item.ValueKind != System.Text.Json.JsonValueKind.Null && Item.ValueKind != System.Text.Json.JsonValueKind.Undefined && Item.TryGetProperty("HealthSectionIncDCMsg", out _))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<healthFormIncDCMsgType>(Item.GetRawText());
                }
                return null;
            }
        }
    }

    /// <summary>
    /// Health form excluding DC message type
    /// </summary>
    public partial class healthFormExcDCMsgType
    {
        [JsonPropertyName("FormCode")]
        public string? FormCode { get; set; }

        [JsonPropertyName("VersionNumber")]
        public string? VersionNumber { get; set; }

        [JsonPropertyName("LanguageType")]
        public string? LanguageType { get; set; }

        [JsonPropertyName("HealthSectionExcDCMsg")]
        public healthSectionExcDCMsgType[]? HealthSectionExcDCMsg { get; set; }
    }

    /// <summary>
    /// Health section excluding DC message type
    /// </summary>
    public partial class healthSectionExcDCMsgType
    {
        [JsonPropertyName("SectionID")]
        public string? SectionID { get; set; }

        [JsonPropertyName("SectionCode")]
        public string? SectionCode { get; set; }

        [JsonPropertyName("SectionText")]
        public string? SectionText { get; set; }

        [JsonPropertyName("Sequence")]
        public string? Sequence { get; set; }

        [JsonPropertyName("ChildSection")]
        public healthSectionExcDCMsgType[]? ChildSection { get; set; }

        [JsonPropertyName("HealthQuestionExcDCMsg")]
        public healthQuestionExcDCMsgType[]? HealthQuestionExcDCMsg { get; set; }
    }

    /// <summary>
    /// Health question excluding DC message type
    /// </summary>
    public partial class healthQuestionExcDCMsgType
    {
        [JsonPropertyName("QuestionID")]
        public string? QuestionID { get; set; }

        [JsonPropertyName("QuestionCode")]
        public string? QuestionCode { get; set; }

        [JsonPropertyName("QuestionText")]
        public string? QuestionText { get; set; }

        [JsonPropertyName("Sequence")]
        public string? Sequence { get; set; }

        [JsonPropertyName("ChildQuestion")]
        public healthQuestionExcDCMsgType[]? ChildQuestion { get; set; }

        [JsonPropertyName("HealthAnswerExcDCMsg")]
        public healthAnswerExcDCMsgType? HealthAnswerExcDCMsg { get; set; }
    }

    /// <summary>
    /// Health answer excluding DC message type
    /// </summary>
    public partial class healthAnswerExcDCMsgType
    {
        [JsonPropertyName("AnswerTypeCode")]
        public string? AnswerTypeCode { get; set; }

        [JsonPropertyName("AnswerMetadata")]
        public string? AnswerMetadata { get; set; }

        [JsonPropertyName("PractitionerID")]
        public string? PractitionerID { get; set; }

        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }

        [JsonPropertyName("Value")]
        public string? Value { get; set; }

        [JsonPropertyName("ValueDescription")]
        public string? ValueDescription { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        [JsonPropertyName("CommentPractitionerID")]
        public string? CommentPractitionerID { get; set; }

        [JsonPropertyName("AbnormalFlag")]
        public bool? AbnormalFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("AbnormalFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AbnormalFlagSpecified { get; set; }
    }

    /// <summary>
    /// Health form including DC message type
    /// </summary>
    public partial class healthFormIncDCMsgType
    {
        [JsonPropertyName("FormCode")]
        public string? FormCode { get; set; }

        [JsonPropertyName("VersionNumber")]
        public string? VersionNumber { get; set; }

        [JsonPropertyName("LanguageType")]
        public string? LanguageType { get; set; }

        [JsonPropertyName("HealthSectionIncDCMsg")]
        public healthSectionIncDCMsgType[]? HealthSectionIncDCMsg { get; set; }
    }

    /// <summary>
    /// Health section including DC message type
    /// </summary>
    public partial class healthSectionIncDCMsgType
    {
        [JsonPropertyName("SectionID")]
        public string? SectionID { get; set; }

        [JsonPropertyName("SectionCode")]
        public string? SectionCode { get; set; }

        [JsonPropertyName("SectionText")]
        public string? SectionText { get; set; }

        [JsonPropertyName("Sequence")]
        public string? Sequence { get; set; }

        [JsonPropertyName("ChildSection")]
        public healthSectionIncDCMsgType[]? ChildSection { get; set; }

        [JsonPropertyName("HealthQuestionIncDCMsg")]
        public healthQuestionIncDCMsgType[]? HealthQuestionIncDCMsg { get; set; }
    }

    /// <summary>
    /// Health question including DC message type
    /// </summary>
    public partial class healthQuestionIncDCMsgType
    {
        [JsonPropertyName("QuestionID")]
        public string? QuestionID { get; set; }

        [JsonPropertyName("QuestionCode")]
        public string? QuestionCode { get; set; }

        [JsonPropertyName("QuestionText")]
        public string? QuestionText { get; set; }

        [JsonPropertyName("Sequence")]
        public string? Sequence { get; set; }

        [JsonPropertyName("ChildQuestion")]
        public healthQuestionIncDCMsgType[]? ChildQuestion { get; set; }

        [JsonPropertyName("HealthAnswerIncDCMsg")]
        public healthAnswerIncDCMsgType? HealthAnswerIncDCMsg { get; set; }
    }

    /// <summary>
    /// Health answer including DC message type
    /// </summary>
    public partial class healthAnswerIncDCMsgType
    {
        [JsonPropertyName("AnswerTypeCode")]
        public string? AnswerTypeCode { get; set; }

        [JsonPropertyName("AnswerMetadata")]
        public string? AnswerMetadata { get; set; }

        [JsonPropertyName("PractitionerID")]
        public string? PractitionerID { get; set; }

        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }

        [JsonPropertyName("Value")]
        public string? Value { get; set; }

        [JsonPropertyName("ValueDescription")]
        public string? ValueDescription { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        [JsonPropertyName("CommentPractitionerID")]
        public string? CommentPractitionerID { get; set; }

        [JsonPropertyName("AbnormalFlag")]
        public bool? AbnormalFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("AbnormalFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AbnormalFlagSpecified { get; set; }

        [JsonPropertyName("HealthDoctorCommentMsg")]
        public healthDoctorCommentMsgType[]? HealthDoctorCommentMsg { get; set; }
    }

    /// <summary>
    /// Health doctor comment message type
    /// </summary>
    public partial class healthDoctorCommentMsgType
    {
        [JsonPropertyName("ClinicID")]
        public string? ClinicID { get; set; }

        [JsonPropertyName("PractitionerID")]
        public string? PractitionerID { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }
    }

    /// <summary>
    /// Health case attachment message type
    /// </summary>
    public partial class healthCaseAttachmentMsgType
    {
        [JsonPropertyName("HealthAttachmentIdentifierMsg")]
        public healthAttachmentIdentifierMsgType? HealthAttachmentIdentifierMsg { get; set; }

        [JsonPropertyName("StatusCode")]
        public string? StatusCode { get; set; }

        [JsonPropertyName("DocumentType")]
        public string? DocumentType { get; set; }

        [JsonPropertyName("SendingMethod")]
        public string? SendingMethod { get; set; }

        [JsonPropertyName("FileName")]
        public string? FileName { get; set; }

        [JsonPropertyName("Detail")]
        public string? Detail { get; set; }

        [JsonPropertyName("FileSize")]
        public string? FileSize { get; set; }

        [JsonPropertyName("MIMEContentType")]
        public string? MIMEContentType { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }
    }

    /// <summary>
    /// Health attachment identifier message type
    /// </summary>
    public partial class healthAttachmentIdentifierMsgType
    {
        [JsonPropertyName("AttachmentIdentifier")]
        public string? AttachmentIdentifier { get; set; }

        [JsonPropertyName("AttachmentIdentifierType")]
        public string? AttachmentIdentifierType { get; set; }
    }

    /// <summary>
    /// Register medical examinations results request health requirement type
    /// </summary>
    public partial class registerMedicalExaminationsResultsRequestHealthRequirementType
    {
        [JsonPropertyName("HealthRequirementMsg")]
        public healthRequirementMsgType? HealthRequirementMsg { get; set; }

        [JsonPropertyName("HealthRequirementIdentifierMsg")]
        public healthRequirementIdentifierMsgType? HealthRequirementIdentifierMsg { get; set; }

        [JsonPropertyName("RegisterMedicalExaminationsResultsRequestExamination")]
        public registerMedicalExaminationsResultsRequestExaminationType? RegisterMedicalExaminationsResultsRequestExamination { get; set; }
    }

    /// <summary>
    /// Health requirement message type
    /// </summary>
    public partial class healthRequirementMsgType
    {
        [JsonPropertyName("HealthRequirementType")]
        public string? HealthRequirementType { get; set; }

        [JsonPropertyName("HealthRequirementDescription")]
        public string? HealthRequirementDescription { get; set; }

        [JsonPropertyName("HealthRequirementReason")]
        public string? HealthRequirementReason { get; set; }

        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

        [JsonPropertyName("HealthRequirementStatusCode")]
        public string? HealthRequirementStatusCode { get; set; }

        [JsonPropertyName("CachedStatusTimestamp")]
        public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }
    }

    /// <summary>
    /// Health requirement identifier message type
    /// </summary>
    public partial class healthRequirementIdentifierMsgType
    {
        [JsonPropertyName("HealthRequirementIdentifier")]
        public string? HealthRequirementIdentifier { get; set; }

        [JsonPropertyName("HealthRequirementIdentifierType")]
        public string? HealthRequirementIdentifierType { get; set; }
    }

    /// <summary>
    /// Register medical examinations results request examination type
    /// </summary>
    public partial class registerMedicalExaminationsResultsRequestExaminationType
    {
        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

        [JsonPropertyName("CreateUserId")]
        public string? CreateUserId { get; set; }

        [JsonPropertyName("CreateUsername")]
        public string? CreateUsername { get; set; }

        [JsonPropertyName("CountryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("ClinicID")]
        public string? ClinicID { get; set; }

        [JsonPropertyName("ExamUpdated")]
        public examUpdatedType? ExamUpdated { get; set; }

        [JsonPropertyName("CachedEffectiveStartDate")]
        public cachedUnstructuredDateType? CachedEffectiveStartDate { get; set; }

        [JsonPropertyName("CachedEffectiveEndDate")]
        public cachedUnstructuredDateType? CachedEffectiveEndDate { get; set; }

        [JsonPropertyName("ExaminationManuallyReceivedFlag")]
        public bool? ExaminationManuallyReceivedFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("ExaminationManuallyReceivedFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExaminationManuallyReceivedFlagSpecified { get; set; }

        [JsonPropertyName("DeclarationFlag")]
        public bool? DeclarationFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("DeclarationFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DeclarationFlagSpecified { get; set; }

        [JsonPropertyName("ExaminationGrading")]
        public string? ExaminationGrading { get; set; }

        [JsonPropertyName("GradingPractitionerID")]
        public string? GradingPractitionerID { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        [JsonPropertyName("PractitionerID")]
        public string? PractitionerID { get; set; }

        [JsonPropertyName("ExaminationStatusReason")]
        public string? ExaminationStatusReason { get; set; }

        [JsonPropertyName("ExaminationStatusComment")]
        public string? ExaminationStatusComment { get; set; }

        [JsonPropertyName("ProxySubmittingUser")]
        public proxySubmittingUserType? ProxySubmittingUser { get; set; }

        [JsonPropertyName("HealthReferralMsg")]
        public healthReferralMsgType? HealthReferralMsg { get; set; }

        [JsonPropertyName("RegisterMedicalExaminationsResultsRequestIdentityDocument")]
        public registerMedicalExaminationsResultsRequestIdentityDocumentType? RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

        [JsonPropertyName("HealthCaseAttachmentMsg")]
        public healthCaseAttachmentMsgType[]? HealthCaseAttachmentMsg { get; set; }

        [JsonPropertyName("HealthFormMsg")]
        public healthFormMsgType? HealthFormMsg { get; set; }

        [JsonPropertyName("HealthMedicalHistoryMsg")]
        public healthMedicalHistoryMsgType? HealthMedicalHistoryMsg { get; set; }
    }

    /// <summary>
    /// Exam updated type
    /// </summary>
    public partial class examUpdatedType
    {
        [JsonPropertyName("CachedCreatedTimestamp")]
        public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

        [JsonPropertyName("CreateUserId")]
        public string? CreateUserId { get; set; }

        [JsonPropertyName("CreateUsername")]
        public string? CreateUsername { get; set; }
    }

    /// <summary>
    /// Proxy submitting user type
    /// </summary>
    public partial class proxySubmittingUserType
    {
        [JsonPropertyName("UserId")]
        public string? UserId { get; set; }

        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }
    }

    /// <summary>
    /// Health referral message type
    /// </summary>
    public partial class healthReferralMsgType
    {
        [JsonPropertyName("ClinicName")]
        public string? ClinicName { get; set; }

        [JsonPropertyName("ReferralIdentityConfirmationFlag")]
        public bool? ReferralIdentityConfirmationFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("ReferralIdentityConfirmationFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReferralIdentityConfirmationFlagSpecified { get; set; }
    }

    /// <summary>
    /// Health medical history message type
    /// </summary>
    public partial class healthMedicalHistoryMsgType
    {
        [JsonPropertyName("ClinicID")]
        public string? ClinicID { get; set; }

        [JsonPropertyName("ClientDeclarationFlag")]
        public bool? ClientDeclarationFlag { get; set; }

        /// <summary>
        /// Optional field - can be ignored during deserialization if present
        /// </summary>
        [JsonPropertyName("ClientDeclarationFlagSpecified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ClientDeclarationFlagSpecified { get; set; }

        [JsonPropertyName("CommentText")]
        public string? CommentText { get; set; }

        [JsonPropertyName("HealthFormMsg")]
        public healthFormMsgType? HealthFormMsg { get; set; }
    }
}

