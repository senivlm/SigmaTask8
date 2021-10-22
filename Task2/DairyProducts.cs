using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaTask8.Task1
{
    class DairyProducts : Product
    {
        //з днями придатності

        public DairyProducts()
        : this(new DateTime(2020, 1, 1), 0, 0, "N/A", 0) { }

        public DairyProducts(DateTime time, double price = 0, double weight = 0,
            string name = "N/A", int exDay = 0) : base(time, price, weight, name, exDay = 0)
        {
        }
        //Equal
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var other = obj as DairyProducts;
            return ((this.NameOfProduct == other.NameOfProduct) && (this.ExpirationDay == other.ExpirationDay));
        }
        //ToString
        public override string ToString()
        {
            return base.ToString();
        }
        //змінити ціну
        public override void ChangePrice(int interest)
        {
            if (interest < 0) { interest = 0; }

            double d_interest = ((double)interest) / 100 + ((double)ExpirationDay) / 100;


            this.PriceOfProduct = this.PriceOfProduct +
                this.PriceOfProduct * d_interest;
        }
    }
}
