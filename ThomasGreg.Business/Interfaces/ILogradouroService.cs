using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Business.Models;

namespace ThomasGreg.Business.Interfaces
{
    public interface ILogradouroService
    {
        Task<LogradouroViewModel> InserirComProcedure(LogradouroViewModel logradouro);
    }
}
