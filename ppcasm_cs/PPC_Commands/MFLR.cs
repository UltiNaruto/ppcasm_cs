using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class MFLR : PPC_Command
    {
        public MFLR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c0802a6;
            if (args.Length != 1)
                throw new Exception("mflr <int_reg>");
            val |= GetIntRegister(args[0]) << 21;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "mflr";
    }
}