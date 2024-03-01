using Fauna.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaunaDBApp.Modelos
{
    [Object]
    internal class Producto
    {
        [Field("name")]
        public string? Name { get; set; }

        [Field("description")]
        public string? Description { get; set; }

        [Field("price")]
        public double Price { get; set; }

        [Field("quantity")]
        public int Quantity { get; set; }

        [Field("backorderLimit")]
        public int BackorderLimit { get; set; }

        [Field("backordered")]
        public bool Backordered { get; set; } = false;
    }
}
