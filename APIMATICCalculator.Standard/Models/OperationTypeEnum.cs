using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Utilities;

namespace APIMATICCalculator.Standard.Models
{
    [JsonConverter(typeof(StringValuedEnumConverter))]
    public enum OperationTypeEnum
    {
        SUM, //Represents the sum operator
        SUBTRACT, //Represents the subtract operator
        MULTIPLY, //Represents the multiply operator
        DIVIDE, //Represents the divide operator
    }

    /// <summary>
    /// Helper for the enum type OperationTypeEnum
    /// </summary>
    public static class OperationTypeEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "SUM", "SUBTRACT", "MULTIPLY", "DIVIDE" };

        /// <summary>
        /// Converts a OperationTypeEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The OperationTypeEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(OperationTypeEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case OperationTypeEnum.SUM:
                case OperationTypeEnum.SUBTRACT:
                case OperationTypeEnum.MULTIPLY:
                case OperationTypeEnum.DIVIDE:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of OperationTypeEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of OperationTypeEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<OperationTypeEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into OperationTypeEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed OperationTypeEnum value</returns>
        public static OperationTypeEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type OperationTypeEnum", value));

            return (OperationTypeEnum) index;
        }
    }
} 