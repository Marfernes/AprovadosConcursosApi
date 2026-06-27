namespace AprovadosConcursosApi.Domain.Entities
{
    public class Orgao
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Sigla { get; set; } = string.Empty;

        public string? Site { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<Edital> Editais { get; set; } = new List<Edital>();
    }
}