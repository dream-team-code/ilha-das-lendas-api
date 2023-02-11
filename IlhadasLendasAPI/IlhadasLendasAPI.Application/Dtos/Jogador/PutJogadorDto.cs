using IlhadasLendasAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace IlhadasLendasAPI.Application.Dtos.Jogador
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutJogadorDto
    {
        /// <summary>
        /// Id do Jogador
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id do jogador.")]
        [Required(ErrorMessage = "O campo id do jogador é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id do jogador está em um formato inválido.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Imagem em base64
        /// </summary>
        /// <example>data:image/png;base64,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</example>
        [Display(Name = "imagem em base64")]
        public string ImagemBase64 { get; set; }

        /// <summary>
        /// Id da Role
        /// </summary>
        /// <example>5C7AC53D-0AE7-41B8-CEC9-08DA91C2F232</example>
        [Display(Name = "Id da role.")]
        [Required(ErrorMessage = "O campo id da role é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da role está em um formato inválido.")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Id da Nacionalidade
        /// </summary>
        /// <example>5C7AC53D-0AE7-41B8-CEC9-08DA91C2F232</example>
        [Display(Name = "Id da nacionalidade.")]
        [Required(ErrorMessage = "O campo id da nacionalidade é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da nacionalidade está em um formato inválido.")]
        public Guid NacionalidadeId { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Nome</example>
        [Display(Name = "Nome do jogador.")]
        [Required(ErrorMessage = "O campo nome do jogador é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Nick
        /// </summary>
        /// <example>Robo</example>
        [Display(Name = "Nick do jogador.")]
        [Required(ErrorMessage = "O campo nick do jogador é obrigatório.")]
        public string Nick { get; set; }

        /// <summary>
        /// Pontuação
        /// </summary>
        /// <example>1</example>
        [Display(Name = "Pontuação do jogador.")]
        [Required(ErrorMessage = "O campo pontuação do jogador é obrigatório.")]
        public int Pontuacao { get; set; }

        /// <summary>
        /// Última pontuação
        /// </summary>
        /// <example>1</example>
        [Display(Name = "Última pontuação do jogador.")]
        [Required(ErrorMessage = "O campo última pontuação do jogador é obrigatório.")]
        public int UltimaPontuacao { get; set; }

        /// <summary>
        /// MVP
        /// </summary>
        /// <example>1</example>
        [Display(Name = "MVP do jogador.")]
        [Required(ErrorMessage = "O campo MVP do jogador é obrigatório.")]
        public int MVP { get; set; }

        /// <summary>
        /// Bagre
        /// </summary>
        /// <example>1</example>
        [Display(Name = "Bagre do jogador.")]
        [Required(ErrorMessage = "O campo Bagre do jogador é obrigatório.")]
        public int Bagre { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status do jogador.")]
        [Required(ErrorMessage = "O campo status do jogador é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}