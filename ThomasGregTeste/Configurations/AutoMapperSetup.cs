using AutoMapper;
using ThomasGreg.Business.AutoMapper;

namespace ThomasGreg.App.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelToViewModel));
            services.AddAutoMapper(typeof(ViewModelToModel));
        }
    }
}
