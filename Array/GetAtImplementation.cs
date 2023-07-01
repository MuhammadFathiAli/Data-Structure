using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace testConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Array GetAt Implementation Practice
             * Function Name : GetAt
             * Assumptions :
                - array data stored in memory heap
                - array address is stored in memory stack
            * Inputs:
                - the array data type
                - the array itself
                - index
            * Processes:
                - Validation :
                    + index is greater than or equal 0
                - GetAt:
                    + get the memory address of the 0th item
                    + get the size of the array datatype 
                    + calculate the address of the given type
                    + get value from memory using the calculated address
            *Outputs : single item or default value
             */
            int[] currAray = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Join(",", currAray));
            Console.WriteLine(OurArray.GetAt<int>(currAray, 3, sizeof(int)));
            Console.WriteLine(OurArray.GetAt<int>(currAray, 0, sizeof(int)));
            Console.WriteLine(OurArray.GetAt<int>(currAray, currAray.Length - 1, sizeof(int)));
            Console.WriteLine(OurArray.GetAt<int>(currAray, currAray.Length, sizeof(int)));
            Console.WriteLine(OurArray.GetAt<int>(currAray, 5, sizeof(int)));
            Console.WriteLine(OurArray.GetAt<int>(currAray, 15, sizeof(int)));


        }
    }
    static class OurArray
    {
        public static T GetAt<T>(T[] source, int index, int SizeOf)
        {
            if (source == null) return default(T);
            if (index < 0) return default(T);

            // to get the address of the 0th item in the array 
            ref byte zeroAdd = ref MemoryMarshal.GetArrayDataReference<byte>(Unsafe.As<byte[]>(source));
            //to get the address of the desired item to GetAt
            ref byte indexRef = ref Unsafe.Add(ref zeroAdd, index * SizeOf);
            // to read the value of the desired address
            ref T item = ref Unsafe.As<byte, T>(ref indexRef);
            return item;
        }
    }
}
