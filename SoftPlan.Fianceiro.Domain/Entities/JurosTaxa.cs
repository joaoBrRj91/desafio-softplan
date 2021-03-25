using System;
using Newtonsoft.Json;
using SoftPlan.Core.DomainObjects;
using SoftPlan.Fianceiro.Domain.Enums;

namespace SoftPlan.Fianceiro.Domain.Entities
{
    public class JurosTaxa : Entity
    {

        public JurosTaxa(
            int meses = 1,
            double porcentagemJuros = 0.01,
            TipoJurosAplicacao tipoJurosAplicacao = TipoJurosAplicacao.JurosCompostos)
        {
            PorcentagemJuros = porcentagemJuros;
            TipoJurosAplicacao = tipoJurosAplicacao;
            Meses = meses;

            Validar();

        }

        public int Meses { get; private set; }

        public double PorcentagemJuros { get; private set; }

        [JsonIgnore]
        public TipoJurosAplicacao TipoJurosAplicacao { get; private set; }


        public string TipoJuros => TipoJurosAplicacao.ToString();


        public void AtualizarMesesJuros(int meses)
        {
            Validacoes.ValidarSeMenorQue(valor: meses, minimo: 1, mensagem: $"O campo {nameof(Meses)} não pode ser menor 1");
            Meses = meses;
        }

        public override void Validar()
        {
            Validacoes.ValidarSeMenorQue(valor: Meses, minimo: 1, mensagem: $"O campo {nameof(Meses)} não permite valores menores que 1");
            Validacoes.ValidarSeMenorQue(valor: PorcentagemJuros, minimo: 0, mensagem: $"O campo {nameof(PorcentagemJuros)} não pode ser menor que 0");

        }
    }
}
