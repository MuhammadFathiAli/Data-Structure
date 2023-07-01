using System;

namespace testConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Array Resize Implementation Practice
             * Function Name : Resize 
             * Assumptions :
                - array data stored in memory heap
                - array address is stored in memory stack
            * Inputs:
                - the array data type
                - the array itself
                - new size
            * Processes:
                - Validation :
                    + the new size is a valid number
                    + the array is not null
                    + the new size of the array is not equal to the current size
                - Resize:
                    + create new array from the same datatype with the new size
                    + move all items from source array to the new array 
                    + assign the address of the new array for the source array address
            *Outputs : nothing
             */
            int[] currAray = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Join(",", currAray));
            Console.WriteLine(currAray.Length);
            OurArray.Resize<int>(ref currAray, 8);
            Console.WriteLine(string.Join(",", currAray));
            Console.WriteLine(currAray.Length);


        }
    }
    static class OurArray
    {
        public static void Resize<T>(ref T[] source, long newSize)
        {
            if (newSize <= 0) return;
            if (source == null) return;
            if (source.Length == newSize) return;
            T[] newArray = new T[newSize];
            //Array.Copy(source, newArray, source.Length);
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));
            source = newArray;
        }
    }
}
