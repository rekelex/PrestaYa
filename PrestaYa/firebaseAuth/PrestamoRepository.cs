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
            var resultprestamo = await firebaseClient.Child("Prestamos").OnceAsync<MPrestamo>();

            return resultprestamo.Select(item => new MPrestamo
            {
                  
                  Id_prestamo = item.Object.Id_prestamo,
                  Monto = item.Object.Monto,
                  Tasa = item.Object.Tasa,
                  Periodicidad = item.Object.Periodicidad, 
                  Status_prestamo = item.Object.Status_prestamo,
                  
              }).ToList();
           
        }

        public async Task Addprestamo(MPrestamo _Mprestamo)
        {
            await firebaseClient.Child("Prestamos").PostAsync(new MPrestamo()
            {
                Id_prestamo = _Mprestamo.Id_prestamo,
                Monto = _Mprestamo.Monto,
                Tasa = _Mprestamo.Tasa,
                Periodicidad = _Mprestamo.Periodicidad,
                Status_prestamo = _Mprestamo.Status_prestamo
            });
        }
        public async Task Updateprestamo(MPrestamo _Mprestamo)
        {
            try
            {


                var toUpdateprestamo = (await firebaseClient
                  .Child("Prestamos")
                  .OnceAsync<MPrestamo>()).Where(a => a.Object.Id_prestamo == _Mprestamo.Id_prestamo).FirstOrDefault();

                await firebaseClient
                  .Child("Prestamos")
                  .Child(toUpdateprestamo.Key)
                  .PutAsync(new MPrestamo() { Id_prestamo = _Mprestamo.Id_prestamo, Monto = _Mprestamo.Monto, Tasa = _Mprestamo.Tasa, Status_prestamo = _Mprestamo.Status_prestamo, Periodicidad = _Mprestamo.Periodicidad });

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        public async Task Deleteprestamo(string Id_prestamo)
        {
            var toDeletePrestamo = (await firebaseClient
              .Child("Prestamos")
              .OnceAsync<MPrestamo>()).Where(a => a.Object.Id_prestamo == Id_prestamo).FirstOrDefault();
            await firebaseClient.Child("Prestamos").Child(toDeletePrestamo.Key).DeleteAsync();

        }




    }
}
