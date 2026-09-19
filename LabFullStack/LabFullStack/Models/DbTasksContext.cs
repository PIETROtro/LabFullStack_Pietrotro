using Microsoft.EntityFrameworkCore;

namespace AppTask.Models;

public class DbTasksContext : DbContext
{
    public DbTasksContext(DbContextOptions<DbTasksContext> options) : base(options)
    {
    }

    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
    public DbSet<Incidente> Incidentes => Set<Incidente>();
    public DbSet<Departamento> Departamentos => Set<Departamento>();
    public DbSet<CentralDeCusto> CentralDeCustos => Set<CentralDeCusto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
        modelBuilder.Entity<Tarefa>().ToTable("Tarefa");
        modelBuilder.Entity<Incidente>().ToTable("Incidente");
        modelBuilder.Entity<Departamento>().ToTable("Departamento");
        modelBuilder.Entity<CentralDeCusto>().ToTable("CentralDeCusto");

        modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.Funcionario)
            .WithMany(f => f.Tarefas)
            .HasForeignKey(t => t.FuncionarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
