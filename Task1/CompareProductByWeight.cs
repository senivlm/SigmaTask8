using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SigmaTask8.Task1
{
    class CompareProductByWeight: IComparer<Product>
    {
        public int Compare([AllowNull] Product x, [AllowNull] Product y)
        {
            return x.WeightOfProduct.CompareTo(y.WeightOfProduct);
        }
    }
}
