﻿using Microsoft.AspNetCore.Http;
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
    public class LavadosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public LavadosController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /**
        * Get(): Aplica el SELECT para obtener la información de los lavados que se 
        * encuentran en la base de datos.
        */

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select lavado_id ,lavado_nombre,costo,precio, duracion, puntos_otorga, puntos_redimir            
                            from
                            dbo.Lavados
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
         * Post(): Aplica el INSERT para agregar un nuevo lavado a la base de datos.
         */

        [HttpPost]
        public JsonResult Post(Lavados emp)
        {
            string query = @"
                           insert into dbo.Lavados (lavado_nombre,costo,precio, duracion, puntos_otorga, puntos_redimir) 
                           values (@lavado_nombre, @costo,@precio, @duracion, @puntos_otorga, @puntos_redimir)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                 
                    myCommand.Parameters.AddWithValue("@lavado_nombre", emp.lavado_nombre);
                    myCommand.Parameters.AddWithValue("@costo", emp.costo);
                    myCommand.Parameters.AddWithValue("@precio", emp.precio);
                    myCommand.Parameters.AddWithValue("@duracion", emp.duracion);
                    myCommand.Parameters.AddWithValue("@puntos_otorga", emp.puntos_otorga);
                    myCommand.Parameters.AddWithValue("@puntos_redimir", emp.puntos_redimir);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        /**
         * Put(): Aplica el UPDATE para actualizar información de los lavados a la base de datos.
         */

        [HttpPut]
        public JsonResult Put(Lavados emp)
        {
            string query = @"
                           update dbo.Lavados
                           set 
                           lavado_nombre=@lavado_nombre,
                           costo=@costo,
                           precio=@precio,
                           duracion=@duracion,
                           puntos_otorga = @puntos_otorga,
                           puntos_redimir = @puntos_redimir
                          
                           where lavado_id= @lavado_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@lavado_id", emp.lavado_id);
                    myCommand.Parameters.AddWithValue("@lavado_nombre", emp.lavado_nombre);
                    myCommand.Parameters.AddWithValue("@costo", emp.costo);
                    myCommand.Parameters.AddWithValue("@precio", emp.precio);
                    myCommand.Parameters.AddWithValue("@duracion", emp.duracion);
                    myCommand.Parameters.AddWithValue("@puntos_otorga", emp.puntos_otorga);
                    myCommand.Parameters.AddWithValue("@puntos_redimir", emp.puntos_redimir);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        /**
        * Delete(): Aplica el DELETE para eliminar lavados de la base de datos, se debe ingresar
        * el id del lavado.
        */

        [HttpDelete("{lavado_id}")]
        public JsonResult Delete(int lavado_id)
        {
            string query = @"
                           delete from dbo.Lavados
                            where lavado_id=@lavado_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@lavado_id", lavado_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        /**
         * GetId(): Aplica el SELECT para obtener la información de los lavados que se 
         * encuentran en la base de datos insertando el id de de los lavados.
         */

        [HttpGet("{lavado_id}")]
        public JsonResult GetId(int lavado_id)
        {
            string query = @"
                            select lavado_id ,lavado_nombre,costo,precio, duracion, puntos_otorga, puntos_redimir         
                            from
                            dbo.Lavados
                            where lavado_id=@lavado_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@lavado_id", lavado_id);

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