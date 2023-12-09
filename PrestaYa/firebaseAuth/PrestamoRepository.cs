using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using PrestaYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrestaYa.firebaseAuth
{
    public class PrestamoRepository
    {
        FirebaseClient firebaseClient;

        public PrestamoRepository() {
            firebaseClient = new FirebaseClient("https://xamarin707-default-rtdb.firebaseio.com/");
        }


        //obtener todos los datos de los clientes
        public async Task<List<Mcliente>> GetAllClientes()
        {
            var result = await firebaseClient.Child("Clientes").OnceAsync<Mcliente>();
            return result.Select(item=> new Mcliente
              {
                  Id=item.Object.Id ?? "",
                  Nombre = item.Object.Nombre?? "",
                  Telefono = item.Object.Telefono ?? "",
                  Direccion = item.Object.Direccion ?? "",
                  Status = item.Object?.Status ?? false
              }).ToList();
        }

        public async Task Addcliente(Mcliente _Mcliente)
        {
            await firebaseClient.Child("Clientes").PostAsync(new Mcliente()
            {
                Id = _Mcliente.Id,
                Nombre = _Mcliente.Nombre,
                Direccion = _Mcliente.Direccion,
                Telefono= _Mcliente.Telefono,
                Status = _Mcliente.Status
            });
        }
        public async Task Updatecliente(Mcliente _Mcliente)
        {
            try
            {

            
            var toUpdatecliente = (await firebaseClient
              .Child("Clientes")
              .OnceAsync<Mcliente>()).Where(a => a.Object.Id == _Mcliente.Id).FirstOrDefault();

            await firebaseClient
              .Child("Clientes")
              .Child(toUpdatecliente.Key)
              .PutAsync(new Mcliente() { Id = _Mcliente.Id, Nombre = _Mcliente.Nombre, Direccion = _Mcliente.Direccion, Status= _Mcliente.Status, Telefono= _Mcliente.Telefono });

                }catch (Exception ex) {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
                            }   
            }
        public async Task Deletecliente(string Id)
        {
            var toDeletePerson = (await firebaseClient
              .Child("Clientes")
              .OnceAsync<Mcliente>()).Where(a => a.Object.Id == Id).FirstOrDefault();
            await firebaseClient.Child("Clientes").Child(toDeletePerson.Key).DeleteAsync();

        }

        //obtener todos los datos de los prestamos
        public async Task<List<MPrestamo>> GetAllPrestamos()
        {
            var result = await firebaseClient.Child("Prestamos").OnceAsync<MPrestamo>();

            return result.Select(item => new MPrestamo
            {
                  
                  Id_prestamo = item.Object.Id_prestamo,
                  Monto = item.Object.Monto,
                  Tasa = item.Object.Tasa,
                  Periocidad = item.Object.Periocidad, 
                  Nombre = new Mcliente
                  {
                      Id = item.Object.Nombre.Id,
                      Nombre = item.Object.Nombre.Nombre,
                  },
              }).ToList();
           
        }



    }
}
