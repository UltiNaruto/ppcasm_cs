using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Byte : PPC_DataType
    {
        public Byte(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".byte <imm8>");
            this.value = new byte[] { Utils.FromStringToUInt8(args[0]) };
        }

        public override string Command => ".byte";
    }
}
