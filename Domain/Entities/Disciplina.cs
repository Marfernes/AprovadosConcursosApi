namespace AprovadosConcursosApi.Domain.Entities
{
    public class Disciplina
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<Assunto> Assuntos { get; set; } = new List<Assunto>();

        public ICollection<Questao> Questoes { get; set; } = new List<Questao>();
    }
}