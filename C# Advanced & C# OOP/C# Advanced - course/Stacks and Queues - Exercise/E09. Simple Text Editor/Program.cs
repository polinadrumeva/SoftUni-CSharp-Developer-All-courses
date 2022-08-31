using System;
using System.Collections.Generic;
using System.Text;

namespace E09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCommand = int.Parse(Console.ReadLine());
            Stack<string> pastDatas = new Stack<string>();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < numbersOfCommand; i++)
            {
                string command = Console.ReadLine();
                if (command.StartsWith("1"))
                {
                    pastDatas.Push(text.ToString());
                    string textForAdd = command.Split()[1];
                    text.Append(textForAdd);
                }
                else if (command.StartsWith("2"))
                {
                    pastDatas.Push(text.ToString());
                    int count = int.Parse(command.Split()[1]);
                    text.Remove(text.Length - count, count);
                }
                else if (command.StartsWith("3"))
                {
                    int index = int.Parse(command.Split()[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command.StartsWith("4"))
                {
                    text = new StringBuilder(pastDatas.Pop());
                }
            }
        }
    }
}
