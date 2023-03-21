using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using hospital.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace hospital.Viewmodels
{
    public class ViewModelCitas : INotifyPropertyChanged
    {

        public ViewModelCitas()
        {



            crearPersonas = new Command(async () => {


                using (var httpClient = new HttpClient())
                {

                    Citas body1 = new Citas()
                    {
                        Fecha = this.fecha,
                        Hora = this.hora,
                        IDPaciente = this.idpaciente,
                        IDMedico =this.idmedico,
                        IDCita = this.idcita
                    };

                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });


            actualizarPersona = new Command(async () => {

                using (var httpClient = new HttpClient())
                {

                    Citas body1 = new Citas()
                    {
                        Fecha = this.fecha,
                        Hora = this.hora,
                        IDPaciente = this.idpaciente,
                        IDMedico = this.idmedico,
                        IDCita = this.idcita
                    };

                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + "/" + personaSeleccionada.IDCita, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });

            borrarPersona = new Command(async () => {

                using (var httpClient = new HttpClient())
                {

                    var respuesta = await httpClient.DeleteAsync(url + "/" + personaSeleccionada.IDCita);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });


            actualizarFormulario = new Command(() => {

                Fecha = personaSeleccionada.Fecha;
                Hora = personaSeleccionada.Hora;
                Idpaciente = personaSeleccionada.IDPaciente;
                Idmedico= personaSeleccionada.IDMedico;
                Idcita=personaSeleccionada.IDCita;

                

            });



            getPersonas();

        }

        private async void getPersonas()
        {

            ListPersonas = new ObservableCollection<Citas>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            Debug.WriteLine(respuesta);

            if (respuesta.IsSuccessStatusCode)
            {
               
                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true

                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Citas>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
        }

        ObservableCollection<Citas> listPersonas = new ObservableCollection<Citas>();

        public ObservableCollection<Citas> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string url = "https://desfrlopez.me/jnavarro/api/lcitas";

        TimeSpan hora;
        public TimeSpan Hora
        {

            get => hora;
            set
            {

                hora = value;
                var args = new PropertyChangedEventArgs(nameof(Hora));
                PropertyChanged?.Invoke(this, args);

            }

        }

        int idpaciente;
        public int Idpaciente
        {

            get => idpaciente;
            set
            {

                idpaciente = value;
                var args = new PropertyChangedEventArgs(nameof(Idpaciente));
                PropertyChanged?.Invoke(this, args);

            }

        }

        int idmedico;
        public int Idmedico
        {

            get => idmedico;
            set
            {

                idmedico = value;
                var args = new PropertyChangedEventArgs(nameof(Idmedico));
                PropertyChanged?.Invoke(this, args);

            }

        }


        int idcita;
        public int Idcita
        {

            get => idcita;
            set
            {

                idcita = value;
                var args = new PropertyChangedEventArgs(nameof(Idcita));
                PropertyChanged?.Invoke(this, args);

            }

        }

        DateTime fecha;
        public DateTime Fecha
        {

            get => fecha;
            set
            {

                fecha = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha));
                PropertyChanged?.Invoke(this, args);

            }

        }


        Citas personaSeleccionada = new Citas();

        public Citas PersonaSeleccionada
        {

            get => personaSeleccionada;
            set
            {

                personaSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(PersonaSeleccionada));
                PropertyChanged?.Invoke(this, args);

            }

        }


        public DateTime FechaMin { get; set; } = new DateTime(1980, 01, 01);


        public Command crearPersonas { get; }
        public Command actualizarFormulario { get; }
        public Command actualizarPersona { get; set; }
        public Command borrarPersona { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
