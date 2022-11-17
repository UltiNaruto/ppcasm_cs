using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LWZX : PPC_Command
    {
        public LWZX(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c00002e;
            if (args.Length != 3)
                throw new Exception("lwzx <int_reg>, <int_reg>, <int_reg>");
            val |= GetIntRegister(args[0]) << 29;
            val |= GetIntRegister(args[1]) << 24;
            val |= GetIntRegister(args[2]) << 20;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "lwzx";
    }
}