using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Productos
    {
        public string prod_id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string costo { get; set; }
        public string proveedor_id { get; set; }
        public int suc_id { get; set; }
        public int stock { get; set; }


        public void setProd_id(string newProd_id)
        {
            this.prod_id = newProd_id;
        }

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
        public void setSuc_id(int newSuc_id)
        {
            this.suc_id = newSuc_id;
        }
        public void setStock(int newStock)
        {
            this.stock = newStock;
        }


    }
}
