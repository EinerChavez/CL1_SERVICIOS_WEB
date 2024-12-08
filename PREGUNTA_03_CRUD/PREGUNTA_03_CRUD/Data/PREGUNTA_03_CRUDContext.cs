using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PREGUNTA_03_CRUD.Models;

namespace PREGUNTA_03_CRUD.Data
{
    public class PREGUNTA_03_CRUDContext : DbContext
    {
        public PREGUNTA_03_CRUDContext (DbContextOptions<PREGUNTA_03_CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<PREGUNTA_03_CRUD.Models.Venta> Ventas { get; set; } = default!;
    }
}
