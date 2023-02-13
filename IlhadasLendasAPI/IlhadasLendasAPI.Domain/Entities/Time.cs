using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Domain.Entities
{
    public class Time : UploadBase64Base
    {
        public string Nome { get; private set; }

        public string Alias { get; private set; }

        public int Vitorias { get; private set; }

        public int Derrotas { get; private set; }

        //public int Media { get; private set; }

        public List<Jogador> Jogadores { get; private set; }

        public void AlterarJogadores(List<Jogador> jogadores)
        {
            Jogadores = jogadores;
        }

        public void PutInformations(Time time)
        {
            AlteraCaminhoRelativo(time.CaminhoRelativo);
            AlteraCaminhoAbsoluto(time.CaminhoAbsoluto);
            AlteraCaminhoFisico(time.CaminhoFisico);
            AlteraHoraEnvio(time.HoraEnvio);
        }
    }
}