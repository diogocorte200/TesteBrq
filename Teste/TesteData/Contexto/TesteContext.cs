using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteData.EntityConfig;
using TesteDomain.Entities;

namespace TesteData.Contexto
{
    public class TesteContext : DbContext
    {
        public TesteContext()
           : base("DefaultConnection")
        {
        }
        public DbSet<Operacoes> Operacoes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Tirar pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Nao permite o delete em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Nao permite o delete em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Define o campo como chave primaria
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Evita que o campo seja criado como nvarchar, o mesmo sera criado como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            //Define o tamanho do campo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(300));


            modelBuilder.Configurations.Add(new OperacaoConfiguration());
        }

    }
}
