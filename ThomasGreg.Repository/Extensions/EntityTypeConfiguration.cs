using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Extensions
{
    public abstract class EntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Map(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired(false);
        }
    }
}
