using PrestaYa.firebaseAuth;
using PrestaYa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrestaYa.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class signUp : ContentPage
	{
        userRepository _userRepository = new userRepository();
        public signUp()
        {
            InitializeComponent();
            BindingContext = new VMsignUp(Navigation);
        }

        public bool isChecked { get; private set; }

        private async void Btnsignup_Clicked(object sender, EventArgs e)
        {
            try
            {

                string name = txtname.Text;
                string email = txtemail.Text;
                string password = txtpassword.Text;
                string confirmpassword = txtconfirmpswrd.Text;


                if (string.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Advertencia", "Ingrese el nombre", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Advertencia", "Ingrese correo electronico", "Aceptar");
                    return;
                }
                if (password.Length < 6)
                {
                    await DisplayAlert("Advetencia", "La contraseña tiene que contener 6 caracteres.", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Advertencia", "Ingrese su contraseña", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(confirmpassword))
                {
                    await DisplayAlert("Advertencia", "Ingrese confirmacion de contraseña", "Aceptar");
                    return;
                }
                if (password != confirmpassword)
                {
                    await DisplayAlert("Advertencia", "Contraseña no coincide", "Aceptar");
                    return;
                }

                bool isSave = await _userRepository.Register(name, email, password);
                if (isSave)
                {
                    await DisplayAlert("Registro", "Usuario registrado con exito", "aceptar");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Registro", "Falla al registar", "aceptar");
                }

            }

            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Advertencia", "El correo ya existe", "Aceptar");
                }
                if (exception.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Advertencia", "Ingrese un correo valido", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "Ok");
                }
            }
        }


        private async void terms_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Terminos y condiciones", "The following terminology applies to these Terms and Conditions, Privacy Statement and Disclaimer Notice and all Agreements: “Client”, “You” and “Your” refers to you, the person log on this website and compliant to the Company's terms and conditions. “The Company”, “Ourselves”, “We”, “Our” and “Us”, refers to our Company. “Party”, “Parties”, or “Us”, refers to both the Client and ourselves. All terms refer to the offer, acceptance and consideration of payment necessary to undertake the process of our assistance to the Client in the most appropriate manner for the express purpose of meeting the Client's needs in respect of provision of the Company's stated services, in accordance with and subject to, prevailing law of Netherlands.", "Cerrar");

        }

    }
}