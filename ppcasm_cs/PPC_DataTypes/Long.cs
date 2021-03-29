using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Long : PPC_DataType
    {
        public Long(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".long <imm32>");
            this.value = BitConverter.GetBytes(Utils.FromStringToUInt32(args[0])).Reverse().ToArray();
        }

        public override string Command => ".long";
    }
}
