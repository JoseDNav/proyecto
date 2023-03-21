using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Citas
    {
        public int IDCita { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int IDPaciente { get; set; }

        public int IDMedico { get; set; }

        public string ToJson()
        {
            return "{\"Fecha\": \"" + Fecha + "\", \"Hora\": \"" + Hora + "\", \"IDPaciente\": " + IDPaciente + ", \"IDMedico\": " + IDMedico + "}";
        }

    }


}
