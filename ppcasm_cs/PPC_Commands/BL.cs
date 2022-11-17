using System;
using System.Linq;

namespace ppcasm_cs.PPC_Commands
{
    class BL : PPC_Command
    {
        public BL(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            long val = 0x48000001;
            long dist_jump = 0;
            long dest = 0;
            if (args.Length != 1)
                throw new Exception("bl <addr>");
            dest = GetUnsignedImm(args[0], 32);
            if(dest % 4 != 0)
                throw new Exception("Destination must be a multiple of 4");
            if (dest < 0x80000000 || dest > 0x817FFFFF)
                throw new Exception("Destination must be inside of MEM1");
            dist_jump = dest - curAddr;
            if(dist_jump < -1 * Math.Pow(2, 23) || dist_jump > Math.Pow(2, 23) - 1)
                throw new Exception("Distance of jump must be between -0x800000 and 0x7FFFFF");
            if (dist_jump < 0)
                val += ((1 << 26) - Math.Abs(dist_jump)) & ~(31 << 27);
            else
                val += dist_jump;
            this.value = BitConverter.GetBytes((UInt32)val).Reverse().ToArray();
        }

        public override string Command => "bl";
    }
}
