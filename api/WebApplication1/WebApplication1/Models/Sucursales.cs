using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sucursales
    {
        public int suc_id { get; set; }
        public string suc_nombre { get; set; }
        public string provincia { get; set; }

        public string canton { get; set; }

        public string distrito { get; set; }

        public string telefono { get; set; }

        public string apertura { get; set; }

        public string gerente_id { get; set; }

        public string ingreso_gerente { get; set; }


        public void setId(int newId)
        {
            this.suc_id = newId;
        }
        public void setNombre(string newSuc_Nombre)
        {
            this.suc_nombre = newSuc_Nombre;
        }
        public void setprovincia(string newprovincia)
        {
            this.provincia = newprovincia;
        }
        public void setcanton(string newcanton)
        {
            this.canton = newcanton;
        }

        public void setdistrito(string newdistrito)
        {
            this.distrito = newdistrito;
        }

        public void settelefono2(string newtelefono1)
        {
            this.distrito = newtelefono1;
        }

        public void setapertura(string newapertura)
        {
            this.apertura = newapertura;
        }
        public void setgerente_id(string newgerente_id)
        {
            this.gerente_id = gerente_id;
        }
        public void setingreso_gerente(string newingreso_gerente)
        {
            this.ingreso_gerente = newingreso_gerente;
        }
        

    }
}
