using System;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Unicode : PPC_DataType
    {
        public Unicode(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".unicode \"<unicode_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new Exception(".unicode \"<unicode_str>\"");
            this.value = Encoding.GetEncoding("UTF-16BE").GetBytes(args[0].Substring(1, args[0].Length - 2) + "\u0000");
        }

        public override string Command => ".unicode";
    }
}
