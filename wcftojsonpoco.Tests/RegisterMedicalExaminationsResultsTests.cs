using System.Text.Json;
using eMedicalService.LegacyJavaWcfService;
using Xunit;

namespace wcftojsonpoco.Tests;

public class RegisterMedicalExaminationsResultsTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    [Fact]
    public void RegisterMedicalExaminationsResultsRequestJson_DeserializesCorrectly_AllPropertiesPopulated()
    {
        // Arrange
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "registerMedicalExaminationsResultsRequestType.json");
        var jsonContent = File.ReadAllText(jsonPath);

        // Act
        var deserialized = JsonSerializer.Deserialize<registerMedicalExaminationsResultsRequestType>(jsonContent, _options);

        // Assert - Root Level Properties
        Assert.NotNull(deserialized);
        Assert.Equal("362291741331387601", deserialized.CorrelationID);
        Assert.Null(deserialized.ProcessingUnit);

        // Assert - HealthCaseIdentifierMsg Array
        Assert.NotNull(deserialized.HealthCaseIdentifierMsg);
        Assert.Equal(3, deserialized.HealthCaseIdentifierMsg.Length);

        var firstIdentifier = deserialized.HealthCaseIdentifierMsg[0];
        Assert.NotNull(firstIdentifier.HealthCaseIdentifier);
        Assert.Equal("U000010CAN", firstIdentifier.HealthCaseIdentifier.HealthCaseIdentifierValue);
        Assert.Equal("IME", firstIdentifier.HealthCaseIdentifier.HealthCaseIdentifierType);

        var secondIdentifier = deserialized.HealthCaseIdentifierMsg[1];
        Assert.NotNull(secondIdentifier.HealthCaseIdentifier);
        Assert.Equal("UCI1705635497213", secondIdentifier.HealthCaseIdentifier.HealthCaseIdentifierValue);
        Assert.Equal("UCI", secondIdentifier.HealthCaseIdentifier.HealthCaseIdentifierType);

        var thirdIdentifier = deserialized.HealthCaseIdentifierMsg[2];
        Assert.NotNull(thirdIdentifier.HealthCaseIdentifier);
        Assert.Equal("-", thirdIdentifier.HealthCaseIdentifier.HealthCaseIdentifierValue);
        Assert.Equal("PREVIOUS_ITERATION_SUBMISSION_DATE", thirdIdentifier.HealthCaseIdentifier.HealthCaseIdentifierType);

        // Assert - RegisterMedicalExaminationsResultsRequestIdentityDocument
        Assert.NotNull(deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument);
        var identityDoc = deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument;
        Assert.Equal("01", identityDoc.DocumentTypeCode);
        Assert.Null(identityDoc.DocumentType);
        Assert.Equal("hehgeccieb", identityDoc.DocumentNumber);
        Assert.Equal("AFG", identityDoc.IssuingCountryName);

        // Assert - Identity Document Cached Issue Date
        Assert.NotNull(identityDoc.CachedIssueDate);
        Assert.Equal("2021", identityDoc.CachedIssueDate.UnstructuredYear);
        Assert.Equal("3", identityDoc.CachedIssueDate.UnstructuredMonth);
        Assert.Equal("4", identityDoc.CachedIssueDate.UnstructuredDay);

        // Assert - Identity Document Cached Expiry Date
        Assert.NotNull(identityDoc.CachedExpiryDate);
        Assert.Equal("2029", identityDoc.CachedExpiryDate.UnstructuredYear);
        Assert.Equal("1", identityDoc.CachedExpiryDate.UnstructuredMonth);
        Assert.Equal("19", identityDoc.CachedExpiryDate.UnstructuredDay);

        // Assert - HealthFacialImageMsg
        Assert.NotNull(deserialized.HealthFacialImageMsg);
        // Note: The JSON has "Item" but the class uses HealthPhotoAttachedMsg
        // This might be a polymorphic deserialization issue that needs investigation

        // Assert - HealthCaseDetailForm
        Assert.NotNull(deserialized.HealthCaseDetailForm);
        // The JSON structure shows HealthFormMsg -> Item with FormCode, VersionNumber, etc.
        // This might need further investigation for proper polymorphic deserialization

        // Assert - HealthCaseAttachmentMsg Array
        Assert.NotNull(deserialized.HealthCaseAttachmentMsg);
        Assert.Equal(2, deserialized.HealthCaseAttachmentMsg.Length);

        var firstAttachment = deserialized.HealthCaseAttachmentMsg[0];
        Assert.NotNull(firstAttachment.HealthAttachmentIdentifierMsg);
        Assert.Equal("35920", firstAttachment.HealthAttachmentIdentifierMsg.AttachmentIdentifier);
        Assert.Equal("EMED", firstAttachment.HealthAttachmentIdentifierMsg.AttachmentIdentifierType);
        Assert.Equal("SENT", firstAttachment.StatusCode);
        Assert.Equal("CDCL", firstAttachment.DocumentType);
        Assert.Equal("EMAIL", firstAttachment.SendingMethod);
        Assert.Null(firstAttachment.FileName);
        Assert.Equal("test signed", firstAttachment.Detail);
        Assert.Null(firstAttachment.FileSize);
        Assert.Null(firstAttachment.MIMEContentType);
        Assert.Null(firstAttachment.CommentText);

        var secondAttachment = deserialized.HealthCaseAttachmentMsg[1];
        Assert.NotNull(secondAttachment.HealthAttachmentIdentifierMsg);
        Assert.Equal("35928", secondAttachment.HealthAttachmentIdentifierMsg.AttachmentIdentifier);
        Assert.Equal("EMED", secondAttachment.HealthAttachmentIdentifierMsg.AttachmentIdentifierType);
        Assert.Equal("UPLD", secondAttachment.StatusCode);
        Assert.Equal("OTHR", secondAttachment.DocumentType);
        Assert.Null(secondAttachment.SendingMethod);
        Assert.Equal("EMED_GEN_RPT.pdf", secondAttachment.FileName);
        Assert.Null(secondAttachment.Detail);
        Assert.Null(secondAttachment.FileSize);
        Assert.Null(secondAttachment.MIMEContentType);
        Assert.Equal("EMED_GEN_RPT", secondAttachment.CommentText);

        // Assert - RegisterMedicalExaminationsResultsRequestHealthRequirement Array
        Assert.NotNull(deserialized.RegisterMedicalExaminationsResultsRequestHealthRequirement);
        Assert.Equal(7, deserialized.RegisterMedicalExaminationsResultsRequestHealthRequirement.Length);

        var firstRequirement = deserialized.RegisterMedicalExaminationsResultsRequestHealthRequirement[0];
        Assert.NotNull(firstRequirement.HealthRequirementMsg);
        Assert.Equal("712", firstRequirement.HealthRequirementMsg.HealthRequirementType);
        Assert.Null(firstRequirement.HealthRequirementMsg.HealthRequirementDescription);
        Assert.Null(firstRequirement.HealthRequirementMsg.HealthRequirementReason);
        Assert.Equal("FNLS", firstRequirement.HealthRequirementMsg.HealthRequirementStatusCode);

        // Assert - Cached Timestamps in first requirement
        Assert.NotNull(firstRequirement.HealthRequirementMsg.CachedCreatedTimestamp);
        var createdTimestamp = firstRequirement.HealthRequirementMsg.CachedCreatedTimestamp;
        Assert.Equal("31", createdTimestamp.UnstructuredSecond);

        Assert.NotNull(firstRequirement.HealthRequirementMsg.CachedStatusTimestamp);

        // Assert - HealthRequirementIdentifierMsg
        Assert.Null(firstRequirement.HealthRequirementIdentifierMsg);

        // Assert - RegisterMedicalExaminationsResultsRequestExamination
        Assert.NotNull(firstRequirement.RegisterMedicalExaminationsResultsRequestExamination);
        var examination = firstRequirement.RegisterMedicalExaminationsResultsRequestExamination;
        Assert.NotNull(examination.CachedCreatedTimestamp);
        Assert.Equal("31", examination.CachedCreatedTimestamp.UnstructuredSecond);
        Assert.Equal("e20909", examination.CreateUserId);
        Assert.Equal("DOCtwo IOM", examination.CreateUsername);
        Assert.Equal("MIS", examination.CountryCode);
        Assert.Equal("TR123", examination.ClinicID);
        Assert.Null(examination.ExamUpdated);
        Assert.False(examination.ExaminationManuallyReceivedFlag);

        // Assert - Cached Effective Dates in examination
        Assert.NotNull(examination.CachedEffectiveStartDate);
        Assert.Equal("7", examination.CachedEffectiveStartDate.UnstructuredDay);

        Assert.NotNull(examination.CachedEffectiveEndDate);
        Assert.Equal("7", examination.CachedEffectiveEndDate.UnstructuredDay);

        // Assert - Fifth requirement has HealthRequirementIdentifierMsg
        var fifthRequirement = deserialized.RegisterMedicalExaminationsResultsRequestHealthRequirement[4];
        Assert.NotNull(fifthRequirement.HealthRequirementIdentifierMsg);
        Assert.Equal("GCMSID", fifthRequirement.HealthRequirementIdentifierMsg.HealthRequirementIdentifierType);

        // Assert - Seventh requirement also has HealthRequirementIdentifierMsg
        var seventhRequirement = deserialized.RegisterMedicalExaminationsResultsRequestHealthRequirement[6];
        Assert.NotNull(seventhRequirement.HealthRequirementIdentifierMsg);
        Assert.Equal("GCMSID", seventhRequirement.HealthRequirementIdentifierMsg.HealthRequirementIdentifierType);
    }

    [Fact]
    public void RegisterMedicalExaminationsResultsRequestType_Serializes_WithCorrectPropertyNames()
    {
        // Arrange
        var request = new registerMedicalExaminationsResultsRequestType
        {
            CorrelationID = "TEST-CORRELATION-123",
            HealthCaseIdentifierMsg = new[]
            {
                new healthCaseIdentifierMsgType
                {
                    HealthCaseIdentifier = new healthCaseIdentifierType
                    {
                        HealthCaseIdentifierValue = "TEST-IME-001",
                        HealthCaseIdentifierType = "IME"
                    },
                    AssessmentType = assessmentTypeType.IME
                }
            },
            ProcessingUnit = "UNIT-01"
        };

        // Act
        var json = JsonSerializer.Serialize(request, _options);

        // Assert
        Assert.Contains("\"CorrelationID\"", json);
        Assert.Contains("\"HealthCaseIdentifierMsg\"", json);
        Assert.Contains("\"ProcessingUnit\"", json);
        Assert.Contains("TEST-CORRELATION-123", json);
        Assert.Contains("TEST-IME-001", json);
    }

    [Fact]
    public void RegisterMedicalExaminationsResultsRequestType_RoundTrip_PreservesData()
    {
        // Arrange
        var original = new registerMedicalExaminationsResultsRequestType
        {
            CorrelationID = "ROUNDTRIP-TEST-456",
            RegisterMedicalExaminationsResultsRequestIdentityDocument = new registerMedicalExaminationsResultsRequestIdentityDocumentType
            {
                DocumentTypeCode = "02",
                DocumentNumber = "PASS123456",
                IssuingCountryName = "USA",
                CachedIssueDate = new cachedUnstructuredDateType
                {
                    UnstructuredYear = "2020",
                    UnstructuredMonth = "6",
                    UnstructuredDay = "15"
                },
                CachedExpiryDate = new cachedUnstructuredDateType
                {
                    UnstructuredYear = "2030",
                    UnstructuredMonth = "6",
                    UnstructuredDay = "14"
                }
            },
            ProcessingUnit = "PROC-UNIT-A"
        };

        // Act
        var json = JsonSerializer.Serialize(original, _options);
        var deserialized = JsonSerializer.Deserialize<registerMedicalExaminationsResultsRequestType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal(original.CorrelationID, deserialized.CorrelationID);
        Assert.Equal(original.ProcessingUnit, deserialized.ProcessingUnit);
        Assert.NotNull(deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument);
        Assert.Equal(original.RegisterMedicalExaminationsResultsRequestIdentityDocument.DocumentTypeCode,
            deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument.DocumentTypeCode);
        Assert.Equal(original.RegisterMedicalExaminationsResultsRequestIdentityDocument.DocumentNumber,
            deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument.DocumentNumber);
        Assert.Equal(original.RegisterMedicalExaminationsResultsRequestIdentityDocument.IssuingCountryName,
            deserialized.RegisterMedicalExaminationsResultsRequestIdentityDocument.IssuingCountryName);
    }

    [Fact]
    public void HealthCaseAttachmentMsgType_SerializesCorrectly()
    {
        // Arrange
        var attachment = new healthCaseAttachmentMsgType
        {
            HealthAttachmentIdentifierMsg = new healthAttachmentIdentifierMsgType
            {
                AttachmentIdentifier = "ATT-001",
                AttachmentIdentifierType = "EMED"
            },
            StatusCode = "SENT",
            DocumentType = "PDF",
            SendingMethod = "EMAIL",
            FileName = "document.pdf",
            Detail = "Test document",
            FileSize = "1024",
            MIMEContentType = "application/pdf",
            CommentText = "Test comment"
        };

        // Act
        var json = JsonSerializer.Serialize(attachment, _options);
        var deserialized = JsonSerializer.Deserialize<healthCaseAttachmentMsgType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthAttachmentIdentifierMsg);
        Assert.Equal("ATT-001", deserialized.HealthAttachmentIdentifierMsg.AttachmentIdentifier);
        Assert.Equal("EMED", deserialized.HealthAttachmentIdentifierMsg.AttachmentIdentifierType);
        Assert.Equal("SENT", deserialized.StatusCode);
        Assert.Equal("PDF", deserialized.DocumentType);
        Assert.Equal("EMAIL", deserialized.SendingMethod);
        Assert.Equal("document.pdf", deserialized.FileName);
        Assert.Equal("Test document", deserialized.Detail);
        Assert.Equal("1024", deserialized.FileSize);
        Assert.Equal("application/pdf", deserialized.MIMEContentType);
        Assert.Equal("Test comment", deserialized.CommentText);
    }

    [Fact]
    public void HealthRequirementMsgType_WithTimestamps_SerializesCorrectly()
    {
        // Arrange
        var requirement = new healthRequirementMsgType
        {
            HealthRequirementType = "501",
            HealthRequirementDescription = "Medical Examination",
            HealthRequirementReason = "Immigration",
            HealthRequirementStatusCode = "INCM",
            CachedCreatedTimestamp = new cachedUnstructuredDateTimeType
            {
                UnstructuredYear = "2024",
                UnstructuredMonth = "12",
                UnstructuredDay = "4",
                UnstructuredHour = "10",
                UnstructuredMinute = "30",
                UnstructuredSecond = "15"
            },
            CachedStatusTimestamp = new cachedUnstructuredDateTimeType
            {
                UnstructuredYear = "2024",
                UnstructuredMonth = "12",
                UnstructuredDay = "4",
                UnstructuredHour = "11",
                UnstructuredMinute = "45",
                UnstructuredSecond = "30"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(requirement, _options);
        var deserialized = JsonSerializer.Deserialize<healthRequirementMsgType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal("501", deserialized.HealthRequirementType);
        Assert.Equal("Medical Examination", deserialized.HealthRequirementDescription);
        Assert.Equal("Immigration", deserialized.HealthRequirementReason);
        Assert.Equal("INCM", deserialized.HealthRequirementStatusCode);

        Assert.NotNull(deserialized.CachedCreatedTimestamp);
        Assert.Equal("2024", deserialized.CachedCreatedTimestamp.UnstructuredYear);
        Assert.Equal("12", deserialized.CachedCreatedTimestamp.UnstructuredMonth);
        Assert.Equal("4", deserialized.CachedCreatedTimestamp.UnstructuredDay);
        Assert.Equal("10", deserialized.CachedCreatedTimestamp.UnstructuredHour);
        Assert.Equal("30", deserialized.CachedCreatedTimestamp.UnstructuredMinute);
        Assert.Equal("15", deserialized.CachedCreatedTimestamp.UnstructuredSecond);

        Assert.NotNull(deserialized.CachedStatusTimestamp);
        Assert.Equal("2024", deserialized.CachedStatusTimestamp.UnstructuredYear);
        Assert.Equal("12", deserialized.CachedStatusTimestamp.UnstructuredMonth);
        Assert.Equal("4", deserialized.CachedStatusTimestamp.UnstructuredDay);
        Assert.Equal("11", deserialized.CachedStatusTimestamp.UnstructuredHour);
        Assert.Equal("45", deserialized.CachedStatusTimestamp.UnstructuredMinute);
        Assert.Equal("30", deserialized.CachedStatusTimestamp.UnstructuredSecond);
    }

    [Fact]
    public void RegisterMedicalExaminationsResultsRequestIdentityDocument_AllFields_SerializeCorrectly()
    {
        // Arrange
        var identityDoc = new registerMedicalExaminationsResultsRequestIdentityDocumentType
        {
            DocumentTypeCode = "01",
            DocumentType = "Passport",
            DocumentNumber = "AB123456",
            IssuingCountryName = "CAN",
            CachedIssueDate = new cachedUnstructuredDateType
            {
                UnstructuredYear = "2019",
                UnstructuredMonth = "5",
                UnstructuredDay = "20"
            },
            CachedExpiryDate = new cachedUnstructuredDateType
            {
                UnstructuredYear = "2029",
                UnstructuredMonth = "5",
                UnstructuredDay = "19"
            },
            GivenName = "John",
            FamilyName = "Doe",
            SexType = sexTypeType.M,
            CachedBirthYear = new cachedUnstructuredBirthYearType
            {
                UnstructuredYear = "1990"
            },
            CachedBirthMonth = new cachedUnstructuredBirthMonthType
            {
                UnstructuredMonth = "3"
            },
            CachedBirthDay = new cachedUnstructuredBirthDayType
            {
                UnstructuredDay = "15"
            },
            BirthCountryCode = "CAN"
        };

        // Act
        var json = JsonSerializer.Serialize(identityDoc, _options);
        var deserialized = JsonSerializer.Deserialize<registerMedicalExaminationsResultsRequestIdentityDocumentType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal("01", deserialized.DocumentTypeCode);
        Assert.Equal("Passport", deserialized.DocumentType);
        Assert.Equal("AB123456", deserialized.DocumentNumber);
        Assert.Equal("CAN", deserialized.IssuingCountryName);

        Assert.NotNull(deserialized.CachedIssueDate);
        Assert.Equal("2019", deserialized.CachedIssueDate.UnstructuredYear);
        Assert.Equal("5", deserialized.CachedIssueDate.UnstructuredMonth);
        Assert.Equal("20", deserialized.CachedIssueDate.UnstructuredDay);

        Assert.NotNull(deserialized.CachedExpiryDate);
        Assert.Equal("2029", deserialized.CachedExpiryDate.UnstructuredYear);
        Assert.Equal("5", deserialized.CachedExpiryDate.UnstructuredMonth);
        Assert.Equal("19", deserialized.CachedExpiryDate.UnstructuredDay);

        Assert.Equal("John", deserialized.GivenName);
        Assert.Equal("Doe", deserialized.FamilyName);
        Assert.Equal(sexTypeType.M, deserialized.SexType);

        Assert.NotNull(deserialized.CachedBirthYear);
        Assert.Equal("1990", deserialized.CachedBirthYear.UnstructuredYear);

        Assert.NotNull(deserialized.CachedBirthMonth);
        Assert.Equal("3", deserialized.CachedBirthMonth.UnstructuredMonth);

        Assert.NotNull(deserialized.CachedBirthDay);
        Assert.Equal("15", deserialized.CachedBirthDay.UnstructuredDay);

        Assert.Equal("CAN", deserialized.BirthCountryCode);
    }

    [Fact]
    public void HealthAttachmentIdentifierMsgType_SerializesCorrectly()
    {
        // Arrange
        var identifier = new healthAttachmentIdentifierMsgType
        {
            AttachmentIdentifier = "12345",
            AttachmentIdentifierType = "EMED"
        };

        // Act
        var json = JsonSerializer.Serialize(identifier, _options);
        var deserialized = JsonSerializer.Deserialize<healthAttachmentIdentifierMsgType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal("12345", deserialized.AttachmentIdentifier);
        Assert.Equal("EMED", deserialized.AttachmentIdentifierType);
        Assert.Contains("\"AttachmentIdentifier\": \"12345\"", json);
        Assert.Contains("\"AttachmentIdentifierType\": \"EMED\"", json);
    }

    [Fact]
    public void HealthRequirementIdentifierMsgType_SerializesCorrectly()
    {
        // Arrange
        var identifier = new healthRequirementIdentifierMsgType
        {
            HealthRequirementIdentifier = "REQ-001",
            HealthRequirementIdentifierType = "GCMSID"
        };

        // Act
        var json = JsonSerializer.Serialize(identifier, _options);
        var deserialized = JsonSerializer.Deserialize<healthRequirementIdentifierMsgType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal("REQ-001", deserialized.HealthRequirementIdentifier);
        Assert.Equal("GCMSID", deserialized.HealthRequirementIdentifierType);
        Assert.Contains("\"HealthRequirementIdentifier\": \"REQ-001\"", json);
        Assert.Contains("\"HealthRequirementIdentifierType\": \"GCMSID\"", json);
    }

    [Fact]
    public void CompleteHealthRequirement_WithAllSubObjects_SerializesCorrectly()
    {
        // Arrange
        var healthRequirement = new registerMedicalExaminationsResultsRequestHealthRequirementType
        {
            HealthRequirementMsg = new healthRequirementMsgType
            {
                HealthRequirementType = "712",
                HealthRequirementStatusCode = "FNLS",
                CachedCreatedTimestamp = new cachedUnstructuredDateTimeType
                {
                    UnstructuredYear = "2024",
                    UnstructuredMonth = "12",
                    UnstructuredDay = "4",
                    UnstructuredHour = "14",
                    UnstructuredMinute = "25",
                    UnstructuredSecond = "31"
                }
            },
            HealthRequirementIdentifierMsg = new healthRequirementIdentifierMsgType
            {
                HealthRequirementIdentifier = "HR-123",
                HealthRequirementIdentifierType = "GCMSID"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(healthRequirement, _options);
        var deserialized = JsonSerializer.Deserialize<registerMedicalExaminationsResultsRequestHealthRequirementType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthRequirementMsg);
        Assert.Equal("712", deserialized.HealthRequirementMsg.HealthRequirementType);
        Assert.Equal("FNLS", deserialized.HealthRequirementMsg.HealthRequirementStatusCode);

        Assert.NotNull(deserialized.HealthRequirementMsg.CachedCreatedTimestamp);
        Assert.Equal("2024", deserialized.HealthRequirementMsg.CachedCreatedTimestamp.UnstructuredYear);
        Assert.Equal("31", deserialized.HealthRequirementMsg.CachedCreatedTimestamp.UnstructuredSecond);

        Assert.NotNull(deserialized.HealthRequirementIdentifierMsg);
        Assert.Equal("HR-123", deserialized.HealthRequirementIdentifierMsg.HealthRequirementIdentifier);
        Assert.Equal("GCMSID", deserialized.HealthRequirementIdentifierMsg.HealthRequirementIdentifierType);
    }
}
