using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStringConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<string> myWords = new List<string>();
            myWords.AddRange(File.ReadAllLines("text.txt"));//считываем из файла слова
            Console.WriteLine("String list:");
            foreach (string mW in myWords)
                Console.WriteLine("{0}", mW);

            Console.WriteLine("--------------string random-------------------");
            int randomString = random.Next(myWords.Count);
            Console.WriteLine("Random string: {0}", myWords[randomString]);

            Console.WriteLine("--------------Five string random-------------");
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                int indexRnd = rnd.Next(myWords.Count);
                Console.WriteLine("{0}", myWords[indexRnd]);
            }
            Console.Read();
        }
    }
}
