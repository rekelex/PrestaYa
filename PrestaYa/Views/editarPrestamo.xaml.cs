using PrestaYa.Model;
using PrestaYa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrestaYa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editarPrestamo : ContentPage
    {
        public editarPrestamo()
        {
            InitializeComponent();
            BindingContext = new VMeditarPrestamo(Navigation);
        }
        public editarPrestamo(MPrestamo _MPrestamo)
        {
            InitializeComponent();
            BindingContext = new VMeditarPrestamo(_MPrestamo);
        }
    }
}