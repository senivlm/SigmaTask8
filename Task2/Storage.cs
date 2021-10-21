//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SigmaTask8.Task1
//{
//    class Storage
//    {
//        private int sizeOfArr;
//        Product[] products;

//        //за замовчуванням--------------------------
//        public Storage()
//        {
//            sizeOfArr = 1;
//            products = new Product[sizeOfArr];
//            for (int i = 0; i < sizeOfArr; i++)
//            {
//                products[i] = new Product();
//            }
//        }
//        //вводить користувач через консоль--------------
//        public Storage(bool UserTry) : this()
//        {
//            try
//            {
//                string input;
//                int variety;
//                if (UserTry == true)
//                {
//                    //розмір масиву
//                    Console.WriteLine("How many products do you want(>=0)?");
//                    input = Console.ReadLine();

//                    //поки не отримуємо потрібне число
//                    while ((!Int32.TryParse(input, out sizeOfArr)) || (sizeOfArr < 0))
//                    {
//                        Console.WriteLine("Wrong input");
//                        input = Console.ReadLine();
//                    }
//                    products = new Product[sizeOfArr];

//                    int counter = 0;
//                    while (counter < sizeOfArr)
//                    {
//                        //вибираємо варіант product
//                        Console.WriteLine("Choose variety: 1->Meat\t 2->Dairy Product\t 3->Product");
//                        input = Console.ReadLine();
//                        while ((!Int32.TryParse(input, out variety)) || (variety < 1) || (variety > 3))
//                        {
//                            Console.WriteLine("Wrong input");
//                            input = Console.ReadLine();
//                        }
//                        //загальні поля
//                        double price;
//                        double weight;
//                        string name;
//                        int exDay;
//                        DateTime date;
//                        //уточняємо інформацію по виду продукту
//                        //м'ясо
//                        if (variety == 1)
//                        {
//                            int category;
//                            int type;
//                            //тип м'яса (одночасно це і його ім'я)
//                            Console.WriteLine("Choose type: 1->Lamb\t2->Veal\t3->Pork\t4->Chicken");
//                            input = Console.ReadLine();
//                            while ((!Int32.TryParse(input, out type)) || (type < 1) || (type > 4))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //категорія
//                            Console.WriteLine("Choose category: 1->High_sort\t 2->I_sort\t3->II_sort");
//                            input = Console.ReadLine();
//                            while ((!Int32.TryParse(input, out category)) || (category < 1) || (category > 3))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //ціну
//                            Console.WriteLine("Write price(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out price)) || (price < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //вага
//                            Console.WriteLine("Write weight(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out weight)) || (weight < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //дні придатності
//                            Console.WriteLine("Write Expitation day(>0)");
//                            input = Console.ReadLine();
//                            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //дата створення
//                            Console.WriteLine("Write creation date(12:08:2001)");
//                            input = Console.ReadLine();
//                            string[] str_date = input.Split(':');
//                            int day, month, year;
//                            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
//                               !Int32.TryParse(str_date[1], out month) || (month < 1) ||
//                               !Int32.TryParse(str_date[2], out year) || (year < 1900))
//                            {
//                                Console.WriteLine("Wrong Date");
//                                input = Console.ReadLine();
//                            }
//                            date = new DateTime(year, month, day);


//                            //створюємо об'єкт з отриманих даних і додаємо в масив
//                            products[counter] = new Meat(date, price, weight, "N/A", exDay, category, type);
//                        }
//                        //молочні
//                        else if (variety == 2)
//                        {
//                            int exdays;

//                            //ім'я продукту
//                            Console.WriteLine("Write name of product");
//                            name = Console.ReadLine();
//                            //ціна
//                            Console.WriteLine("Write price(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out price)) || (price < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //вага
//                            Console.WriteLine("Write weight(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out weight)) || (weight < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //дні придатності
//                            Console.WriteLine("Write Expitation day(>0)");
//                            input = Console.ReadLine();
//                            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //дата створення
//                            Console.WriteLine("Write creation date(12:08:2001)");
//                            input = Console.ReadLine();
//                            string[] str_date = input.Split(':');
//                            int day, month, year;
//                            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
//                               !Int32.TryParse(str_date[1], out month) || (month < 1) ||
//                               !Int32.TryParse(str_date[2], out year) || (year < 1900))
//                            {
//                                Console.WriteLine("Wrong Date");
//                                input = Console.ReadLine();
//                            }
//                            date = new DateTime(year, month, day);


//                            //створюємо об'єкт з отриманих даних і додаємо в масив
//                            products[counter] = new DairyProducts(date, price, weight, "N/A", exDay);
//                        }
//                        //звичайний
//                        else
//                        {
//                            //все те саме, але без спеціальних особливостей
//                            Console.WriteLine("Write price(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out price)) || (price < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            Console.WriteLine("Write weight(>0)");
//                            input = Console.ReadLine();
//                            while ((!Double.TryParse(input, out weight)) || (weight < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            Console.WriteLine("Write name of product");
//                            name = Console.ReadLine();
//                            //дні придатності
//                            Console.WriteLine("Write Expitation day(>0)");
//                            input = Console.ReadLine();
//                            while ((!Int32.TryParse(input, out exDay)) || (exDay < 0))
//                            {
//                                Console.WriteLine("Wrong input");
//                                input = Console.ReadLine();
//                            }
//                            //дата створення
//                            Console.WriteLine("Write creation date(12:08:2001)");
//                            input = Console.ReadLine();
//                            string[] str_date = input.Split(':');
//                            int day, month, year;
//                            while (!Int32.TryParse(str_date[0], out day) || (day < 1) ||
//                               !Int32.TryParse(str_date[1], out month) || (month < 1) ||
//                               !Int32.TryParse(str_date[2], out year) || (year < 1900))
//                            {
//                                Console.WriteLine("Wrong Date");
//                                input = Console.ReadLine();
//                            }
//                            date = new DateTime(year, month, day);


