using PrestaYa.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace PrestaYa.ViewModel
{
    public class VMindex : BaseViewModel
    {
        #region Variables
        string _text;
        #endregion
        #region Constructores
        public VMindex(INavigation navigation)
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
        public async Task Startp()
        {
            await Navigation.PushAsync(new login());
        }
        public void process() { }


        #endregion
        #region Comandos

        public ICommand Startcommand => new Command(async () => await Startp());
        public ICommand processcommand => new Command(process);
        #endregion
    }
}
