using BuscaCep.Models;
using BuscaCep.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep.Repositories
{
    public class CepRepository
    {
        public Task<Cep> Get(string cep)
        {
            var client = RestService.For<ICepApiService>("https://viacep.com.br");
            var task = client.GetCep(cep);

            return task;
        }
    }
}
