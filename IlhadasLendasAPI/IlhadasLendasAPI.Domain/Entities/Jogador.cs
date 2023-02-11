using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Domain.Entities
{
    public class Jogador : UploadBase64Base
    {
        public Guid RoleId { get; private set; }

        public Guid NacionalidadeId { get; private set; }

        public string Nome { get; private set; }

        public string Nick { get; private set; }

        public string CategoriaJogador { get; private set; }

        public int Pontuacao { get; private set; }

        public int UltimaPontuacao { get; private set; }

        public int MVP { get; private set; }

        public int Bagre { get; private set; }

        public Role Role { get; private set; }

        public Nacionalidade Nacionalidade { get; private set; }

        public List<Time> Times { get; private set; }
    }
}