//                            products[counter] = new Product(date, price, weight, "N/A", exDay);
//                        }
//                        counter++;
//                    }
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        //конструктор через готовий список------------------
//        public Storage(Product[] arr)
//        {
//            try
//            {
//                if (arr.Length == 0)
//                    throw new ArgumentException("Cannot be empty array");
//                this.products = new Product[arr.Length];
//                for (int i = 0; i < arr.Length; i++)
//                {
//                    products[i] = arr[i];
//                }
//                sizeOfArr = arr.Length;
//            }
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        //конструктор через зчитування з файлу-------------
//        public Storage(string path)
//        {
//            ReadFromFile(path);
//        }

//        //отримати інформацію з файлу--------------------
//        public void ReadFromFile(string path)
//        {
//            try
//            {
//                if (File.Exists(path))
//                {
//                    using (StreamReader r = new StreamReader(path))
//                    {
//                        //кількість рядків 
//                        string line = r.ReadLine();
//                        int rows;
//                        if (!Int32.TryParse(line, out rows))
//                        {
//                            throw new ArgumentException("Wrong Rows input");
//                        }
//                        //оновлюємо розмір масиву
//                        this.products = new Product[rows];

//                        //зчитуємо поки не буде кінця файлу
//                        for (int i = 0; i < rows; i++)
//                        {
//                            line = r.ReadLine();
//                            //визначити який тип продукту нам записали
//                            int elements = line.Split().Length;
//                            //якщо дано 5 елементів, то це клас Product
//                            //Product і DairyProduct однакові, у обох є термін придатності
//                            if (elements == 5)
//                            {
//                                products[i] = new Product();
//                                products[i].Parse(line);
//                            }
//                            //якщо 6 елем, то це класс Meat
//                            else if (elements == 6)
//                            {
//                                products[i] = new Meat();
//                                products[i].Parse(line);
//                            }
//                            else
//                            {
//                                throw new ArgumentException("Wrong number of elements in text");
//                            }
//                        }
//                    }

//                }
//                else
//                {
//                    throw new FileNotFoundException("File not found");
//                }
//            }
//            catch (FileNotFoundException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        //перевіряє дати пригодністі всіх елементів у storage
//        public void CheckExpirationDate(string pathToWrite)
//        {
//            try
//            {
//                //зберігає індекси, що треба знищити
//                int[] indexesToRemove = new int[products.Length];
//                int cout = 0;
//                for (int i = 0; i < products.Length; i++)
//                {
//                    //Substract порінює дві дати і вертає різницю між ними у TimeSpan
//                    //Порівнюємо з теперішньою датою
//                    TimeSpan difference = DateTime.Now.Subtract(this[i].CreationDay);
//                    //отримує скільки днів минуло
//                    int daysPassed = (int)difference.TotalDays;
//                    //якщо термін пригодністі сплив
//                    //додаємо у список на вилучення
//                    if (daysPassed > products[i].ExpirationDay)
//                    {
//                        indexesToRemove[cout] = i;
//                        cout++;
//                    }
//                }
//                //вилучаємо просрочені елементи
//                //і записуємо їх у файл
//                using (StreamWriter writer = new StreamWriter(pathToWrite))
//                {
//                    for (int i = 0; i < cout; i++)
//                    {
//                        writer.WriteLine(products[indexesToRemove[i]]);
//                        //видаляємо з масиву просрочені продукти через where
//                        products = products.Where((source, index) => index != indexesToRemove[i]).ToArray();
//                        //зменшуємо індекси для вилучення
//                        //оскільки масив зменшився
//                        for (int k = i + 1; k < cout; k++)
//                        {
//                            indexesToRemove[k]--;
//                        }
//                    }
//                }
//            }
//            catch (IOException ex)
//            {
//                Console.WriteLine("File is still open: " + ex.Message);
//            }
//            catch (ArgumentOutOfRangeException ex)
//            {
//                Console.WriteLine("Cannot calculate date " + ex.Message);
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                Console.WriteLine("index out of range " + ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }

//        //вивестю всю інформацію-----------------
//        public override string ToString()
//        {
//            string res = "";
//            for (int i = 0; i < products.Length; i++)
//            {
//                res += String.Format("№{0}->{1}\n", i + 1, products[i].ToString());
//            }
//            return res;
//        }

//        //знайти м'ясні масиви-----------------
//        public Meat[] FindMeatProducts()
//        {
//            Meat[] arr;
//            int counter = 0; ;
//            foreach (var item in products)
//            {
//                if (item.GetType() == typeof(Meat))
//                {
//                    counter++;
//                }
//            }
//            arr = new Meat[counter];
//            counter = 0;
//            for (int i = 0; i < products.Length; i++)
//            {
//                if (products[i].GetType() == typeof(Meat))
//                {
//                    arr[counter] = (Meat)products[i];
//                    counter++;
//                }
//            }
//            return arr;
//        }

//        //індексатор-----------------
//        public Product this[int index]
//        {

//            get
//            {
//                try
//                {
//                    return products[index];
//                }
//                catch (IndexOutOfRangeException)
//                {
//                    Console.WriteLine("Wrong index");
//                    return new Product();
//                }
//            }
//            set
//            {
//                try
//                {
//                    products[index] = value;
//                }
//                catch (IndexOutOfRangeException)
//                {
//                    Console.WriteLine("Wrong index");
//                }

//            }

//        }
//        //змінити ціни у всіх------------------------
//        public void ChangeAllPrice(int interest)
//        {
//            foreach (var item in products)
//            {
//                item.ChangePrice(interest);
//            }
//        }

//    }
//}
