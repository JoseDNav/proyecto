using hospital.Viewmodels;
using hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCitas : ContentPage
    {
        public ViewCitas()
        {
            InitializeComponent();
            BindingContext = new MyViewModel();
        }
    }
}