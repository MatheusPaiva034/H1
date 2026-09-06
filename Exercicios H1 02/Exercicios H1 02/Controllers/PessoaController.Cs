using Microsoft.AspNetCore.Mvc;
using Exercicios_H1_02.models;

namespace Exercicios_H1_02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        //Adicionar uma pessoa
        [HttpPost]
        public IActionResult Adicionar(Pessoa pessoa)
        {
            pessoas.Add(pessoa);

            return Ok(pessoa);
        }

        //Atualizar os dados de uma pessoa
        [HttpPut("{cpf}")]
        public IActionResult Atualizar(string cpf, Pessoa pessoa)
        {
            var pessoaEncontrada = pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (pessoaEncontrada == null)
            {
                return NotFound();
            }

            pessoaEncontrada.Nome = pessoa.Nome;
            pessoaEncontrada.Cpf = pessoa.Cpf;
            pessoaEncontrada.Peso = pessoa.Peso;
            pessoaEncontrada.Altura = pessoa.Altura;

            return Ok(pessoaEncontrada);
        }

        //Remover uma pessoa pelo CPF
        [HttpDelete("{cpf}")]
        public IActionResult Remover(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return NotFound();
            }

            pessoas.Remove(pessoa);

            return Ok("Pessoa removida com sucesso.");
        }

        //Buscar todas as pessoas
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            return Ok(pessoas);
        }

        //Buscar uma pessoa pelo CPF
        [HttpGet("{cpf}")]
        public IActionResult BuscarPorCpf(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        //Buscar pessoas com IMC entre 18 e 24
        [HttpGet("imc")]
        public IActionResult BuscarPorImc()
        {
            var resultado = pessoas
                .Where(p => p.IMC >= 18 && p.IMC <= 24)
                .ToList();

            return Ok(resultado);
        }

        //Buscar pessoas pelo nome
        [HttpGet("nome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = pessoas
                .Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(resultado);
        }
    }
}