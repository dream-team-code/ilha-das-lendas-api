using IlhadasLendasAPI.Application.Dtos.Jogador;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using System.Collections.Generic;

namespace IlhadasLendasAPI.Application.Dtos.Time
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewTimeDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Media { get; set; }

        public string CaminhoRelativo { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public Status Status { get; set; }

        public List<ViewJogadorDto> Jogadores { get; set; }

        public void CarregaMedia()
        {
            int soma = 0;
            int divisao = 0;
            foreach (ViewJogadorDto jogador in Jogadores)
            {
                if (jogador.Role.Nome != "Coach" && jogador.Status == Status.Ativo)
                {
                    soma += jogador.Pontuacao;
                    divisao++;
                }
            }

            if (soma != 0 && divisao!= 0) { Media = soma / divisao; }
            else { Media = 0; }
        }
    }
}