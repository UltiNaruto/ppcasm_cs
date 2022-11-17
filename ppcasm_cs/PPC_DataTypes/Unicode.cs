using System.Collections.Generic;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Unicode : PPC_DataType
    {
        public Unicode(System.UInt32 addr, System.String[] args) : base(addr, args)
        {
            List<System.Byte> str_as_bytes = new List<System.Byte>();
            if (args.Length != 1)
                throw new System.Exception(".unicode \"<unicode_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new System.Exception(".unicode \"<unicode_str>\"");
            str_as_bytes.AddRange(Encoding.GetEncoding("UTF-16BE").GetBytes(args[0].Substring(1, args[0].Length - 2)));
            str_as_bytes.Add(0);
            str_as_bytes.Add(0);
            this.value = str_as_bytes.ToArray();
        }

        public override string Command => ".unicode";
    }
}
