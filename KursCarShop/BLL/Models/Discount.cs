using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Discount
    {
        public Discount(decimal val)
        {
            _value = val;
        }

        private decimal _value = 0;
        public decimal Value { get { return _value; } }

        public decimal GetDiscountedPrice(decimal sum)
        {
            if (sum > 1000000)
                return sum - sum * _value;
            return sum;
        }
    }
}
