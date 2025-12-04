using System.Text.Json;
using eMedicalService.LegacyJavaWcfService.RegisterHealthCase;
using Xunit;
using Xunit.Abstractions;

namespace wcftojsonpoco.Tests;

public class RegisterHealthCaseRequestTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };
    private readonly ITestOutputHelper _output;

    public RegisterHealthCaseRequestTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CompareOriginalAndReserializedJson()
    {
        // Arrange
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "registration.json");
        var originalJsonContent = File.ReadAllText(jsonPath);

        // Act - Deserialize the original JSON
        var deserialized = JsonSerializer.Deserialize<registerHealthCaseRequestType>(originalJsonContent, _options);

        // Re-serialize the object back to JSON
        var reserializedJson = JsonSerializer.Serialize(deserialized, _options);

        // Write both JSONs to files for comparison
        var outputDir = Path.Combine(AppContext.BaseDirectory, "JsonComparison");
        Directory.CreateDirectory(outputDir);

        var originalOutputPath = Path.Combine(outputDir, "original_registerHealthCase.json");
        var reserializedOutputPath = Path.Combine(outputDir, "reserialized_registerHealthCase.json");

        File.WriteAllText(originalOutputPath, originalJsonContent);
        File.WriteAllText(reserializedOutputPath, reserializedJson);

        // Parse both JSON strings to extract and compare ALL fields
        var originalJsonDoc = JsonDocument.Parse(originalJsonContent);
        var reserializedJsonDoc = JsonDocument.Parse(reserializedJson);

        var fieldComparisons = new List<(string FieldPath, string OriginalValue, string ReserializedValue, bool Match)>();
        var mismatches = new List<string>();

        // Extract all fields from both JSONs
        ExtractAllFieldsForComparison(originalJsonDoc.RootElement, reserializedJsonDoc.RootElement, "$", fieldComparisons, mismatches);

        // Build output content
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("=== COMPREHENSIVE JSON FIELD COMPARISON (RegisterHealthCaseRequest) ===\n");
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
        var comparisonOutputPath = Path.Combine(outputDir, "field_comparison_report_registerHealthCase.txt");
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

    private void ExtractAllFieldsForComparison(JsonElement original, JsonElement reserialized, string path, List<(string, string, string, bool)> fieldComparisons, List<string> mismatches)
    {
        switch (original.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in original.EnumerateObject())
                {
                    var newPath = string.IsNullOrEmpty(path) || path == "$" ? property.Name : $"{path}.{property.Name}";

                    if (reserialized.TryGetProperty(property.Name, out var reserializedProp))
                    {
                        ExtractAllFieldsForComparison(property.Value, reserializedProp, newPath, fieldComparisons, mismatches);
                    }
                    else
                    {
                        fieldComparisons.Add((newPath, property.Value.ToString(), "<MISSING>", false));
                        mismatches.Add($"Field missing in reserialized JSON: {newPath}");
                    }
                }
                break;

            case JsonValueKind.Array:
                var originalLength = original.GetArrayLength();
                var reserializedLength = reserialized.GetArrayLength();

                if (originalLength != reserializedLength)
                {
                    fieldComparisons.Add((path, $"Array[{originalLength}]", $"Array[{reserializedLength}]", false));
                    mismatches.Add($"Array length mismatch at {path}: {originalLength} vs {reserializedLength}");
                }
                else
                {
                    for (int i = 0; i < originalLength; i++)
                    {
                        var newPath = $"{path}[{i}]";
                        ExtractAllFieldsForComparison(original[i], reserialized[i], newPath, fieldComparisons, mismatches);
                    }
                }
                break;

            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Null:
                // Compare leaf node values
                var originalValue = original.ToString();
                var reserializedValue = reserialized.ToString();
                var valuesMatch = originalValue == reserializedValue;

                fieldComparisons.Add((path, originalValue, reserializedValue, valuesMatch));

                if (!valuesMatch)
                {
                    mismatches.Add($"Value mismatch at {path}: '{originalValue}' vs '{reserializedValue}'");
                }
                break;
        }
    }
}

