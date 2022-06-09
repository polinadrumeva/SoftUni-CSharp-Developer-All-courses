using System;

namespace L02._Generic_Array_Creator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            T[] itemsArr = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                itemsArr[i] = item;
            }
            return itemsArr;
        }

        
    }
}
