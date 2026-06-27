namespace AprovadosConcursosApi.Domain.Entities
{
    public class Assunto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public Guid DisciplinaId { get; set; }

        public Disciplina Disciplina { get; set; } = null!;

        public ICollection<Questao> Questoes { get; set; } = new List<Questao>();
    }
}