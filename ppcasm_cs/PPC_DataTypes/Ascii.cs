using System;
using System.Collections.Generic;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Ascii : PPC_DataType
    {
        public Ascii(UInt32 addr, String[] args) : base(addr, args)
        {
            List<Byte> str_as_bytes = new List<Byte>();
            if (args.Length != 1)
                throw new Exception(".ascii \"<ascii_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new Exception(".ascii \"<ascii_str>\"");
            str_as_bytes.AddRange(Encoding.ASCII.GetBytes(args[0].Substring(1, args[0].Length - 2)));
            while (str_as_bytes.Count % 4 != 0)
                str_as_bytes.Add(0);
            this.value = str_as_bytes.ToArray();
        }

        public override string Command => ".ascii";
    }
}
