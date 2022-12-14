using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class AssertionConcern
    {
        public static void ValidarSeIgual(object obj01, object obj02, string mensagem)
        {
            if (!obj01.Equals(obj02))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeDiferente(object obj01, object obj02, string mensagem)
        {
            if (obj01.Equals(obj02))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarCaracteres(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if(length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarCaracteres(string valor,int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarExpressao(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if(!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if(valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeNulo(object obj01, string mensagem)
        {
            if(obj01 == null)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if(valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeFalso(bool valor, string mensagem)
        {
            if (valor)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVerdadeiro(bool valor, string mensagem)
        {
            if (!valor)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}