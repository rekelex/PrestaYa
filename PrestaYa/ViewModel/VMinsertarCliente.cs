using GalaSoft.MvvmLight.Command;
using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMinsertarCliente : BaseViewModel
    {
        PrestamoRepository prestamorepositorio = new PrestamoRepository();
        VMtablaClientes tablaclient = new VMtablaClientes();
        #region Variables
        string nombre;
        string telefono;
        string direccion;
        bool status;
        #endregion
        #region Constructores
        public VMinsertarCliente(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion
        #region Objetos
        
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

        #endregion
        #region Procesos

        private async void addcliente()
        {
            List<Mcliente> registros = await prestamorepositorio.GetAllClientes();
            int cant_registros = registros.Count();
            int IdGenerado;
            if (cant_registros == 0)
                IdGenerado = 1;
            else
                 IdGenerado = cant_registros++;
            var person = new Mcliente
            {
                Id = string.Format("CL" + IdGenerado),
                Nombre = nombre,
                Telefono = telefono,
                Direccion = direccion,
                Status = status
            };

            await prestamorepositorio.Addcliente(person);
            
            await App.Current.MainPage.Navigation.PushAsync(new tablaClientes());



        }
        public void process() { }


        #endregion
        #region Comandos

        //public ICommand InsertCommand => new Command(async () => await addcliente());
        public ICommand InsertCommand
        {
            get
            {
                return new RelayCommand(addcliente);
            }
        }
        public ICommand processcommand => new Command(process);
        #endregion
    }

}
