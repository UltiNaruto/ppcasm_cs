using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FMSUBS : PPC_Command
    {
        public FMSUBS(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xec000038;
            if (args.Length != 4)
                throw new Exception("fmsubs <float_reg>, <float_reg>, <float_reg>, <float_reg>");
            val += GetFloatRegister(args[0]) << 21;
            val += GetFloatRegister(args[1]) << 16;
            val += GetFloatRegister(args[2]) << 11;
            val += GetFloatRegister(args[3]) << 6;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fmsubs";
    }
}