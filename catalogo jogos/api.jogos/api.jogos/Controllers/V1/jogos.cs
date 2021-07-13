using api.jogos.Exception;
using api.jogos.InputModel;
using api.jogos.Services;
using api.jogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.jogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class jogos : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public jogos(IJogoService jogoService)
        {
            _jogoService = jogoService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);

        }


        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogos = await _jogoService.Obter(idJogo);

            if (jogos == null)
                return NoContent();

            return Ok(jogos);

        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }


        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)


            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
#pragma warning disable CS0168 // A variável foi declarada, mas nunca foi usada
            catch (JogoNaoCadastradoException ex)
#pragma warning restore CS0168 // A variável foi declarada, mas nunca foi usada
            { {
                    return NotFound("Não existe esse jogo");
                }
            }

            [HttpDelete("{idJogo:guid}")]
#pragma warning disable CS8321 // A função local foi declarada, mas nunca usada
            public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
#pragma warning restore CS8321 // A função local foi declarada, mas nunca usada
            {
                try
                {
                    await _jogoService.Remover(idJogo);

                    return Ok();
                }
                catch (JogoNaoCadastradoException ex)
                {
                    {
                        return NotFound("Não existe esse jogo");
                    }
                }
            }
        }
    }
}