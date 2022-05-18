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
    public class EscolaridadeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EscolaridadeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult ConsultaGeral()
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"SELECT COD_ESCOLARIDADE, TXT_ESCOLARIDADE
                             FROM TB_ESCOLARIDADE";
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
        public JsonResult InsereEscolaridade(Escolaridade esc)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"INSERT INTO TB_ESCOLARIDADE
                                VALUES ('" + esc.COD_ESCOLARIDADE + @"',
                                        '" + esc.TXT_ESCOLARIDADE + @"')";
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

            return new JsonResult("Escolaridade adicionada com sucesso!");
        }

        [HttpPut]
        public JsonResult AlteraEscolaridade(Escolaridade esc)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"UPDATE TB_ESCOLARIDADE
                              SET TXT_ESCOLARIDADE = '" + esc.TXT_ESCOLARIDADE + @"'
                            WHERE COD_ESCOLARIDADE = '" + esc.COD_ESCOLARIDADE + @"'";
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

            return new JsonResult("Escolaridade alterada com sucesso!");
        }

        [HttpDelete]
        public JsonResult DeletaEscolaridade(Escolaridade esc)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"DELETE FROM TB_ESCOLARIDADE
                                 WHERE COD_ESCOLARIDADE = '" + esc.COD_ESCOLARIDADE + @"'";
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

            return new JsonResult("Escolaridade deletada com sucesso!");
        }
    }
}