using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class FCMPU : PPC_Command
    {
        public FCMPU(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0xfc000000;
            if (args.Length != 3)
                throw new Exception("fcmpu <cond_reg>, <float_reg>, <float_reg>");
            val += GetConditionRegister(args[0]) << 23;
            val += GetFloatRegister(args[1]) << 16;
            val += GetFloatRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "fcmpu";
    }
}