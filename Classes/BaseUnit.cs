using Godot;
using System.Collections.Generic;

namespace UnitConversionTool.Classes;
public partial class BaseUnit : Node
{
    public static void ConversionDictionary()
    {
        // Nested Dictionary: string -> (string -> double)
        var conversionDictionary = new Dictionary<string, Dictionary<string, double>>
        {
            ["Architectural feet/inches"] = new Dictionary<string, double>
            {
                // base units inches
                { "inches", 1.0 },
                { "feet", 0.8333333 },
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
                { "feet", 0.8333333 },
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
            ["Mbar"] = new Dictionary<string, double>
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
            }
        };
        
        /* TODO:
         * need to get user input from LineEditUserInput
         * need to get user input from length, weight, pressure, or flow Option Buttons
         * check that selection is in the dictionary
         * set the target_base to the Option Button Selection
         * for key, value in target_base.items();
         *      converted_output[key] = round(value * from_units, ##number of decimal places to include##)
         * return converted_output - meaning it needs to be sent to TEoutput in the user interface
         *
         * TODO:
         * additional check needed for Architectural input to run input through parser
         * all other input needs to be checked that it adheres integer/decimal format
         *
         * TODO:
         * error messages for improperly formatted input also can be sent to TEoutput
         *
         * TODO:
         * try to set up processing to recognize enter from keyboard or pressing the Submit button
         * if user is running new input without using the clear button first, program needs to
         * automatically clear TEoutput before inserting new output
         * 
         */
    }
}
