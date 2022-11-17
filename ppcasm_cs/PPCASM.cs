using System;
using System.Collections.Generic;
using System.Linq;

namespace ppcasm_cs
{
    public class PPCASM
    {
        static Dictionary<String, Type> dict_instructions = new Dictionary<String, Type>()
        {
            // Supported commands
            { "add", typeof(PPC_Commands.ADD) },
            { "addc", typeof(PPC_Commands.ADDC) },
            { "addfic", typeof(PPC_Commands.ADDFIC) },
            { "addi", typeof(PPC_Commands.ADDI) },
            { "addic", typeof(PPC_Commands.ADDIC) },
            { "addic.", typeof(PPC_Commands.ADDIC_DOT) },
            { "addis", typeof(PPC_Commands.ADDIS) },
            { "and", typeof(PPC_Commands.AND) },
            { "andi", typeof(PPC_Commands.ANDI) },
            { "andis", typeof(PPC_Commands.ANDIS) },
            { "b", typeof(PPC_Commands.B) },
            { "bc", typeof(PPC_Commands.BC) },
            { "bctrl", typeof(PPC_Commands.BCTRL) },
            { "beq", typeof(PPC_Commands.BEQ) },
            { "bge", typeof(PPC_Commands.BGE) },
            { "bgt", typeof(PPC_Commands.BGT) },
            { "bl", typeof(PPC_Commands.BL) },
            { "ble", typeof(PPC_Commands.BLE) },
            { "blr", typeof(PPC_Commands.BLR) },
            { "blt", typeof(PPC_Commands.BLT) },
            { "bne", typeof(PPC_Commands.BNE) },
            { "bns", typeof(PPC_Commands.BNS) },
            { "bso", typeof(PPC_Commands.BSO) },
            { "cmplw", typeof(PPC_Commands.CMPLW) },
            { "cmplwi", typeof(PPC_Commands.CMPLWI) },
            { "cmpw", typeof(PPC_Commands.CMPW) },
            { "cmpwi", typeof(PPC_Commands.CMPWI) },
            { "cntlzw", typeof(PPC_Commands.CNTLZW) },
            { "fadd", typeof(PPC_Commands.FADD) },
            { "fadds", typeof(PPC_Commands.FADDS) },
            { "fcfid", typeof(PPC_Commands.FCFID) },
            { "fcmpu", typeof(PPC_Commands.FCMPU) },
            { "fdivs", typeof(PPC_Commands.FDIVS) },
            { "fdiv", typeof(PPC_Commands.FDIV) },
            { "fmr", typeof(PPC_Commands.FMR) },
            { "fmul", typeof(PPC_Commands.FMUL) },
            { "fmuls", typeof(PPC_Commands.FMULS) },
            { "fneg", typeof(PPC_Commands.FNEG) },
            { "fmsubs", typeof(PPC_Commands.FMSUBS) },
            { "fnmsubs", typeof(PPC_Commands.FNMSUBS) },
            { "fsub", typeof(PPC_Commands.FSUB) },
            { "fsubs", typeof(PPC_Commands.FSUBS) },
            { "lbz", typeof(PPC_Commands.LBZ) },
            { "lbzu", typeof(PPC_Commands.LBZU) },
            { "lfd", typeof(PPC_Commands.LFD) },
            { "lfdu", typeof(PPC_Commands.LFDU) },
            { "lfdux", typeof(PPC_Commands.LFDUX) },
            { "lfdx", typeof(PPC_Commands.LFDX) },
            { "lfs", typeof(PPC_Commands.LFS) },
            { "lfsu", typeof(PPC_Commands.LFSU) },
            { "lfsux", typeof(PPC_Commands.LFSUX) },
            { "lfsx", typeof(PPC_Commands.LFSX) },
            { "lha", typeof(PPC_Commands.LHA) },
            { "lhau", typeof(PPC_Commands.LHAU) },
            { "lhz", typeof(PPC_Commands.LHZ) },
            { "lhzu", typeof(PPC_Commands.LHZU) },
            { "li", typeof(PPC_Commands.LI) },
            { "lis", typeof(PPC_Commands.LIS) },
            { "lwz", typeof(PPC_Commands.LWZ) },
            { "lwzu", typeof(PPC_Commands.LWZU) },
            { "lwzx", typeof(PPC_Commands.LWZX) },
            { "mflr", typeof(PPC_Commands.MFLR) },
            { "mr", typeof(PPC_Commands.MR) },
            { "mtlr", typeof(PPC_Commands.MTLR) },
            { "nop", typeof(PPC_Commands.NOP) },
            { "nor", typeof(PPC_Commands.NOR) },
            { "or", typeof(PPC_Commands.OR) },
            { "ori", typeof(PPC_Commands.ORI) },
            { "oris", typeof(PPC_Commands.ORIS) },
            { "rlwimi", typeof(PPC_Commands.RLWIMI) },
            { "rlwimi.", typeof(PPC_Commands.RLWIMI_DOT) },
            { "rlwinm", typeof(PPC_Commands.RLWINM) },
            { "rlwinm.", typeof(PPC_Commands.RLWINM_DOT) },
            { "stb", typeof(PPC_Commands.STB) },
            { "stbu", typeof(PPC_Commands.STBU) },
            { "stdu", typeof(PPC_Commands.STDU) },
            { "stfd", typeof(PPC_Commands.STFD) },
            { "stfs", typeof(PPC_Commands.STFS) },
            { "stfsu", typeof(PPC_Commands.STFSU) },
            { "sth", typeof(PPC_Commands.STH) },
            { "sthu", typeof(PPC_Commands.STHU) },
            { "stw", typeof(PPC_Commands.STW) },
            { "stwu", typeof(PPC_Commands.STWU) },
            { "stwx", typeof(PPC_Commands.STWX) },
            { "sub", typeof(PPC_Commands.SUB) },
            { "subfic", typeof(PPC_Commands.SUBFIC) },
            { "subi", typeof(PPC_Commands.SUBI) },
            { "subis", typeof(PPC_Commands.SUBIS) },
            { "xor", typeof(PPC_Commands.XOR) },
            { "xori", typeof(PPC_Commands.XORI) },
            { "xoris", typeof(PPC_Commands.XORIS) },
            // data types
            { ".byte", typeof(PPC_DataTypes.Byte) },
            { ".word", typeof(PPC_DataTypes.Word) },
            { ".dword", typeof(PPC_DataTypes.Dword) },
            { ".float", typeof(PPC_DataTypes.Float32) },
            { ".double", typeof(PPC_DataTypes.Float64) },
            { ".ascii", typeof(PPC_DataTypes.Ascii) },
            { ".unicode", typeof(PPC_DataTypes.Unicode) }
        };

