using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class STFSU : PPC_Command
    {
        public STFSU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<UInt32, UInt32> idx_reg = default(KeyValuePair<UInt32, UInt32>);
            UInt32 val = 0xd4000000;
            if (args.Length != 2)
                throw new Exception("stfsu <float_reg>, <idx_reg>");
            val += GetFloatRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            val += idx_reg.Key;
            val += idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "stfsu";
    }
}