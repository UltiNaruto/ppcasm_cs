using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class STBU : PPC_Command
    {
        public STBU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<UInt32, UInt32> idx_reg = default(KeyValuePair<UInt32, UInt32>);
            UInt32 val = 0x9c000000;
            if (args.Length != 2)
                throw new Exception("stbu <int_reg>, <idx_reg>");
            val += GetIntRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            val += idx_reg.Key;
            val += idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "stbu";
    }
}