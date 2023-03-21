using System;
using System.Collections.Generic;
using System.Text;

namespace hospital.Models
{
    public class Hospitales
    {
        public int IDHospitalizacion { get; set; }

        public int IDPaciente { get; set; }

        public int IDHabitacion { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        public string ToJson()
        {
            return "{\"IDPaciente\": \"" + IDPaciente + "\", \"IDHabitacion\": \"" + IDHabitacion + "\", \"FechaEntrada\": \"" + FechaEntrada + "\", \"FechaSalida\": \"" + FechaSalida + "\"}";
        }


    }
}
