using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrestaYa.firebaseAuth
{
    internal class userRepository
    {
        static string WebAuth = "AIzaSyBdMRh0nuhCcaVNfmlWK74rTwKE9uHsch8";
        FirebaseAuthProvider authProvider;
        public userRepository()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAuth));
        }
        public async Task<bool> Register(string name, string email, string password)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }
        public async Task<string> SignIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }
    }
}
