using AutoMapper;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap(typeof(Cliente), typeof(ClienteViewModel));
            CreateMap(typeof(Logradouro), typeof(LogradouroViewModel));
        }
    }
}
