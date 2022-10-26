using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Lavados
    {
        public int lavado_id { get; set; }
        public string lavado_nombre { get; set; }
        public string costo { get; set; }

        public string precio { get; set; }

        public string duracion { get; set; }

        public string puntos_otorga { get; set; }

        public string puntos_redimir { get; set; }


        public void setLavado_id(int newLavado_id)
        {
            this.lavado_id = newLavado_id;
        }
        public void setLavado_nombre(string newLavado_nombre)
        {
            this.lavado_nombre = newLavado_nombre;
        }
        public void setCosto(string newCosto)
        {
            this.costo = newCosto;
        }
        public void setPrecio(string newPrecio)
        {
            this.precio = newPrecio;
        }

        public void setDuracion(string newDuracion)
        {
            this.duracion = newDuracion;
        }

        public void setPuntos_otorga(string newPuntos_otorga)
        {
            this.puntos_otorga = newPuntos_otorga;
        }

        public void setPuntos_redimir(string newPuntos_redimir)
        {
            this.puntos_redimir = newPuntos_redimir;
        }

    }
}
