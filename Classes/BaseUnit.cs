using System;
using System.Collections.Generic;

namespace UnitConversionTool.Classes;
public class BaseUnit
{
    private readonly Dictionary<string, Dictionary<string, decimal>> _conversionDictionary;
    
    public BaseUnit()
    {
        // Nested Dictionary: string -> (string -> double)
        _conversionDictionary = new Dictionary<string, Dictionary<string, decimal>>
        {
            ["Architectural feet/inches"] = new Dictionary<string, decimal>
            {
                // base units inches
                { "inches", 1.0m },
                { "feet", 0.08333333m },
                { "millimeters", 25.4m },
                { "centimeters", 2.54m },
                { "meters", 0.0254m }
            },
            ["Decimal feet"] = new Dictionary<string, decimal>
            {
                // base units feet
                { "inches", 12.0m },
                { "feet", 1.0m },
                { "millimeters", 304.8m },
                { "centimeters", 30.48m },
                { "meters", 0.3048m }
            },
            ["Decimal inches"] = new Dictionary<string, decimal>
            {
                // base units inches
                { "inches", 1.0m },
                { "feet", 0.08333333m },
                { "millimeters", 25.4m },
                { "centimeters", 2.54m },
                { "meters", 0.0254m }
            },
            ["Millimeters"] = new Dictionary<string, decimal>
            {
                // base units millimeters
                { "inches", 0.0393700787m },
                { "feet", 0.0032808399m },
                { "millimeters", 1.0m },
                { "centimeters", 0.1m },
                { "meters", 0.001m }
            },
            ["Centimeters"] = new Dictionary<string, decimal>
            {
                // base units centimeters
                { "inches", 0.393700787m },
                { "feet", 0.032808399m },
                { "millimeters", 10.0m },
                { "centimeters", 1.0m },
                { "meters", 0.01m }
            },
            ["Meters"] = new Dictionary<string, decimal>
            {
                // base units meters
                { "inches", 39.37007874m },
                { "feet", 3.280839895m },
                { "millimeters", 1000.0m },
                { "centimeters", 100.0m },
                { "meters", 1.0m }
            },
            ["Pounds"] = new Dictionary<string, decimal>
            {
                // base units pounds
                { "pounds", 1.0m },
                { "kilograms", 0.45359237m }
            },
            ["Kilograms"] = new Dictionary<string, decimal>
            {
                // base units kilograms
                { "pounds", 2.2046226218m },
                { "kilograms", 1.0m }
            },
            ["PSI"] = new Dictionary<string, decimal>
            {
                // base units PSI
                { "psi", 1.0m },
                { "mbar", 68.9475728m }
            },
            ["Mbar"] = new Dictionary<string, decimal>
            {
                // base units mbar
                { "psi", 0.014503773800721815m },
                { "mbar", 1.0m }
            },
            ["Barrels/hour"] = new Dictionary<string, decimal>
            {
                // base units barrels per hour
                { "barrels per hour", 1.0m },
                { "cubic meters per hour", 0.15898729560000074m }
            },
            ["Cubic meters/hour"] = new Dictionary<string, decimal>
            {
                //base units cubic meters per hour
                { "barrels per hour", 6.2898107438466m },
                { "cubic meters per hour", 1.0m }
            }
        };
    }

    public IReadOnlyDictionary<string, decimal> GetCategoryUnits(string category)
    {
        if (_conversionDictionary.TryGetValue(category, out var innerDict))
        {
            return innerDict;
        }
        // if category doesn't exist
        return null;
    }
}
