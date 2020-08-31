using BuscaCep.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep.Services
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json/")]
        Task<Cep> GetCep(string cep);
    }
}
