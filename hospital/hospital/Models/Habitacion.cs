using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Habitacion
    {
        public int IDHabitacion { get; set; }

        public string Numero { get; set; }

        public string Tipo { get; set; }

        public string Precio { get; set; }

        public string ToJson()
        {
            return "{\"Numero\": \"" + Numero + "\"}";
        }
    }
}
