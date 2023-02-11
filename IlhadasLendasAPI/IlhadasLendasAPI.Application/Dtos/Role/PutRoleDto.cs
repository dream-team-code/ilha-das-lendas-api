using System.ComponentModel.DataAnnotations;

namespace IlhadasLendasAPI.Application.Dtos.Role
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutRoleDto : PostRoleDto
    {
        /// <summary>
        /// Id da role
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da role.")]
        [Required(ErrorMessage = "O campo id da role é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da role está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}