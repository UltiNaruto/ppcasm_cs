using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Dword : PPC_DataType
    {
        public Dword(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".dword <imm32>");
            this.value = BitConverter.GetBytes(Utils.FromStringToUInt32(args[0])).Reverse().ToArray();
        }

        public override string Command => ".dword";
    }
}
