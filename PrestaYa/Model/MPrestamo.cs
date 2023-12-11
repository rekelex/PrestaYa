using System;
using System.Collections.Generic;
using System.Text;

namespace PrestaYa.Model
{
    public class MPrestamo
    {
        public string Id_prestamo { get; set; }
        public Mcliente Id { get; set; }
       public Mcliente Nombre { get; set; }
        public string Monto { get; set; }
        public string Tasa { get; set; }
        public string Periodicidad { get; set; }  
        public bool Status_prestamo { get; set; }
    }
}
