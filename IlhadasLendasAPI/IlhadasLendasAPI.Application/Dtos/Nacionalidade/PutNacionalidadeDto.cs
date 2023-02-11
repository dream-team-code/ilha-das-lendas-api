using System.ComponentModel.DataAnnotations;

namespace IlhadasLendasAPI.Application.Dtos.Nacionalidade
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutNacionalidadeDto : PostNacionalidadeDto
    {
        /// <summary>
        /// Id da nacionalidade
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da nacionalidade.")]
        [Required(ErrorMessage = "O campo id da nacionalidade é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da nacionalidade está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}