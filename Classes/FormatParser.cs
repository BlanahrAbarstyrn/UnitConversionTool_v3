using Godot;
using System;
using System.Text.RegularExpressions;

namespace UnitConversionTool.Classes;
public partial class FormatParser : Node
{
    public static void Parse()
    {
        var pattern = new Regex(@"
            (?: (\d+) ' \s* -? )?     # Optional feet
            (?: (\d+) \s* -? )?       # Optional inches
            (?: (\d+) / (\d+) )?      # Optional fraction
            \s* ""?                   # Optional trailing inch marks
        ",
            RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
        string[] tests =
        {
            "5' 8 1/2\"",
            "6' 0\"",
            "5'8\"",
            "8\"",
            "1/2\""
        };
        foreach (var input in tests)
        {
            double totalInches = ParseMeasurementToInches(input, pattern);
            Console.WriteLine($"{input} => {totalInches} inches");
        }
    }
    /*
     * Summary:
     * Parses a measurement string like 5' 8 1/2" into total inches.
     */
    static double ParseMeasurementToInches(string input, Regex pattern)
    {
        var match = pattern.Match(input);
        if (!match.Success) return double.NaN;
        
        // Safe parsing with defaults
        int feet = ParseIntSafe(match.Groups[1].Value, 0);
        int inches = ParseIntSafe(match.Groups[2].Value, 0);
        int numerator = ParseIntSafe(match.Groups[3].Value, 0);
        int denominator = ParseIntSafe(match.Groups[4].Value, 1);
        
        return (feet * 12) + inches + (double)numerator / denominator;
    }
    /*
     * Summary:
     * Parses and integer safely, returning a default value if parsing fails.
     */
    static int ParseIntSafe(string value, int defaultValue)
    {
        return int.TryParse(value, out int result) ? result : defaultValue;
    }
}
