// using System.Text.Json.Serialization;

// namespace eMedicalService.LegacyJavaWcfService
// {
//     public partial class enterpriseErrorsType
//     {
//         // Can contain: logicErrorsType, securityErrorsType, systemErrorsType, validationErrorsType
//         [JsonPropertyName("LogicErrors")]
//         public logicErrorsType? LogicErrors { get; set; }

//         [JsonPropertyName("SecurityErrors")]
//         public securityErrorsType? SecurityErrors { get; set; }

//         [JsonPropertyName("SystemErrors")]
//         public systemErrorsType? SystemErrors { get; set; }

//         [JsonPropertyName("ValidationErrors")]
//         public validationErrorsType? ValidationErrors { get; set; }
//     }

//     public partial class logicErrorsType
//     {
//         [JsonPropertyName("LogicError")]
//         public logicErrorType[]? LogicError { get; set; }
//     }

//     public partial class logicErrorType
//     {
//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("ErrorCode")]
//         public string? ErrorCode { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("LocationText")]
//         public string? LocationText { get; set; }

//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }
//     }

//     public partial class validationErrorsType
//     {
//         [JsonPropertyName("ValidationError")]
//         public validationErrorType[]? ValidationError { get; set; }
//     }

//     public partial class validationErrorType
//     {
//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("ErrorCode")]
//         public string? ErrorCode { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("LocationText")]
//         public string? LocationText { get; set; }

//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }
//     }

//     public partial class systemErrorsType
//     {
//         [JsonPropertyName("SystemError")]
//         public systemErrorType[]? SystemError { get; set; }
//     }

//     public partial class systemErrorType
//     {
//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("ErrorCode")]
//         public string? ErrorCode { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }
//     }

//     public partial class securityErrorsType
//     {
//         [JsonPropertyName("SecurityError")]
//         public securityErrorType[]? SecurityError { get; set; }
//     }

//     public partial class securityErrorType
//     {
//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("ErrorCode")]
//         public string? ErrorCode { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }
//     }

//     public partial class warningType
//     {
//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }

//         [JsonPropertyName("LocationText")]
//         public string? LocationText { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("WarningCode")]
//         public string? WarningCode { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }
//     }

//     public partial class informationType
//     {
//         [JsonPropertyName("AdditionalDetailText")]
//         public string? AdditionalDetailText { get; set; }

//         [JsonPropertyName("LocationText")]
//         public string? LocationText { get; set; }

//         [JsonPropertyName("DescriptionText")]
//         public string? DescriptionText { get; set; }

//         [JsonPropertyName("InformationCode")]
//         public string? InformationCode { get; set; }

//         [JsonPropertyName("OriginatorLocation")]
//         public string? OriginatorLocation { get; set; }

//         [JsonPropertyName("OriginatorName")]
//         public string? OriginatorName { get; set; }
//     }

//     public partial class acknowledgementMessageType
//     {
//         [JsonPropertyName("Informations")]
//         public informationType[]? Informations { get; set; }

//         [JsonPropertyName("Warnings")]
//         public warningType[]? Warnings { get; set; }

//         [JsonPropertyName("Acknowledgement")]
//         public acknowledgementType Acknowledgement { get; set; }
//     }

//     [JsonConverter(typeof(JsonStringEnumConverter))]
//     public enum acknowledgementType
//     {
//         SUCCESS,
//     }

//     public partial class cachedUnstructuredDateTimeType
//     {
//         [JsonPropertyName("UnstructuredYear")]
//         public string? UnstructuredYear { get; set; }

//         [JsonPropertyName("UnstructuredMonth")]
//         public string? UnstructuredMonth { get; set; }

//         [JsonPropertyName("UnstructuredDay")]
//         public string? UnstructuredDay { get; set; }

//         [JsonPropertyName("UnstructuredHour")]
//         public string? UnstructuredHour { get; set; }

//         [JsonPropertyName("UnstructuredMinute")]
//         public string? UnstructuredMinute { get; set; }

//         [JsonPropertyName("UnstructuredSecond")]
//         public string? UnstructuredSecond { get; set; }
//     }

//     public partial class registerHealthCaseRequirementType
//     {
//         [JsonPropertyName("HealthRequirementType")]
//         public string? HealthRequirementType { get; set; }

//         [JsonPropertyName("CachedCreatedTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

