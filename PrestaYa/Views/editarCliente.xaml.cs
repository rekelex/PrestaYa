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
    public partial class editarCliente : ContentPage
    {
        public editarCliente()
        {
            InitializeComponent();
            BindingContext = new VMeditarCliente(Navigation);
        }
        public editarCliente(Mcliente _Mcliente)
        {
            InitializeComponent();
            BindingContext = new VMeditarCliente(_Mcliente);
        }
    }
}