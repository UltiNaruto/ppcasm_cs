using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class CMPWI : PPC_Command
    {
        public CMPWI(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x2c000000;
            if (args.Length != 2)
                throw new Exception("cmpwi <int_reg>, <imm16>");
            val |= GetIntRegister(args[0]) << 16;
            val |= GetUnsignedImm(args[1], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "cmpwi";
    }
}
