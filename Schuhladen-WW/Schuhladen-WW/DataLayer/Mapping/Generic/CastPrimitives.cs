using System;
using System.Globalization;
using System.Reflection;

namespace Schuhladen_WW.Mapping.Generic
{
    public static class CastPrimitives
    {
        public static PropertyInfo CastToString (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            _PropertyInfo.SetValue(obj_BaseClass, obj_Value.ToString().Trim(), null);
            return _PropertyInfo;
        }

        public static PropertyInfo CastToBool (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            if (obj_Value == null)
            {
                _PropertyInfo.SetValue(obj_BaseClass, null, null);
            }
            else
            {
                _PropertyInfo.SetValue(obj_BaseClass, ParseBoolean(obj_Value.ToString()), null);
            }
            return _PropertyInfo;
        }

        public static PropertyInfo CastToLong (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            _PropertyInfo.SetValue(obj_BaseClass, long.Parse(obj_Value.ToString()), null);
            return _PropertyInfo;
        }

        public static PropertyInfo CastToInt (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            if (obj_Value == null)
            {
                _PropertyInfo.SetValue(obj_BaseClass, null, null);
            }
            else
            {
                _PropertyInfo.SetValue(obj_BaseClass, int.Parse(obj_Value.ToString()), null);
            }
            return _PropertyInfo;
        }

        public static PropertyInfo CastToDecimal (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            _PropertyInfo.SetValue(obj_BaseClass, double.Parse(obj_Value.ToString()), null);
            return _PropertyInfo;
        }

        public static PropertyInfo CastToDouble (PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            double dbl_Number;
            bool bool_isValid = double.TryParse(obj_Value.ToString(), out dbl_Number);
            if (bool_isValid)
            {
                _PropertyInfo.SetValue(obj_BaseClass, double.Parse(obj_Value.ToString()), null);
            }
            return _PropertyInfo;
        }

        public static PropertyInfo CastToDateTime(PropertyInfo _PropertyInfo, object obj_BaseClass, object obj_Value)
        {
            DateTime dt_DateTime;
            bool isValid = DateTime.TryParse(obj_BaseClass.ToString(), out dt_DateTime);
            if (isValid)
            {
                _PropertyInfo.SetValue(obj_BaseClass, dt_DateTime, null);
            }
            else
            {
                isValid = DateTime.TryParseExact(obj_BaseClass.ToString(), "ddMMyyyy", new CultureInfo("de-DE"), DateTimeStyles.AssumeLocal, out dt_DateTime);
                if (isValid)
                {
                    _PropertyInfo.SetValue(obj_BaseClass, dt_DateTime, null);
                }
            }
            return _PropertyInfo;
        }

        public static bool ParseBoolean(object obj_Value)
        {
            if (obj_Value == null || obj_Value == DBNull.Value) return false;

            switch (obj_Value.ToString().ToLowerInvariant())
            {
                case "1":
                case "y":
                case "yes":
                case "true":
                    return true;

                case "0":
                case "n":
                case "no":
                case "false":
                default:
                    return false;
            }
        }
    }
}
