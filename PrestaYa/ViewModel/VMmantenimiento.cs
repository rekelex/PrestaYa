using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMmantenimiento : BaseViewModel
    {

        #region Variables
        string _text;
        #endregion
        #region Constructores
        public VMmantenimiento(INavigation navigation)
        {
            Navigation = navigation;
            
        }

        #endregion
        #region Objetos
        public string Text
        {
            get { return _text; }
            set => SetValue(ref _text, value);
        }

        #endregion
        #region Procesos
        public async Task clientesir()
        {
            await Navigation.PushAsync(new tablaClientes());

        }
        public async Task prestamosir()
        {
            await Navigation.PushAsync(new tablaPrestamo());
        }
        public void process() { }
        
        #endregion
        #region Comandos

        public ICommand clientecommand => new Command(async () => await clientesir());
        public ICommand prestamocommand => new Command(async () => await prestamosir());

        public ICommand processcommand => new Command(process);
        #endregion
    }
}
