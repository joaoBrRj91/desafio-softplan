using System;
using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Entities;
using SoftPlan.Fianceiro.Domain.Enums;
using Xunit;

namespace SoftPlan.financeiro.Tests
{
    public class JurosAplicacaoTests
    {
        [Fact]
        public void JurosAplicacao_Validar_ValorInicial_Menor_Que_1_Deve_Retornar_Domain_Exception()
        {
            //Arrange & Act & Assert

            var domainException = Assert.Throws<DomainException>(
                 () => new JurosAplicacao(valorInicial: -10, new JurosTaxa())
            );

            Assert.Equal("O campo [ValorInicial] não pode ser menor que 0", domainException.Message);
        }


        [Fact]
        public void JurosAplicacao_Validar_Deve_Ser_Possivel_Realizar_Criacao_Com_Valores_Validos()
        {
            //Arrange & Act & Assert

            var jurosAplicacao = new JurosAplicacao(valorInicial: 100, new JurosTaxa());

            Assert.Equal(100, jurosAplicacao.ValorInicial);
            Assert.Equal(1, jurosAplicacao.TaxaJuros.Meses);
            Assert.Equal(0.01, jurosAplicacao.TaxaJuros.PorcentagemJuros);
            Assert.Equal(TipoJurosAplicacao.JurosCompostos, jurosAplicacao.TaxaJuros.TipoJurosAplicacao);

        }


        [Fact]
        public void JurosAplicacao_Validar_Deve_Retornar_Calculo_Juros_Composto_Corretamente()
        {
            //Arrange & Act & Assert

            var jurosAplicacao = new JurosAplicacao(valorInicial: 100, new JurosTaxa(meses: 5));
            jurosAplicacao.CalcularValorJurosAplicado();

            Assert.Equal(105.10M, jurosAplicacao.ValorFinal);
           

        }
    }
}
