using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _26._03Generics
{
    class Item<TKey, TValue>
    {
        public TValue Value { get; set; }
        public TKey Key { get; set; }
        
        public Item(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        
    }
    class EasyMap<TKey,TValue>: IEnumerable
    {
        private List<Item<TKey,TValue>> Items = new List<Item<TKey,TValue>>();
        private List<TKey> Keys = new List<TKey>();

        public int Count=>Items.Count;
        public EasyMap()
        {

        }
        public void Add(Item<TKey,TValue> item)
        {
            if(!Keys.Contains(item.Key))
            {
                Keys.Add(item.Key);
                Items.Add(item);
            }
        }
        public TValue Search(TKey key)
        {
            if(Keys.Contains(key))
            {
                return Items.Single(i=>i.Key.Equals(key)).Value;
            }
            return default(TValue);
        }
        public void Remove(TKey key)
        {
            if (Keys.Contains(key))
            {
                Keys.Remove(key);
                Items.Remove(Items.Single(i => i.Key.Equals(key)));
            }
           
        }

        public IEnumerator GetEnumerator()
        {
           return Items.GetEnumerator();
        }
    }

    class Dict<TKey,TValue>:IEnumerable
    {
        private int size = 100;
        private Item<TKey, TValue>[] Items;
        private List<TKey> Keys = new List<TKey>();
           
        public Dict() 
        {
            Items = new Item<TKey, TValue>[size];
        }
        public void Add (Item<TKey,TValue>item)
        {
            var hash=GetHash(item.Key);
            if(Keys.Contains(item.Key))
            {
                return;
            }
            if (Items[hash] == null)
            {
                Keys.Add(item.Key);
                Items[hash] = item;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (Items[i] == null)
                    {
                        Keys.Add(item.Key);
                        Items[i] = item;
                        placed = true;
                        break;
                    }
                    if (Items[i].Key.Equals(item.Key))
                    {
                        return;
                    }
                   
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            Keys.Add(item.Key);
                            Items[i] = item;
                            placed = true;
                            break;
                        }
                        if (Items[i].Key.Equals(item.Key))
                        {
                            return;
                        }

                    }
                }
                if(!placed)
                {
                    throw new Exception("Словарь заполнен");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                if(item!=null)
                {
                    yield return item;
                }
            }
        }

        public void Remove(TKey key)
        {
            var hash = GetHash(key);
            if (!Keys.Contains(key))
            {
                return;
            }
            if (Items[hash] == null)
            {
                for (var i = 0; i < size; i++)
                {
                    if (Items[i]!= null && Items[i].Key.Equals(key))
                    {
                       Items[i]=null;
                        Keys.Remove(key);
                        return;
                    }
                }
                return ;
            }
            if (Items[hash].Key.Equals(key))
            {
                Items[hash]=null;
                Keys.Remove(key);
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (Items[i] == null)
                    {
                        return;
                    }
                    if (Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                    
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            return;
                        }
                        if (Items[i].Key.Equals(key))
                        {
                            Items[i] = null;
                            Keys.Remove(key);
                            return;
                        }
                    }
                }
            }
        }

        public TValue Search(TKey key)
        {
            var hash = GetHash(key);
            if(!Keys.Contains(key))
            {
                return default(TValue);
            }

            if (Items[hash]==null)
            {
                foreach (var item in Items)
                {
                    if(item.Key.Equals(key))
                    { 
                        return item.Value;
                    }
                }
                return default(TValue);
            }
            if (Items[hash].Key.Equals(key))
            {
                return Items[hash].Value;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (Items[i] == null)
                    {
                        return default(TValue);
                    }
                    if (Items[i].Key.Equals(key))
                    {
                        return Items[i].Value;
                      
                    }
                   
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            return default(TValue);
                        }
                        if (Items[i].Key.Equals(key))
                        {
                            return Items[i].Value;
                        }
                    }
                }
            }
            return default(TValue);
        }
        private int GetHash(TKey key)
        {
            return key.GetHashCode()%size;
        }
    }
    internal class Program
    {
      
        static void Main(string[] args)
        {
            var dict = new Dict<int, string>();
            dict.Add(new Item<int, string>(1, "Один"));
            dict.Add(new Item<int, string>(1, "Один"));
            dict.Add(new Item<int, string>(2, "Два"));
            dict.Add(new Item<int, string>(3, "Три"));
            dict.Add(new Item<int, string>(4, "Четыре"));
            dict.Add(new Item<int, string>(5, "Пять"));
            dict.Add(new Item<int, string>(101, "Сто один"));

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
            WriteLine(dict.Search(7) ?? "Не найдено"); // Короткая запись проверки на null
            WriteLine(dict.Search(3) ?? "Не найдено");
            WriteLine(dict.Search(101) ?? "Не найдено");

            dict.Remove(3);
            dict.Remove(1);
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
            WriteLine();
            ReadLine();



            var easyMap=new EasyMap<int,string>();
            easyMap.Add(new Item<int, string>(1, "Один"));
            easyMap.Add(new Item<int, string>(2, "Два"));
            easyMap.Add(new Item<int, string>(3, "Три"));
            easyMap.Add(new Item<int, string>(4, "Четыре"));
            easyMap.Add(new Item<int, string>(5, "Пять"));

            foreach(var item in easyMap)
            {
                Console.WriteLine(item);
            }
            WriteLine(easyMap.Search(7) ?? "Не найдено");
            WriteLine(easyMap.Search(3) ?? "Не найдено");
            easyMap.Remove(3);
            easyMap.Remove(1);
            foreach (var item in easyMap)
            {
                Console.WriteLine(item);
            }
            ReadLine();
        }
    }
}
