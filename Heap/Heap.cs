using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Heap<Tdata> where Tdata : IComparable<Tdata>
    {
        private List<Tdata> DataList { get; set; }
        private int Size { get; set; }

        public Heap()
        {
            DataList = new List<Tdata>(new Tdata[10]);
            Size = 0;
        }
        public void Insert(Tdata data)
        {
            int i = Size;
            DataList[i] = data;
            Size++;

            int parentIndex = (i - 1) / 2;
            while (i != 0 && DataList[i].CompareTo(DataList[parentIndex]) < 0)
            {
                DataList[i] = DataList[parentIndex];
                DataList[parentIndex] = data;
                i = parentIndex;
                parentIndex = (i - 1) / 2;
            }


        }
        public Tdata Pop()
        {
            if (Size == 0) return default(Tdata);
            var i = 0;
            var data = DataList[i];
            DataList[i] = DataList[Size - 1];
            Size--;
            var leftIndex = (2 * i) + 1;
            while (leftIndex < Size)
            {
                var rightIndex = (2 * i) + 2;
                var smallerIndex = leftIndex;
                if (DataList[rightIndex] != null && DataList[leftIndex] != null &&
                    DataList[rightIndex].CompareTo(DataList[leftIndex]) < 0)
                {
                    smallerIndex = rightIndex;
                }
                if (DataList[smallerIndex].CompareTo(DataList[i]) >= 0)
                {
                    break;
                }
                var temp = DataList[i];
                DataList[i] = DataList[smallerIndex];
                DataList[smallerIndex] = temp;
                i = smallerIndex;
                leftIndex = (2 * i) + 1;
            }
            return data;
        }
        public void Print()
        {
            var print_data = "";
            for (var i = 0; i < Size; i++)
            {
                print_data += DataList[i] + " - ";
            }
            Console.WriteLine(print_data);
        }
        public int GetSize()
        {
            return Size;
        }
        public void Draw()
        {

            var levels_count = Math.Log2(Size) + 1;
            var line_width = Math.Pow(2, levels_count - 1);
            var j = 0;
            for (var i = 0; i < levels_count; i++)
            {
                var nodes_count = Math.Pow(2, i);
                var space = Math.Ceiling(line_width - nodes_count / 2);
                var space_between = Math.Ceiling(levels_count / nodes_count);
                space_between = space_between < 1 ? 1 : space_between;
                var k = j;
                var str = " ";
                for (int m = 0; m < space + space_between; m++)
                {
                    str += " ";
                }
                for (; j < k + nodes_count; j++)
                {
                    if (j == Size)
                    {
                        break;
                    }
                    if (DataList.Count > j)
                    {
                        str += DataList[j];
                        for (int n = 0; n < space_between; n++)
                        {
                            str += " ";

                        }
                    }
                }
                for (int z = 0; z < space; z++)
                {
                    str += " ";
                }
                str += "\n";

                Console.WriteLine(str);
            }
        }
    }
}
