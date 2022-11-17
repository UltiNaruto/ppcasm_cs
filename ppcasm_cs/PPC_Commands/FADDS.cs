using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FADDS : PPC_Command
    {
        public FADDS(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xec00002a;
            if (args.Length != 3)
                throw new Exception("fadds <float_reg>, <float_reg>, <float_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 16;
            val |= GetFloatRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fadds";
    }
}