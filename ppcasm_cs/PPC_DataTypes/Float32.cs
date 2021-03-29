using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Float32 : PPC_DataType
    {
        public Float32(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".float <f32>");
            this.value = BitConverter.GetBytes(Utils.FromStringToFloat32(args[0])).Reverse().ToArray();
        }

        public override string Command => ".float";
    }
}
