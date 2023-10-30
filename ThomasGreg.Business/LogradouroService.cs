using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Business.Interfaces;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business
{
    public class LogradouroService : ILogradouroService
    {
        private readonly IMapper _mapper;
        private readonly ILogradouroRepository _repository;

        public LogradouroService(ILogradouroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LogradouroViewModel> InserirComProcedure(LogradouroViewModel logradouro)
        {
            var logradouroParaCadastro = _mapper.Map<Logradouro>(logradouro);
            try
            {
                var logradouroInserido = await _repository.InserirComProcedure(logradouroParaCadastro);
                logradouro = _mapper.Map<LogradouroViewModel>(logradouroInserido);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return logradouro;
        }
    }
}
