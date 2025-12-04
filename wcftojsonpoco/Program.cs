using System.Text.Json;
using eMedicalService.LegacyJavaWcfService;

Console.WriteLine("=== WCF to JSON Serialization Test ===\n");

// // Configure JSON options
// var options = new JsonSerializerOptions
// {
//     WriteIndented = true
// };

// // Test 1: registerHealthCaseRequestType with nested properties
// Console.WriteLine("--- Test 1: registerHealthCaseRequestType ---");
// var healthCaseRequest = new registerHealthCaseRequestType
// {
//     CorrelationID = "CORR-12345",
//     CachedCreationDate = new cachedUnstructuredDateType
//     {
//         UnstructuredYear = "2024",
//         UnstructuredMonth = "12",
//         UnstructuredDay = "02"
//     },
//     HealthCaseIdentifierMsg = new[]
//     {
//         new healthCaseIdentifierMsgType
//         {
//             HealthCaseIdentifier = new healthCaseIdentifierType
//             {
//                 HealthCaseIdentifierValue = "HC-001",
//                 HealthCaseIdentifierType = "PRIMARY"
//             },
//             AssessmentType = assessmentTypeType.IME
//         }
//     },
//     HealthClinicIdentifierMsg = new healthClinicIdentifierMsgType
//     {
//         HealthClinicIdentifier = "CLINIC-001",
//         HealthClinicIdentifierType = "INTERNAL"
//     },
//     RegisterHealthCaseClientBiographicalDetails = new registerHealthCaseClientBiographicalDetailsType
//     {
//         Title = "Mr",
//         GivenName = "John",
//         FamilyName = "Doe",
//         SexType = sexTypeType.M,
//         CachedBirthYear = new cachedUnstructuredBirthYearType { UnstructuredYear = "1990" },
//         CachedBirthMonth = new cachedUnstructuredBirthMonthType { UnstructuredMonth = "05" },
//         CachedBirthDay = new cachedUnstructuredBirthDayType { UnstructuredDay = "15" },
//         BirthCountryCode = "AUS",
//         HealthClientContactListMsg = new[]
//         {
//             new healthClientContactMsgType
//             {
//                 UsageCode = "HOME",
//                 HealthPrimaryContactFlag = true,
//                 EmailAddress = "john.doe@example.com"
//             },
//             new healthClientContactMsgType
//             {
//                 UsageCode = "WORK",
//                 HealthPrimaryContactFlag = false,
//                 HealthLocationMsg = new healthLocationMsgType
//                 {
//                     AddressLine1 = "123 Main Street",
//                     LocalityName = "Sydney",
//                     StateTerritoryName = "NSW",
//                     CountryCode = "AUS",
//                     PostalCode = "2000"
//                 }
//             },
//             new healthClientContactMsgType
//             {
//                 UsageCode = "MOBILE",
//                 HealthTelephoneMsg = new healthTelephoneMsgType
//                 {
//                     CountryTelephoneCode = "+61",
//                     AreaCode = "2",
//                     TelephoneNumber = "98765432"
//                 }
//             }
//         }
//     }
// };

// string json1 = JsonSerializer.Serialize(healthCaseRequest, options);
// Console.WriteLine(json1);

// var deserializedRequest = JsonSerializer.Deserialize<registerHealthCaseRequestType>(json1, options);
// Console.WriteLine($"\nRound-trip test: CorrelationID = {deserializedRequest?.CorrelationID}");
// Console.WriteLine($"Round-trip test: GivenName = {deserializedRequest?.RegisterHealthCaseClientBiographicalDetails?.GivenName}");
// Console.WriteLine($"Round-trip test: SexType = {deserializedRequest?.RegisterHealthCaseClientBiographicalDetails?.SexType}");

// // Test 2: acknowledgementMessageType with populated arrays
// Console.WriteLine("\n--- Test 2: acknowledgementMessageType ---");
// var ackMessage = new acknowledgementMessageType
// {
//     Acknowledgement = acknowledgementType.SUCCESS,
//     Informations = new[]
//     {
//         new informationType
//         {
//             OriginatorName = "HealthService",
//             InformationCode = "INFO-001",
//             DescriptionText = "Processing completed successfully"
//         }
//     },
//     Warnings = new[]
//     {
//         new warningType
//         {
//             OriginatorName = "HealthService",
//             WarningCode = "WARN-001",
//             DescriptionText = "Some data was incomplete"
//         }
//     }
// };

// string json2 = JsonSerializer.Serialize(ackMessage, options);
// Console.WriteLine(json2);

// var deserializedAck = JsonSerializer.Deserialize<acknowledgementMessageType>(json2, options);
// Console.WriteLine($"\nRound-trip test: Acknowledgement = {deserializedAck?.Acknowledgement}");
// Console.WriteLine($"Round-trip test: Info count = {deserializedAck?.Informations?.Length}");

// // Test 3: enterpriseErrorsType with mixed error types (polymorphic)
// Console.WriteLine("\n--- Test 3: enterpriseErrorsType ---");
// var enterpriseErrors = new enterpriseErrorsType
// {
//     LogicErrors = new logicErrorsType
//     {
//         LogicError = new[]
//         {
//             new logicErrorType
//             {
//                 ErrorCode = "LOGIC-001",
//                 DescriptionText = "Logic validation failed"
//             }
//         }
//     },
//     ValidationErrors = new validationErrorsType
//     {
//         ValidationError = new[]
//         {
//             new validationErrorType
//             {
//                 ErrorCode = "VAL-001",
//                 DescriptionText = "Required field missing"
//             }
//         }
//     },
//     SecurityErrors = new securityErrorsType
//     {
//         SecurityError = new[]
//         {
//             new securityErrorType
//             {
//                 ErrorCode = "SEC-001",
//                 DescriptionText = "Unauthorized access"
//             }
//         }
//     },
//     SystemErrors = new systemErrorsType
//     {
//         SystemError = new[]
//         {
//             new systemErrorType
//             {
//                 ErrorCode = "SYS-001",
//                 DescriptionText = "Database connection failed"
//             }
//         }
//     }
// };

