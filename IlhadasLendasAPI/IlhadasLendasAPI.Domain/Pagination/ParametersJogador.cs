namespace IlhadasLendasAPI.Domain.Pagination
{
    public class ParametersJogador : ParametersPalavraChave
    {
        public List<Guid> RoleId { get; set; }

        public bool DreamTeam { get; set; }

        public string TimeALias { get; set; }
    }
}