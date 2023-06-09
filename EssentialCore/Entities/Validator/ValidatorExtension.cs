using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Validator
{
    public static class ValidatorExtension
    {
        public static bool Validate(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool Validate(this DateTime? value)
        {
            return value.HasValue;
        }

        public static bool Validate(this IEntityBase entityBase)
        {
            return entityBase.Validate();
        }

        public static bool Validate(this bool boolValue)
        {
            return boolValue == true || boolValue == false;
        }

        public static bool Validate(this bool? boolValue)
        {
            return boolValue.HasValue;
        }

        public static bool Validate(this int? intValue)
        {
            return intValue.Validate(0);
        }

        public static bool Validate(this int? intValue, int minValue)
        {
            return intValue.Validate(minValue, int.MaxValue);
        }

        public static bool Validate(this int? intValue, int minValue, int maxValue)
        {
            return intValue.HasValue && intValue >= minValue && intValue <= maxValue;
        }

        public static bool Validate(this float? floatValue)
        {
            return floatValue.HasValue;
        }

        public static bool Validate(this decimal? decimalValue)
        {
            return decimalValue.HasValue;
        }

        public static bool Validate(this decimal? decimalValue, decimal minValue)
        {
            return decimalValue.Validate(minValue, decimal.MaxValue);
        }

        public static bool Validate(this decimal? value, decimal minValue, decimal maxValue)
        {
            return value.HasValue && value >= minValue && value <= maxValue;
        }
    }
}
