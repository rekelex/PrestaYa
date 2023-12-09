using GalaSoft.MvvmLight.Command;
using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    public class VMtablaClientes : BaseViewModel
    {
        PrestamoRepository prestamoRepository = new PrestamoRepository();


        #region Variables
        public string nombre;
        public string telefono;
        public string direccion;
        public bool status;
        public bool isRefreshing = false;
        public object ListViewClientes;
        #endregion
        #region Constructores
        public VMtablaClientes(INavigation navigation)
        {
            LoadData();
            TestListViewBindingAsync();
            Navigation = navigation;

        }
        public VMtablaClientes()
        {
            LoadData();
            TestListViewBindingAsync();
            

        }


        #endregion
        #region Objetos
        public string Txtnombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string Txttelefono
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }
        public string Txtdireccion
        {
            get { return this.direccion; }
            set { SetValue(ref this.direccion, value); }
        }
        public bool Selectstatus
        {
            get { return this.status; }
            set { SetValue(ref this.status, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object listViewClientes
        {

            get { return this.ListViewClientes; }
            set
            {
                SetValue(ref this.ListViewClientes, value);
            }
        }

        #endregion
        #region Procesos

        public async Task addclientepage()
        {
            await Navigation.PushAsync(new insertarCliente());
        }
        public async Task LoadData()
        {
            this.listViewClientes = await prestamoRepository.GetAllClientes();
        }

        public ObservableCollection<Mcliente> clientesCollection = new ObservableCollection<Mcliente>();

        public async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Mcliente>();

            {
                Ingredients = await prestamoRepository.GetAllClientes();
            }
            foreach (var Ingredient in Ingredients)
            {
                clientesCollection.Add(Ingredient);
            }

        }





        public void process() { }


        #endregion
        #region Comandos
        
        public ICommand addclientcommand => new Command(async () => await addclientepage());
        public ICommand processcommand => new Command(process);
       
        #endregion
    }

}