// string json3 = JsonSerializer.Serialize(enterpriseErrors, options);
// Console.WriteLine(json3);

// // Test 4: All enum values including sexTypeType.Item
// Console.WriteLine("\n--- Test 4: Enum Serialization ---");
// var enumTest = new
// {
//     AcknowledgementSuccess = acknowledgementType.SUCCESS,
//     SexItem = sexTypeType.Item,
//     SexFemale = sexTypeType.F,
//     SexMale = sexTypeType.M,
//     SexUnknown = sexTypeType.U,
//     SexIndeterminate = sexTypeType.X,
//     AssessmentIME = assessmentTypeType.IME,
//     AssessmentDHC = assessmentTypeType.DHC,
//     AssessmentESC = assessmentTypeType.ESC,
//     AssessmentPHC = assessmentTypeType.PHC
// };

// string json4 = JsonSerializer.Serialize(enumTest, options);
// Console.WriteLine(json4);

// // Test 5: cachedExpectedDeliveryDateType (inheritance)
// Console.WriteLine("\n--- Test 5: Inheritance (cachedExpectedDeliveryDateType) ---");
// var expectedDeliveryDate = new cachedExpectedDeliveryDateType
// {
//     UnstructuredYear = "2025",
//     UnstructuredMonth = "06",
//     UnstructuredDay = "15"
// };

// string json5 = JsonSerializer.Serialize(expectedDeliveryDate, options);
// Console.WriteLine(json5);

// var deserializedDate = JsonSerializer.Deserialize<cachedExpectedDeliveryDateType>(json5, options);
// Console.WriteLine($"Round-trip test: Year = {deserializedDate?.UnstructuredYear}");

// // Test 6: Nullable booleans
// Console.WriteLine("\n--- Test 6: Nullable Booleans ---");
// var contactWithNullable = new healthClientContactMsgType
// {
//     UsageCode = "TEST",
//     HealthPrimaryContactFlag = null,
//     CommentText = "Testing nullable bool"
// };

// string json6 = JsonSerializer.Serialize(contactWithNullable, options);
// Console.WriteLine(json6);

// var deserializedContact = JsonSerializer.Deserialize<healthClientContactMsgType>(json6, options);
// Console.WriteLine($"Round-trip test: HealthPrimaryContactFlag = {deserializedContact?.HealthPrimaryContactFlag?.ToString() ?? "null"}");

// // Test 7: healthFacialImageMsgType
// Console.WriteLine("\n--- Test 7: healthFacialImageMsgType ---");
// var facialImageAttached = new healthFacialImageMsgType
// {
//     HealthPhotoAttachedMsg = new healthPhotoAttachedMsgType
//     {
//         FaceImageFileName = "photo.jpg",
//         FaceImageFileContent = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
//     }
// };

// string json7a = JsonSerializer.Serialize(facialImageAttached, options);
// Console.WriteLine("Photo Attached:");
// Console.WriteLine(json7a);

// var facialImageNotAttached = new healthFacialImageMsgType
// {
//     HealthPhotoNotAttachedMsg = new healthPhotoNotAttachedMsgType
//     {
//         PhotoNotAttachedCode = "NO_PHOTO",
//         CommentText = "Photo will be provided later"
//     }
// };

// string json7b = JsonSerializer.Serialize(facialImageNotAttached, options);
// Console.WriteLine("\nPhoto Not Attached:");
// Console.WriteLine(json7b);

// // Test 8: Verify PascalCase property names in JSON output
// Console.WriteLine("\n--- Test 8: PascalCase Property Names Verification ---");
// var simpleTest = new healthCaseIdentifierType
// {
//     HealthCaseIdentifierValue = "TEST-123",
//     HealthCaseIdentifierType = "EXTERNAL"
// };

// string json8 = JsonSerializer.Serialize(simpleTest, options);
// Console.WriteLine(json8);
// Console.WriteLine($"Contains 'HealthCaseIdentifierValue': {json8.Contains("\"HealthCaseIdentifierValue\"")}");
// Console.WriteLine($"Contains 'HealthCaseIdentifierType': {json8.Contains("\"HealthCaseIdentifierType\"")}");

// // Test 9: Complex nested object with nullable assessment type
// Console.WriteLine("\n--- Test 9: Nullable Assessment Type ---");
// var caseIdWithNullAssessment = new healthCaseIdentifierMsgType
// {
//     HealthCaseIdentifier = new healthCaseIdentifierType
//     {
//         HealthCaseIdentifierValue = "HC-999",
//         HealthCaseIdentifierType = "TEMP"
//     },
//     AssessmentType = null
// };

// string json9 = JsonSerializer.Serialize(caseIdWithNullAssessment, options);
// Console.WriteLine(json9);

// var caseIdWithAssessment = new healthCaseIdentifierMsgType
// {
//     HealthCaseIdentifier = new healthCaseIdentifierType
//     {
//         HealthCaseIdentifierValue = "HC-999",
//         HealthCaseIdentifierType = "TEMP"
//     },
//     AssessmentType = assessmentTypeType.DHC
// };

// string json9b = JsonSerializer.Serialize(caseIdWithAssessment, options);
// Console.WriteLine(json9b);

// Console.WriteLine("\n=== All Tests Completed Successfully ===");
