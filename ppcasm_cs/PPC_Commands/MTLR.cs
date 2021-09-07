using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class MTLR : PPC_Command
    {
        public MTLR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c0803a6;
            if (args.Length != 1)
                throw new Exception("mtlr <int_reg>");
            val += GetIntRegister(args[0]) << 21;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "mtlr";
    }
}