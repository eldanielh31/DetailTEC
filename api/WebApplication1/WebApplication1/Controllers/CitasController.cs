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
    public class CitasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CitasController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /**
         * Get(): Aplica el SELECT para obtener la información de las citas que se 
         * encuentran en la base de datos.
         */

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select cita_id , date, cedula, placa, suc_id, lavado_id, trabajador_id            
                            from
                            dbo.Citas
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
         * Post(): Aplica el INSERT para agregar una nueva cita a la base de datos.
         */

        [HttpPost]
        public JsonResult Post(Citas emp)
        {
            string query = @"
                           insert into dbo.Citas ( date, cedula,placa,suc_id, lavado_id, trabajador_id) 
                           values ( @date,  @cedula, @placa,@suc_id, @lavado_id, @trabajador_id)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
      
                    myCommand.Parameters.AddWithValue("@date", emp.date);
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@placa", emp.placa);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myCommand.Parameters.AddWithValue("@lavado_id", emp.lavado_id);
                    myCommand.Parameters.AddWithValue("@trabajador_id", emp.trabajador_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        /**
         * Put(): Aplica el UPDATE para actualizar información de las citas a la base de datos.
         */

        [HttpPut]
        public JsonResult Put(Citas emp)
        {
            string query = @"
                           update dbo.Citas
                           set
                           date=@date,
                           cedula=@cedula,
                           placa=@placa,
                           suc_id=@suc_id,
                           lavado_id=@lavado_id,
                           trabajador_id = @trabajador_id
                          
                           where cita_id= @cita_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cita_id", emp.cita_id);
                    myCommand.Parameters.AddWithValue("@date", emp.date);
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@placa", emp.placa);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myCommand.Parameters.AddWithValue("@lavado_id", emp.lavado_id);
                    myCommand.Parameters.AddWithValue("@trabajador_id", emp.trabajador_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        /**
         * Delete(): Aplica el DELETE para eliminar citas de la base de datos, se debe ingresar
         * el id de la cita.
         */

        [HttpDelete("{cita_id}")]
        public JsonResult Delete(int cita_id)
        {
            string query = @"
                           delete from dbo.Citas
                            where cita_id=@cita_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cita_id", cita_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        /**
         * GetId(): Aplica el SELECT para obtener la información de las citas que se 
         * encuentran en la base de datos insertando el id de la cita.
         */

        [HttpGet("{cita_id}")]
        public JsonResult GetId(int cita_id)
        {
            string query = @"
                            select cita_id , date, cedula,placa,suc_id, lavado_id, trabajador_id         
                            from
                            dbo.Citas
                            where cita_id=@cita_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cita_id", cita_id);

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