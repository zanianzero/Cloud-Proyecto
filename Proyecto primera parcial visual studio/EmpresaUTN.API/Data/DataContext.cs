using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpresaUTN.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<EmpresaUTN.Modelos.Restaurante> Restaurantes { get; set; } = default!;

        public DbSet<EmpresaUTN.Modelos.Ingrediente>? Ingredientes { get; set; }

        public DbSet<EmpresaUTN.Modelos.Plato>? Platos { get; set; }
    }
