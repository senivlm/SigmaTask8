using SigmaTask8.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigmaTask8.Task2
{
    static class StorageFunctions
    {
        //знайти подібні продукти у обох сховищах------------------------------------
        public static List<Product> GetSimilarProducts(Storage st1, Storage st2)
        {
            if (st1 == null || st2 == null)
                throw new ArgumentNullException("Storage is null");
            //знаходимо однакові імена через Where, де прописуємо лямба функцію
            //продукти мають бути однакові, тому можна використати функцію Contains
            //під кнець перетвоюємо масив у список
            return st1.Products.Where((prodFromSt1) => st2.Products.Contains(prodFromSt1)).ToList();
        }
        //всі різні продукти з двох сховищ--------------------
        public static SortedSet<Product> GetAllUniqueProducts(Storage st1, Storage st2)
        {
            if (st1 == null || st2 == null)
                throw new ArgumentNullException("Storage is null");

            //Set не позволить продуктам повторитись
            //однакові продукти - це ті, що мають однакове ім'я
            SortedSet<Product> uniqueProducts = new SortedSet<Product>(new CompareProductByName());
            //проходимось по кожному сховищу і додаємо
            foreach(var prod in st1)
            {
                uniqueProducts.Add(prod);
            }
            foreach (var prod in st2)
            {
                uniqueProducts.Add(prod);
            }
            return uniqueProducts;
        }
        //Знайти всі товари, які є в першому складі,яких немає в 2 складі-----------------
        public static List<Product> GetProductsInFirstStore(Storage st1, Storage st2)
        {
            if (st1 == null || st2 == null)
                throw new ArgumentNullException("Storage is null");

            //те саме, але при оберненій дії
            return st1.Products.Where((prodFromSt1) => !(st2.Products.Contains(prodFromSt1))).ToList();
        }

    }
}
