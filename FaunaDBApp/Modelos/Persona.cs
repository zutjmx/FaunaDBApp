using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fauna.Mapping.Attributes;

namespace FaunaDBApp.Modelos
{
    [Object]
    internal class Persona
    {
        // Property names are automatically converted to camelCase.
        [Field]
        public string? Id { get; set; }

        [Field("nombre")]
        public string? Nombre { get; set; }

        [Field("paterno")]
        public string? Paterno { get; set; }

        [Field("materno")]
        public string? Materno { get; set; }

        [Field]
        public int Edad { get; set; }
    }
}
