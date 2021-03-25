using System;
using SoftPlan.Core.DomainObjects;

namespace SoftPlan.Fianceiro.Domain.Entities
{
    public class JurosAplicacao : Entity
    {

        public JurosAplicacao(
            decimal valorInicial,
            JurosTaxa taxaJuros)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;

            Validar();
           
        }

        public decimal ValorInicial { get; private set; }

        public decimal ValorFinal { get; private set; }

        public JurosTaxa TaxaJuros { get; private set; }


        public decimal CalcularValorJurosAplicado()
        {

            ValorFinal = ValorInicial * (decimal)Math.Pow(1 + TaxaJuros.PorcentagemJuros, TaxaJuros.Meses);
            ValorFinal = TruncarValorJurosAplicado(ValorFinal);
            return ValorFinal;

        }

        public decimal TruncarValorJurosAplicado(decimal valor) =>
            Math.Truncate(valor * 100) / 100;


        public override void Validar()
        {
            Validacoes.ValidarSeMenorQue(valor: ValorInicial, minimo: 0, mensagem: $"O campo {nameof(ValorInicial)} não pode ser menor que 0");
            Validacoes.ValidarSeNulo(object1: TaxaJuros, mensagem: $"Os dados referente a taxa de jutos não foram preenchidos");

            TaxaJuros.Validar();

        }

    }
}
