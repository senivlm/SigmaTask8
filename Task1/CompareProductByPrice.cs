using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SigmaTask8.Task1
{
    class CompareProductByPrice : IComparer<Product>
    {
        public int Compare([AllowNull] Product x, [AllowNull] Product y)
        {
            return x.PriceOfProduct.CompareTo(y.PriceOfProduct);
        }
    }
}
