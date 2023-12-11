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
    internal class VMeditarPrestamo : BaseViewModel
    {

        PrestamoRepository prestamorepository = new PrestamoRepository();

        #region Variables

        private string id_prestamo;
        private string monto;
        private string tasa;
        private string periodicidad;
        private bool status_prestamo;
        #endregion
        #region Constructores
        public VMeditarPrestamo(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMeditarPrestamo(MPrestamo _Mprestamo)
        {
            Txtidprestamo = _Mprestamo.Id_prestamo;
            Txttasa = _Mprestamo.Tasa;
            Txtperiodicidad = _Mprestamo.Periodicidad;
            Txtstatusprestamo = _Mprestamo.Status_prestamo;
            Txtmonto = _Mprestamo.Monto;

        }
        #endregion
        #region Objetos
        public string Txtidprestamo
        {
            get { return id_prestamo; }
            set => SetValue(ref id_prestamo, value);
        }
        public string Txttasa
        {
            get { return tasa; }
            set => SetValue(ref tasa, value);
        }
        public string Txtperiodicidad
        {
            get { return periodicidad; }
            set => SetValue(ref periodicidad, value);
        }
        public string Txtmonto
        {
            get { return monto; }
            set => SetValue(ref monto, value);
        }
        public bool Txtstatusprestamo
        {
            get { return status_prestamo; }
            set { if (status_prestamo != value) { status_prestamo = value; OnPropertyChanged(nameof(Txtstatusprestamo)); } }
        }
        #endregion
        #region Procesos
        public async Task Asyncprocess()
        {

        }
        private async void UpdateMethod()
        {
            var person = new MPrestamo
            {
                Id_prestamo = Txtidprestamo,
                Monto = Txtmonto,
                Status_prestamo = Txtstatusprestamo,
                Tasa = Txttasa,
                Periodicidad = Txtperiodicidad
            };

            await prestamorepository.Updateprestamo(person);

            await App.Current.MainPage.Navigation.PushAsync(new tablaPrestamo());
        }
        private async void DeleteMethod()
        {
            await prestamorepository.Deletecliente(Txtidprestamo);
            await App.Current.MainPage.Navigation.PushAsync(new tablaPrestamo());

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
