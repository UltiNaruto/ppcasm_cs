using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class SUBFIC : PPC_Command
    {
        public SUBFIC(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x20000000;
            if (args.Length != 3)
                throw new Exception("subfic <float_reg>, <float_reg>, <imm15>");
            val += GetFloatRegister(args[0]) << 21;
            val += GetFloatRegister(args[1]) << 16;
            val += GetUnsignedImm(args[2], 15);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "subfic";
    }
}