using System;
using System.Linq;

namespace ppcasm_cs.PPC_DataTypes
{
    class Float64 : PPC_DataType
    {
        public Float64(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".double <f64>");
            this.value = BitConverter.GetBytes(Utils.FromStringToFloat64(args[0])).Reverse().ToArray();
        }

        public override string Command => ".double";
    }
}
