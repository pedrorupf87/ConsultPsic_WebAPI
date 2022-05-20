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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EspecialidadeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult ConsultaGeral()
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"SELECT COD_ESPECIALIDADE, TXT_ESPECIALIDADE
                             FROM TB_ESPECIALIDADE";
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
        public JsonResult InsereEspecialidade(Especialidade esp)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"INSERT INTO TB_ESPECIALIDADE
                                  (COD_ESPECIALIDADE
                                  ,TXT_ESPECIALIDADE)
                                  
                                  SELECT MAX(COD_ESPECIALIDADE) + 1
                                 ,'" + esp.TXT_ESPECIALIDADE + @"'
                                  FROM TB_ESPECIALIDADE";
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

            return new JsonResult("Especialidade adicionada com sucesso!");
        }

        [HttpPut]
        public JsonResult AlteraEspecialidade(Especialidade esp)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"UPDATE TB_ESPECIALIDADE
                              SET TXT_ESPECIALIDADE = '" + esp.TXT_ESPECIALIDADE + @"'
                            WHERE COD_ESPECIALIDADE = '" + esp.COD_ESPECIALIDADE + @"'";
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

            return new JsonResult("Especialidade alterada com sucesso!");
        }

        [HttpDelete("{id}")]
        public JsonResult DeletaEspecialidade(int id)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"DELETE FROM TB_ESPECIALIDADE
                                 WHERE COD_ESPECIALIDADE = '" + id + @"'";
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

            return new JsonResult("Especialidade deletada com sucesso!");
        }
    }
}