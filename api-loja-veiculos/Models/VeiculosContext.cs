using Microsoft.EntityFrameworkCore;
using api_loja_veiculos.Models;

namespace api_loja_veiculos.Data{
    public class VeiculosContext : DbContext{
        public VeiculosContext(DbContextOptions<VeiculosContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }}}