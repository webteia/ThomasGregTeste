using Microsoft.EntityFrameworkCore;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, EntityTypeConfiguration<T> configuration) where T : BaseEntity
        {
            configuration.Map(modelBuilder.Entity<T>());
        }

        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, EntityTypeConfigurationNoPk<T> configuration) where T : BaseEntityNoPK
        {
            configuration.Map(modelBuilder.Entity<T>());
        }
    }
}
