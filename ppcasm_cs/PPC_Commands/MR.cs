using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class MR : PPC_Command
    {
        public MR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c000378;
            if (args.Length != 2)
                throw new Exception("mr <int_reg>, <int_reg>");
            val |= GetIntRegister(args[1]) << 21;
            val |= GetIntRegister(args[0]) << 16;
            val |= GetIntRegister(args[1]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "mr";
    }
}