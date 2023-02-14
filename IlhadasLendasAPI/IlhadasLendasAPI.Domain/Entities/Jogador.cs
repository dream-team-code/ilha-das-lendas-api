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
            Dictionary<int, string> regras = new()
                {
                    {  5, "Academy" },
                    {  6, "Bagre" },
                    {  7, "Mediano" },
                    {  8, "Bom" },
                    {  9, "God" },
                    { 10, "God" }
            };

            int Pontos = Pontuacao > 100 ? Pontuacao = 100 : Pontuacao < 50 ? Pontuacao = 50 : Pontuacao;

            double value = Pontos * 0.1;
            string stringValue = value.ToString() + ",0"; 
            int finalValue = Convert.ToInt32(stringValue.Substring(0, stringValue.IndexOf(",")));
            CategoriaJogador = regras[finalValue];
        }
    }
}