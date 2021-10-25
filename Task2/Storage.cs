﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask8.Task1
{
    class Storage
    {
        List<Product> products;
        //властивість
        public List<Product> Products => products;

        //конструктор--------------------------
        public Storage()
        {
            products = new List<Product>();
        }

        //ініціалізація через список-------------------------
        public void InitByArray(Product[] prod_arr)
        {
            this.products = new List<Product>(prod_arr);
        }

        //швидка ініціаліція------------
        public void QuickInit()
        {
            products.Add(new Product(new DateTime(2021,3,12),3.21,3.3,"Waterlemon",30));
            products.Add(new Product(new DateTime(2021,9,28),5,1.3,"Banana",30));
            products.Add(new Product(new DateTime(2020,5,2),10,0.5,"Nuts",30));
            products.Add(new Meat(new DateTime(2021,10,20),10,0.5,"NA",30,1,2));
            products.Add(new DairyProduct(new DateTime(2021,10,2),5,0.5,"Milk",30));
        }
        //зчитати з консолі------------------------------------
        public void ReadFromConsole()
        {
            string input;
            int variety;
            int sizeOfArr;   
            //розмір масиву
            Console.WriteLine("How many products do you want(>=0)?");
            input = Console.ReadLine();

            //поки не отримуємо потрібне число
            while ((!Int32.TryParse(input, out sizeOfArr)) || (sizeOfArr < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //оновлюємо розмір масиву
            products.Clear();
            for (int counter = 0; counter < sizeOfArr;counter++)
            {
                //вибираємо варіант product
                Console.WriteLine("Choose variety: 1->Meat\t 2->Dairy Product\t 3->Product");
                input = Console.ReadLine();
                while ((!Int32.TryParse(input, out variety)) || (variety < 1) || (variety > 3))
                {
                    Console.WriteLine("Wrong input");
                    input = Console.ReadLine();
                }
                if (variety == 1)
                {
                    //створюємо об'єкт з отриманих даних і додаємо в масив
                    products.Add(ReadMeat());
                }
                //молочні
                else if (variety == 2)
                {
                    products.Add(ReadDairy());
                }
                //звичайний
                else
                {
                    products.Add(ReadProduct());
                }
            }
        }
        
        private Meat ReadMeat()
        {
            string input;
            //загальні поля
            double price;
            double weight;
            string name;
            int exDay;
            DateTime date;
            //уточняємо інформацію по виду продукту
            //м'ясо
            int category;
            int type;
            //тип м'яса (одночасно це і його ім'я)
            Console.WriteLine("Choose type: 1->Lamb\t2->Veal\t3->Pork\t4->Chicken");
            input = Console.ReadLine();
            while ((!Int32.TryParse(input, out type)) || (type < 1) || (type > 4))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //категорія
            Console.WriteLine("Choose category: 1->High_sort\t 2->I_sort\t3->II_sort");
            input = Console.ReadLine();
            while ((!Int32.TryParse(input, out category)) || (category < 1) || (category > 3))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //ціну
            Console.WriteLine("Write price(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out price)) || (price < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //вага
            Console.WriteLine("Write weight(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out weight)) || (weight < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //дні придатності
            Console.WriteLine("Write Expitation day(>0)");
            input = Console.ReadLine();
            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //дата створення
            Console.WriteLine("Write creation date(12:08:2001)");
            input = Console.ReadLine();
            string[] str_date = input.Split(':');
            int day, month, year;
            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
                !Int32.TryParse(str_date[1], out month) || (month < 1) ||
                !Int32.TryParse(str_date[2], out year) || (year < 1900))
            {
                Console.WriteLine("Wrong Date");
                input = Console.ReadLine();
            }
            date = new DateTime(year, month, day);
            //створюємо об'єкт з отриманих даних і додаємо в масив
            return new Meat(date, price, weight, "N/A", exDay, category, type);
        }
        private DairyProduct ReadDairy()
        {
            string input;
            //загальні поля
            double price;
            double weight;
            string name;
            int exDay;
            DateTime date;

            //ім'я продукту
            Console.WriteLine("Write name of product");
            name = Console.ReadLine();
            //ціна
            Console.WriteLine("Write price(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out price)) || (price < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //вага
            Console.WriteLine("Write weight(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out weight)) || (weight < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //дні придатності
            Console.WriteLine("Write Expitation day(>0)");
            input = Console.ReadLine();
            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //дата створення
            Console.WriteLine("Write creation date(12:08:2001)");
            input = Console.ReadLine();
            string[] str_date = input.Split(':');
            int day, month, year;
            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
                !Int32.TryParse(str_date[1], out month) || (month < 1) ||
                !Int32.TryParse(str_date[2], out year) || (year < 1900))
            {
                Console.WriteLine("Wrong Date");
                input = Console.ReadLine();
            }
            date = new DateTime(year, month, day);

            return new DairyProduct(date, price, weight, name, exDay);
        }Це неправильно мати різні методи для зчитування об'єктів дочірніх класів
        private Product ReadProduct()
        {
            string input;
            //загальні поля
            double price;
            double weight;
            string name;
            int exDay;
            DateTime date;
            //все те саме, але без спеціальних особливостей
            Console.WriteLine("Write price(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out price)) || (price < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            Console.WriteLine("Write weight(>0)");
            input = Console.ReadLine();
            while ((!Double.TryParse(input, out weight)) || (weight < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            Console.WriteLine("Write name of product");
            name = Console.ReadLine();
            //дні придатності
            Console.WriteLine("Write Expitation day(>0)");
            input = Console.ReadLine();
            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            //дата створення
            Console.WriteLine("Write creation date(12:08:2001)");
            input = Console.ReadLine();
            string[] str_date = input.Split(':');
            int day, month, year;
            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
                !Int32.TryParse(str_date[1], out month) || (month < 1) ||
                !Int32.TryParse(str_date[2], out year) || (year < 1900))
            {
                Console.WriteLine("Wrong Date");
                input = Console.ReadLine();
            }
            date = new DateTime(year, month, day);
            
            return new Product(date, price, weight, name, exDay);
        }

        //отримати інформацію з файлу--------------------
        public void ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    //кількість рядків 
                    string line = r.ReadLine();
                    int rows;
                    if (!Int32.TryParse(line, out rows))
                    {
                        throw new ArgumentException("Wrong Rows input");
                    }
                    //оновлюємо розмір масиву
                    products.Clear();

                    //зчитуємо поки не буде кінця файлу
                    for (int i = 0; i < rows; i++)
                    {
                        line = r.ReadLine();
                        //визначити який тип продукту нам записали
                        int elements = line.Split().Length;
                        //якщо дано 5 елементів, то це клас Product
                        //Product і DairyProduct однакові, у обох є термін придатності
                        if (elements == 5)
                        {
                            products.Add(new Product());
                            products[i].Parse(line);
                        }
                        //якщо 6 елем, то це класс Meat
                        else if (elements == 6)
                        {
                            products.Add(new Product());
                            products[i].Parse(line);
                        }
                        else
                        {
                            throw new ArgumentException("Wrong number of elements in text");
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
        }

        //перевіряє дати пригодністі всіх елементів у storage-------------
        public void CheckExpirationDate(string pathToWrite)
        {
            //зберігає індекси, що треба знищити
            int[] indexesToRemove = new int[products.Count];
            int cout = 0;
            for (int i = 0; i < products.Count; i++)
            {
                //Substract порінює дві дати і вертає різницю між ними у TimeSpan
                //Порівнюємо з теперішньою датою
                TimeSpan difference = DateTime.Now.Subtract(this[i].CreationDay);
                //отримує скільки днів минуло
                int daysPassed = (int)difference.TotalDays;
                //якщо термін пригодністі сплив
                //додаємо у список на вилучення
                if (daysPassed > products[i].ExpirationDay)
                {
                    indexesToRemove[cout] = i;
                    cout++;
                }
            }
            //вилучаємо просрочені елементи
            //і записуємо їх у файл
            using (StreamWriter writer = new StreamWriter(pathToWrite))
            {
                for (int i = 0; i < cout; i++)
                {
                    writer.WriteLine(products[indexesToRemove[i]]);
                    //видаляємо з масиву просрочені продукти через where
                    products = (List<Product>)products.Where((source, index) => index != indexesToRemove[i]);
                    //зменшуємо індекси для вилучення
                    //оскільки масив зменшився
                    for (int k = i + 1; k < cout; k++)
                    {
                        indexesToRemove[k]--;
                    }
                }
            }
        }

        //вивестю всю інформацію-----------------
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < products.Count; i++)
            {
                res += String.Format("№{0}->{1}\n", i + 1, products[i].ToString());
            }
            return res;
        }

        //знайти м'ясні масиви-----------------
        public Meat[] FindMeatProducts()
        {
            return (Meat[])products.Where(x => x is Meat).ToArray();
        }

        //індексатор-----------------
        public Product this[int index]
        {

            get
            {
                try
                {
                    return products[index];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wrong index");
                    return new Product();
                }
            }
            set
            {
                try
                {
                    products[index] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wrong index");
                }

            }

        }
        //змінити ціни у всіх------------------------
        public void ChangeAllPrice(int interest)
        {
            foreach (var item in products)
            {
                item.ChangePrice(interest);
            }
        }
        //енумератор-------------------
        public IEnumerator<Product> GetEnumerator()
        {
            return new StorageEnumerator(products);
        }

    }
    //Клас Енумератор для Storage--------
    class StorageEnumerator: IEnumerator<Product>
    {
        List<Product> products;
        int position = -1;

        public StorageEnumerator(List<Product> products)
        {
            this.products = products;
        }
        public Product Current
        {
            get
            {
                if (position == -1 || position >= products.Count)
                    throw new InvalidOperationException("Wrong position");
                return products[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose(){}

        public bool MoveNext()
        {
            if (position < products.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
