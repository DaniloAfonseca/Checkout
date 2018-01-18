using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Contracts
{
    public class Product
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public Offer SpecialOffer { get; set; }
    }
}