//         [JsonPropertyName("HealthRequirementStatusCode")]
//         public string? HealthRequirementStatusCode { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }
//     }

//     public partial class registerHealthCaseVisaContextType
//     {
//         [JsonPropertyName("HealthVisaContextType")]
//         public string? HealthVisaContextType { get; set; }

//         [JsonPropertyName("HealthVisaContextValue")]
//         public string? HealthVisaContextValue { get; set; }
//     }

//     public partial class healthTelephoneMsgType
//     {
//         [JsonPropertyName("CountryTelephoneCode")]
//         public string? CountryTelephoneCode { get; set; }

//         [JsonPropertyName("AreaCode")]
//         public string? AreaCode { get; set; }

//         [JsonPropertyName("TelephoneNumber")]
//         public string? TelephoneNumber { get; set; }
//     }

//     public partial class healthLocationMsgType
//     {
//         [JsonPropertyName("AddressLine1")]
//         public string? AddressLine1 { get; set; }

//         [JsonPropertyName("AddressLine2")]
//         public string? AddressLine2 { get; set; }

//         [JsonPropertyName("AddressLine3")]
//         public string? AddressLine3 { get; set; }

//         [JsonPropertyName("AddressLine4")]
//         public string? AddressLine4 { get; set; }

//         [JsonPropertyName("LocalityName")]
//         public string? LocalityName { get; set; }

//         [JsonPropertyName("StateTerritoryName")]
//         public string? StateTerritoryName { get; set; }

//         [JsonPropertyName("ProvinceName")]
//         public string? ProvinceName { get; set; }

//         [JsonPropertyName("CountryCode")]
//         public string? CountryCode { get; set; }

//         [JsonPropertyName("PostalCode")]
//         public string? PostalCode { get; set; }
//     }

//     public partial class healthClientContactMsgType
//     {
//         [JsonPropertyName("UsageCode")]
//         public string? UsageCode { get; set; }

//         [JsonPropertyName("HealthPrimaryContactFlag")]
//         public bool? HealthPrimaryContactFlag { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         // Can be: string (EmailAddress), healthLocationMsgType, or healthTelephoneMsgType
//         [JsonPropertyName("EmailAddress")]
//         public string? EmailAddress { get; set; }

//         [JsonPropertyName("HealthLocationMsg")]
//         public healthLocationMsgType? HealthLocationMsg { get; set; }

//         [JsonPropertyName("HealthTelephoneMsg")]
//         public healthTelephoneMsgType? HealthTelephoneMsg { get; set; }
//     }

//     public partial class healthIdentityDocumentMsgType
//     {
//         [JsonPropertyName("DocumentTypeCode")]
//         public string? DocumentTypeCode { get; set; }

//         [JsonPropertyName("DocumentType")]
//         public string? DocumentType { get; set; }

//         [JsonPropertyName("DocumentNumber")]
//         public string? DocumentNumber { get; set; }

//         [JsonPropertyName("IssuingCountryName")]
//         public string? IssuingCountryName { get; set; }

//         [JsonPropertyName("CachedIssueDate")]
//         public cachedUnstructuredDateType? CachedIssueDate { get; set; }

//         [JsonPropertyName("CachedExpiryDate")]
//         public cachedUnstructuredDateType? CachedExpiryDate { get; set; }
//     }

//     [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
//     [JsonDerivedType(typeof(cachedExpectedDeliveryDateType), typeDiscriminator: "cachedExpectedDeliveryDateType")]
//     [JsonDerivedType(typeof(cachedUnstructuredDateType), typeDiscriminator: "cachedUnstructuredDateType")]
//     public partial class cachedUnstructuredDateType
//     {
//         [JsonPropertyName("UnstructuredYear")]
//         public string? UnstructuredYear { get; set; }

//         [JsonPropertyName("UnstructuredMonth")]
//         public string? UnstructuredMonth { get; set; }

//         [JsonPropertyName("UnstructuredDay")]
//         public string? UnstructuredDay { get; set; }
//     }

//     public partial class cachedExpectedDeliveryDateType : cachedUnstructuredDateType
//     {
//     }

//     public partial class cachedUnstructuredBirthDayType
//     {
//         [JsonPropertyName("UnstructuredDay")]
//         public string? UnstructuredDay { get; set; }
//     }

