using System;
using System.Collections.Generic;
using System.Text;

namespace PrestaYa.Model
{
    public class Mcliente
    {
        public string Id {  get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set;}
        public string Telefono { get; set;}
        public bool Status { get; set;}
    }
}
