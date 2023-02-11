using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public List<Jogador> Jogadores { get; private set; } = new List<Jogador>();
    }
}