using System;
using System.Globalization;

namespace ppcasm_cs
{
    class Utils
    {
        public static float FromStringToFloat32(String val)
        {
            return Convert.ToSingle(val.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        public static double FromStringToFloat64(String val)
        {
            return Convert.ToDouble(val.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        public static UInt32 FromStringToUInt32(String val)
        {
            if (val.StartsWith("0x"))
                return Convert.ToUInt32(val, 16);
            else
                return Convert.ToUInt32(val);
        }
    }
}
