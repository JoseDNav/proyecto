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
    public class ViewModelResultados : INotifyPropertyChanged
    {

        public ViewModelResultados()
        {



            crearPersonas = new Command(async () => {


                using (var httpClient = new HttpClient())
                {

                    Resultados body1 = new Resultados()
                    {
                        IDResultado = this.idresultado,
                        IDExamen = this.idexamen,
                        IDPaciente = this.idpaciente,
                        Resultado = this.resultadoE,
                        Fecha = this.fecha

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

                    Resultados body1 = new Resultados()
                    {
                        IDResultado = this.idresultado,
                        IDExamen = this.idexamen,
                        IDPaciente = this.idpaciente,
                        Resultado = this.resultadoE,
                        Fecha = this.fecha

                    };

                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PutAsync(url + "/" + personaSeleccionada.IDResultado, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        getPersonas();

                    }

                }

            });

            borrarPersona = new Command(async () => {

                using (var httpClient = new HttpClient())
                {

                    var respuesta = await httpClient.DeleteAsync(url + "/" + personaSeleccionada.IDResultado);

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

            ListPersonas = new ObservableCollection<Resultados>();

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
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<Resultados>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
        }

        ObservableCollection<Resultados> listPersonas = new ObservableCollection<Resultados>();

        public ObservableCollection<Resultados> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        string url = "https://desfrlopez.me/jnavarro/api/lresultadosexamenes";

        int idresultado;
        public int IDresultado
        {

            get => idresultado;
            set
            {

                idresultado = value;
                var args = new PropertyChangedEventArgs(nameof(IDresultado));
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

        int idexamen;
        public int IDexamen
        {

            get => idexamen;
            set
            {

                idexamen = value;
                var args = new PropertyChangedEventArgs(nameof(IDexamen));
                PropertyChanged?.Invoke(this, args);

            }

        }


        string resultadoE;
        public string ResultadoE
        {

            get => resultadoE;
            set
            {

                resultadoE = value;
                var args = new PropertyChangedEventArgs(nameof(ResultadoE));
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


        Resultados personaSeleccionada = new Resultados();

        public Resultados PersonaSeleccionada
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
