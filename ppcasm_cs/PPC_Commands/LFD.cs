using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LFD : PPC_Command
    {
        public LFD(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<Int32, UInt32> idx_reg = default(KeyValuePair<Int32, UInt32>);
            UInt32 val = 0xC8000000;
            if (args.Length != 2)
                throw new Exception("lfd <float_reg>, <idx_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            val = (UInt32)(val | (UInt16)idx_reg.Key);
            val |= idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "lfd";
    }
}