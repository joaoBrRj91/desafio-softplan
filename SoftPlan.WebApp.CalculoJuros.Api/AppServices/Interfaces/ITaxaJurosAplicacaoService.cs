using SoftPlan.Fianceiro.Domain.Entities;

namespace SoftPlan.WebApp.CalculoJuros.Api.AppServices.Interfaces
{
    public interface ITaxaJurosAplicacaoService
    {
        JurosAplicacao ObterJurosTaxaAplicacao(decimal valorInicial, int meses);

        JurosTaxa ObterTaxaJurosCorrente(int meses);
    }
}
