using System;

namespace ppcasm_cs
{
    public class PPC_Instruction
    {
        protected UInt32 currentAddress;
        protected byte[] value;
        protected String[] args;

        public UInt32 Address { get { return currentAddress; } }
        public byte[] Value { get { return value; } }
        public virtual String Command { get { throw new Exception(); } }
        public String[] Arguments { get { return args; } }

        protected PPC_Instruction(UInt32 curAddr, String[] _args) 
        {
            currentAddress = curAddr;
            args = _args;
            if (args == null)
                args = new String[0];
        }
    }
}
