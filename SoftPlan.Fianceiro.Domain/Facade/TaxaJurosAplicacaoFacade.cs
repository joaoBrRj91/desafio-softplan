using System;
using Newtonsoft.Json;
using SoftPlan.Core.ClientConsumersApps.Http;
using SoftPlan.Fianceiro.Domain.Entities;
using SoftPlan.Fianceiro.Domain.Facade.Interfaces;

namespace SoftPlan.Fianceiro.Domain.Facade
{
    public class TaxaJurosAplicacaoFacade : ITaxaJurosAplicacaoFacade
    {
       
        public JurosTaxa ObterTaxaJurosCorrente(int meses)
        {
            using (var client = new AppHttpClient())
            {

                var response = client.GetHttpClient().GetAsync($"{client.baseAddress}/taxajuros").Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Ocorreu um erro inesperado. StatusCode {response.StatusCode}, mensagem {response.RequestMessage}");

                string conteudo = response.Content.ReadAsStringAsync().Result;
                var jurosTaxa = JsonConvert.DeserializeObject<JurosTaxa>(conteudo);

                return jurosTaxa;

            }
        }
    }
}
