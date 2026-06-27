namespace AprovadosConcursosApi.Domain.Entities
{
    public class Questao
    {
        public Guid Id { get; set; }

        public string Enunciado { get; set; } = string.Empty;

        public string AlternativaA { get; set; } = string.Empty;

        public string AlternativaB { get; set; } = string.Empty;

        public string AlternativaC { get; set; } = string.Empty;

        public string AlternativaD { get; set; } = string.Empty;

        public string? AlternativaE { get; set; }

        public string Gabarito { get; set; } = string.Empty;

        public string? Comentario { get; set; }

        public int Ano { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public Guid BancaId { get; set; }

        public Banca Banca { get; set; } = null!;

        public Guid DisciplinaId { get; set; }

        public Disciplina Disciplina { get; set; } = null!;

        public Guid AssuntoId { get; set; }

        public Assunto Assunto { get; set; } = null!;
    }
}