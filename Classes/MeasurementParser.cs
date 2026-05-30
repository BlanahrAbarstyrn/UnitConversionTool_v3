using System;
using System.Text.RegularExpressions;
using UnitConversionTool.Globals;
using Godot;

namespace UnitConversionTool.Classes;

public static class MeasurementParser
{
    // Regex breakdown:
    // ^(?<sign>-)?                    -> Optional negative sign
    // (?:(?<feet>\d+)\s*['’′]\s*)??   -> Optional feet (lazy match to not steal from inches)
    // (?:(?<inches>\d+))??            -> Optional whole inches
    // \s*(?<fraction>(?<num>\d+)\/(?<den>\d+))? -> Optional fraction
    // \s*(?:"|”|″|in)?$               -> Optional ending inch symbols
    private static readonly Regex MeasurementRegex = new Regex(
        @"^(?<sign>-)?(?:(?<feet>\d+)\s*['’′]\s*)??(?:(?<inches>\d+))??\s*(?<fraction>(?<num>\d+)\/(?<den>\d+))?\s*(?:""|”|″|in)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );
    
    public static void ParseToInches(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            GlobalValues.Instance.HasError = true;
            GlobalValues.Instance.ValidDouble = 0.0;
            return;
        }
        
        // Clean up common architectural noise like hyphens (e.g., 5'-6" -> 5' 6")
        string sanitized = input.Trim().Replace("-", " ");

        Match match = MeasurementRegex.Match(sanitized);
        if (!match.Success)
        {
            GlobalValues.Instance.HasError = true;
            GlobalValues.Instance.ValidDouble = 0.0;
            return;
        }
        
        // Verify we actually captured at least one numeric component
        if (!match.Groups["feet"].Success && !match.Groups["inches"].Success && !match.Groups["fraction"].Success)
        {
            GlobalValues.Instance.HasError = true;
            GlobalValues.Instance.ValidDouble = 0.0;
            return;
        }

        float feet = match.Groups["feet"].Success ? float.Parse(match.Groups["feet"].Value) : 0f;
        float inches = match.Groups["inches"].Success ? float.Parse(match.Groups["inches"].Value) : 0f;

        if (match.Groups["fraction"].Success)
        {
            float num = float.Parse(match.Groups["num"].Value);
            float den = float.Parse(match.Groups["den"].Value);
            
            if (den == 0)
            {
                GlobalValues.Instance.HasError = true;
                GlobalValues.Instance.ValidDouble = 0.0;
                return; // Prevent division by zero
            }
            inches += num / den;
        }
        
        float totalInches = (feet * 12f) + inches;

        // Apply negative sign if present
        if (match.Groups["sign"].Success)
        {
            totalInches *= -1f;
        }
        
        GlobalValues.Instance.HasError = false;
        GlobalValues.Instance.ValidDouble = totalInches;
    }
}

