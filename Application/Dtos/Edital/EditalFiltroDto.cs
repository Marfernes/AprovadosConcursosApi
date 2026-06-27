namespace AprovadosConcursosApi.Application.Dtos.Edital
{
    public class EditalFiltroDto
    {
        public string? Titulo { get; set; }

        public Guid? OrgaoId { get; set; }

        public Guid? BancaId { get; set; }

        public Guid? CargoId { get; set; }

        public bool? Ativo { get; set; }

        public int Pagina { get; set; } = 1;

        public int Quantidade { get; set; } = 10;
    }
}