//     public partial class cachedUnstructuredBirthMonthType
//     {
//         [JsonPropertyName("UnstructuredMonth")]
//         public string? UnstructuredMonth { get; set; }
//     }

//     public partial class cachedUnstructuredBirthYearType
//     {
//         [JsonPropertyName("UnstructuredYear")]
//         public string? UnstructuredYear { get; set; }
//     }

//     public partial class registerHealthCaseClientBiographicalDetailsType
//     {
//         [JsonPropertyName("Title")]
//         public string? Title { get; set; }

//         [JsonPropertyName("GivenName")]
//         public string? GivenName { get; set; }

//         [JsonPropertyName("FamilyName")]
//         public string? FamilyName { get; set; }

//         [JsonPropertyName("SexType")]
//         public sexTypeType SexType { get; set; }

//         [JsonPropertyName("CachedBirthYear")]
//         public cachedUnstructuredBirthYearType? CachedBirthYear { get; set; }

//         [JsonPropertyName("CachedBirthMonth")]
//         public cachedUnstructuredBirthMonthType? CachedBirthMonth { get; set; }

//         [JsonPropertyName("CachedBirthDay")]
//         public cachedUnstructuredBirthDayType? CachedBirthDay { get; set; }

//         [JsonPropertyName("BirthCountryCode")]
//         public string? BirthCountryCode { get; set; }

//         [JsonPropertyName("RelationshipToPrimaryApplicant")]
//         public string? RelationshipToPrimaryApplicant { get; set; }

//         [JsonPropertyName("HealthIdentityDocumentMsg")]
//         public healthIdentityDocumentMsgType? HealthIdentityDocumentMsg { get; set; }

//         [JsonPropertyName("HealthClientContactListMsg")]
//         public healthClientContactMsgType[]? HealthClientContactListMsg { get; set; }

//         [JsonPropertyName("RegisterHealthCaseVisaContext")]
//         public registerHealthCaseVisaContextType[]? RegisterHealthCaseVisaContext { get; set; }

//         [JsonPropertyName("RegisterHealthCaseRequirementList")]
//         public registerHealthCaseRequirementType[]? RegisterHealthCaseRequirementList { get; set; }
//     }

//     /// <summary>
//     /// Sex type enumeration. Note: Item represents "-" in the original XML schema.
//     /// For JSON serialization, Item serializes as "Item" string.
//     /// </summary>
//     [JsonConverter(typeof(JsonStringEnumConverter))]
//     public enum sexTypeType
//     {
//         /// <summary>
//         /// Represents "-" (unspecified/dash) in the original XML schema
//         /// </summary>
//         Item,

//         F,

//         M,

//         U,

//         X,
//     }

//     public partial class healthClinicIdentifierMsgType
//     {
//         [JsonPropertyName("HealthClinicIdentifier")]
//         public string? HealthClinicIdentifier { get; set; }

//         [JsonPropertyName("HealthClinicIdentifierType")]
//         public string? HealthClinicIdentifierType { get; set; }
//     }

//     public partial class healthCaseIdentifierType
//     {
//         [JsonPropertyName("HealthCaseIdentifierValue")]
//         public string? HealthCaseIdentifierValue { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierType")]
//         public string? HealthCaseIdentifierType { get; set; }
//     }

//     public partial class healthCaseIdentifierMsgType
//     {
//         [JsonPropertyName("HealthCaseIdentifier")]
//         public healthCaseIdentifierType? HealthCaseIdentifier { get; set; }

//         [JsonPropertyName("AssessmentType")]
//         public assessmentTypeType? AssessmentType { get; set; }
//     }

//     [JsonConverter(typeof(JsonStringEnumConverter))]
//     public enum assessmentTypeType
//     {
//         IME,

//         DHC,

//         ESC,

//         PHC,
//     }

//     public partial class registerHealthCaseRequestType
//     {
//         [JsonPropertyName("CorrelationID")]
//         public string? CorrelationID { get; set; }

//         [JsonPropertyName("CachedCreationDate")]
//         public cachedUnstructuredDateType? CachedCreationDate { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierMsg")]
//         public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

//         [JsonPropertyName("HealthClinicIdentifierMsg")]
//         public healthClinicIdentifierMsgType? HealthClinicIdentifierMsg { get; set; }

