namespace AprovadosConcursosApi.Domain.Entities
{
    public class Cargo
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<Edital> Editais { get; set; } = new List<Edital>();
    }
}