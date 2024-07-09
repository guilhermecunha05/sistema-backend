using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace programaçaoDoZero.Controllers
{
    [Route("api/Cunha")]
    [ApiController]
    public class CunhaController : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet()]
        public string OlaMundo()
        {
            var mensagem = "ola mundo via API";
            return mensagem;
        }
        [Route("OlaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API" + nome;
            return mensagem;
        }
        [Route("somar")]
        [HttpGet]
        public string somar(int valor1,int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "a soma é" + soma;
            return mensagem; 
        }
    }
}
