using hospital.Models;
using hospital.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Text.Json;
using System.Runtime.Serialization.Json;

namespace hospital.Viewmodels
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public ViewModelMainPage()
        {
            inicioSesion = new Command(async () => {


                HttpClient cliente = new HttpClient();

                var respuesta = await cliente.GetAsync(url + "/" + this.usuario + "/" + this.pass);

                if (respuesta.IsSuccessStatusCode)
                {

                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    var inicioSesion = System.Text.Json.JsonSerializer.Deserialize<List<login>>(contenido);

                    if (inicioSesion[0].is_valid == 1)
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            await Application.Current.MainPage.Navigation.PushAsync(new Inicio());
                        });
                    }
                    else
                    {
                        Resultado = "Inicio de Sesión Erroneo";
                    }
                }
            });




        }

        string url = "https://desfrlopez.me/jnavarro/api/login";

        string usuario;
        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string pass;
        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command inicioSesion { get; }

        public Command registro { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
