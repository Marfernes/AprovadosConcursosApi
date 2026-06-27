namespace AprovadosConcursosApi.Application.Dtos.Edital
{
    public class EditalDto
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

        public string Orgao { get; set; } = string.Empty;

        public string Banca { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}