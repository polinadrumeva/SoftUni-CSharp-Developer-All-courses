using System;

namespace _1___Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string dataType = string.Empty;

            while (command != "END")
            {
                bool intTryParseIsSucceess = int.TryParse(command, out int intValue);
                bool doubleTryParseIsSuccess = double.TryParse(command, out double doubleValue);
                bool charTryParseIsSuccess = char.TryParse(command, out char charValue);
                bool boolTryParseIsSuccess = bool.TryParse(command, out bool boolValue);

                if (intTryParseIsSucceess)
                {
                    dataType = "integer";
                }
                else if (doubleTryParseIsSuccess)
                {
                    dataType = "floating point";
                }
                else if (boolTryParseIsSuccess)
                {
                    dataType = "boolean";
                }
                else if (charTryParseIsSuccess)
                {
                    dataType = "character";
                }
                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{command} is {dataType} type");
                command = Console.ReadLine();
            }
        }
    }
}