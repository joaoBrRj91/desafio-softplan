using System;
using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Entities;
using SoftPlan.Fianceiro.Domain.Facade.Interfaces;
using SoftPlan.Fianceiro.Domain.Services.Interfaces;

namespace SoftPlan.Fianceiro.Domain.Services
{
    public class TaxaJurosAplicacaoService : ITaxaJurosAplicacaoService
    {
        private readonly ITaxaJurosAplicacaoFacade _taxaJurosAplicacaoFacade;

        public TaxaJurosAplicacaoService(ITaxaJurosAplicacaoFacade taxaJurosAplicacaoFacade)
            => _taxaJurosAplicacaoFacade = taxaJurosAplicacaoFacade;

        public JurosAplicacao ObterJurosTaxaAplicacao(decimal valorInicial, int meses)
        {

            try
            {
                var jurosTaxa = ObterTaxaJurosCorrente(meses);
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
            var jurosTaxa =_taxaJurosAplicacaoFacade.ObterTaxaJurosCorrente(meses);
            jurosTaxa.AtualizarMesesJuros(meses);

            return jurosTaxa;
        }

    }
}
