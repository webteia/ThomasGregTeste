using System;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business.Interfaces
{
    public interface IClienteService
    {
        public List<ClienteViewModel> CarregarTodosOsClientes();
        Task<ClienteViewModel> CriarCliente(ClienteViewModel cliente);
        ClienteViewModel ObterPorId(int id);
    }
}
