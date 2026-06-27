namespace AprovadosConcursosApi.Application.Dtos.Orgao
{
    public class CreateOrgaoDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Sigla { get; set; } = string.Empty;

        public string? Site { get; set; }
    }
}