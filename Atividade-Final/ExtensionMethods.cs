using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Atividade_Final
{
    public static class ExtensionMethods
    {
        public static double Lucro(this Produto prod)
        {
            return Math.Abs(prod.Preco - prod.Custo);
        }

        public static void Desconto(this Produto prod, double percentual)
        {
            percentual /= 100;
            prod.Preco -= (percentual * prod.Preco);
        }

        public static void Acrescimo(this Produto prod, double percentual)
        {
            percentual /= 100;
            prod.Preco += (percentual * prod.Preco);
        }

        public static double Media(this Produto[] prod)
        {
            var total = 0.0;
         
            var vetorPreenchido = prod.Where(x => x != null).ToArray();

            var prices = vetorPreenchido.Select(x => x.Preco).ToArray();

            total = prices.Sum();
            return total / prices.Length;

            
        }
    }
}
