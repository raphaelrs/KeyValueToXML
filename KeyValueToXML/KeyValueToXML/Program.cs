using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KeyValueToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KeyValuePair<string, int>> foobar = new List<KeyValuePair<string, int>>();

            KeyValuePair<string, int> key1 = new KeyValuePair<string, int>();
            KeyValuePair<string, int> key2 = new KeyValuePair<string, int>();
            KeyValuePair<string, int> key3 = new KeyValuePair<string, int>();

            key1.Key = "key 1";
            key2.Key = "key 2";
            key3.Key = "key 3";

            key1.Value = 1;
            key1.Value = 2;
            key1.Value = 3;

            foobar.Add(key1);
            foobar.Add(key2);
            foobar.Add(key3);

            XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<string, int>>));

            using (Stream stm = File.Create("foo.txt"))
            {
                serializer.Serialize(stm, foobar);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(List<KeyValuePair<string, int>>));

            StreamReader reader = new StreamReader("foo.txt");

            List<KeyValuePair<string, int>> foobar2 = (List<KeyValuePair<string, int>>)deserializer.Deserialize(reader);

            foreach (var item in foobar2)
            {
                Console.WriteLine("_______");
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            Console.WriteLine("_______");

            Console.ReadKey();
        }
    }

    [Serializable]
    [XmlType(TypeName = "WhateverNameYouLike")]
    public struct KeyValuePair<K, V>
    {
        [System.Xml.Serialization.XmlElement("Chave")]
        public K Key { get; set; }
        [System.Xml.Serialization.XmlElement("Valor")]
        public V Value{ get; set; }
    }
}
