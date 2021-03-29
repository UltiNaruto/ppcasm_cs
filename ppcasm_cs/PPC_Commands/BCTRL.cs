using System;

namespace ppcasm_cs.PPC_Commands
{
    class BCTRL : PPC_Command
    {
        public BCTRL(UInt32 curAddr, String[] args) : base(curAddr, args)
        {
            this.value = new byte[4] { 0x4e, 0x80, 0x00, 0x21 };
        }

        public override string Command => "bctrl";
    }
}
