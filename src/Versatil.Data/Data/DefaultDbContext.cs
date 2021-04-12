using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Versatil.Domain.Entities;

namespace Versatil.Data.Data
{
    public class DefaultDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        //Tables
        public DbSet<Uf> UFs { get; set; }
        public DbSet<Cidades> CIDADESs { get; set; }
        public DbSet<Empresas> EMPRESASs { get; set; }
        public DbSet<Bancos> BANCOSs { get; set; }
        public DbSet<Marcas> MARCASs { get; set; }
        public DbSet<Setores> SETORESs { get; set; }
        public DbSet<Servicos> SERVICOSs { get; set; }
        public DbSet<Funcionarios> FUNCIONARIOSs { get; set; }
        public DbSet<Clientes> CLIENTESs { get; set; }
        public DbSet<Profissoes> PROFISSOESs { get; set; }
        public DbSet<ContasDemonstrativos> CONTASDEMONSTRATIVOSs { get; set; }
        public DbSet<ContasGrupos> CONTASGRUPOSs { get; set; }
        public DbSet<ContasSubgrupos> CONTASSUBGRUPOSs { get; set; }
        public DbSet<Contas> CONTASs { get; set; }
        public DbSet<Unidades> UNIDADESs { get; set; }
        public DbSet<Cfop> CFOPs { get; set; }
        public DbSet<SituacaoTributariaCofins> SITUACAOTRIBUTARIACOFINSs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}