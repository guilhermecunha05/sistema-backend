using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using programaçaoDoZero.models;
using programaçaoDoZero.Models;
using programaçaoDoZero.Services;

namespace programacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(programaçaoDoZero.Controllers.CadastroRequest request)
        {

            var result = new CadastroResult();

            if (request == null ||
               string.IsNullOrEmpty(request.Nome) ||
               string.IsNullOrEmpty(request.Sobrenome) ||
               string.IsNullOrEmpty(request.CPF) ||
               string.IsNullOrEmpty(request.Telefone) ||
               string.IsNullOrEmpty(request.Genero) ||
               string.IsNullOrEmpty(request.Email) ||
               string.IsNullOrEmpty(request.Senha))
            {

                result.Sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.Nome, request.Sobrenome, request.Telefone, request.Genero, request.Email, request.CPF, request.Senha);
            }
            return result;

        }
        [HttpPost]
        [Route("esqueceuSenha")]
        public esqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new esqueceuSenhaResult();
            if (request == null ||
                string.IsNullOrEmpty(request.Email))
            {
                result.Sucesso = false;
                result.mensagem = "E-mail obrigatòrio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);


                result = usuarioService.esqueceuSenha(request.Email);
            }

            return result;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();
            if (request == null ||
                String.IsNullOrEmpty(request.Email))
            {
                result.Sucesso = false;
                result.mensagem = "E-mail obrigatòrio";
            }
            else if (request.Senha == "")
            {
                result.Sucesso = false;
                result.mensagem = "senha obrigatória";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.Email, request.Senha);
            }

            return result;
        }

        [HttpGet]
        [Route("ObterUsuario")]
        
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else
                {
                    result.Sucesso = true;
                    result.nome = usuario.Nome;

                }
            }

            return result;
        }
    }
}