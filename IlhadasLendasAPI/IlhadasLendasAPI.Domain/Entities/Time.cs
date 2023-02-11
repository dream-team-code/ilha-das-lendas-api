using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Domain.Entities
{
    public class Time : UploadBase64Base
    {
        public string Nome { get; private set; }

        public int Media { get; private set; }

        public List<Jogador> Jogadores { get; private set; }
    }
}