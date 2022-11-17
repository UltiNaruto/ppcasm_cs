using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class SUB : PPC_Command
    {
        public SUB(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x7c000050;
            if (args.Length != 3)
                throw new Exception("sub <int_reg>, <int_reg>, <int_reg>");
            val |= GetIntRegister(args[0]) << 21;
            val |= GetIntRegister(args[1]) << 16;
            val |= GetIntRegister(args[2]) << 11;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "sub";
    }
}