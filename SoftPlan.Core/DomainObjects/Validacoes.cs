namespace SoftPlan.Core.DomainObjects
{

    public class Validacoes
    {

        public static void ValidarSeNulo(object object1, string mensagem)
        {
        
            if (object1 == null) throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo) throw new DomainException(mensagem);

        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo) throw new DomainException(mensagem);

        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo) throw new DomainException(mensagem);

        }


    }
}
