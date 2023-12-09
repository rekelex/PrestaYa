using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMtablaPrestamo : BaseViewModel
    {
        PrestamoRepository prestamorepository = new PrestamoRepository();

        public ObservableCollection<MPrestamo> prestamosCollection = new ObservableCollection<MPrestamo>();
        public ObservableCollection<Mcliente> clientcollection = new ObservableCollection<Mcliente>();
        #region Variables
        Mcliente selectcliente;
        public List<Mcliente> listaclientes = new List<Mcliente>();
        public string id_prestamo;
        public string monto;
        public string tasa;
        public string periodicidad;
        public bool status_prestamo;
        public string id;
        public string nombre;
        public bool isRefreshing = false;
        public object ListViewPrestamo;
        #endregion
        #region Constructores
        public VMtablaPrestamo(INavigation navigation)
        {
            LoadData();
            TestListViewBindingAsync();
            Navigation = navigation;
        }

        #endregion
        #region Objetos

        public List<Mcliente> Listaclientes
        {
            get { return listaclientes; }
            set { SetValue(ref listaclientes, value); }
        }
        public Mcliente Selectcliente
        {
            get { return selectcliente; }
            set
            {
                SetProperty(ref selectcliente, value);
                Txtnombre = selectcliente.Nombre;
                Txtid = selectcliente.Id;
            }
        }
        public string Txtmonto
        {
            get { return this.monto; }
            set { SetValue(ref this.monto, value); }
        }
        public string Txttasa
        {
            get { return this.tasa; }
            set { SetValue(ref this.tasa, value); }
        }

        public string Txtperiodicidad
        {
            get { return this.periodicidad; }
            set { SetValue(ref this.periodicidad, value); }
        }
        public bool Txtstatus_prestamo
        {
            get { return this.status_prestamo; }
            set { SetValue(ref this.status_prestamo, value); }
        }
        public string Txtnombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Txtid
        {
            get { return this.id; }
            set { SetValue(ref this.id, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object listViewprestamo
        {

            get { return this.ListViewPrestamo; }
            set
            {
                SetValue(ref this.ListViewPrestamo, value);
            }
        }


        #endregion
        #region Procesos
        public async Task LoadData()
        {
            this.listViewprestamo = await prestamorepository.GetAllClientes();
        }


        private async Task TestListViewBindingAsync()
        {
            var prestamos = new List<MPrestamo>();

            {
                prestamos = await prestamorepository.GetAllPrestamos();
            }
            foreach (var prestamo in prestamos)
            {
                prestamosCollection.Add(prestamo);
            }

        }
        public void process() { }


        #endregion
        #region Comandos

        //public ICommand Asyncprocesscommand => new Command(async () => await Asyncprocess());
        public ICommand processcommand => new Command(process);
        #endregion
    }
}
