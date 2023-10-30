using FluentValidation;
using ThomasGreg.Repository.Interfaces;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business.Validacoes
{
    public class ClienteValidacao: AbstractValidator<ClienteViewModel>
    {
        private readonly IClienteRepository _repository;

        public ClienteValidacao(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void ValidacaoInclusao(ClienteViewModel cliente)
        {
            ValidarEntrada();
            ValidarEmailJaExiste(cliente);
            cliente.Validacoes = Validate(cliente);
        }

        private void ValidarEntrada()
        {
            RuleFor(rule => rule.Email).NotNull().WithMessage("O Email é obrigatório.").WithErrorCode("403");
            RuleFor(rule => rule.Nome).NotNull().WithMessage("O Nome é obrigatório.").WithErrorCode("403");
        }

        private void ValidarEmailJaExiste(ClienteViewModel cliente)
        {
            var existeEmail = _repository.Obter(x => x.Email == cliente.Email);
            RuleFor(x => existeEmail).Null().WithMessage("Já existe um cliente utilizando esse email").WithErrorCode("403");
        }
    }
}
