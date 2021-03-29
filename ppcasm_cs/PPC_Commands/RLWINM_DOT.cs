using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class RLWINM_DOT : PPC_Command
    {
        public RLWINM_DOT(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x54000001;
            if (args.Length != 5)
                throw new Exception("rlwinm. <int_reg>, <int_reg>, <imm5>, <imm5>, <imm5>");
            val += GetIntRegister(args[0]) << 16;
            val += GetIntRegister(args[1]) << 21;
            val += GetUnsignedImm(args[2], 5) << 11;
            val += GetUnsignedImm(args[3], 5) << 4;
            val += GetUnsignedImm(args[4], 5) << 1;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "rlwinm.";
    }
}