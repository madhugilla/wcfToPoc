using System.Text.Json;
using eMedicalService.LegacyJavaWcfService;
using Xunit;

namespace wcftojsonpoco.Tests;

public class JsonSerializationTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    [Fact]
    public void RegisterHealthCaseRequestType_Serializes_WithPascalCasePropertyNames()
    {
        // Arrange
        var request = new registerHealthCaseRequestType
        {
            CorrelationID = "CORR-12345",
            CachedCreationDate = new cachedUnstructuredDateType
            {
                UnstructuredYear = "2024",
                UnstructuredMonth = "12",
                UnstructuredDay = "02"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(request, _options);

        // Assert
        Assert.Contains("\"CorrelationID\"", json);
        Assert.Contains("\"CachedCreationDate\"", json);
        Assert.Contains("\"UnstructuredYear\"", json);
        Assert.Contains("CORR-12345", json);
    }

    [Fact]
    public void RegisterHealthCaseRequestType_RoundTrip_PreservesData()
    {
        // Arrange
        var original = new registerHealthCaseRequestType
        {
            CorrelationID = "TEST-CORR-ID",
            HealthClinicIdentifierMsg = new healthClinicIdentifierMsgType
            {
                HealthClinicIdentifier = "CLINIC-001",
                HealthClinicIdentifierType = "INTERNAL"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(original, _options);
        var deserialized = JsonSerializer.Deserialize<registerHealthCaseRequestType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal(original.CorrelationID, deserialized.CorrelationID);
        Assert.NotNull(deserialized.HealthClinicIdentifierMsg);
        Assert.Equal(original.HealthClinicIdentifierMsg.HealthClinicIdentifier, deserialized.HealthClinicIdentifierMsg.HealthClinicIdentifier);
    }

    [Fact]
    public void AcknowledgementType_SerializesAsString()
    {
        // Arrange
        var message = new acknowledgementMessageType
        {
            Acknowledgement = acknowledgementType.SUCCESS
        };

        // Act
        var json = JsonSerializer.Serialize(message, _options);

        // Assert
        Assert.Contains("\"SUCCESS\"", json);
        Assert.DoesNotContain("\"0\"", json); // Should not serialize as integer
    }

    [Fact]
    public void SexTypeType_SerializesAsString()
    {
        // Arrange
        var details = new registerHealthCaseClientBiographicalDetailsType
        {
            SexType = sexTypeType.M
        };

        // Act
        var json = JsonSerializer.Serialize(details, _options);

        // Assert
        Assert.Contains("\"M\"", json);
    }

    [Fact]
    public void AssessmentTypeType_SerializesAsString()
    {
        // Arrange
        var caseId = new healthCaseIdentifierMsgType
        {
            AssessmentType = assessmentTypeType.IME
        };

        // Act
        var json = JsonSerializer.Serialize(caseId, _options);

        // Assert
        Assert.Contains("\"IME\"", json);
    }

    [Fact]
    public void NullableAssessmentType_SerializesAsNull_WhenNull()
    {
        // Arrange
        var caseId = new healthCaseIdentifierMsgType
        {
            AssessmentType = null,
            HealthCaseIdentifier = new healthCaseIdentifierType
            {
                HealthCaseIdentifierValue = "TEST"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(caseId, _options);
        var deserialized = JsonSerializer.Deserialize<healthCaseIdentifierMsgType>(json, _options);

        // Assert
        Assert.Contains("\"AssessmentType\": null", json);
        Assert.NotNull(deserialized);
        Assert.Null(deserialized.AssessmentType);
    }

    [Fact]
    public void NullableBool_SerializesCorrectly()
    {
        // Arrange - with null
        var contactNull = new healthClientContactMsgType
        {
            HealthPrimaryContactFlag = null,
            UsageCode = "TEST"
        };

        // Act
        var jsonNull = JsonSerializer.Serialize(contactNull, _options);
        var deserializedNull = JsonSerializer.Deserialize<healthClientContactMsgType>(jsonNull, _options);

        // Assert
        Assert.Contains("\"HealthPrimaryContactFlag\": null", jsonNull);
        Assert.NotNull(deserializedNull);
        Assert.Null(deserializedNull.HealthPrimaryContactFlag);

        // Arrange - with true
        var contactTrue = new healthClientContactMsgType
        {
            HealthPrimaryContactFlag = true,
            UsageCode = "TEST"
        };

        // Act
        var jsonTrue = JsonSerializer.Serialize(contactTrue, _options);
        var deserializedTrue = JsonSerializer.Deserialize<healthClientContactMsgType>(jsonTrue, _options);

        // Assert
        Assert.Contains("\"HealthPrimaryContactFlag\": true", jsonTrue);
        Assert.NotNull(deserializedTrue);
        Assert.True(deserializedTrue.HealthPrimaryContactFlag);
    }

    [Fact]
    public void HealthClientContactMsgType_Email_SerializesCorrectly()
    {
        // Arrange
        var contact = new healthClientContactMsgType
        {
            UsageCode = "HOME",
            EmailAddress = "test@example.com"
        };

        // Act
        var json = JsonSerializer.Serialize(contact, _options);
        var deserialized = JsonSerializer.Deserialize<healthClientContactMsgType>(json, _options);

        // Assert
        Assert.Contains("\"EmailAddress\": \"test@example.com\"", json);
        Assert.NotNull(deserialized);
        Assert.Equal("test@example.com", deserialized.EmailAddress);
    }

    [Fact]
    public void HealthClientContactMsgType_Location_SerializesCorrectly()
    {
        // Arrange
        var contact = new healthClientContactMsgType
        {
            UsageCode = "WORK",
            HealthLocationMsg = new healthLocationMsgType
            {
                AddressLine1 = "123 Main Street",
                LocalityName = "Sydney",
                CountryCode = "AUS"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(contact, _options);
        var deserialized = JsonSerializer.Deserialize<healthClientContactMsgType>(json, _options);

        // Assert
        Assert.Contains("\"HealthLocationMsg\"", json);
        Assert.Contains("\"AddressLine1\": \"123 Main Street\"", json);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthLocationMsg);
        Assert.Equal("123 Main Street", deserialized.HealthLocationMsg.AddressLine1);
    }

    [Fact]
    public void HealthClientContactMsgType_Telephone_SerializesCorrectly()
    {
        // Arrange
        var contact = new healthClientContactMsgType
        {
            UsageCode = "MOBILE",
            HealthTelephoneMsg = new healthTelephoneMsgType
            {
                CountryTelephoneCode = "+61",
                AreaCode = "2",
                TelephoneNumber = "98765432"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(contact, _options);
        var deserialized = JsonSerializer.Deserialize<healthClientContactMsgType>(json, _options);

        // Assert
        Assert.Contains("\"HealthTelephoneMsg\"", json);
        Assert.Contains("\"TelephoneNumber\": \"98765432\"", json);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthTelephoneMsg);
        Assert.Equal("98765432", deserialized.HealthTelephoneMsg.TelephoneNumber);
    }

    [Fact]
    public void EnterpriseErrorsType_SerializesAllErrorTypes()
    {
        // Arrange
        var errors = new enterpriseErrorsType
        {
            LogicErrors = new logicErrorsType
            {
                LogicError = new[] { new logicErrorType { ErrorCode = "L001" } }
            },
            ValidationErrors = new validationErrorsType
            {
                ValidationError = new[] { new validationErrorType { ErrorCode = "V001" } }
            },
            SecurityErrors = new securityErrorsType
            {
                SecurityError = new[] { new securityErrorType { ErrorCode = "S001" } }
            },
            SystemErrors = new systemErrorsType
            {
                SystemError = new[] { new systemErrorType { ErrorCode = "SYS001" } }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(errors, _options);
        var deserialized = JsonSerializer.Deserialize<enterpriseErrorsType>(json, _options);

        // Assert
        Assert.Contains("\"LogicErrors\"", json);
        Assert.Contains("\"ValidationErrors\"", json);
        Assert.Contains("\"SecurityErrors\"", json);
        Assert.Contains("\"SystemErrors\"", json);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.LogicErrors);
        Assert.NotNull(deserialized.LogicErrors.LogicError);
        Assert.Equal("L001", deserialized.LogicErrors.LogicError[0].ErrorCode);
    }

    [Fact]
    public void CachedExpectedDeliveryDateType_InheritsFromCachedUnstructuredDateType()
    {
        // Arrange
        var date = new cachedExpectedDeliveryDateType
        {
            UnstructuredYear = "2025",
            UnstructuredMonth = "06",
            UnstructuredDay = "15"
        };

        // Act
        var json = JsonSerializer.Serialize(date, _options);
        var deserialized = JsonSerializer.Deserialize<cachedExpectedDeliveryDateType>(json, _options);

        // Assert
        Assert.Contains("\"UnstructuredYear\": \"2025\"", json);
        Assert.NotNull(deserialized);
        Assert.Equal("2025", deserialized.UnstructuredYear);
        Assert.Equal("06", deserialized.UnstructuredMonth);
        Assert.Equal("15", deserialized.UnstructuredDay);
    }

    [Fact]
    public void HealthFacialImageMsgType_PhotoAttached_SerializesCorrectly()
    {
        // Arrange
        var image = new healthFacialImageMsgType
        {
            HealthPhotoAttachedMsg = new healthPhotoAttachedMsgType
            {
                FaceImageFileName = "photo.jpg",
                FaceImageFileContent = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(image, _options);
        var deserialized = JsonSerializer.Deserialize<healthFacialImageMsgType>(json, _options);

        // Assert
        Assert.Contains("\"HealthPhotoAttachedMsg\"", json);
        Assert.Contains("\"FaceImageFileName\": \"photo.jpg\"", json);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthPhotoAttachedMsg);
        Assert.Equal("photo.jpg", deserialized.HealthPhotoAttachedMsg.FaceImageFileName);
    }

    [Fact]
    public void HealthFacialImageMsgType_PhotoNotAttached_SerializesCorrectly()
    {
        // Arrange
        var image = new healthFacialImageMsgType
        {
            HealthPhotoNotAttachedMsg = new healthPhotoNotAttachedMsgType
            {
                PhotoNotAttachedCode = "NO_PHOTO",
                CommentText = "Will be provided later"
            }
        };

        // Act
        var json = JsonSerializer.Serialize(image, _options);
        var deserialized = JsonSerializer.Deserialize<healthFacialImageMsgType>(json, _options);

        // Assert
        Assert.Contains("\"HealthPhotoNotAttachedMsg\"", json);
        Assert.Contains("\"PhotoNotAttachedCode\": \"NO_PHOTO\"", json);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.HealthPhotoNotAttachedMsg);
        Assert.Equal("NO_PHOTO", deserialized.HealthPhotoNotAttachedMsg.PhotoNotAttachedCode);
    }

    [Fact]
    public void AcknowledgementMessageType_WithArrays_SerializesCorrectly()
    {
        // Arrange
        var message = new acknowledgementMessageType
        {
            Acknowledgement = acknowledgementType.SUCCESS,
            Informations = new[]
            {
                new informationType
                {
                    InformationCode = "INFO-001",
                    DescriptionText = "Operation completed"
                }
            },
            Warnings = new[]
            {
                new warningType
                {
                    WarningCode = "WARN-001",
                    DescriptionText = "Data incomplete"
                }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(message, _options);
        var deserialized = JsonSerializer.Deserialize<acknowledgementMessageType>(json, _options);

        // Assert
        Assert.Contains("\"Informations\"", json);
        Assert.Contains("\"Warnings\"", json);
        Assert.NotNull(deserialized);
        Assert.Single(deserialized.Informations!);
        Assert.Single(deserialized.Warnings!);
        Assert.Equal("INFO-001", deserialized.Informations![0].InformationCode);
        Assert.Equal("WARN-001", deserialized.Warnings![0].WarningCode);
    }

    [Fact]
    public void ComplexNestedObject_SerializesCorrectly()
    {
        // Arrange
        var request = new registerHealthCaseRequestType
        {
            CorrelationID = "COMPLEX-TEST",
            HealthCaseIdentifierMsg = new[]
            {
                new healthCaseIdentifierMsgType
                {
                    HealthCaseIdentifier = new healthCaseIdentifierType
                    {
                        HealthCaseIdentifierValue = "HC-001",
                        HealthCaseIdentifierType = "PRIMARY"
                    },
                    AssessmentType = assessmentTypeType.IME
                }
            },
            RegisterHealthCaseClientBiographicalDetails = new registerHealthCaseClientBiographicalDetailsType
            {
                GivenName = "John",
                FamilyName = "Doe",
                SexType = sexTypeType.M,
                CachedBirthYear = new cachedUnstructuredBirthYearType { UnstructuredYear = "1990" }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(request, _options);
        var deserialized = JsonSerializer.Deserialize<registerHealthCaseRequestType>(json, _options);

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal("COMPLEX-TEST", deserialized.CorrelationID);
        Assert.NotNull(deserialized.HealthCaseIdentifierMsg);
        Assert.Single(deserialized.HealthCaseIdentifierMsg);
        Assert.Equal("HC-001", deserialized.HealthCaseIdentifierMsg[0].HealthCaseIdentifier?.HealthCaseIdentifierValue);
        Assert.Equal(assessmentTypeType.IME, deserialized.HealthCaseIdentifierMsg[0].AssessmentType);
        Assert.NotNull(deserialized.RegisterHealthCaseClientBiographicalDetails);
        Assert.Equal("John", deserialized.RegisterHealthCaseClientBiographicalDetails.GivenName);
        Assert.Equal(sexTypeType.M, deserialized.RegisterHealthCaseClientBiographicalDetails.SexType);
    }

    [Fact]
    public void AllEnumValues_SerializeCorrectly()
    {
        // Test all sex types
        Assert.Equal("\"Item\"", JsonSerializer.Serialize(sexTypeType.Item));
        Assert.Equal("\"F\"", JsonSerializer.Serialize(sexTypeType.F));
        Assert.Equal("\"M\"", JsonSerializer.Serialize(sexTypeType.M));
        Assert.Equal("\"U\"", JsonSerializer.Serialize(sexTypeType.U));
        Assert.Equal("\"X\"", JsonSerializer.Serialize(sexTypeType.X));

        // Test all assessment types
        Assert.Equal("\"IME\"", JsonSerializer.Serialize(assessmentTypeType.IME));
        Assert.Equal("\"DHC\"", JsonSerializer.Serialize(assessmentTypeType.DHC));
        Assert.Equal("\"ESC\"", JsonSerializer.Serialize(assessmentTypeType.ESC));
        Assert.Equal("\"PHC\"", JsonSerializer.Serialize(assessmentTypeType.PHC));

        // Test acknowledgement type
        Assert.Equal("\"SUCCESS\"", JsonSerializer.Serialize(acknowledgementType.SUCCESS));
    }
}
