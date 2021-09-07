using System;
using System.Collections.Generic;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Unicode : PPC_DataType
    {
        public Unicode(UInt32 addr, String[] args) : base(addr, args)
        {
            List<Byte> str_as_bytes = new List<Byte>();
            if (args.Length != 1)
                throw new Exception(".unicode \"<unicode_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new Exception(".unicode \"<unicode_str>\"");
            str_as_bytes.AddRange(Encoding.GetEncoding("UTF-16BE").GetBytes(args[0].Substring(1, args[0].Length - 2)));
            while (str_as_bytes.Count % 4 != 0)
                str_as_bytes.Add(0);
            this.value = str_as_bytes.ToArray();
        }

        public override string Command => ".unicode";
    }
}
