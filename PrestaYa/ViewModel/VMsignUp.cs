using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrestaYa.ViewModel
{
    internal class VMsignUp : BaseViewModel
    {

        #region Variables
        string _text;
        #endregion
        #region Constructores
        public VMsignUp(INavigation navigation)
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
        public async Task Asyncprocess()
        {

        }
        public void process() { }


        #endregion
        #region Comandos

        public ICommand Asyncprocesscommand => new Command(async () => await Asyncprocess());
        public ICommand processcommand => new Command(process);
        #endregion
    }
}

