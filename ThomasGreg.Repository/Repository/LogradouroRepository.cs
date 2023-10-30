using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Repository
{
    public class LogradouroRepository : BaseRepository<Logradouro>, ILogradouroRepository
    {
        public async Task<Logradouro> InserirComProcedure(Logradouro logradouro)
        {
            var novoLogradouro = new Logradouro();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ClienteId", logradouro.ClienteId);
            queryParameters.Add("@Endereco", logradouro.Endereco);

            using (SqlConnection conn = new SqlConnection(Environment.GetEnvironmentVariable("Default")))
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(
                    sql: "[dbo].[InsertLogradouro]",
                    param: queryParameters,
                    commandType: CommandType.StoredProcedure);
            }

            return novoLogradouro;
        }
    }
}
