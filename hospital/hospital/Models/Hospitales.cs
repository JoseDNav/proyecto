using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Hospitales
    {
        public int IDHospitalizacion { get; set; }

        public string IDPaciente { get; set; }

        public string IDHabitacion { get; set; }

        public string FechaEntrada { get; set; }

        public string FechaSalida { get; set; }

        public string ToJson()
        {
            return "{\"IDPaciente\": \"" + IDPaciente + "\", \"IDHabitacion\": \"" + IDHabitacion + "\", \"FechaEntrada\": \"" + FechaEntrada + "\", \"FechaSalida\": \"" + FechaSalida + "\"}";
        }


    }
}
