using SigmaTask8.Task1;
using SigmaTask8.Task3;
using System;
using System.Collections.Generic;

namespace SigmaTask8
{
    class Program
    {
        static void Main(string[] args)
        {
            //завдання 1 ---------------------
            //створюємо лист продуктів
            List<Product> list = new List<Product>();
            Random random = new Random();
            for(int i =1; i < 6; i++)
            {
                string name = $"Product №{i}";
                double price = random.NextDouble() + random.Next(0, 10);
                double weight = random.NextDouble() + random.Next(0, 10);
                list.Add(new Product(new DateTime(2021,10,i),price,weight,name,30));
            }
            //перетворємо в масив
            Product[] prod_arr = list.ToArray();
            //сортуємо по ціні
            SortClass.Sort(prod_arr, new CompareProductByPrice().Compare);
            //виводимо
            Console.WriteLine("Sorted by price : \n");
            foreach(var item in prod_arr)
            {
                Console.WriteLine(item.ToString()+"\n");
            } 


            //сортуємо по вазі
            SortClass.Sort(prod_arr, new CompareProductByWeight().Compare);
            //виводимо
            Console.WriteLine("Sorted by weight : \n");
            foreach (var item in prod_arr)
            {
                Console.WriteLine(item.ToString() + "\n");
            }

            //завдання 2 ----------------------------
            Console.WriteLine("Task 2 ======\n");
            Storage stor1 = new Storage();
            stor1.InitByArray(prod_arr);
            foreach (var prod in stor1)
            {
                Console.WriteLine(prod.ToString());
            }

            //завдання 3 --------------------
            string path = @"C:\Users\Acer\OneDrive\Робочий стіл\C#\SigmaTask8\Task3\TextFile.txt";
            TextCollection colection = new TextCollection();
            colection.ReadFromFile(path);

            Console.WriteLine("\nSentences: \n{0}",colection.ToString());
            //foreach(var text in colection)
            colection.SortByLenght();
            Console.WriteLine("\nSentences: \n{0}", colection.ToString());

            Console.WriteLine("Deppest lenght is\n{0}",colection.GetGreatestDepth());

            

            Console.WriteLine("\n\nWrite to end");
            Console.ReadLine();
        }
    }
}
