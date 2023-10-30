using AutoMapper;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business.AutoMapper
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap(typeof(ClienteViewModel), typeof(Cliente));
            CreateMap(typeof(LogradouroViewModel), typeof(Logradouro));
        }
    }
}
