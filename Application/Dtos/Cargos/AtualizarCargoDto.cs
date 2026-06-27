namespace AprovadosConcursosApi.Application.Dtos.Cargos
{
    public class AtualizarCargoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}