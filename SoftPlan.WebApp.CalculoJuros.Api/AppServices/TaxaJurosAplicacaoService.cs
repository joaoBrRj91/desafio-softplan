using System;
using Newtonsoft.Json;
using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Entities;
using SoftPlan.WebApp.CalculoJuros.Api.AppServices.ApiClient;
using SoftPlan.WebApp.CalculoJuros.Api.AppServices.Interfaces;

namespace SoftPlan.WebApp.CalculoJuros.Api.AppServices
{
    public class TaxaJurosAplicacaoService : ITaxaJurosAplicacaoService
    {

        //TODO: Injetar o IConfiguration para obter o baseuUrl do appSettings
        public TaxaJurosAplicacaoService()
        {
        }

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
            using (var client = new ClientApplication())
            {

                var response = client.GetHttpClient().GetAsync("http://localhost:5000/taxajuros").Result;

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
