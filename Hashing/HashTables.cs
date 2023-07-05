using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class HashTable<Tkey, Tvalue> 
    {
        public KeyValuePair[] entries;
        int initialSize;
        int entriesCount;

        public HashTable()
        {
            initialSize = 3;
            entriesCount = 0;
            entries = new KeyValuePair[initialSize];
        }
        public void Remove(Tkey key)
        {
            int hash = GetHash(key);
            if (entries[hash] != null && entries[hash].Key != key)
            {
                hash = CollisionHandling(key, hash, false);
            }
            if (hash == -1 || entries[hash] == null) return;
            if (entries[hash].Key == key)
            {
                entries[hash] = null;
            }
            else
            {
                throw new Exception("Invalid Hashtable");
            }
        }
        private int GetHash(Tkey key)
        {
            uint fnvOffsetBasis = 2166136261;
            uint fnvPrime = 16777619;

            byte[] data = Encoding.ASCII.GetBytes(key.ToString());

            uint hash = fnvOffsetBasis;

            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * fnvPrime;
            }
            Console.WriteLine("[hash] " + key.ToString()
                + " " + hash + " " + hash.ToString("x")
                  + " " + hash % (uint)this.entries.Length);

            return (int)(hash % (uint)this.entries.Length);
        }
        public void Set(Tkey key, Tvalue value)
        {
            ResizeOrNot();
            AddToEnties(key, value);
        }
        public Tvalue Get(Tkey key)
        {
            int hash = GetHash(key);
            if (entries[hash] != null && entries[hash].Key != key)
            {
                hash = CollisionHandling(key, hash, false);
            }
            if (hash == -1 || entries[hash] == null) return default(Tvalue);
            if (entries[hash].Key == key)
            {
                return entries[hash].Value;
            }
            else
            {
                throw new Exception("Invalid Hashtable");
            }

        }
        public void AddToEnties(Tkey key, Tvalue value)
        {
            int hash = GetHash(key);
            if (entries[hash] != null && entries[hash].Key != key)
            {
                hash = CollisionHandling(key, hash, true);
            }
            if (hash == -1)
            {
                throw new Exception("Invalid HashTable!!");
            }
            if (entries[hash] == null)
            {
                KeyValuePair newEntry = new KeyValuePair(key, value);
                entries[hash] = newEntry;
                entriesCount++;
                return;
            }
            else
            {
                entries[hash].Value = value;
                return;
            }
            throw new Exception("Invalid HashTable!!");
        }
        private int CollisionHandling(Tkey key, int hash, bool set)
        {
            int newHash;
            for (int i = 1; i < entries.Length; i++)
            {
                newHash = (hash + i) % entries.Length;

                Console.WriteLine("[coll] " + key.ToString()
                        + " " + hash + ", new hash: " + newHash);
                if (set && (entries[newHash] == null || entries[newHash].Key == key)) //set
                {
                    return newHash;
                }
                else if (!set && entries[newHash].Key == key) //get
                {
                    return newHash;
                }
            }
            return -1;
        }
        private void ResizeOrNot()
        {
            if (entriesCount < entries.Length) return;
            int newSize = entries.Length * 2;
            Console.WriteLine("[resize] from " +
              this.entries.Length + " to " + newSize);
            KeyValuePair[] entriesCopy = new KeyValuePair[entries.Length];
            Array.Copy(entries, entriesCopy, entries.Length);
            entries = new KeyValuePair[newSize];
            entriesCount = 0;
            for (int i = 0; i < entriesCopy.Length; i++)
            {
                if (entriesCopy[i] == null) continue;
                AddToEnties(entriesCopy[i].Key, entriesCopy[i].Value);
            }
        }
        public int Size()
        {
            return entriesCount;
        }
        public void Print()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("[Size] " + this.Size());

            for (int i = 0; i < this.entries.Length; i++)
            {
                if (this.entries[i] == null)
                {
                    Console.WriteLine("[" + i + "] null");
                }
                else
                {
                    Console.WriteLine("[" + i + "] " +
                      this.entries[i].Key + ":" +
                        this.entries[i].Value);
                }
            }

            Console.WriteLine("============");
        }
        public class KeyValuePair
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
