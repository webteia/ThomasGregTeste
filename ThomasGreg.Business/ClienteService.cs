using AutoMapper;
using ThomasGreg.Business.Interfaces;
using ThomasGreg.Business.Validacoes;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business
{
    public class ClienteService: IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;
        private readonly ClienteValidacao _validacao;

        public ClienteService(IClienteRepository repository, IMapper mapper, ClienteValidacao validacao)
        {
            _repository = repository;
            _mapper = mapper;
            _validacao = validacao;
        }

        public ClienteViewModel ObterPorId(int id)
        {
            return _mapper.Map<ClienteViewModel>(_repository.Obter(x => x.Id == id, l => l.Logradouros));
        }

        public List<ClienteViewModel> CarregarTodosOsClientes()
        {
            var clientesRetorno = _repository.Listar(x => x.Id > 0, l => l.Logradouros).ToList();
            return _mapper.Map<List<ClienteViewModel>>(clientesRetorno);
        }

        public async Task<ClienteViewModel> CriarCliente(ClienteViewModel cliente)
        {
            _validacao.ValidacaoInclusao(cliente);

            if (cliente.Validacoes.Errors.Any())
            {
                return cliente;
            }

            var clienteParaCadastro = _mapper.Map<Cliente>(cliente);
            try
            {
                var clienteInserido = await _repository.AdicionarAsync(clienteParaCadastro);
                cliente = _mapper.Map<ClienteViewModel>(clienteInserido);
            } catch (Exception ex) 
            { 
                throw ex; 
            }

            return cliente;
        }
    }
}