//         [JsonPropertyName("RegisterHealthCaseClientBiographicalDetails")]
//         public registerHealthCaseClientBiographicalDetailsType? RegisterHealthCaseClientBiographicalDetails { get; set; }
//     }

//     public partial class notifyMedicalExaminationStatusRequestType
//     {
//         [JsonPropertyName("CorrelationID")]
//         public string? CorrelationID { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierMsg")]
//         public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

//         [JsonPropertyName("CachedCreationDate")]
//         public cachedUnstructuredDateType? CachedCreationDate { get; set; }

//         // Can be: healthCaseStatusUpdateType or notifyMedicalExaminationStatusRequestHealthRequirementType[]
//         [JsonPropertyName("HealthCaseStatusUpdate")]
//         public healthCaseStatusUpdateType? HealthCaseStatusUpdate { get; set; }

//         [JsonPropertyName("NotifyMedicalExaminationStatusRequestHealthRequirement")]
//         public notifyMedicalExaminationStatusRequestHealthRequirementType[]? NotifyMedicalExaminationStatusRequestHealthRequirement { get; set; }
//     }

//     public partial class healthCaseStatusUpdateType
//     {
//         [JsonPropertyName("HealthCaseExternalIdentifier")]
//         public string? HealthCaseExternalIdentifier { get; set; }

//         [JsonPropertyName("HealthCaseExternalIdentifierType")]
//         public string? HealthCaseExternalIdentifierType { get; set; }

//         [JsonPropertyName("HealthCaseStatus")]
//         public string? HealthCaseStatus { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }
//     }

//     public partial class notifyMedicalExaminationStatusRequestHealthRequirementType
//     {
//         [JsonPropertyName("HealthRequirementIdentifierMsg")]
//         public healthRequirementIdentifierMsgType? HealthRequirementIdentifierMsg { get; set; }

//         [JsonPropertyName("NotifyMedicalExaminationStatusRequestExamination")]
//         public notifyMedicalExaminationStatusRequestExaminationType? NotifyMedicalExaminationStatusRequestExamination { get; set; }
//     }

//     public partial class healthRequirementIdentifierMsgType
//     {
//         [JsonPropertyName("HealthRequirementIdentifier")]
//         public string? HealthRequirementIdentifier { get; set; }

//         [JsonPropertyName("HealthRequirementIdentifierType")]
//         public string? HealthRequirementIdentifierType { get; set; }
//     }

//     public partial class notifyMedicalExaminationStatusRequestExaminationType
//     {
//         [JsonPropertyName("ExaminationExternalIdentifier")]
//         public string? ExaminationExternalIdentifier { get; set; }

//         [JsonPropertyName("ExaminationExternalIdentifierType")]
//         public string? ExaminationExternalIdentifierType { get; set; }

//         [JsonPropertyName("ExaminationStatus")]
//         public string? ExaminationStatus { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }

//         [JsonPropertyName("ExaminationManuallyReceivedFlag")]
//         public bool? ExaminationManuallyReceivedFlag { get; set; }

//         [JsonPropertyName("ExaminationGrading")]
//         public string? ExaminationGrading { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("NotifyMedicalStatusRequestHealthClientContext")]
//         public notifyMedicalStatusRequestHealthClientContextType? NotifyMedicalStatusRequestHealthClientContext { get; set; }
//     }

//     public partial class notifyMedicalStatusRequestHealthClientContextType
//     {
//         [JsonPropertyName("Title")]
//         public string? Title { get; set; }

//         [JsonPropertyName("GivenName")]
//         public string? GivenName { get; set; }

//         [JsonPropertyName("FamilyName")]
//         public string? FamilyName { get; set; }

//         [JsonPropertyName("SexType")]
//         public sexTypeType SexType { get; set; }

//         [JsonPropertyName("CachedBirthYear")]
//         public cachedUnstructuredBirthYearType? CachedBirthYear { get; set; }

//         [JsonPropertyName("CachedBirthMonth")]
//         public cachedUnstructuredBirthMonthType? CachedBirthMonth { get; set; }

//         [JsonPropertyName("CachedBirthDay")]
//         public cachedUnstructuredBirthDayType? CachedBirthDay { get; set; }

//         [JsonPropertyName("BirthCountryCode")]
//         public string? BirthCountryCode { get; set; }

//         [JsonPropertyName("HealthIdentityDocumentMsg")]
//         public healthIdentityDocumentMsgType? HealthIdentityDocumentMsg { get; set; }

