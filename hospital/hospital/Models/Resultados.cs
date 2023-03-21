using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Resultados
    {
        public int IDResultado { get; set; }

        public string IDExamen { get; set; }

        public string IDPaciente { get; set; }

        public string Resultado { get; set; }

        public string Fecha { get; set; }

        public string ToJson()
        {
            return "{\"IDExamen\": \"" + IDExamen + "\", \"IDPaciente\": \"" + IDPaciente + "\", \"Resultado\": \"" + Resultado + "\", \"Fecha\": \"" + Fecha + "\"}";
        }

    }
}
