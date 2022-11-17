using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class CMPLWI : PPC_Command
    {
        public CMPLWI(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x28000000;
            if (args.Length != 2)
                throw new Exception("cmplwi <int_reg>, <imm16>");
            val |= GetIntRegister(args[0]) << 16;
            val |= GetUnsignedImm(args[1], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "cmplwi";
    }
}
