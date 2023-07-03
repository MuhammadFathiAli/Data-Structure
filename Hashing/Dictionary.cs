using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Dictionary<Tkey, Tvalue> where Tkey : class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;
        public Dictionary()
        {
            initialSize = 3;
            entries = new KeyValuePair[initialSize];
        }
        public void ResizeOrNot()
        {
            if (entriesCount < entries.Length - 1) return;
            int newSize = entries.Length + initialSize;
            Console.WriteLine($"Array will be resized from [{entries.Length}] to [{newSize}]");
            KeyValuePair[] newEntries = new KeyValuePair[newSize];
            Array.Copy(entries, newEntries, entries.Length);
            entries = newEntries;
        }
        public int Size()
        {
            return entriesCount;
        }
        public bool TryAddOrUpdate(Tkey key, Tvalue value)
        {
            if (entries == null) return false;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    Console.WriteLine("Value Updated");
                    entries[i].Value = value;
                    return true;
                }
            }
            ResizeOrNot();
            KeyValuePair newEntry = new KeyValuePair(key, value);
            entries[entriesCount] = newEntry;
            entriesCount++;
            Console.WriteLine("Key Value Pair Added successfully");
            return true;
        }
        public bool TryGet(Tkey key, out Tvalue value)
        {
            value = default;
            if (entries == null) return false;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    value = entries[i].Value;
                    return true;
                }
            }
            return false;
        }
        public bool TryRemove(Tkey key)
        {
            if (entries == null) return false;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    entries[i] = entries[entriesCount - 1];
                    entries[entriesCount - 1] = null;
                    entriesCount--;
                    return true;
                }
            }
            return false;
        }
        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + this.Size());
            for (int i = 0; i < this.entries.Length; i++)
            {
                if (this.entries[i] == null)
                {
                    Console.WriteLine("[" + i + "]");
                    continue;
                }
                else
                {
                    Console.WriteLine("[" + i + "]" + this.entries[i].Key
                      + ":" + this.entries[i].Value);
                }
            }
            Console.WriteLine("==========");
        }

        class KeyValuePair
        {
            public Tkey Key { get; private set; }
            public Tvalue Value { get; set; }

            public KeyValuePair(Tkey _key, Tvalue _value)
            {
                Key = _key;
                Value = _value;
            }
        }
    }
}
