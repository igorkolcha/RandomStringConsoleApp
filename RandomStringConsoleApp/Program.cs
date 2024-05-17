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
            int y = 1;
            StreamWriter streamWriter = new StreamWriter("text2.txt");
            List<string> myWords = new List<string>();
            myWords.AddRange(File.ReadAllLines("english.txt"));//считываем из текстового файла слова
            Console.WriteLine("String list:");
            foreach (string mW in myWords)
                Console.WriteLine("{0}   {1}", y++, mW);

            Console.WriteLine("--------------String random-------------------");
            int randomString = random.Next(myWords.Count);
            Console.WriteLine("Random string: {0}", myWords[randomString]);

            Console.WriteLine("--------------120 string random-------------");

            //Random rnd = new Random();

            for(int i = 0; i < 120; i++)
            {
                //int indexRnd = rnd.Next(myWords.Count);
                int indexRnd = random.Next(myWords.Count);//mew
                    Console.WriteLine("{0}", myWords[indexRnd]);
                    //записываем в текстовый файл text2 рандомные слова
                    streamWriter.WriteLine(myWords[indexRnd]);
            }
            streamWriter.Close();

            void Duplicates()
            {
                //Проверка повторяющихся слов в текстовом файле text2
                Console.WriteLine("-------------------Duplicates---------------");

                List<string> newWords = new List<string>();
                newWords.AddRange(File.ReadAllLines("text2.txt"));

                var duplicates = newWords.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(z => new { Item = z.Key, Count = z.Count() })
                    .ToList();
                Console.WriteLine(String.Join("\n", duplicates));               
            }

            Duplicates();

            Console.Read();           
        }
    }
}
