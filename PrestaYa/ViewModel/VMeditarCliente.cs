using GalaSoft.MvvmLight.Command;
using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMeditarCliente : BaseViewModel
    {

        PrestamoRepository prestamorepository = new PrestamoRepository();

        #region Variables
        
        private string id;
        private string nombre;
        private string telefono;
        private bool status;
        private string direccion;
        #endregion
        #region Constructores
        public VMeditarCliente(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMeditarCliente(Mcliente _Mcliente)
        {
            Txtid = _Mcliente.Id;
            Txtnombre = _Mcliente.Nombre;
            Txttelefono = _Mcliente.Telefono;
            Txtstatus = _Mcliente.Status;
            Txtdireccion = _Mcliente.Direccion;
            
        }
        #endregion
        #region Objetos
        public string Txtid
        {
            get { return id; }
            set => SetValue(ref id, value);
        }
        public string Txtnombre
        {
            get { return nombre; }
            set => SetValue(ref nombre, value);
        }
        public string Txttelefono
        {
            get { return telefono; }
            set => SetValue(ref telefono, value);
        }
        public string Txtdireccion
        {
            get { return direccion; }
            set => SetValue(ref direccion, value);
        }
        public bool Txtstatus
        {
            get { return status; }
            set { SetValue(ref status, value); }
        }
        #endregion
        #region Procesos
        public async Task Asyncprocess()
        {

        }
        private async void UpdateMethod()
        {
            var person = new Mcliente
            {
                Id = Txtid,
                Nombre = Txtnombre,
                Telefono = Txttelefono,
                Direccion = Txtdireccion,
                Status = Txtstatus,
            };

            await prestamorepository.Updatecliente(person);

            await App.Current.MainPage.Navigation.PushAsync(new tablaClientes());
        }
        private async void DeleteMethod()
        {
           await prestamorepository.Deletecliente(Txtid);
            await App.Current.MainPage.Navigation.PushAsync(new tablaClientes());

        }
        public void process() { }


        #endregion
        #region Comandos
        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(UpdateMethod);
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteMethod);
            }
        }
        public ICommand Asyncprocesscommand => new Command(async () => await Asyncprocess());
        public ICommand processcommand => new Command(process);
        #endregion
    }
}

