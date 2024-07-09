

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programaçaoDoZero.Controllers
{
    public class CadastroRequest
    {
        public  string Nome { get; set; }
        public  string Sobrenome { get; set; }
        public  string CPF { get; set; }
        public  string Email { get; set; }
        public string Telefone { get; set; }
        public  string Senha { get; set; }
        public  string Genero { get; set; }
    }
}
