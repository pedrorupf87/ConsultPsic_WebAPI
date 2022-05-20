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
    public class ConvenioController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConvenioController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult ConsultaGeral()
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"SELECT NUM_REGISTRO_ANS,
                                  NUM_CNPJ,
                                  NOM_RZ_SOCIAL,
                                  NOM_FANTASIA,
                                  TXT_MODALIDADE,
                                  TXT_ENDERECO,
                                  NUM_ENDERECO,
                                  TXT_COMPLEMENTO,
                                  TXT_BAIRRO,
                                  TXT_CIDADE,
                                  TXT_UF,
                                  NUM_CEP,
                                  NUM_DDD,
                                  NUM_TELEFONE,
                                  TXT_EMAIL,
                                  DAT_REGISTRO_ANS
                             FROM TB_CONVENIOS";
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
        public JsonResult InsereConvenio(Convenio convenio)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"INSERT INTO TB_CONVENIOS
                                VALUES ('" + convenio.NUM_REGISTRO_ANS + @"',
                                        '" + convenio.NUM_CNPJ + @"',
                                        '" + convenio.NOM_RZ_SOCIAL + @"',
                                        '" + convenio.NOM_FANTASIA + @"',
                                        '" + convenio.TXT_MODALIDADE + @"',
                                        '" + convenio.TXT_ENDERECO + @"',
                                        '" + convenio.NUM_ENDERECO + @"',
                                        '" + convenio.TXT_COMPLEMENTO + @"',
                                        '" + convenio.TXT_BAIRRO + @"',
                                        '" + convenio.TXT_CIDADE + @"',
                                        '" + convenio.TXT_UF + @"',
                                        '" + convenio.NUM_CEP + @"',
                                        '" + convenio.NUM_DDD + @"',
                                        '" + convenio.NUM_TELEFONE + @"',
                                        '" + convenio.TXT_EMAIL + @"',
                                        '" + convenio.DAT_REGISTRO_ANS + "')";
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

            return new JsonResult("Convênio adicionado com sucesso!");
        }

        [HttpPut]
        public JsonResult AlteraConvenio(Convenio convenio)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"UPDATE TB_CONVENIOS
                              SET NUM_CNPJ         = '" + convenio.NUM_CNPJ + @"',
							      NOM_RZ_SOCIAL    = '" + convenio.NOM_RZ_SOCIAL + @"',
						          NOM_FANTASIA	   = '" + convenio.NOM_FANTASIA + @"',
							      TXT_MODALIDADE   = '" + convenio.TXT_MODALIDADE + @"',
							      TXT_ENDERECO     = '" + convenio.TXT_ENDERECO + @"',
							      NUM_ENDERECO     = '" + convenio.NUM_ENDERECO + @"',
							      TXT_COMPLEMENTO  = '" + convenio.TXT_COMPLEMENTO + @"',
							      TXT_BAIRRO       = '" + convenio.TXT_BAIRRO + @"',
							      TXT_CIDADE       = '" + convenio.TXT_CIDADE + @"',
							      TXT_UF           = '" + convenio.TXT_UF + @"',
							      NUM_CEP          = '" + convenio.NUM_CEP + @"',
							      NUM_DDD          = '" + convenio.NUM_DDD + @"',
							      NUM_TELEFONE     = '" + convenio.NUM_TELEFONE + @"',
							      TXT_EMAIL        = '" + convenio.TXT_EMAIL + @"',
                            WHERE NUM_REGISTRO_ANS = '" + convenio.NUM_REGISTRO_ANS + @"'";
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

            return new JsonResult("Convênio alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public JsonResult DeletaConvenio(int id)
        {
            string conn = _config.GetConnectionString("conn");
            string sql = @"DELETE FROM TB_CONVENIOS
                                 WHERE NUM_REGISTRO_ANS = '" + id + @"'";
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

            return new JsonResult("Convênio excluído com sucesso!");
        }
    }
}