//         [JsonPropertyName("HealthClientContactListMsg")]
//         public healthClientContactMsgType[]? HealthClientContactListMsg { get; set; }
//     }

//     public partial class deleteCachedHealthCaseRequestType
//     {
//         [JsonPropertyName("CorrelationID")]
//         public string? CorrelationID { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierMsg")]
//         public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }
//     }

//     public partial class registerMedicalExaminationsResultsRequestType
//     {
//         [JsonPropertyName("CorrelationID")]
//         public string? CorrelationID { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierMsg")]
//         public healthCaseIdentifierMsgType[]? HealthCaseIdentifierMsg { get; set; }

//         [JsonPropertyName("RegisterMedicalExaminationsResultsRequestIdentityDocument")]
//         public registerMedicalExaminationsResultsRequestIdentityDocumentType? RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

//         [JsonPropertyName("HealthFacialImageMsg")]
//         public healthFacialImageMsgType? HealthFacialImageMsg { get; set; }

//         [JsonPropertyName("HealthCaseDetailForm")]
//         public healthCaseDetailFormType? HealthCaseDetailForm { get; set; }

//         [JsonPropertyName("HealthCaseAttachmentMsg")]
//         public healthCaseAttachmentMsgType[]? HealthCaseAttachmentMsg { get; set; }

//         [JsonPropertyName("RegisterMedicalExaminationsResultsRequestHealthRequirement")]
//         public registerMedicalExaminationsResultsRequestHealthRequirementType[]? RegisterMedicalExaminationsResultsRequestHealthRequirement { get; set; }

//         [JsonPropertyName("ProcessingUnit")]
//         public string? ProcessingUnit { get; set; }
//     }

//     public partial class registerMedicalExaminationsResultsRequestIdentityDocumentType
//     {
//         [JsonPropertyName("DocumentTypeCode")]
//         public string? DocumentTypeCode { get; set; }

//         [JsonPropertyName("DocumentType")]
//         public string? DocumentType { get; set; }

//         [JsonPropertyName("DocumentNumber")]
//         public string? DocumentNumber { get; set; }

//         [JsonPropertyName("IssuingCountryName")]
//         public string? IssuingCountryName { get; set; }

//         [JsonPropertyName("CachedIssueDate")]
//         public cachedUnstructuredDateType? CachedIssueDate { get; set; }

//         [JsonPropertyName("CachedExpiryDate")]
//         public cachedUnstructuredDateType? CachedExpiryDate { get; set; }

//         [JsonPropertyName("GivenName")]
//         public string? GivenName { get; set; }

//         [JsonPropertyName("FamilyName")]
//         public string? FamilyName { get; set; }

//         [JsonPropertyName("SexType")]
//         public sexTypeType SexType { get; set; }

//         [JsonPropertyName("CachedBirthYear")]
//         public cachedUnstructuredBirthYearType? CachedBirthYear { get; set; }

//         [JsonPropertyName("CachedBirthMonth")]
//         public cachedUnstructuredBirthMonthType? CachedBirthMonth { get; set; }

//         [JsonPropertyName("CachedBirthDay")]
//         public cachedUnstructuredBirthDayType? CachedBirthDay { get; set; }

//         [JsonPropertyName("BirthCountryCode")]
//         public string? BirthCountryCode { get; set; }
//     }

//     public partial class healthFacialImageMsgType
//     {
//         // Can be: healthPhotoAttachedMsgType or healthPhotoNotAttachedMsgType
//         [JsonPropertyName("HealthPhotoAttachedMsg")]
//         public healthPhotoAttachedMsgType? HealthPhotoAttachedMsg { get; set; }

//         [JsonPropertyName("HealthPhotoNotAttachedMsg")]
//         public healthPhotoNotAttachedMsgType? HealthPhotoNotAttachedMsg { get; set; }
//     }

//     public partial class healthPhotoAttachedMsgType
//     {
//         [JsonPropertyName("FaceImageFileName")]
//         public string? FaceImageFileName { get; set; }

//         [JsonPropertyName("FaceImageFileContent")]
//         public byte[]? FaceImageFileContent { get; set; }
//     }

//     public partial class healthPhotoNotAttachedMsgType
//     {
//         [JsonPropertyName("PhotoNotAttachedCode")]
//         public string? PhotoNotAttachedCode { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }
//     }

