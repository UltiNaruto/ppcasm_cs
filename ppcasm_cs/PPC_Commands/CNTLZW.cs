using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class CNTLZW : PPC_Command
    {
        public CNTLZW(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c000034;
            if (args.Length != 2)
                throw new Exception("cntlzw <int_reg>, <int_reg>");
            val += GetIntRegister(args[0]) << 21;
            val += GetIntRegister(args[1]) << 16;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "cntlzw";
    }
}
