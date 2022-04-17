using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ME04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> morseCode = Console.ReadLine().Split().ToList();
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < morseCode.Count; i++)
            {
                if (morseCode[i] == ".-")
                {
                    code.Append("A");
                }
                else if (morseCode[i] == "-...")
                {
                    code.Append("B");
                }
                else if (morseCode[i] == "-.-.")
                {
                    code.Append("C");
                }
                else if (morseCode[i] == "-..")
                {
                    code.Append("D");
                }
                else if (morseCode[i] == ".")
                {
                    code.Append("E");
                }
                else if (morseCode[i] == "..-.")
                {
                    code.Append("F");
                }
                else if (morseCode[i] == "--.")
                {
                    code.Append("G");
                }
                else if (morseCode[i] == "....")
                {
                    code.Append("H");
                }
                else if (morseCode[i] == "..")
                {
                    code.Append("I");
                }
                else if (morseCode[i] == ".---")
                {
                    code.Append("J");
                }
                else if (morseCode[i] == "-.-")
                {
                    code.Append("K");
                }
                else if (morseCode[i] == ".-..")
                {
                    code.Append("L");
                }
                else if (morseCode[i] == "--")
                {
                    code.Append("M");
                }
                else if (morseCode[i] == "-.")
                {
                    code.Append("N");
                }
                else if (morseCode[i] == "---")
                {
                    code.Append("O");
                }
                else if (morseCode[i] == ".--.")
                {
                    code.Append("P");
                }
                else if (morseCode[i] == "--.-")
                {
                    code.Append("Q");
                }
                else if (morseCode[i] == ".-.")
                {
                    code.Append("R");
                }
                else if (morseCode[i] == "...")
                {
                    code.Append("S");
                }
                else if (morseCode[i] == "-")
                {
                    code.Append("T");
                }
                else if (morseCode[i] == "..-")
                {
                    code.Append("U");
                }
                else if (morseCode[i] == "...-")
                {
                    code.Append("V");
                }
                else if (morseCode[i] == ".--")
                {
                    code.Append("W");
                }
                else if (morseCode[i] == "-..-")
                {
                    code.Append("X");
                }
                else if (morseCode[i] == "-.--")
                {
                    code.Append("Y");
                }
                else if (morseCode[i] == "--..")
                {
                    code.Append("Z");
                }
                else if (morseCode[i] == "|")
                {
                    code.Append(" ");
                }
            }

            Console.WriteLine(code.ToString());
        }
       
    }
}
