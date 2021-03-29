using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class LI : PPC_Command
    {
        public LI(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x38000000;
            if (args.Length != 2)
                throw new Exception("li <int_reg>, <imm16>");
            val += GetIntRegister(args[0]) << 21;
            val += GetUnsignedImm(args[1], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "li";
    }
}
