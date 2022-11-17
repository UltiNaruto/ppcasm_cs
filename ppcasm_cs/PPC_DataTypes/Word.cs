using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Word : PPC_DataType
    {
        public Word(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".word <imm16>");
            this.value = BitConverter.GetBytes(Utils.FromStringToUInt16(args[0])).Reverse().ToArray();
        }

        public override string Command => ".word";
    }
}
