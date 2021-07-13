using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.jogos.Exception
{
    public class JogoJaCadastradoException : SystemException
    {
        public JogoJaCadastradoException()
            : base("Este já jogo está cadastrado")
        { }
    }
}
