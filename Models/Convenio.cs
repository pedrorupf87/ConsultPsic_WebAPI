using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultPsic_WebAPI.Models
{
    public class Convenio
    {
        public int NUM_REGISTRO_ANS { get; set; }
        public string NUM_CNPJ { get; set; }
        public string NOM_RZ_SOCIAL { get; set; }
        public string NOM_FANTASIA { get; set; }
        public string TXT_MODALIDADE { get; set; }
        public string TXT_ENDERECO { get; set; }
        public string NUM_ENDERECO { get; set; }
        public string TXT_COMPLEMENTO { get; set; }
        public string TXT_BAIRRO { get; set; }
        public string TXT_CIDADE { get; set; }
        public string TXT_UF { get; set; }
        public int NUM_CEP { get; set; }
        public int NUM_DDD { get; set; }
        public string NUM_TELEFONE { get; set; }
        public string TXT_EMAIL { get; set; }
        public string DAT_REGISTRO_ANS { get; set;}
    }
}