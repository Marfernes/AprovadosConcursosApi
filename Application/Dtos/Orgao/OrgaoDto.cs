namespace AprovadosConcursosApi.Application.Dtos.Orgao
{
    public class OrgaoDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Sigla { get; set; } = string.Empty;

        public string? Site { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}