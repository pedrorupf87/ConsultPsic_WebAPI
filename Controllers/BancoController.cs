using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConsultPsic_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsultPsic_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : Controller
    {
        private readonly IConfiguration _config;

        public BancoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult ConsultaGeral()
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"SELECT COD_BANCO, NOM_BANCO
                             FROM TB_BANCO";
            DataTable dt = new DataTable();
            SqlDataReader dr;
            using (SqlConnection conexao = new SqlConnection(conn))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    conexao.Close();
                }
            }

            return new JsonResult(dt);
        }

        [HttpPost]
        public JsonResult InsereBanco(Banco banco)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"INSERT INTO TB_BANCO
                                VALUES ('" + banco.COD_BANCO + @"',
                                        '" + banco.NOM_BANCO + @"')";
            DataTable dt = new DataTable();
            SqlDataReader dr;
            using (SqlConnection conexao = new SqlConnection(conn))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    conexao.Close();
                }
            }

            return new JsonResult("Banco adicionado com sucesso!");
        }

        [HttpPut]
        public JsonResult AlteraBanco(Banco banco)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"UPDATE TB_BANCO
                              SET NOM_BANCO = '" + banco.NOM_BANCO + @"'
                            WHERE COD_BANCO = '" + banco.COD_BANCO + @"'";
            DataTable dt = new DataTable();
            SqlDataReader dr;
            using (SqlConnection conexao = new SqlConnection(conn))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    conexao.Close();
                }
            }

            return new JsonResult("Banco alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public JsonResult DeletaBanco(int id)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"DELETE FROM TB_BANCO
                                 WHERE COD_BANCO = '" + id + @"'";
            DataTable dt = new DataTable();
            SqlDataReader dr;
            using (SqlConnection conexao = new SqlConnection(conn))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    conexao.Close();
                }
            }

            return new JsonResult("Banco excluído com sucesso!");
        }
    }
}