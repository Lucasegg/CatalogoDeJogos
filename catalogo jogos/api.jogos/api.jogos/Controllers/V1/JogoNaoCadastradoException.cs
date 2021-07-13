using System;
using System.Runtime.Serialization;

namespace api.jogos.Controllers.V1
{
    [Serializable]
    internal class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException()
        {
        }

        public JogoNaoCadastradoException(string message) : base(message)
        {
        }

        public JogoNaoCadastradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JogoNaoCadastradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}