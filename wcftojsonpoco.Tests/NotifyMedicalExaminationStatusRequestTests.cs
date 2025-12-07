using System.Text.Json;
using eMedicalService.LegacyJavaWcfService.NotifyMedicalExaminationStatus;
using Xunit;
using Xunit.Abstractions;

namespace wcftojsonpoco.Tests;

public class NotifyMedicalExaminationStatusRequestTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };
    private readonly ITestOutputHelper _output;

    public NotifyMedicalExaminationStatusRequestTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CompareOriginalAndReserializedJson()
    {
        // Arrange
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "Domain.Contracts.Messages.notifyMedicalExaminationStatusRequestType.json");
        var originalJsonContent = File.ReadAllText(jsonPath);

        // Act - Deserialize the original JSON
        var deserialized = JsonSerializer.Deserialize<notifyMedicalExaminationStatusRequestType>(originalJsonContent, _options);

        // Re-serialize the object back to JSON
        var reserializedJson = JsonSerializer.Serialize(deserialized, _options);

        // Write both JSONs to files for comparison
        var outputDir = Path.Combine(AppContext.BaseDirectory, "JsonComparison");
        Directory.CreateDirectory(outputDir);

        var originalOutputPath = Path.Combine(outputDir, "original_notifyMedicalExaminationStatus.json");
        var reserializedOutputPath = Path.Combine(outputDir, "reserialized_notifyMedicalExaminationStatus.json");

        File.WriteAllText(originalOutputPath, originalJsonContent);
        File.WriteAllText(reserializedOutputPath, reserializedJson);

        // Parse both JSON strings to extract and compare ALL fields
        var originalJsonDoc = JsonDocument.Parse(originalJsonContent);
        var reserializedJsonDoc = JsonDocument.Parse(reserializedJson);

        var fieldComparisons = new List<(string FieldPath, string OriginalValue, string ReserializedValue, bool Match)>();
        var mismatches = new List<string>();

        // Extract all fields from both JSONs
        JsonTestHelper.ExtractAllFieldsForComparison(originalJsonDoc.RootElement, reserializedJsonDoc.RootElement, "$", fieldComparisons, mismatches);

        // Build output content
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("=== COMPREHENSIVE JSON FIELD COMPARISON (NotifyMedicalExaminationStatusRequest) ===\n");
        sb.AppendLine($"Total fields compared: {fieldComparisons.Count}");
        sb.AppendLine($"Matching fields: {fieldComparisons.Count(f => f.Match)}");
        sb.AppendLine($"Mismatching fields: {fieldComparisons.Count(f => !f.Match)}");
        sb.AppendLine("");

        if (fieldComparisons.Any(f => !f.Match))
        {
            sb.AppendLine("=== MISMATCHED FIELDS ===");
            foreach (var mismatch in fieldComparisons.Where(f => !f.Match))
            {
                sb.AppendLine($"Field: {mismatch.FieldPath}");
                sb.AppendLine($"  Original:     {mismatch.OriginalValue}");
                sb.AppendLine($"  Reserialized: {mismatch.ReserializedValue}");
                sb.AppendLine("");
            }
        }

        sb.AppendLine("=== ALL FIELD DETAILS ===");
        foreach (var comparison in fieldComparisons)
        {
            var status = comparison.Match ? "✓ MATCH" : "❌ MISMATCH";
            sb.AppendLine($"{status} | {comparison.FieldPath}");
            sb.AppendLine($"       Original:     {comparison.OriginalValue}");
            sb.AppendLine($"       Reserialized: {comparison.ReserializedValue}");
        }

        // Write to file
        var comparisonOutputPath = Path.Combine(outputDir, "field_comparison_report_notifyMedicalExaminationStatus.txt");
        File.WriteAllText(comparisonOutputPath, sb.ToString());

        // Output to console for terminal visibility
        Console.WriteLine("\n" + sb.ToString());
        Console.WriteLine($"Full report written to: {comparisonOutputPath}\n");

        // Output to test output helper
        _output.WriteLine(sb.ToString());
        _output.WriteLine($"Full report written to: {comparisonOutputPath}");

        // Assert - All fields must match
        Assert.True(fieldComparisons.Count > 0, "No fields were found to compare");
        Assert.Empty(mismatches);
    }
}

