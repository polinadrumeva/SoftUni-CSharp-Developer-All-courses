using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05._Stack_of_Strings
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        { 
            return Count == 0;
        }

        public void AddRange(IEnumerable<string> items) 
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }
    }
}
