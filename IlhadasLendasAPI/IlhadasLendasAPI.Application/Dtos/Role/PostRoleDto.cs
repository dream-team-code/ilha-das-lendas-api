using IlhadasLendasAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace IlhadasLendasAPI.Application.Dtos.Role
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostRoleDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Jungle</example>
        [Display(Name = "Nome da role.")]
        [Required(ErrorMessage = "O campo nome da role é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        /// <example>Selva</example>
        [Display(Name = "Descrição da role.")]
        [Required(ErrorMessage = "O campo descrição da role é obrigatório.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status da role.")]
        [Required(ErrorMessage = "O campo status do role é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}