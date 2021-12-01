using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ppcasm_cs
{
    class PPC_Command : PPC_Instruction
    {
        protected PPC_Command(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
        }

        protected bool IsIntRegister(String arg)
        {
            UInt32 register_num = UInt32.MaxValue;
            if (arg[0] != 'r')
                return false;
            if (!UInt32.TryParse(arg.Substring(1), out register_num))
                return false;
            if (register_num > 31)
                return false;
            return true;
        }

        protected bool IsFloatRegister(String arg)
        {
            UInt32 register_num = UInt32.MaxValue;
            if (arg[0] != 'f')
                return false;
            if (!UInt32.TryParse(arg.Substring(1), out register_num))
                return false;
            if (register_num > 31)
                return false;
            return true;
        }

        protected bool IsConditionRegister(String arg)
        {
            UInt32 register_num = UInt32.MaxValue;
            if (!arg.StartsWith("cr"))
                return false;
            if (!UInt32.TryParse(arg.Substring(2), out register_num))
                return false;
            if (register_num > 7)
                return false;
            return true;
        }

        protected bool IsSignedImm(String arg, int bits)
        {
            Int32 value = Int32.MinValue;
            try
            {
                if (arg.StartsWith("-0x"))
                    value = Convert.ToInt32(arg.Substring(1), 16) * -1;
                else if (arg.StartsWith("0x"))
                    value = Convert.ToInt32(arg, 16);
                else
                    value = Convert.ToInt32(arg);
                if (value < -1 * Math.Pow(2, bits - 1) || value > Math.Pow(2, bits - 1) - 1)
                    return false;
                return true;
            }
            catch { return false; }
        }

        protected bool IsUnsignedImm(String arg, int bits)
        {
            UInt32 value = UInt32.MinValue;
            try
            {
                if (arg.Contains("0x"))
                    value = Convert.ToUInt32(arg, 16);
                else
                    value = Convert.ToUInt32(arg);
                if (value > Math.Pow(2, bits) - 1)
                    return false;
                return true;
            }
            catch { return false; }
        }

        protected bool IsIndexedRegister(String arg)
        {
            String[] values = Regex.Split(arg, "^([-]{0,1}0x[0-9|a-f]{1,4})\\((r[1-2][0-9]|r[0-9]|r3[0-1])\\)$")
                                   .Where(s => s != "")
                                   .ToArray();
            if (values == null || values.Length != 2)
                return false;
            if (!IsSignedImm(values[0], 16))
                return false;
            if (!IsIntRegister(values[1]))
                return false;
            return true;
        }

        protected UInt32 GetIntRegister(String arg)
        {
            if (!IsIntRegister(arg))
                throw new Exception("GetIntRegister() has received an invalid input");
            return UInt32.Parse(arg.Substring(1));
        }

        protected UInt32 GetFloatRegister(String arg)
        {
            if (!IsFloatRegister(arg))
                throw new Exception("GetFloatRegister() has received an invalid input");
            return UInt32.Parse(arg.Substring(1));
        }

        protected UInt32 GetConditionRegister(String arg)
        {
            if (!IsConditionRegister(arg))
                throw new Exception("GetConditionRegister() has received an invalid input");
            return UInt32.Parse(arg.Substring(2));
        }

        protected Int32 GetSignedImm(String arg, int bits)
        {
            if (!IsSignedImm(arg, bits))
                throw new Exception("GetSignedImm() has received an invalid input");
            if (arg.Contains("0x"))
                return Convert.ToInt32(arg, 16);
            else
                return Convert.ToInt32(arg);
        }

        protected UInt32 GetUnsignedImm(String arg, int bits)
        {
            if (!IsUnsignedImm(arg, bits))
                throw new Exception("GetUnsignedImm() has received an invalid input");
            if(arg.Contains("0x"))
                return Convert.ToUInt32(arg, 16);
            else
                return Convert.ToUInt32(arg);
        }

        protected KeyValuePair<Int16, UInt32> GetIndexedRegister(String arg)
        {
            if (!IsIndexedRegister(arg))
                throw new Exception("GetIndexedRegister() has received an invalid input");
            String[] values = Regex.Split(arg, "^([-]{0,1}0x[0-9|a-f]{1,4})\\(r([1-2][0-9]|[0-9]|3[0-1])\\)$")
                                   .Where(s => s != "")
                                   .ToArray();

            Int16 imm16 = 0;
            if (values[0][0] == '-')
            {
                imm16 = Convert.ToInt16(values[0].Substring(1), 16);
                imm16 *= -1;
            }
            else
                imm16 = Convert.ToInt16(values[0], 16);

            return new KeyValuePair<Int16, UInt32>(imm16, Convert.ToUInt32(values[1]));
        }
    }
}
