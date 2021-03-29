using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class BLT : PPC_Command
    {
        public BLT(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            UInt32 val = 0x41800000;
            UInt32 dist_jump = 0;
            UInt32 dest = 0;
            if (args.Length != 1)
                throw new Exception("blt <addr>");
            dest = GetUnsignedImm(args[0], 32);
            if(dest % 4 != 0)
                throw new Exception("Destination must be a multiple of 4");
            if (dest < 0x80000000 || dest > 0x817FFFFF)
                throw new Exception("Destination must be inside of MEM1");
            dist_jump = dest - curAddr;
            if (dist_jump < -1 * Math.Pow(2, 15) || dist_jump > Math.Pow(2, 15) - 1)
                throw new Exception("Distance of jump must be between -0x8000 and 0x7FFF");
            val += dist_jump;
            this.value = BitConverter.GetBytes(val).Reverse().ToArray();
        }

        public override string Command => "blt";
    }
}
