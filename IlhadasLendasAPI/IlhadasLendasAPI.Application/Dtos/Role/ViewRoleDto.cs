using IlhadasLendasAPI.Domain.Enum;

namespace IlhadasLendasAPI.Application.Dtos.Role
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewRoleDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }
    }
}