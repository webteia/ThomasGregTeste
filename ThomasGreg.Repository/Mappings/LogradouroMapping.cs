using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThomasGreg.Repository.Extensions;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Mappings
{
    public class LogradouroMapping : EntityTypeConfiguration<Logradouro>
    {
        public override void Map(EntityTypeBuilder<Logradouro> builder)
        {
            builder
                .Property(x => x.Endereco)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Logradouros)
                .HasForeignKey(x => x.ClienteId);

            base.Map(builder);
        }
    }
}
