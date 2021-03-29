using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class ADDIC : PPC_Command
    {
        public ADDIC(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x30000000;
            if (args.Length != 3)
                throw new Exception("addic <int_reg>, <int_reg>, <imm16>");
            val += GetIntRegister(args[0]) << 21;
            val += GetIntRegister(args[1]) << 16;
            val += GetUnsignedImm(args[2], 15);
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "addic";
    }
}