using System;

namespace ppcasm_cs.PPC_Commands
{
    class BLR : PPC_Command
    {
        public BLR(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            this.value = new byte[4] { 0x4e, 0x80, 0x00, 0x20 };
        }

        public override string Command => "blr";
    }
}
