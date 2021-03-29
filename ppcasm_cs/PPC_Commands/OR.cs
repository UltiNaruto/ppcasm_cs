using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class OR : PPC_Command
    {
        public OR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c000378;
            if (args.Length != 3)
                throw new Exception("or <int_reg>, <int_reg>, <int_reg>");
            val += GetIntRegister(args[0]) << 21;
            val += GetIntRegister(args[1]) << 16;
            val += GetIntRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "or";
    }
}