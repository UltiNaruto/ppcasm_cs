using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class XORI : PPC_Command
    {
        public XORI(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x68000000;
            if (args.Length != 3)
                throw new Exception("xori <int_reg>, <int_reg>, <imm16>");
            val += GetIntRegister(args[0]) << 16;
            val += GetIntRegister(args[1]) << 21;
            val += GetUnsignedImm(args[2], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "xori";
    }
}