using System;
using System.Text;

namespace ppcasm_cs.PPC_DataTypes
{
    class Ascii : PPC_DataType
    {
        public Ascii(UInt32 addr, String[] args) : base(addr, args)
        {
            if (args.Length != 1)
                throw new Exception(".ascii \"<ascii_str>\"");
            if (args[0][0] != '"'
             || args[0][args[0].Length - 1] != '"')
                throw new Exception(".ascii \"<ascii_str>\"");
            this.value = Encoding.ASCII.GetBytes(args[0].Substring(1, args[0].Length - 2) + "\0");
        }

        public override string Command => ".ascii";
    }
}
