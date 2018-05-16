using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"..\..\randomtext.txt";

            foreach (string word in GetWords(path, s => s.StartsWith("a"))) Console.Write("{0}; ", word);
            Console.ReadLine();

            var resultaten = GetWords(path, s => s.StartsWith("a"));
            List<string> list = new List<string>(resultaten);

        }

        public static IEnumerable<string> GetWords(string path, Predicate<string> s)
        {
            string[] text;
            try
            {
                StreamReader sr = new StreamReader(path);
                text = sr.ReadToEnd().Split(new char[0]);
            }
            catch
            {
                Console.WriteLine("Error occured, file not found. Current filled in path: " + path);
                Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
                yield break;
            }

            IEnumerable<string> ienum = text.Where<string>(new Func<string, bool>(s));
            ienum = ienum.OrderBy(v => v);
            foreach (String a in ienum)
            {
                yield return a;
            }

        }
    }
}
