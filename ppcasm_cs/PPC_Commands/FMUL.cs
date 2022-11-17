using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FMUL : PPC_Command
    {
        public FMUL(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xfc000032;
            if (args.Length != 3)
                throw new Exception("fmul <float_reg>, <float_reg>, <float_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 16;
            val |= GetFloatRegister(args[2]) << 6;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fmul";
    }
}