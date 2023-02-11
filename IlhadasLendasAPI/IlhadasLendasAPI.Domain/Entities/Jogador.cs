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

        public void PutInformations(Jogador jogador)
        {
            AlteraCaminhoRelativo(jogador.CaminhoRelativo);
            AlteraCaminhoAbsoluto(jogador.CaminhoAbsoluto);
            AlteraCaminhoFisico(jogador.CaminhoFisico);
            AlteraHoraEnvio(jogador.HoraEnvio);
        }

        public void CarregaCategoriaJogador()
        {
            Dictionary<string, int> regra = new()
                {
                    { "Academy", 50 },
                    { "Bagre", 60 },
                    { "Mediano", 70 },
                    { "Bom", 80 },
                    { "God", 90 },
            };

            if (Pontuacao <= 50)
            {
                CategoriaJogador = "Academy";
            }
            else if (Pontuacao > 50 && Pontuacao <= 60)
            {
                CategoriaJogador = "Bagre";
            }
            else if (Pontuacao > 60 && Pontuacao <= 70)
            {
                CategoriaJogador = "Mediano";
            }
            else if (Pontuacao > 70 && Pontuacao <= 80)
            {
                CategoriaJogador = "Bom";
            }else
            {
                CategoriaJogador = "God";
            }
        }
    }
}