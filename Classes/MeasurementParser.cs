using System;
using System.Text.RegularExpressions;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Classes;

public static class MeasurementParser
{
    // Keep this field at the class level so it compiles only once
    private static readonly Regex MeasurementRegex = new Regex(@"^
        (?: (?<feet>\d+) \s* ' \s* -? \s* )?      
        (?: (?<inches>\d+) \s* ""? \s* -? \s* )?   
        (?: (?<num>\d+) \s* / \s* (?<den>\d+) \s* ""? )? 
        $", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    public static void ParseToInches(string input)
    {
        string cleanedInput = input.Trim();
        Match match = MeasurementRegex.Match(cleanedInput);

        // Return 0 or throw an exception if the input is empty or invalid
        if (!match.Success || string.IsNullOrEmpty(cleanedInput))
        {
            GlobalValues.Instance.HasError = true;
            GlobalValues.Instance.ValidDecimal = 0;
            return;
        }

        decimal feet   = string.IsNullOrEmpty(match.Groups["feet"].Value)   ? 0 : decimal.Parse(match.Groups["feet"].Value);
        decimal inches = string.IsNullOrEmpty(match.Groups["inches"].Value) ? 0 : decimal.Parse(match.Groups["inches"].Value);
        decimal num    = string.IsNullOrEmpty(match.Groups["num"].Value)    ? 0 : decimal.Parse(match.Groups["num"].Value);
        decimal den    = string.IsNullOrEmpty(match.Groups["den"].Value)    ? 1 : decimal.Parse(match.Groups["den"].Value);
        
        GlobalValues.Instance.HasError = false;
        GlobalValues.Instance.ValidDecimal = (feet * 12m) + inches + (num / den);
    }
}

