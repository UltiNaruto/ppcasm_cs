﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LHAU : PPC_Command
    {
        public LHAU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            KeyValuePair<Int32, UInt32> idx_reg = default(KeyValuePair<Int32, UInt32>);
            UInt32 val = 0xac000000;
            if (args.Length != 2)
                throw new Exception("lhau <int_reg>, <idx_reg>");
            val |= GetIntRegister(args[0]) << 21;
            idx_reg = GetIndexedRegister(args[1]);
            val = (UInt32)(val | (UInt16)idx_reg.Key);
            val |= idx_reg.Value << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "lhau";
    }
}