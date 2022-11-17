using System.Collections.Generic;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Ascii : PPC_DataType
    {
        public Ascii(System.UInt32 addr, System.String[] args) : base(addr, args)
        {
            List<System.Byte> str_as_bytes = new List<System.Byte>();
            if (args.Length != 1)
                throw new System.Exception(".ascii \"<ascii_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new System.Exception(".ascii \"<ascii_str>\"");
            str_as_bytes.AddRange(Encoding.ASCII.GetBytes(args[0].Substring(1, args[0].Length - 2)));
            str_as_bytes.Add(0);
            this.value = str_as_bytes.ToArray();
        }

        public override string Command => ".ascii";
    }
}
