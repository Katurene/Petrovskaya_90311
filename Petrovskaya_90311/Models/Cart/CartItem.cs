using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Models.Cart
{
    public class CartItem
    {
        public Animal Animal { get; set; }
        public int Quantity { get; set; }
    }
}
