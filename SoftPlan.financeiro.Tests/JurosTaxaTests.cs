using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Entities;
using Xunit;

namespace SoftPlan.financeiro.Tests
{
    public class JurosTaxaTests
    {
        [Fact]
        public void JurosTaxa_Validar_Mes_Menor_Que_1_Deve_Retornar_Domain_Exception()
        {

            var domainException = Assert.Throws<DomainException>(
                 () => new JurosTaxa(meses: 0)
            );

            Assert.Equal("O campo [Meses] não permite valores menores que 1", domainException.Message);

        }


        [Fact]
        public void JurosTaxa_Validar_Deve_Retornar_Valores_Default()
        {

            var jurosTaxa = new JurosTaxa();

            Assert.Equal(1, jurosTaxa.Meses);
            Assert.Equal(0.01, jurosTaxa.PorcentagemJuros);
            Assert.Equal(Fianceiro.Domain.Enums.TipoJurosAplicacao.JurosCompostos, jurosTaxa.TipoJurosAplicacao);

        }


        [Fact]
        public void JurosTaxa_Validar_Deve_Retornar_Sucesso_Ao_Informar_Dados_Validos()
        {

            var jurosTaxa = new JurosTaxa(
                meses: 10,
                porcentagemJuros: 0.05,
                Fianceiro.Domain.Enums.TipoJurosAplicacao.JurosCompostos);

            Assert.Equal(10, jurosTaxa.Meses);
            Assert.Equal(0.05, jurosTaxa.PorcentagemJuros);
            Assert.Equal(Fianceiro.Domain.Enums.TipoJurosAplicacao.JurosCompostos, jurosTaxa.TipoJurosAplicacao);

        }


        [Fact]
        public void JurosTaxa_Validar_Atualizacao_Mes_Menor_Que_1_Deve_Retornar_Domain_Exception()
        {

            var domainException = Assert.Throws<DomainException>(
                 () =>
                 {
                     var taxaJuros = new JurosTaxa(meses: 5);
                     taxaJuros.AtualizarMesesJuros(meses: 0);
                 }
            );

            Assert.Equal("O campo [Meses] não permite valores menores que 1", domainException.Message);


        }

        [Fact]
        public void JurosTaxa_Validar_Deve_Retornar_Mes_Atualizado()
        {

            var jurosTaxa = new JurosTaxa();
            jurosTaxa.AtualizarMesesJuros(meses: 5);

            Assert.Equal(5, jurosTaxa.Meses);


        }

    }
}
