using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThomasGreg.Repository.Extensions;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Mappings
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .Property(x => x.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Logotipo)
                .HasColumnType("varchar(500)")
                .IsRequired();

            base.Map(builder);
        }
    }
}
