using api.jogos.InputModel;
using api.jogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.jogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoViewModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
        Task Inserir(object jogoInputModel);
        Task Atualizar(Guid idJogo, JogoInputModel jogoInputModel);
    }
}
