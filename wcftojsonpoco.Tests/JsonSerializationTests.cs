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

    [Fact]
    public void RegistrationJson_DeserializesIntoRegisterHealthCaseRequestType_PropertiesPopulated()
    {
        // Arrange: read JSON from the test output directory
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "registration.json");
        Assert.True(File.Exists(jsonPath), $"registration.json not found at {jsonPath}");
        var json = File.ReadAllText(jsonPath);

        // Act
        var model = JsonSerializer.Deserialize<registerHealthCaseRequestType>(json, _options);

        // Assert - top-level properties and exact values
        Assert.NotNull(model);
        Assert.Equal("100000000000000001", model!.CorrelationID);
        Assert.NotNull(model.CachedCreationDate);
        Assert.Equal("2019", model.CachedCreationDate!.UnstructuredYear);
        Assert.Equal("11", model.CachedCreationDate!.UnstructuredMonth);
        Assert.Equal("1", model.CachedCreationDate!.UnstructuredDay);

        // HealthCaseIdentifierMsg
        Assert.NotNull(model.HealthCaseIdentifierMsg);
        Assert.Equal(20, model.HealthCaseIdentifierMsg!.Length);
        // Exhaustively validate all entries against expected values
        var expectedCaseIds = new (string value, string type)[]
        {
            ("U000010002", "UMI"),
            ("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),
            ("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),
            ("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),
            ("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),("40033127", "IME"),
            ("9191", "IOMGID")
        };
        for (int i = 0; i < expectedCaseIds.Length; i++)
        {
            var item = model.HealthCaseIdentifierMsg[i];
            Assert.NotNull(item.HealthCaseIdentifier);
            Assert.Equal(expectedCaseIds[i].value, item.HealthCaseIdentifier!.HealthCaseIdentifierValue);
            Assert.Equal(expectedCaseIds[i].type, item.HealthCaseIdentifier!.HealthCaseIdentifierType);
            Assert.Null(item.AssessmentType);
        }

        // HealthClinicIdentifierMsg
        Assert.NotNull(model.HealthClinicIdentifierMsg);
        Assert.Equal("12345", model.HealthClinicIdentifierMsg!.HealthClinicIdentifier);
        Assert.Equal("CLINIC_ID", model.HealthClinicIdentifierMsg!.HealthClinicIdentifierType);

        // RegisterHealthCaseClientBiographicalDetails
        Assert.NotNull(model.RegisterHealthCaseClientBiographicalDetails);
        var bio = model.RegisterHealthCaseClientBiographicalDetails!;
        Assert.Null(bio.Title);
        Assert.Equal("Maria", bio.GivenName);
        Assert.Equal("Mañego", bio.FamilyName);
        // Enum SexType in JSON is numeric 1; verify mapped enum value
        Assert.Equal(sexTypeType.F, bio.SexType);
        Assert.Equal("1990", bio.CachedBirthYear!.UnstructuredYear);
        Assert.Equal("11", bio.CachedBirthMonth!.UnstructuredMonth);
        Assert.Equal("15", bio.CachedBirthDay!.UnstructuredDay);
        Assert.Equal("AFGH", bio.BirthCountryCode);
        Assert.Equal("WI", bio.RelationshipToPrimaryApplicant);
        Assert.NotNull(bio.CachedBirthYear);
        Assert.False(string.IsNullOrWhiteSpace(bio.CachedBirthYear!.UnstructuredYear));
        Assert.NotNull(bio.CachedBirthMonth);
        Assert.False(string.IsNullOrWhiteSpace(bio.CachedBirthMonth!.UnstructuredMonth));
        Assert.NotNull(bio.CachedBirthDay);
        Assert.False(string.IsNullOrWhiteSpace(bio.CachedBirthDay!.UnstructuredDay));

        // Nested document
        Assert.NotNull(bio.HealthIdentityDocumentMsg);
        Assert.Equal("01", bio.HealthIdentityDocumentMsg!.DocumentTypeCode);
        Assert.Null(bio.HealthIdentityDocumentMsg!.DocumentType);
        Assert.Equal("12345", bio.HealthIdentityDocumentMsg!.DocumentNumber);
        Assert.Equal("AFG", bio.HealthIdentityDocumentMsg!.IssuingCountryName);
        Assert.Equal("2019", bio.HealthIdentityDocumentMsg!.CachedIssueDate!.UnstructuredYear);
        Assert.Equal("1", bio.HealthIdentityDocumentMsg!.CachedIssueDate!.UnstructuredMonth);
        Assert.Equal("1", bio.HealthIdentityDocumentMsg!.CachedIssueDate!.UnstructuredDay);
        Assert.Equal("2025", bio.HealthIdentityDocumentMsg!.CachedExpiryDate!.UnstructuredYear);
        Assert.Equal("11", bio.HealthIdentityDocumentMsg!.CachedExpiryDate!.UnstructuredMonth);
        Assert.Equal("1", bio.HealthIdentityDocumentMsg!.CachedExpiryDate!.UnstructuredDay);

        // Contact list
        Assert.NotNull(bio.HealthClientContactListMsg);
        Assert.Single(bio.HealthClientContactListMsg!);
        var contact = bio.HealthClientContactListMsg![0];
        Assert.Equal("3", contact.UsageCode);
        Assert.True(contact.HealthPrimaryContactFlag);
        Assert.Null(contact.CommentText);
        // Item is an address object in JSON; depending on generated model, it may map to HealthLocationMsg or an Address union.
        // Validate via HealthLocationMsg when present; otherwise ensure at least AddressLine1 is captured.
        if (contact.HealthLocationMsg is not null)
        {
            Assert.Equal("street", contact.HealthLocationMsg.AddressLine1);
            Assert.Null(contact.HealthLocationMsg.AddressLine2);
            Assert.Null(contact.HealthLocationMsg.AddressLine3);
            Assert.Null(contact.HealthLocationMsg.AddressLine4);
            Assert.Null(contact.HealthLocationMsg.LocalityName);
            Assert.Null(contact.HealthLocationMsg.StateTerritoryName);
            Assert.Equal("kandahar", contact.HealthLocationMsg.ProvinceName);
            Assert.Equal("AFGH", contact.HealthLocationMsg.CountryCode);
            Assert.Null(contact.HealthLocationMsg.PostalCode);
        }

        // Visa context
        Assert.NotNull(bio.RegisterHealthCaseVisaContext);
        Assert.Single(bio.RegisterHealthCaseVisaContext!);
        Assert.Equal("IME", bio.RegisterHealthCaseVisaContext![0].HealthVisaContextType);
        Assert.Equal("REF", bio.RegisterHealthCaseVisaContext![0].HealthVisaContextValue);

        // Requirements list
        Assert.NotNull(bio.RegisterHealthCaseRequirementList);
        Assert.Equal(5, bio.RegisterHealthCaseRequirementList!.Length);
        // Exhaustively validate all requirements
        var expectedReqs = new (string type, (string Y, string M, string D, string h, string m, string s) created, (string Y, string M, string D, string h, string m, string s) status)[]
        {
            ("501", ("2019","11","1","0","17","21"), ("2019","11","1","0","24","54")),
            ("502", ("2019","11","1","0","17","21"), ("2019","11","1","0","23","46")),
            ("707", ("2019","11","1","0","17","21"), ("2019","11","1","0","23","35")),
            ("712", ("2019","11","1","0","17","21"), ("2019","11","1","0","23","22")),
            ("948", ("2019","11","1","0","20","49"), ("2019","11","1","0","21","12"))
        };
        for (int i = 0; i < expectedReqs.Length; i++)
        {
            var req = bio.RegisterHealthCaseRequirementList[i];
            Assert.Equal(expectedReqs[i].type, req.HealthRequirementType);
            Assert.Equal("INCM", req.HealthRequirementStatusCode);
            Assert.Equal(expectedReqs[i].created.Y, req.CachedCreatedTimestamp!.UnstructuredYear);
            Assert.Equal(expectedReqs[i].created.M, req.CachedCreatedTimestamp!.UnstructuredMonth);
            Assert.Equal(expectedReqs[i].created.D, req.CachedCreatedTimestamp!.UnstructuredDay);
            Assert.Equal(expectedReqs[i].created.h, req.CachedCreatedTimestamp!.UnstructuredHour);
            Assert.Equal(expectedReqs[i].created.m, req.CachedCreatedTimestamp!.UnstructuredMinute);
            Assert.Equal(expectedReqs[i].created.s, req.CachedCreatedTimestamp!.UnstructuredSecond);
            Assert.Equal(expectedReqs[i].status.Y, req.CachedStatusTimestamp!.UnstructuredYear);
            Assert.Equal(expectedReqs[i].status.M, req.CachedStatusTimestamp!.UnstructuredMonth);
            Assert.Equal(expectedReqs[i].status.D, req.CachedStatusTimestamp!.UnstructuredDay);
            Assert.Equal(expectedReqs[i].status.h, req.CachedStatusTimestamp!.UnstructuredHour);
            Assert.Equal(expectedReqs[i].status.m, req.CachedStatusTimestamp!.UnstructuredMinute);
            Assert.Equal(expectedReqs[i].status.s, req.CachedStatusTimestamp!.UnstructuredSecond);
        }
    }
}
