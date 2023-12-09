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
    public partial class tablaClientes : ContentPage
    {
        public tablaClientes()
        {
            InitializeComponent();
            BindingContext = new VMtablaClientes(Navigation);
            
        }

         void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _buscarcliente = BindingContext as VMtablaClientes;
            ListViewName.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                ListViewName.ItemsSource = _buscarcliente.clientesCollection;
            }
            else
            {
                
                ListViewName.ItemsSource = _buscarcliente.clientesCollection.Where(i => i.Nombre.Contains(e.NewTextValue) || i.Telefono.Contains(e.NewTextValue));
            }

            ListViewName.EndRefresh();
        }

        private async void ListViewName_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new editarCliente(e.SelectedItem as Mcliente));

        }
    }
}