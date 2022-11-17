using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class SUBIS : PPC_Command
    {
        public SUBIS(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x3c000000;
            if (args.Length != 3)
                throw new Exception("subis <int_reg>, <int_reg>, <imm16>");
            val |= GetIntRegister(args[0]) << 21;
            val |= GetIntRegister(args[1]) << 16;
            val |= 0x10000 - GetUnsignedImm(args[2], 16);
            if ((uint)(val & 0x8000) != 0x8000)
                throw new Exception("Value cannot be above 32767");
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "subis";
    }
}