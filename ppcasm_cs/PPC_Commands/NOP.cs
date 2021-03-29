using System;

namespace ppcasm_cs.PPC_Commands
{
    class NOP : PPC_Command
    {
        public NOP(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            this.value = new byte[4] { 0x60, 0x00, 0x00, 0x00 };
        }

        public override string Command => "nop";
    }
}
