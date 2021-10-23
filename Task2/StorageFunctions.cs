using SigmaTask8.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigmaTask8.Task2
{
    static class StorageFunctions
    {
        //знайти подібні продукти------------------------------------
        public static List<Product> GetSimilarProducts(Storage st1, Storage st2)
        {
            if (st1 == null || st2 == null)
                throw new ArgumentNullException("Storage is null");
            //знаходимо однакові через Where, Contains і лямба функцію
            List<Product> similarProducts = (List<Product>) st1.Products.Where(productFromSt1 =>st2.Products.Contains(productFromSt1));
            return similarProducts;
        }
        //всі різні продукти з двох сховищ--------------------
        public static List<Product> GetAllUniqueProducts(Storage st1, Storage st2)
        {
            if (st1 == null || st2 == null)
                throw new ArgumentNullException("Storage is null");


            return new List<Product>();
        }
        //Знайти всі товари, які є в першому складі,  яких немає в 2 складі-----------------
        public static List<Product> GetProductsInFirstStore(Storage st1, Storage st2)
        {
            return new List<Product>();
        }

    }
}
