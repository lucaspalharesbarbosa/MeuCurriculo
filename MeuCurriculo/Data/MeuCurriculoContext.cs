using MeuCurriculo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuCurriculo.Data {
    public class MeuCurriculoContext : DbContext {

        public MeuCurriculoContext(DbContextOptions<MeuCurriculoContext> options) : base(options) { }

        public DbSet<Habilidade> Habilidades { get; set; }
    }
}
