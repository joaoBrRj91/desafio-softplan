using System;

namespace SoftPlan.Fianceiro.Domain.Entities
{
    public class JurosAplicacao
    {

        public JurosAplicacao(
            decimal valorInicial,
            JurosTaxa taxaJuros)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
           
        }

        public decimal ValorInicial { get; private set; }

        public decimal ValorFinal { get; private set; }

        public JurosTaxa TaxaJuros { get; private set; }

        public decimal CalcularValorJurosAplicado()
        {

            ValorFinal = ValorInicial * (decimal)Math.Pow(1 + TaxaJuros.PorcentagemJuros, TaxaJuros.Meses);
            ValorFinal = TruncarValorJurosAplicado(ValorFinal, precisao: 2);
            return ValorFinal;

        }


        public decimal TruncarValorJurosAplicado(decimal valor, decimal precisao) =>
            Math.Truncate(valor * precisao) / 100;

    }
}