//     public partial class healthCaseDetailFormType
//     {
//         [JsonPropertyName("HealthFormExcDCMsg")]
//         public healthFormExcDCMsgType? HealthFormExcDCMsg { get; set; }

//         [JsonPropertyName("HealthFormIncDCMsg")]
//         public healthFormIncDCMsgType? HealthFormIncDCMsg { get; set; }
//     }

//     public partial class healthFormMsgType
//     {
//         [JsonPropertyName("FormType")]
//         public string? FormType { get; set; }

//         [JsonPropertyName("FormVersion")]
//         public string? FormVersion { get; set; }
//     }

//     public partial class healthFormExcDCMsgType
//     {
//         [JsonPropertyName("FormType")]
//         public string? FormType { get; set; }

//         [JsonPropertyName("FormVersion")]
//         public string? FormVersion { get; set; }

//         [JsonPropertyName("FormStatus")]
//         public string? FormStatus { get; set; }

//         [JsonPropertyName("HealthSectionExcDCMsg")]
//         public healthSectionExcDCMsgType[]? HealthSectionExcDCMsg { get; set; }
//     }

//     public partial class healthSectionExcDCMsgType
//     {
//         [JsonPropertyName("SectionTypeCode")]
//         public string? SectionTypeCode { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("SectionStatus")]
//         public string? SectionStatus { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }

//         [JsonPropertyName("HealthQuestionExcDCMsg")]
//         public healthQuestionExcDCMsgType[]? HealthQuestionExcDCMsg { get; set; }
//     }

//     public partial class healthQuestionExcDCMsgType
//     {
//         [JsonPropertyName("QuestionTypeCode")]
//         public string? QuestionTypeCode { get; set; }

//         [JsonPropertyName("QuestionMetadata")]
//         public string? QuestionMetadata { get; set; }

//         [JsonPropertyName("Conditional")]
//         public bool? Conditional { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("HealthAnswerExcDCMsg")]
//         public healthAnswerExcDCMsgType[]? HealthAnswerExcDCMsg { get; set; }
//     }

//     public partial class healthAnswerExcDCMsgType
//     {
//         [JsonPropertyName("AnswerTypeCode")]
//         public string? AnswerTypeCode { get; set; }

//         [JsonPropertyName("AnswerMetadata")]
//         public string? AnswerMetadata { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("UserName")]
//         public string? UserName { get; set; }

//         [JsonPropertyName("Value")]
//         public string? Value { get; set; }

//         [JsonPropertyName("ValueDescription")]
//         public string? ValueDescription { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("CommentPractitionerID")]
//         public string? CommentPractitionerID { get; set; }

//         [JsonPropertyName("AbnormalFlag")]
//         public bool? AbnormalFlag { get; set; }
//     }

//     public partial class healthFormIncDCMsgType
//     {
//         [JsonPropertyName("FormType")]
//         public string? FormType { get; set; }

//         [JsonPropertyName("FormVersion")]
//         public string? FormVersion { get; set; }

//         [JsonPropertyName("FormStatus")]
//         public string? FormStatus { get; set; }

//         [JsonPropertyName("HealthSectionIncDCMsg")]
//         public healthSectionIncDCMsgType[]? HealthSectionIncDCMsg { get; set; }
//     }

//     public partial class healthSectionIncDCMsgType
//     {
//         [JsonPropertyName("SectionTypeCode")]
//         public string? SectionTypeCode { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("SectionStatus")]
//         public string? SectionStatus { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }

//         [JsonPropertyName("HealthQuestionIncDCMsg")]
//         public healthQuestionIncDCMsgType[]? HealthQuestionIncDCMsg { get; set; }
//     }

//     public partial class healthQuestionIncDCMsgType
//     {
//         [JsonPropertyName("QuestionTypeCode")]
//         public string? QuestionTypeCode { get; set; }

//         [JsonPropertyName("QuestionMetadata")]
//         public string? QuestionMetadata { get; set; }

//         [JsonPropertyName("Conditional")]
//         public bool? Conditional { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("HealthAnswerIncDCMsg")]
//         public healthAnswerIncDCMsgType[]? HealthAnswerIncDCMsg { get; set; }
//     }

//     public partial class healthAnswerIncDCMsgType
//     {
//         [JsonPropertyName("AnswerTypeCode")]
//         public string? AnswerTypeCode { get; set; }

