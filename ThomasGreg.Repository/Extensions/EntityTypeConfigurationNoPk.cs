using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Extensions
{
    public abstract class EntityTypeConfigurationNoPk<T> where T : BaseEntityNoPK
    {
        public virtual void Map(EntityTypeBuilder<T> builder)
        {
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
