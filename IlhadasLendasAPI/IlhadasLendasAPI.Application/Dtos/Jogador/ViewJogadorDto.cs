using IlhadasLendasAPI.Application.Dtos.Nacionalidade;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Domain.Enum;

namespace IlhadasLendasAPI.Application.Dtos.Jogador
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewJogadorDto
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid NacionalidadeId { get; set; }

        public string Nome { get; set; }

        public string Nick { get; set; }

        public int Pontuacao { get; set; }

        public int UltimaPontuacao { get; set; }

        public int MVP { get; set; }

        public int Bagre { get; set; }

        public CategoriaJogador CategoriaJogador { get; set; }

        public Status Status { get; set; }

        public string CaminhoRelativo { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public ViewRoleDto Role { get; set; }

        public ViewNacionalidadeDto Nacionalidade { get; set; }
    }
}