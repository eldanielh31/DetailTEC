using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Trabajadores
    {
        public int trabajador_id { get; set; }
        public int cedula { get; set; }
        public string nombre {get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string  ingreso { get; set; }
        public string nacimiento { get; set; }
        public string edad { get; set; }
        public string password_trab { get; set; }
        public string rol { get; set; }
        public string pago { get; set; }
        public string email { get; set; }

        public void setTrabajador_id(int newTrabajador_id)
        {
            this.trabajador_id = newTrabajador_id;
        }
        public void setCedula (int newCedula)
        {
            this.cedula = newCedula;
        }
        public void setNombre(string newNombre)
        {
            this.nombre = newNombre;
        }
        public void setApellido1(string newApellido1)
        {
            this.apellido1 = newApellido1;
        }
        public void setApellido2(string newApellido2)
        {
            this.apellido2 = newApellido2;
        }
        public void setIngreso(string newIngreso)
        {
            this.ingreso = newIngreso;
        }
        public void setNacimiento(string newNacimiento)
        {
            this.nacimiento = newNacimiento;
        }
        public void setPassword_trab(string newPassword_trab)
        {
            this.password_trab = newPassword_trab;
        }
        public void setRol(string newRol)
        {
            this.rol = newRol;
        }
        public void setPago(string newPago)
        {
            this.pago = newPago;
        }

        public void setEmail(string newEmail)
        {
            this.email = newEmail;
        }



    }
}


