using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Examenes
    {
        public int IDExamen { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Costo { get; set; }

        public string ToJson()
        {
            return "{\"Nombre\": \"" + Nombre + "\"}";
        }

    }
}
