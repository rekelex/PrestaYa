using GalaSoft.MvvmLight.Command;
using PrestaYa.firebaseAuth;
using PrestaYa.Model;
using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMinsertarPrestamo : BaseViewModel
    {
        PrestamoRepository prestamorepositorio = new PrestamoRepository();
       
        #region Variables
        public string id_prestamo;
        public string monto;
        public string tasa;
        public string periodicidad;
        public bool status_prestamo;
        #endregion
        #region Constructores
        public VMinsertarPrestamo(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion
        #region Objetos
       

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
       
        public bool Statusprestamo
        {
            get { return status_prestamo; }
            set { if (status_prestamo != value) { status_prestamo = value; OnPropertyChanged(nameof(Statusprestamo)); } }
        }
        #endregion
        #region Procesos
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void addprestamo()
        {
            List<MPrestamo> registros = await prestamorepositorio.GetAllPrestamos();
            int maxId = registros.Count > 0 ? registros.Max(registro => ExtractNumeroId(registro.Id_prestamo)) : 0;



            var person = new MPrestamo
            {
                Id_prestamo = string.Format("PRE{0}", maxId + 1),
                Monto = monto,
                Tasa = tasa,
                Periodicidad = periodicidad,
                Status_prestamo = status_prestamo
            };

            await prestamorepositorio.Addprestamo(person);

            await App.Current.MainPage.Navigation.PushAsync(new tablaPrestamo());



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
                return new RelayCommand(addprestamo);
            }
        }
        public ICommand processcommand => new Command(process);
        #endregion
    }
}
