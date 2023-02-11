using IlhadasLendasAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace IlhadasLendasAPI.Application.Dtos.Nacionalidade
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostNacionalidadeDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Brasileiro</example>
        [Display(Name = "Nome da nacionalidade.")]
        [Required(ErrorMessage = "O campo nome da nacionalidade é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status da nacionalidade.")]
        [Required(ErrorMessage = "O campo status do nacionalidade é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}