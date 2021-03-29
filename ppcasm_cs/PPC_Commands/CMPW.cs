using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class CMPW : PPC_Command
    {
        public CMPW(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c000000;
            if (args.Length != 2)
                throw new Exception("cmpw <int_reg>, <int_reg>");
            val += GetIntRegister(args[0]) << 16;
            val += GetIntRegister(args[1]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "cmpw";
    }
}