//         [JsonPropertyName("AnswerMetadata")]
//         public string? AnswerMetadata { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("UserName")]
//         public string? UserName { get; set; }

//         [JsonPropertyName("Value")]
//         public string? Value { get; set; }

//         [JsonPropertyName("ValueDescription")]
//         public string? ValueDescription { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("CommentPractitionerID")]
//         public string? CommentPractitionerID { get; set; }

//         [JsonPropertyName("AbnormalFlag")]
//         public bool? AbnormalFlag { get; set; }

//         [JsonPropertyName("HealthDoctorCommentMsg")]
//         public healthDoctorCommentMsgType[]? HealthDoctorCommentMsg { get; set; }
//     }

//     public partial class healthDoctorCommentMsgType
//     {
//         [JsonPropertyName("ClinicID")]
//         public string? ClinicID { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("CachedCreatedTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }
//     }

//     public partial class healthCaseAttachmentMsgType
//     {
//         [JsonPropertyName("HealthAttachmentIdentifierMsg")]
//         public healthAttachmentIdentifierMsgType? HealthAttachmentIdentifierMsg { get; set; }

//         [JsonPropertyName("StatusCode")]
//         public string? StatusCode { get; set; }

//         [JsonPropertyName("DocumentType")]
//         public string? DocumentType { get; set; }

//         [JsonPropertyName("SendingMethod")]
//         public string? SendingMethod { get; set; }

//         [JsonPropertyName("FileName")]
//         public string? FileName { get; set; }

//         [JsonPropertyName("Detail")]
//         public string? Detail { get; set; }

//         [JsonPropertyName("FileSize")]
//         public string? FileSize { get; set; }

//         [JsonPropertyName("MIMEContentType")]
//         public string? MIMEContentType { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }
//     }

//     public partial class healthAttachmentIdentifierMsgType
//     {
//         [JsonPropertyName("AttachmentIdentifier")]
//         public string? AttachmentIdentifier { get; set; }

//         [JsonPropertyName("AttachmentIdentifierType")]
//         public string? AttachmentIdentifierType { get; set; }
//     }

//     public partial class registerMedicalExaminationsResultsRequestHealthRequirementType
//     {
//         [JsonPropertyName("HealthRequirementMsg")]
//         public healthRequirementMsgType? HealthRequirementMsg { get; set; }

//         [JsonPropertyName("HealthRequirementIdentifierMsg")]
//         public healthRequirementIdentifierMsgType? HealthRequirementIdentifierMsg { get; set; }

//         [JsonPropertyName("RegisterMedicalExaminationsResultsRequestExamination")]
//         public registerMedicalExaminationsResultsRequestExaminationType? RegisterMedicalExaminationsResultsRequestExamination { get; set; }
//     }

//     public partial class healthRequirementMsgType
//     {
//         [JsonPropertyName("HealthRequirementType")]
//         public string? HealthRequirementType { get; set; }

//         [JsonPropertyName("HealthRequirementDescription")]
//         public string? HealthRequirementDescription { get; set; }

//         [JsonPropertyName("HealthRequirementReason")]
//         public string? HealthRequirementReason { get; set; }

//         [JsonPropertyName("CachedCreatedTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

//         [JsonPropertyName("HealthRequirementStatusCode")]
//         public string? HealthRequirementStatusCode { get; set; }

//         [JsonPropertyName("CachedStatusTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedStatusTimestamp { get; set; }
//     }

//     public partial class registerMedicalExaminationsResultsRequestExaminationType
//     {
//         [JsonPropertyName("CachedCreatedTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

//         [JsonPropertyName("CreateUserId")]
//         public string? CreateUserId { get; set; }

//         [JsonPropertyName("CreateUsername")]
//         public string? CreateUsername { get; set; }

//         [JsonPropertyName("CountryCode")]
//         public string? CountryCode { get; set; }

//         [JsonPropertyName("ClinicID")]
//         public string? ClinicID { get; set; }

//         [JsonPropertyName("ExamUpdated")]
//         public examUpdatedType? ExamUpdated { get; set; }

//         [JsonPropertyName("CachedEffectiveStartDate")]
//         public cachedUnstructuredDateType? CachedEffectiveStartDate { get; set; }

