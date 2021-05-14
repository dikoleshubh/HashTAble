using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAsh
{
    class MyMapNode<K, V>
    {
        private readonly int size;//size of hashtable
        private readonly LinkedList<keyValue<K, V>>[] items;


        public struct keyValue<k, v> // KeyVAlue Constructor
        {

            public k Key { get; set; }
            public v Value { get; set; }

        }
        public MyMapNode(int size)
        {
            this.size = size; //array of linkedlist size is defined
           
            this.items = new LinkedList<keyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key) //GetArrayPosition is method and passing key as parameter
        {
           
            int position = key.GetHashCode() % size;//GetHashCode is predifine method,to identifey the hashcode of this particular key
            return Math.Abs(position);//Math.abs function To identify integer value and At what index this purticular keyvalue is present.
        }

        protected LinkedList<keyValue<K, V>> GetLinkedList(int position)//method and GetLinkedList having return type is Linkedlist keyvalue pair which is define line no13
        {
            
           
            //position is passed into array of items and stored in variable linkedlist with data type as defined below.
            LinkedList<keyValue<K, V>> linkedList = items[position];

            if (linkedList == null)
            {
                linkedList = new LinkedList<keyValue<K, V>>();
                //adding a linkedlist in the given array position
                items[position] = linkedList;
            }
            //returning linked list.
            return linkedList;
        }

        public V Get(K key)//generic method
        {

            int position = GetArrayPosition(key);//call method

            //linkedlist is accessed after getting the position from the array
           

            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);//identifying the position calling the getLinkedlist()
           
            foreach (keyValue<K, V> item in linkedList)
            {
                //if key element matches with the key in linkedlist, value is retuned
                //otherwise loop is iterated.
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)//used add method and passes 2 parameter pushing the data into hashtable using linkedlist opraton
        {

            int position = GetArrayPosition(key);

            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
           
            //keyValue struct is instatiated and stores the key and value, which is passed as one object to linkedlist.
            keyValue<K, V> item = new keyValue<K, V>() { Key = key, Value = value };
            //keyvalue is added in the linkedlist.
            linkedList.AddLast(item);
        }


        public void Remove(K key)//rempving particular entery  from hashtable
        {
            //getting the  position of linkedlist in which key value pair is stored and is to be removed
            int position = GetArrayPosition(key);
            //calling the dictionary from which element is to be removed.
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            //if key of item matches from iteration done in particular linked list, key value pairs are assigned to foundItem variable.
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            //iterating loop in linkedlist to find out the key
            foreach (keyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            //if item is found, it is removed
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public void Display()
        {

            foreach (var linkedList in items)
            {

                if (linkedList != null)
                    foreach (keyValue<K, V> keyvalue in linkedList)
                    {

                        Console.WriteLine(keyvalue.Key + "\t" + keyvalue.Value);
                    }
            }
        }
    }
}
