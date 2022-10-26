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
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ProductosController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        /**
         * Get(): Aplica el SELECT para obtener la información de los productos que se 
         * encuentran en la base de datos.
         */

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select prod_id, nombre ,marca,costo,proveedor_id, suc_id, stock         
                            from
                            dbo.Productos
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
         * Post(): Aplica el INSERT para agregar un nuevo producto a la base de datos.
         */

        [HttpPost]
        public JsonResult Post(Productos emp)
        {
            string query = @"
                           insert into dbo.Productos (nombre ,marca,costo,proveedor_id, suc_id, stock ) 
                           values (@nombre ,@marca,@costo,@proveedor_id, @suc_id, @stock )             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
 
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@marca", emp.marca);
                    myCommand.Parameters.AddWithValue("@costo", emp.costo);
                    myCommand.Parameters.AddWithValue("@proveedor_id", emp.proveedor_id);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myCommand.Parameters.AddWithValue("@stock", emp.stock);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        /**
         * Put(): Aplica el UPDATE para actualizar información de los productos a la base de datos.
         */

        [HttpPut]
        public JsonResult Put(Productos emp)
        {
            string query = @"
                           update dbo.Productos
                           set 
                           nombre= @nombre,
                           marca=@marca,
                           costo=@costo,
                           proveedor_id=@proveedor_id,
                           suc_id=@suc_id,
                           stock=@stock
                                             
                           where prod_id= @prod_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@prod_id", emp.prod_id);
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@marca", emp.marca);
                    myCommand.Parameters.AddWithValue("@costo", emp.costo);
                    myCommand.Parameters.AddWithValue("@proveedor_id", emp.proveedor_id);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myCommand.Parameters.AddWithValue("@stock", emp.stock);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }



    }
}