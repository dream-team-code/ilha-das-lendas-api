using IlhadasLendasAPI.Domain.Enum;

namespace IlhadasLendasAPI.Application.Dtos.Nacionalidade
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewNacionalidadeDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Status Status { get; set; }
    }
}