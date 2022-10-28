using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Productos
    {
        public string nombre { get; set; }
        public string marca { get; set; }
        public string costo { get; set; }

        public string proveedor_id { get; set; }


        public void setNombre(string newNombre)
        {
            this.nombre = newNombre;
        }
        public void setMarca(string newMarca)
        {
            this.marca = newMarca;
        }
        public void setCosto(string newCosto)
        {
            this.costo = newCosto;
        }
        public void setProveedor_id(string newProveedor_id)
        {
            this.proveedor_id = newProveedor_id;
        }

    }
}
