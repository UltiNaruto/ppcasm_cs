using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class ANDI : PPC_Command
    {
        public ANDI(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x70000000;
            if (args.Length != 3)
                throw new Exception("andi <int_reg>, <int_reg>, <imm16>");
            val |= GetIntRegister(args[0]) << 21;
            val |= GetIntRegister(args[1]) << 16;
            val |= GetUnsignedImm(args[2], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "andi";
    }
}