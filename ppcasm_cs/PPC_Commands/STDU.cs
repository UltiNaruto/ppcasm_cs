using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class STDU : PPC_Command
    {
        public STDU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<Int32, UInt32> idx_reg = default(KeyValuePair<Int32, UInt32>);
            UInt32 val = 0xdc000000;
            if (args.Length != 2)
                throw new Exception("stdu <float_reg>, <idx_reg>");
            val += GetFloatRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            val = (UInt32)((Int32)val + idx_reg.Key);
            val += idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "stdu";
    }
}