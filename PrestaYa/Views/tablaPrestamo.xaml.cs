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
    public partial class tablaPrestamo : ContentPage
    {
        public tablaPrestamo()
        {
            InitializeComponent();
            BindingContext = new VMtablaPrestamo(Navigation);
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _buscarcliente = BindingContext as VMtablaPrestamo;
            ListViewName.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                ListViewName.ItemsSource = _buscarcliente.prestamosCollection;
            }
            else
            {

                ListViewName.ItemsSource = _buscarcliente.prestamosCollection.Where(i => i.Monto.Contains(e.NewTextValue) || i.Tasa.Contains(e.NewTextValue) || i.Periodicidad.Contains(e.NewTextValue));
            }

            ListViewName.EndRefresh();
        }

        private async void ListViewName_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new editarPrestamo(e.SelectedItem as MPrestamo));
        }
    }
}