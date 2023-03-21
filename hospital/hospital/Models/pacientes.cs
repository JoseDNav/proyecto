using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class pacientes
    {
        public int IDPaciente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string ToJson()
        {
            return "{\"Nombre\": \"" + Nombre + "\"}";
        }


    }
}
