using System;
using System.Collections.Generic;
using System.Text;

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
            double count = 0.0;
            foreach (var item in prod)
            {
                if (item != null)
                {
                    total += item.Preco;
                    count++;
                }
            }
            return total / count;
        }
    }
}
