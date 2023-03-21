using hospital.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace hospital.Viewmodels
{
    internal class ViewModelHospitales : INotifyPropertyChanged
    {

        public ViewModelHospitales()
        {



            crearPersonas = new Command(async () => {


                using (var httpClient = new HttpClient())
                {

                    Hospitales body1 = new Hospitales()
                    {
                        IDHospitalizacion = this.idhospitales,
                        IDPaciente = this.idpaciente,
                        IDHabitacion = this.idhabitacion,
                        FechaEntrada = this.fechaentrada,
                        FechaSalida = this.fechasalida

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

                    Hospitales body1 = new Hospitales()
                    {
                        IDHospitalizacion = this.idhospitales,
                        IDPaciente = this.idpaciente,
                        IDHabitacion = this.idhabitacion,
                        FechaEntrada = this.fechaentrada,
                        FechaSalida = this.fechasalida

                    };

                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + "/" + personaSeleccionada.IDHospitalizacion, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });

            borrarPersona = new Command(async () => {

                using (var httpClient = new HttpClient())
                {

                    var respuesta = await httpClient.DeleteAsync(url + "/" + personaSeleccionada.IDHospitalizacion);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });






            getPersonas();

        }

        private async void getPersonas()
        {

            ListPersonas = new ObservableCollection<Hospitales>();

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
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Hospitales>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
        }

        ObservableCollection<Hospitales> listPersonas = new ObservableCollection<Hospitales>();

        public ObservableCollection<Hospitales> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string url = "https://desfrlopez.me/jnavarro/api/lhospitalizaciones";

        int idhospitales;
        public int IDhospitales
        {

            get => idhospitales;
            set
            {

                idhospitales = value;
                var args = new PropertyChangedEventArgs(nameof(IDhospitales));
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

        int idhabitacion;
        public int IDhabitacion
        {

            get => idhabitacion;
            set
            {

                idhabitacion = value;
                var args = new PropertyChangedEventArgs(nameof(IDhabitacion));
                PropertyChanged?.Invoke(this, args);

            }

        }


        DateTime fechaentrada;
        public DateTime Fechaentrada
        {

            get => fechaentrada;
            set
            {

                fechaentrada = value;
                var args = new PropertyChangedEventArgs(nameof(Fechaentrada));
                PropertyChanged?.Invoke(this, args);

            }

        }

        DateTime fechasalida;
        public DateTime Fechasalida
        {

            get => fechasalida;
            set
            {

                fechasalida = value;
                var args = new PropertyChangedEventArgs(nameof(Fechasalida));
                PropertyChanged?.Invoke(this, args);

            }

        }


        Hospitales personaSeleccionada = new Hospitales();

        public Hospitales PersonaSeleccionada
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
