/*
 *Name: hadil alshaikhsaleh 
 *student number: 040981664
 *lab1 C#
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace lab1
{
    class Program
    {
        private static List<string> words = new List<string>();
        static void Main(string[] args)
        {
            bool run = true;
            char selection;
            while (run)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("-------");
                Console.WriteLine("1- Import words from file");
                Console.WriteLine("2- Bubble sort words");
                Console.WriteLine("3- LINQ/Lambda sort words");
                Console.WriteLine("4- Count the Distinct Words ");
                Console.WriteLine("5- Take the first 10 words");
                Console.WriteLine("6- Get and display words that start with 'j' and display the count");
                Console.WriteLine("7- Get and display words that end with 'd' and display the count");
                Console.WriteLine("8- Get and display words that are greater than 4 characters long, and display the count");
                Console.WriteLine("9- Get and display words that are less than 3 characters long and start with the letter 'a', and display the count");
                Console.WriteLine("x- Exit");
                Console.WriteLine();
                Console.WriteLine("Make a selection:");
                selection = Console.ReadKey().KeyChar;
                Console.ReadLine();
                switch (selection)
                {
                    case '1':
                        //Import words from file;
                        readFile();
                        break;
                    case '2':
                        //Bubble sort words;
                        bubbleSort(words);
                        break;
                    case '3':
                        // LINQ/Lambda sort words;
                        lambdaSort(words);
                        break;
                    case '4':
                        //Count the Distinct Words;
                        countDistinctWords(words);
                        break;
                    case '5':
                        //Console.WriteLine("5- Take the first 10 words");
                        firstTenWords(words);
                        break;
                    case '6':
                        // Get and display words that start with 'j' and display the count;
                        startsWithJCount(words);
                        break;
                    case '7':
                        //  Get and display words that end with 'd' and display the count;
                        endsWithDCount(words);
                        break;
                    case '8':
                        //  Get and display words that are greater than 4 characters long, and display the count;
                        greaterThanFourChars(words);
                        break;
                    case '9':
                        //Get and display words that are less than 3 characters long and start with the letter 'a', and display the count;
                        lessThanThreeChars(words);
                        break;
                    case 'x':
                        Console.WriteLine("Exit");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }

        private static void readFile()
        {

            StreamReader reader = new StreamReader("c://Users/Hadeel/source/repos/lab1_hadil/lab1_hadil/Words.txt");
            string word;
            int counter = 0;
            Console.WriteLine("Reading Words");
            while ((word = reader.ReadLine()) != null)
            {
                words.Add(word);
                counter++;
            }
            Console.WriteLine("Reading words complete");
            Console.WriteLine("Number of words found: {0}", counter);
            Console.WriteLine();

        }

        private static List<string> bubbleSort(List<string> words)
        {

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < (words.Count - 1); i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (string.Compare(words[j], words[i]) < 0)
                    {
                        string tempString = words[j];
                        words[j] = words[i];
                        words[i] = tempString;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("Elapsed Time: {0} ms", watch.ElapsedMilliseconds);
            Console.WriteLine();
            return words;
        }
        private static List<string> lambdaSort(List<string> words)
        {

            Stopwatch watch = Stopwatch.StartNew();
            var query = words.OrderBy(str => str).ToList();
            words = query;
            watch.Stop();
            Console.WriteLine("Elapsed Time: {0} ms", watch.ElapsedMilliseconds);
            return words;
        }
        private static void countDistinctWords(List<string> words)
        {

            int numDistinctWords = (from x in words select x).Distinct().Count();
            Console.WriteLine("the number of distinct words is: {0}", numDistinctWords);
            Console.WriteLine();
        }
        private static void firstTenWords(List<string> words)
        {

            var take = words.Take(10).ToList();
            foreach (var word in take)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
        private static void startsWithJCount(List<string> words)
        {


            var query = from x in words where x.StartsWith("j") select x;
            int count = 0;
            foreach (var word in query)
            {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("The number of words that starts with 'j': {0}", count);
            Console.WriteLine();
        }
        private static void endsWithDCount(List<string> words)
        {

            var query = from x in words where x.EndsWith("d") select x;
            int count = 0;
            foreach (var word in query)
            {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("The number of words that end with 'd':{0}", count);
            Console.WriteLine();
        }
        private static void greaterThanFourChars(List<string> words)
        {

            var query = from x in words where x.Length > 4 select x;
            int count = 0;
            foreach (var word in query)
            {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("The number of words longer than 4 characters:{0}", count);
            Console.WriteLine();
        }
        private static void lessThanThreeChars(List<string> words)
        {

            var query = from x in words where x.Length < 3 && x.StartsWith("a") select x;
            int count = 0;
            foreach (var word in query)
            {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("The number of words less than 3 characters and starts with 'a':{0}", count);
            Console.WriteLine();
        }


    }

}

