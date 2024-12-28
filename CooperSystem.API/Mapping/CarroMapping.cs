using CooperSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Mapping
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique(true);

            builder.Property(x => x.Nome).IsRequired();

            builder.Property(x => x.Cor).IsRequired();

            builder.Property(x => x.AnoModelo).IsRequired();

            builder.Property(x => x.AnoFabricacao).IsRequired();

            builder.Property(x => x.Ativo).IsRequired();

            builder.Property(x => x.MarcaId);

            builder.HasOne(c => c.Marca)
               .WithMany()
               .HasForeignKey(c => c.MarcaId);

            builder.Property(x => x.QtdCarros);
        }
    }
}
