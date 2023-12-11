using GalaSoft.MvvmLight.Command;
using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        MPrestamo selectprestamo;
        public List<MPrestamo> listaprestamos = new List<MPrestamo>();
        string nombre;
        string telefono;
        string direccion;
        bool status;
        public string id_prestamo;
        public string monto;
        #endregion
        #region Constructores
        public VMinsertarCliente(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion
        #region Objetos
        public List<MPrestamo> Listaprestamos
        {
            get { return listaprestamos; }
            set { SetValue(ref listaprestamos, value); }
        }
        public MPrestamo selectPrestamo
        {
            get { return selectprestamo; }
            set
            {
                SetProperty(ref selectprestamo, value);
                Txtidprestamo = selectprestamo.Id_prestamo;
                Txtmonto = selectprestamo.Monto;
            }
        }

        public string Txtidprestamo
        {
            get { return id_prestamo; }
            set { SetValue(ref id_prestamo, value); }
        }
        public string Txtmonto
        {
            get { return monto; }
            set { SetValue(ref monto, value); }
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
        public bool Status
        {
            get { return status; }
            set { if (status != value){ status = value; OnPropertyChanged(nameof(Status)); } }
        }
        #endregion
        #region Procesos
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void addcliente()
        {
            List<Mcliente> registros = await prestamorepositorio.GetAllClientes();
            int maxId = registros.Count > 0 ? registros.Max(registro => ExtractNumeroId(registro.Id)) : 0;



            var person = new Mcliente
            {
                Id = string.Format("CL{0}", maxId + 1),
                Nombre = nombre,
                Telefono = telefono,
                Direccion = direccion,
                Status = status
            };

            await prestamorepositorio.Addcliente(person);
            
            await App.Current.MainPage.Navigation.PushAsync(new tablaClientes());



        }

        private static int ExtractNumeroId(string id)
        {
            string numeroIdString = new string(id.Where(char.IsDigit).ToArray());
            return int.Parse(numeroIdString);
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
