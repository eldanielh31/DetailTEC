using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Lavados_productos
    {
        public int lavado_id { get; set; }
        public string producto { get; set; }
       


        public void setLavados_id(int newLavados_id)
        {
            this.lavado_id = newLavados_id;
        }
        public void setProductos(string newProductos)
        {
            this.producto = newProductos;
        }
   


    }
}