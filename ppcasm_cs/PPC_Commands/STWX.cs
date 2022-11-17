﻿using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class STWX : PPC_Command
    {
        public STWX(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c00012e;
            if (args.Length != 3)
                throw new Exception("stwx <int_reg>, <int_reg>, <int_reg>");
            val |= GetIntRegister(args[0]) << 21;
            val |= GetIntRegister(args[1]) << 16;
            val |= GetIntRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "stwx";
    }
}