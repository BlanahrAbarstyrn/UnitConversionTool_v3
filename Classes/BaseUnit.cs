using System.Collections.Generic;

namespace UnitConversionTool.Classes;
public class BaseUnit
{
    private readonly Dictionary<string, Dictionary<string, double>> _conversionDictionary;
    
    public BaseUnit()
    {
        // Nested Dictionary: string -> (string -> double)
        _conversionDictionary = new Dictionary<string, Dictionary<string, double>>
        {
            ["Architectural feet/inches"] = new Dictionary<string, double>
            {
                // base units inches
                { "inches", 1.0 },
                { "feet", 0.08333333 },
                { "millimeters", 25.4 },
                { "centimeters", 2.54 },
                { "meters", 0.0254 }
            },
            ["Decimal feet"] = new Dictionary<string, double>
            {
                // base units feet
                { "inches", 12.0 },
                { "feet", 1.0 },
                { "millimeters", 304.8 },
                { "centimeters", 30.48 },
                { "meters", 0.3048 }
            },
            ["Decimal inches"] = new Dictionary<string, double>
            {
                // base units inches
                { "inches", 1.0 },
                { "feet", 0.08333333 },
                { "millimeters", 25.4 },
                { "centimeters", 2.54 },
                { "meters", 0.0254 }
            },
            ["Millimeters"] = new Dictionary<string, double>
            {
                // base units millimeters
                { "inches", 0.0393700787 },
                { "feet", 0.0032808399 },
                { "millimeters", 1.0 },
                { "centimeters", 0.1 },
                { "meters", 0.001 }
            },
            ["Centimeters"] = new Dictionary<string, double>
            {
                // base units centimeters
                { "inches", 0.393700787 },
                { "feet", 0.032808399 },
                { "millimeters", 10.0 },
                { "centimeters", 1.0 },
                { "meters", 0.01 }
            },
            ["Meters"] = new Dictionary<string, double>
            {
                // base units meters
                { "inches", 39.37007874 },
                { "feet", 3.280839895 },
                { "millimeters", 1000.0 },
                { "centimeters", 100.0 },
                { "meters", 1.0 }
            },
            ["Pounds"] = new Dictionary<string, double>
            {
                // base units pounds
                { "pounds", 1.0 },
                { "kilograms", 0.45359237 }
            },
            ["Kilograms"] = new Dictionary<string, double>
            {
                // base units kilograms
                { "pounds", 2.2046226218 },
                { "kilograms", 1.0 }
            },
            ["PSI"] = new Dictionary<string, double>
            {
                // base units PSI
                { "psi", 1.0 },
                { "mbar", 68.9475728 }
            },
            ["MBar"] = new Dictionary<string, double>
            {
                // base units mbar
                { "psi", 0.014503773800721815 },
                { "mbar", 1.0 }
            },
            ["Barrels/hour"] = new Dictionary<string, double>
            {
                // base units barrels per hour
                { "barrels per hour", 1.0 },
                { "cubic meters per hour", 0.15898729560000074 }
            },
            ["Cubic meters/hour"] = new Dictionary<string, double>
            {
                //base units cubic meters per hour
                { "barrels per hour", 6.2898107438466 },
                { "cubic meters per hour", 1.0 }
            },
            ["Pound per foot"] = new Dictionary<string, double>
            {
                // base units pound per foot
                { "pound per foot" , 1.0 },
                { "newton per meter", 14.593902887139143 }
            },
            ["Newton per meter"] = new Dictionary<string, double>
            {
                // base units newton per meter
                { "pound per foot" , 0.068521766091869 },
                { "newton per meter", 1.0 }
            }
        };
    }

    public IReadOnlyDictionary<string, double> GetCategoryUnits(string category)
    {
        if (_conversionDictionary.TryGetValue(category, out var innerDict))
        {
            return innerDict;
        }
        // if category doesn't exist
        return null;
    }
}
