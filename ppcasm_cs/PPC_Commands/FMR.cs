using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FMR : PPC_Command
    {
        public FMR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xfc000090;
            if (args.Length != 2)
                throw new Exception("fmr <float_reg>, <float_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fmr";
    }
}