using System;

namespace ppcasm_cs
{
    class PPC_DataType : PPC_Instruction
    {
        protected PPC_DataType(UInt32 curAddress, String[] args) : base(curAddress, args) { }
    }
}