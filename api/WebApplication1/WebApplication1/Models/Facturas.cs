using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Facturas
    {
        public int fact_id { get; set; }
        public string cita_id { get; set; }
        public string snacks_consumidos { get; set; }

        public string bebidas_consumidas { get; set; }

        public string precio_servicio { get; set; }

        public string monto { get; set; }

        public string iva { get; set; }


        public void setFact_id(int newFact_id)
        {
            this.fact_id = newFact_id;
        }
        public void setCita_id(string newCita_id)
        {
            this.cita_id = newCita_id;
        }
        public void setSnacks_consumidos(string newSnacks_consumidos)
        {
            this.snacks_consumidos = newSnacks_consumidos;
        }
        public void setBebidas_consumidas(string newBebidas_consumidas)
        {
            this.bebidas_consumidas = newBebidas_consumidas;
        }

        public void setPrecio_servicio(string newPrecio_servicio)
        {
            this.precio_servicio = newPrecio_servicio;
        }

        public void setMonto(string newMonto)
        {
            this.monto = newMonto;
        }

        public void setIva(string newIva)
        {
            this.iva = newIva;
        }


    }
}