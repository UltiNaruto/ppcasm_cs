using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class ANDIS : PPC_Command
    {
        public ANDIS(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x74000000;
            if (args.Length != 3)
                throw new Exception("andis <int_reg>, <int_reg>, <imm16>");
            val += GetIntRegister(args[0]) << 21;
            val += GetIntRegister(args[1]) << 16;
            val += GetUnsignedImm(args[2], 16);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "andis";
    }
}