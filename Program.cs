using SigmaTask8.Task1;
using System;
using System.Collections.Generic;

namespace SigmaTask8
{
    class Program
    {
        static void Main(string[] args)
        {
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
            //перетвор.ємо в масив
            Product[] arr = list.ToArray();
            //сортуємо по ціні
            SortClass.Sort(arr, new CompareProductByPrice().Compare);
            //виводимо
            Console.WriteLine("Sorted by price : \n");
            foreach(var item in arr)
            {
                Console.WriteLine(item.ToString()+"\n");
            } 


            //сортуємо по вазі
            SortClass.Sort(arr, new CompareProductByWeight().Compare);
            //виводимо
            Console.WriteLine("Sorted by weight : \n");
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString() + "\n");
            }


            Console.WriteLine("\n\nWrite to end");
            Console.ReadLine();
        }
    }
}
