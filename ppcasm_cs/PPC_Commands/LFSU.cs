using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LFSU : PPC_Command
    {
        public LFSU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<Int16, UInt32> idx_reg = default(KeyValuePair<Int16, UInt32>);
            UInt32 val = 0xc4000000;
            if (args.Length != 2)
                throw new Exception("lfsu <float_reg>, <idx_reg>");
            val += GetFloatRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            if (idx_reg.Key < 0)
                val |= (1 << 16);
            val = (UInt32)((Int32)val + idx_reg.Key);
            val += idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "lfsu";
    }
}