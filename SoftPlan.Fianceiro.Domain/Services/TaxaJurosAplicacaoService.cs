using System;
using Newtonsoft.Json;
using SoftPlan.Core.ClientConsumersApps.Http;
using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Entities;
using SoftPlan.Fianceiro.Domain.Services.Interfaces;

namespace SoftPlan.Fianceiro.Domain.Services
{
    public class TaxaJurosAplicacaoService : ITaxaJurosAplicacaoService
    {

        public JurosAplicacao ObterJurosTaxaAplicacao(decimal valorInicial, int meses)
        {
            var jurosTaxa = ObterTaxaJurosCorrente(meses);

            try
            {
                var jurosAplicacao = new JurosAplicacao(valorInicial, jurosTaxa);
                jurosAplicacao.CalcularValorJurosAplicado();
                return jurosAplicacao;

            }
            catch (DomainException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado : {ex.Message}", innerException: ex);
            }


        }


        public JurosTaxa ObterTaxaJurosCorrente(int meses)
        {
            using (var client = new AppHttpClient())
            {

                var response = client.GetHttpClient().GetAsync($"{client.baseAddress}/taxajuros").Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Ocorreu um erro inesperado. StatusCode {response.StatusCode}, mensagem {response.RequestMessage}");

                string conteudo = response.Content.ReadAsStringAsync().Result;
                var jurosTaxa = JsonConvert.DeserializeObject<JurosTaxa>(conteudo);

                jurosTaxa?.AtualizarMesesJuros(meses);

                return jurosTaxa;

            }
        }

    }
}
