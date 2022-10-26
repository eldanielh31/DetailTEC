using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Clientes
    {
        public string cedula { get; set; }
        public string cliente_nombre { get; set; }

        public string fecha_nac { get; set; }

        public string direccion { get; set; }

        public string telefono1 { get; set; }

        public int telefono2 { get; set; }

        public string email { get; set; }

        public string usuario { get; set; }

        public string psw_cliente { get; set; }

        public int puntos { get; set; }

        public void setCedula(string newCedula)
        {
            this.cedula = newCedula;
        }
        public void setNombre(string newCliente_Nombre)
        {
            this.cliente_nombre = newCliente_Nombre;
        }
        public void setFecha_nac(string newFecha_nac)
        {
            this.fecha_nac = newFecha_nac;
        }
        public void setdireccion(string newdireccion)
        {
            this.direccion = newdireccion;
        }

        public void settelefono1(string newtelefono1)
        {
            this.telefono1 = newtelefono1;
        }

        public void settelefono2(int newtelefono2)
        {
            this.telefono2 = newtelefono2;
        }

        public void setEmail(string newEmail)
        {
            this.email = newEmail;
        }
        public void setUsuario(string newUsuario)
        {
            this.usuario = newUsuario;
        }
        public void setPassword_cliente(string newPassword_cliente)
        {
            this.psw_cliente = newPassword_cliente;
        }
        public void setPuntos(int newPuntos)
        {
            this.puntos = newPuntos;
        }

    }
}