        public static PPC_Instruction[] Parse(UInt32 address, params String[] instructions)
        {
            List<PPC_Instruction> compiled_instructions = new List<PPC_Instruction>();
            UInt32 addr = address;
            String command = "";
            String[] args = null;
            int space_index = -1;
            String trimmed_instruction = "";

            foreach(String instruction in instructions)
            {
                trimmed_instruction = instruction;

                // Clear double spaces
                while (trimmed_instruction.Contains("  "))
                {
                    trimmed_instruction = trimmed_instruction.Replace("  ", " ");
                }

                // Check if there are arguments
                space_index = trimmed_instruction.IndexOf(' ');
                if (space_index == -1)
                {
                    command = trimmed_instruction;
                }
                else
                {
                    command = trimmed_instruction.Substring(0, space_index);
                    if(dict_instructions[command].BaseType == typeof(PPC_DataType))
                        args = trimmed_instruction.Substring(space_index, trimmed_instruction.Length - space_index)
                          .Split(',')
                          .Select(s => s.Trim())
                          .ToArray();
                    else
                        args = trimmed_instruction.Substring(space_index, trimmed_instruction.Length - space_index)
                          .Split(',')
                          .Select(s => s.Trim().ToLower())
                          .ToArray();
                }

                compiled_instructions.Add(((PPC_Instruction)Activator.CreateInstance(dict_instructions[command], addr, args)));
    
                command = "";
                args = null;
                addr += (UInt32)compiled_instructions.Last().Value.Length;
            }

            return compiled_instructions.ToArray();
        }
    }
}
