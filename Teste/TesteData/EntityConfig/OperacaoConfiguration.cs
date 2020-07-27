using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDomain.Entities;

namespace TesteData.EntityConfig
{
    public class OperacaoConfiguration : EntityTypeConfiguration<Operacoes>
    {
        public OperacaoConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.ClientSector)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
