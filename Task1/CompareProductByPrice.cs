using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SigmaTask8.Task1
{
    class CompareProductByPrice : IComparer<Object>
    {
        public int Compare([AllowNull] Object x, [AllowNull] Object y)
        {
            Product p1 = x as Product;
            Product p2 = y as Product;
            return p1.PriceOfProduct.CompareTo(p2.PriceOfProduct);
        }
    }
}
