using System;
using Newtonsoft.Json;
using SoftPlan.Fianceiro.Domain.Enums;

namespace SoftPlan.Fianceiro.Domain.Entities
{
    public class JurosTaxa
    {

        public JurosTaxa(
            double porcentagemJuros = 0.01,
            TipoJurosAplicacao tipoJurosAplicacao = TipoJurosAplicacao.JurosCompostos)
        {
            PorcentagemJuros = porcentagemJuros;
            TipoJurosAplicacao = tipoJurosAplicacao;

        }

        public int Meses { get; private set; }

        public double PorcentagemJuros { get; private set; }

        [JsonIgnore]
        public TipoJurosAplicacao TipoJurosAplicacao { get; private set; }


        public string TipoJuros => TipoJurosAplicacao.ToString();


        public void AtualizarMesesJuros(int meses)
        {
            Meses = meses;
        }
    }
}
