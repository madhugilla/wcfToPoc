using System.Text.Json;

namespace wcftojsonpoco.Tests;

/// <summary>
/// Shared helper class for JSON comparison tests
/// </summary>
public static class JsonTestHelper
{
    /// <summary>
    /// Extracts and compares all fields from two JSON elements recursively
    /// </summary>
    public static void ExtractAllFieldsForComparison(
        JsonElement original, 
        JsonElement reserialized, 
        string path, 
        List<(string FieldPath, string OriginalValue, string ReserializedValue, bool Match)> fieldComparisons, 
        List<string> mismatches)
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

    /// <summary>
    /// Compares JSON elements recursively and tracks matches and mismatches
    /// </summary>
    public static void CompareJsonElements(
        JsonElement original, 
        JsonElement reserialized, 
        string path, 
        List<string> mismatches, 
        List<string> matches)
    {
        switch (original.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in original.EnumerateObject())
                {
                    var newPath = string.IsNullOrEmpty(path) ? property.Name : $"{path}.{property.Name}";

                    if (reserialized.TryGetProperty(property.Name, out var reserializedProp))
                    {
                        CompareJsonElements(property.Value, reserializedProp, newPath, mismatches, matches);
                    }
                    else
                    {
                        mismatches.Add($"❌ {newPath}: MISSING in reserialized JSON");
                    }
                }
                break;

            case JsonValueKind.Array:
                var originalLength = original.GetArrayLength();
                var reserializedLength = reserialized.GetArrayLength();

                if (originalLength != reserializedLength)
                {
                    mismatches.Add($"❌ {path}: Array length mismatch - Original: {originalLength}, Reserialized: {reserializedLength}");
                }
                else
                {
                    for (int i = 0; i < originalLength; i++)
                    {
                        var newPath = $"{path}[{i}]";
                        CompareJsonElements(original[i], reserialized[i], newPath, mismatches, matches);
                    }
                }
                break;

            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Null:
                // Compare values
                var originalValue = original.ToString();
                var reserializedValue = reserialized.ToString();

                if (originalValue == reserializedValue)
                {
                    matches.Add($"{path}: {originalValue}");
                }
                else
                {
                    mismatches.Add($"❌ {path}: Value mismatch\n   Original:     {originalValue}\n   Reserialized: {reserializedValue}");
                }
                break;
        }
    }

    /// <summary>
    /// Truncates field display strings for better readability
    /// </summary>
    public static string TruncateFieldForDisplay(string field, int maxChars = 10)
    {
        if (string.IsNullOrEmpty(field))
            return field;

        // Split by colon to separate path from value
        var parts = field.Split(new[] { ": " }, StringSplitOptions.None);

        if (parts.Length == 2)
        {
            var path = parts[0];
            var value = parts[1];

            // Truncate path if longer than maxChars
            var truncatedPath = path.Length > maxChars ? path.Substring(0, maxChars) + "..." : path;

            // Truncate value if longer than maxChars
            var truncatedValue = value.Length > maxChars ? value.Substring(0, maxChars) + "..." : value;

            return $"{truncatedPath}: {truncatedValue}";
        }

        // For multi-line content (like mismatches with Original/Reserialized)
        var truncated = field.Length > maxChars * 2 ? field.Substring(0, maxChars * 2) + "..." : field;
        return truncated;
    }
}
