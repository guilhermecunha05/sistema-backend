using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using programaçaoDoZero.Models;

namespace programaçaoDoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "branco";
            meuVeiculo.Marca = "ford";
            meuVeiculo.Modelo = "fiesta";
            meuVeiculo.Placa = "DEX-3358";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            

            return meuVeiculo;
        }
        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Modelo = "Porto fino";
            meuCarro.Marca = "Ferrari";
            meuCarro.Placa = "PHP-3245";
            meuCarro.Cor = "Azul";

            meuCarro.Acelerar();
            return meuCarro;

        }
        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Lamborghini";
            minhaMoto.Modelo = "Huracan";
            minhaMoto.Placa = "THC-777";
            minhaMoto.Cor = "Azul";

            minhaMoto.Acelerar();
            
            return minhaMoto;
            
        }
    }
}
