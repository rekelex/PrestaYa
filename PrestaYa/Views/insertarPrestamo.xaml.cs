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
    public partial class insertarPrestamo : ContentPage
    {
        public insertarPrestamo()
        {
            InitializeComponent();
            BindingContext = new VMinsertarPrestamo(Navigation);
        }
    }
}