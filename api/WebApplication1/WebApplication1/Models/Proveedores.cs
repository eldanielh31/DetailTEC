using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Proveedores
    {
        public int proveedor_id { get; set; }

        public string proveedor_nombre { get; set; }

        public string proveedor_apellido1 { get; set; }

        public string proveedor_apellido2 { get; set; }

        public string ced_juridica { get; set; }

        public string direccion { get; set; }

        public string email { get; set; }

        public string contacto_nombre { get; set; }

        public string contacto_numero { get; set; }



        public void setProveedor_id(int newProveedor_id)
        {
            this.proveedor_id = newProveedor_id;
        }
        public void setProveedor_nombre(string newProveedor_nombre)
        {
            this.proveedor_nombre = newProveedor_nombre;
        }
        public void setProveedor_apellido1(string newProveedor_apellido1)
        {
            this.proveedor_apellido1 = newProveedor_apellido1;
        }
        public void setProveedor_apellido2(string newProveedor_apellido2)
        {
            this.proveedor_apellido2 = newProveedor_apellido2;
        }

        public void setCed_juridica(string newCed_juridica)
        {
            this.ced_juridica = newCed_juridica;
        }

        public void setDireccion(string newDireccion)
        {
            this.direccion = newDireccion;
        }

        public void setEmail(string newEmail)
        {
            this.email = newEmail;
        }
        public void setContacto_nombre(string newContacto_nombre)
        {
            this.contacto_nombre = newContacto_nombre;
        }
        public void setContacto_numero(string newContacto_numero)
        {
            this.contacto_numero = newContacto_numero;
        }
       

    }
}