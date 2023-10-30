using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
    }
}
