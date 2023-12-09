using PrestaYa.firebaseAuth;
using PrestaYa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrestaYa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            BindingContext = new VMlogin(Navigation);
        }
        userRepository _userRepository = new userRepository();

        private async void btnsingin_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = txtemail.Text;
                string password = txtpassword.Text;
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Advertencia", "Ingrese un correo valido", "Aceptar");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Advertencia", "Ingrese una contraseña valida", "Aceptar");
                    return;
                }
                string token = await _userRepository.SignIn(email, password);
                if (!string.IsNullOrEmpty(token))
                {
                    Preferences.Set("token", token);
                    Preferences.Set("userEmail", email);
                    await Navigation.PushAsync(new Menu());
                }
                else
                {
                    await DisplayAlert("Inicio de sesion", "Inicio de sesion fallido", "Aceptar");
                }
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "Ingrese parametros validos", "Aceptar");

            }
        }

        private void registrar_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new signUp());

        }
    }
}