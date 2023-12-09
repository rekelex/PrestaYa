using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMmenu : BaseViewModel
    {

        #region Variables
        string _text;
        #endregion
        #region Constructores
        public VMmenu(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMmenu(INavigation navigation, string usuario)
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
        public async Task maintenancego()
        {
            await Navigation.PushAsync(new mantenimiento());
        }
        public async Task reportego()
        {
            await Navigation.PushAsync(new tablaPrestamo());
        }
        public async Task ayudago()
        {
            await Navigation.PushAsync(new insertarCliente());
        }
        public async Task nextin()
        {
            await Navigation.PushAsync(new tablaPrestamo());
        }
    
        public void process() { }


        #endregion
        #region Comandos

        public ICommand Maintenancecommand => new Command(async () => await maintenancego());
        public ICommand Reportecommand => new Command(async () => await reportego());
        public ICommand Ayudacommand => new Command(async () => await ayudago());

        public ICommand intecommand => new Command(async () => await nextin());
        public ICommand processcommand => new Command(process);
        #endregion
    }
}

