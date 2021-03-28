using SoftPlan.Fianceiro.Domain.Entities;

namespace SoftPlan.Fianceiro.Domain.Facade.Interfaces
{
    public interface ITaxaJurosAplicacaoFacade
    {

        JurosTaxa ObterTaxaJurosCorrente(int meses);
    }
}
