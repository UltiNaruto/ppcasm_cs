using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class ADDFIC : PPC_Command
    {
        public ADDFIC(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x20000000;
            if (args.Length != 3)
                throw new Exception("addfic <float_reg>, <float_reg>, <imm15>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 16;
            val |= GetUnsignedImm(args[2], 15);
            if ((uint)(val & 0x8000) != 0x8000)
                throw new Exception("Value cannot be above 32767");
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "addfic";
    }
}