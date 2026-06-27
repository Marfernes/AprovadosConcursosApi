
namespace AprovadosConcursosApi.Domain.Entities
{
    public class Banca
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Sigla { get; set; }

        public string? Site { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<Edital> Editais { get; set; } = new List<Edital>();

        public ICollection<Questao> Questoes { get; set; } = new List<Questao>();
    }
}