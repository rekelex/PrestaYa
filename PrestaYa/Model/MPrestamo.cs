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
        public string Periocidad { get; set; }  
        public string Status_prestamo { get; set; }
    }
}
