using SoftPlan.Fianceiro.Domain.Entities;

namespace SoftPlan.Fianceiro.Domain.Services.Interfaces
{
    public interface ITaxaJurosAplicacaoService
    {
        JurosAplicacao ObterJurosTaxaAplicacao(decimal valorInicial, int meses);

        JurosTaxa ObterTaxaJurosCorrente(int meses);
    }
}