//         [JsonPropertyName("CachedEffectiveEndDate")]
//         public cachedUnstructuredDateType? CachedEffectiveEndDate { get; set; }

//         [JsonPropertyName("ExaminationManuallyReceivedFlag")]
//         public bool? ExaminationManuallyReceivedFlag { get; set; }

//         [JsonPropertyName("DeclarationFlag")]
//         public bool? DeclarationFlag { get; set; }

//         [JsonPropertyName("ExaminationGrading")]
//         public string? ExaminationGrading { get; set; }

//         [JsonPropertyName("GradingPractitionerID")]
//         public string? GradingPractitionerID { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("PractitionerID")]
//         public string? PractitionerID { get; set; }

//         [JsonPropertyName("ExaminationStatusReason")]
//         public string? ExaminationStatusReason { get; set; }

//         [JsonPropertyName("ExaminationStatusComment")]
//         public string? ExaminationStatusComment { get; set; }

//         [JsonPropertyName("ProxySubmittingUser")]
//         public proxySubmittingUserType? ProxySubmittingUser { get; set; }

//         [JsonPropertyName("HealthReferralMsg")]
//         public healthReferralMsgType? HealthReferralMsg { get; set; }

//         [JsonPropertyName("RegisterMedicalExaminationsResultsRequestIdentityDocument")]
//         public registerMedicalExaminationsResultsRequestIdentityDocumentType? RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

//         [JsonPropertyName("HealthCaseAttachmentMsg")]
//         public healthCaseAttachmentMsgType[]? HealthCaseAttachmentMsg { get; set; }

//         [JsonPropertyName("HealthFormMsg")]
//         public healthFormMsgType? HealthFormMsg { get; set; }

//         [JsonPropertyName("HealthMedicalHistoryMsg")]
//         public healthMedicalHistoryMsgType? HealthMedicalHistoryMsg { get; set; }
//     }

//     public partial class examUpdatedType
//     {
//         [JsonPropertyName("CachedCreatedTimestamp")]
//         public cachedUnstructuredDateTimeType? CachedCreatedTimestamp { get; set; }

//         [JsonPropertyName("CreateUserId")]
//         public string? CreateUserId { get; set; }

//         [JsonPropertyName("CreateUsername")]
//         public string? CreateUsername { get; set; }
//     }

//     public partial class proxySubmittingUserType
//     {
//         [JsonPropertyName("UserId")]
//         public string? UserId { get; set; }

//         [JsonPropertyName("UserName")]
//         public string? UserName { get; set; }
//     }

//     public partial class healthReferralMsgType
//     {
//         [JsonPropertyName("ClinicName")]
//         public string? ClinicName { get; set; }

//         [JsonPropertyName("ReferralIdentityConfirmationFlag")]
//         public bool? ReferralIdentityConfirmationFlag { get; set; }
//     }

//     public partial class healthMedicalHistoryMsgType
//     {
//         [JsonPropertyName("ClinicID")]
//         public string? ClinicID { get; set; }

//         [JsonPropertyName("ClientDeclarationFlag")]
//         public bool? ClientDeclarationFlag { get; set; }

//         [JsonPropertyName("CommentText")]
//         public string? CommentText { get; set; }

//         [JsonPropertyName("HealthFormMsg")]
//         public healthFormMsgType? HealthFormMsg { get; set; }
//     }

//     public partial class notifyCachedHealthClientDetailsUpdateResponseType
//     {
//         [JsonPropertyName("CorrelationID")]
//         public string? CorrelationID { get; set; }

//         [JsonPropertyName("HealthCaseIdentifierListResponseMsg")]
//         public healthCaseIdentifierMsgType[]? HealthCaseIdentifierListResponseMsg { get; set; }

//         [JsonPropertyName("SuccessFlag")]
//         public bool? SuccessFlag { get; set; }

//         [JsonPropertyName("HealtheMedicalErrorResponseMsg")]
//         public healtheMedicalErrorResponseMsgType? HealtheMedicalErrorResponseMsg { get; set; }
//     }

//     public partial class healtheMedicalErrorResponseMsgType
//     {
//         [JsonPropertyName("eMedicalErrorCode")]
//         public string? eMedicalErrorCode { get; set; }

//         [JsonPropertyName("eMedicalErrorMessage")]
//         public string? eMedicalErrorMessage { get; set; }
//     }
// }
