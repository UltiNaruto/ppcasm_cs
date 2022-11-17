using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FCFID : PPC_Command
    {
        public FCFID(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xfc00069c;
            if (args.Length != 2)
                throw new Exception("fcfid <float_reg>, <float_reg>");
            val |= GetFloatRegister(args[0]) << 21;
            val |= GetFloatRegister(args[1]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fcfid";
    }
}