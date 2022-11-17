using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LFSX : PPC_Command
    {
        public LFSX(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c00042e;
            if (args.Length != 3)
                throw new Exception("lfsx <float_reg>, <int_reg>, <int_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetIntRegister(args[1]) << 16;
            val |= GetIntRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "lfsx";
    }
}