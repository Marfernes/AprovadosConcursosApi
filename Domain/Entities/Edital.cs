namespace AprovadosConcursosApi.Domain.Entities
{
    public class Edital
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

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public Guid OrgaoId { get; set; }

        public Orgao Orgao { get; set; } = null!;

        public Guid BancaId { get; set; }

        public Banca Banca { get; set; } = null!;

        public Guid CargoId { get; set; }

        public Cargo Cargo { get; set; } = null!;
    }
}