using Microsoft.EntityFrameworkCore;
using AprovadosConcursosApi.Domain.Entities.Users;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Infrastructure.Data.ContextBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Banca> Bancas { get; set; }
        public DbSet<Orgao> Orgaos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Edital> Editais { get; set; }
        public DbSet<Questao> Questoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // USER (sem cascade perigoso)
            // =========================
            modelBuilder.Entity<User>();

            // =========================
            // ASSUNTO → DISCIPLINA
            // =========================
            modelBuilder.Entity<Assunto>()
                .HasOne(a => a.Disciplina)
                .WithMany()
                .HasForeignKey(a => a.DisciplinaId)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // QUESTÃO → ASSUNTO
            // =========================
            modelBuilder.Entity<Questao>()
                .HasOne(q => q.Assunto)
                .WithMany()
                .HasForeignKey(q => q.AssuntoId)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // QUESTÃO → DISCIPLINA (IMPORTANTE)
            // =========================
            modelBuilder.Entity<Questao>()
                .HasOne(q => q.Disciplina)
                .WithMany()
                .HasForeignKey(q => q.DisciplinaId)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // QUESTÃO → BANCA
            // =========================
            modelBuilder.Entity<Questao>()
                .HasOne(q => q.Banca)
                .WithMany(b => b.Questoes)
                .HasForeignKey(q => q.BancaId)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // EDITAL RELATIONS
            // =========================
            modelBuilder.Entity<Edital>()
                .HasOne(e => e.Banca)
                .WithMany(b => b.Editais)
                .HasForeignKey(e => e.BancaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Edital>()
                .HasOne(e => e.Orgao)
                .WithMany()
                .HasForeignKey(e => e.OrgaoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Edital>()
                .HasOne(e => e.Cargo)
                .WithMany()
                .HasForeignKey(e => e.CargoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Edital>()
                .Property(e => e.Salario)
                .HasPrecision(18, 2);
        }
    }
}