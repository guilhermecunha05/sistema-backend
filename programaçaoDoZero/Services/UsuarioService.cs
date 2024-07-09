using programaçaoDoZero.models;
using programaçaoDoZero.Repository;
using programaçaoDoZero.Endities;
using programaçaoDoZero.Commom;
namespace programaçaoDoZero.Services
{
    public class UsuarioService
    {
        private string  _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email,string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario  existe
                if (usuario.Senha == senha)

                {   //senha valida
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.Sucesso = false;
                    result.mensagem = "usuario ou senha invalidos";
                }
            }
            else
            {
                //usuario não existe
                result.Sucesso = false;
                result.mensagem = "usuário ou senha invalidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string Telefone,string CPF,string email,string senha, string Genero)
        {
            var result = new CadastroResult();

            var repositorio = new UsuarioRepository(_connectionString);

            var usuarioExistente  = repositorio.ObterUsuarioPorEmail(email);

            if(usuarioExistente != null)
            {
                //usuario já existe
                result.Sucesso = false;
                result.mensagem = "usuario jà existe no sistema";
            }

            else
            {
                //usuario não existe
                var usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.CPF = CPF;
                usuario.Telefone = Telefone;
                usuario.Genero = Genero;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = repositorio.Inserir(usuario);

                if (affectedRows > 0)
                {
                    //inseriu com sucesso
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.Sucesso = false;
                    result.mensagem = "erro ao inserir usuario. tente novamente";
                }
            }
            return result;
        }

        public esqueceuSenhaResult esqueceuSenha(string email)
        {
            var result = new esqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario == null)
            {
                //não existe
                result.Sucesso = false;
                result.mensagem = "usuario não existe para esse Email";
            }
            else
            {
                //usuario existe
                var EmailSender = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é + usuario.Senha";

                EmailSender.Enviar(assunto,corpo,usuario.Email);
            
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);
            return usuario;
        }
    }
}
