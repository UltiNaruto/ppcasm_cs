using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FNMSUBS : PPC_Command
    {
        public FNMSUBS(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xec00003c;
            if (args.Length != 4)
                throw new Exception("fnmsubs <float_reg>, <float_reg>, <float_reg>, <float_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 16;
            val |= GetFloatRegister(args[2]) << 11;
            val |= GetFloatRegister(args[3]) << 6;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fnmsubs";
    }
}