namespace AprovadosConcursosApi.Application.Dtos.Edital
{
    public class UpdateEditalDto
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string NumeroEdital { get; set; } = string.Empty;

        public int QuantidadeVagas { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime? DataInscricaoInicio { get; set; }

        public DateTime? DataInscricaoFim { get; set; }

        public DateTime? DataProva { get; set; }

        public string? LinkEdital { get; set; }

        public Guid OrgaoId { get; set; }

        public Guid BancaId { get; set; }

        public Guid CargoId { get; set; }

        public bool Ativo { get; set; }
    }
}