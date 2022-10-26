using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ClientesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /**
         * Get(): Aplica el SELECT para obtener la información de los clientes que se 
         * encuentran en la base de datos.
         */

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select cliente_nombre,cedula ,fecha_nac, direccion,telefono1, telefono2, email, 
                            usuario, psw_cliente, puntos              
                            from
                            dbo.Clientes
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        /**
         * Post(): Aplica el INSERT para agregar un nuevo cliente a la base de datos.
         */

        [HttpPost]
        public JsonResult Post(Clientes emp)
        {
            string query = @"
                           insert into dbo.Clientes (cliente_nombre,cedula ,fecha_nac, direccion,telefono1, telefono2, email, 
                            usuario, psw_cliente, puntos) 
                           values (@cliente_nombre,@cedula ,@fecha_nac, @direccion,@telefono1, @telefono2, @email, 
                            @usuario, @psw_cliente, @puntos)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cliente_nombre", emp.cliente_nombre);
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@fecha_nac", emp.fecha_nac);
                    myCommand.Parameters.AddWithValue("@direccion", emp.direccion);
                    myCommand.Parameters.AddWithValue("@telefono1", emp.telefono1);
                    myCommand.Parameters.AddWithValue("@telefono2", emp.telefono2);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myCommand.Parameters.AddWithValue("@usuario", emp.usuario);
                    myCommand.Parameters.AddWithValue("@psw_cliente", emp.psw_cliente);
                    myCommand.Parameters.AddWithValue("@puntos", emp.puntos);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        /**
         * Put(): Aplica el UPDATE para actualizar información de los clientes a la base de datos.
         */

        [HttpPut]
        public JsonResult Put(Clientes emp)
        {
            string query = @"
                           update dbo.Clientes
                           set cliente_nombre=@cliente_nombre,
                            fecha_nac=@fecha_nac,
                            direccion=@direccion,
                            telefono1=@telefono1,
                            telefono2=@telefono2,
                            email = @email,
                            usuario = @usuario,
                            psw_cliente = @psw_cliente,
                            puntos = @puntos
                            where cedula= @cedula


                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cliente_nombre", emp.cliente_nombre);
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@fecha_nac", emp.fecha_nac);
                    if (String.IsNullOrEmpty(emp.direccion))
                    {
                        myCommand.Parameters.AddWithValue("@direccion", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@direccion", emp.direccion);

                    if (String.IsNullOrEmpty(emp.telefono1))
                    {
                        myCommand.Parameters.AddWithValue("@telefono1", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@telefono1", emp.telefono1);
                  
                    myCommand.Parameters.AddWithValue("@telefono2", emp.telefono2);

                    if (String.IsNullOrEmpty(emp.email))
                    {
                        myCommand.Parameters.AddWithValue("@email", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@email", emp.email);

                    if (String.IsNullOrEmpty(emp.usuario))
                    {
                        myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@usuario", emp.usuario);

                    if (String.IsNullOrEmpty(emp.psw_cliente))
                    {
                        myCommand.Parameters.AddWithValue("@psw_cliente", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@psw_cliente", emp.psw_cliente);

                    if (emp.puntos == null)
                    {
                        myCommand.Parameters.AddWithValue("@puntos", DBNull.Value);
                    }
                    else
                        myCommand.Parameters.AddWithValue("@puntos", emp.puntos);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        /**
        * Delete(): Aplica el DELETE para eliminar clientes de la base de datos, se debe ingresar
        * el id del cliente.
        */

        [HttpDelete("{cedula}")]
        public JsonResult Delete(string cedula)
        {
            string query = @"
                           delete from dbo.Clientes
                            where cedula=@cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", cedula);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        /**
         * Getcedula(): Aplica el SELECT para obtener la información de los clientes que se 
         * encuentran en la base de datos insertando la cedula de de los clientes.
         */

        [HttpGet("{cedula}")]
        public JsonResult Getcedula(string cedula)
        {
            string query = @"
                            select cliente_nombre,cedula ,fecha_nac, direccion,telefono1, telefono2, email, 
                            usuario, psw_cliente, puntos          
                            from
                            dbo.Clientes
                            where cedula=@cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", cedula);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

         
             return new JsonResult(table);
        }

        /**
         * GetEmail(): Aplica el SELECT para obtener la información de los clientes que se 
         * encuentran en la base de datos insertando el email de de los clientes.
         */

        [HttpGet("email/{email}")]
        public JsonResult GetEmail(string email)
        {
            string query = @"
                            select * from
                            dbo.Clientes
                            where email=@email
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@email", email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


    }
}