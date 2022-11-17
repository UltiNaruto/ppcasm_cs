using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class NOR : PPC_Command
    {
        public NOR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c0000f8;
            if (args.Length != 3)
                throw new Exception("nor <int_reg>, <int_reg>, <int_reg>");
            val |= GetIntRegister(args[1]) << 21;
            val |= GetIntRegister(args[0]) << 16;
            val |= GetIntRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "nor";
    }
}