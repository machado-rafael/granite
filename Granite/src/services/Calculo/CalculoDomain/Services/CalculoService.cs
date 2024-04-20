using Calculo.CalculoDomain.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Net.Http.Headers;

namespace Calculo.CalculoDomain.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly IConfiguration _configuration;

        public CalculoService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public decimal CalculaJuros(decimal valorInicial, int tempo, decimal juros = 0)
        {
            if (juros == 0) 
            {
                juros = GetTaxa();
            }

            if(valorInicial < 0)
            {
                valorInicial = 0;
            }

            return Math.Round(valorInicial * ((decimal)Math.Pow((double)((juros / 100) + 1), tempo)), 2);
        }

        public string RetornaRepositorio()
        {
            return _configuration.GetSection("Repository:GitHub").Value;
        }

        private decimal GetTaxa()
        {
            decimal taxa = 0;
            try
            {
                string url = _configuration.GetSection("APITaxa:URLBase").Value;
                string uriTaxa = _configuration.GetSection("APITaxa:Endpoint:GetTaxa").Value;

                var client = new RestClient(url);
                var request = new RestRequest(uriTaxa, Method.Get);

                var response = client.Execute(request);

                if (response != null && response.Content != null)
                {
                    taxa = Convert.ToDecimal(response.Content);
                }

                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} ({1})", (int)999, ex.Message);
            }            

            return taxa;

        }
    }
}
