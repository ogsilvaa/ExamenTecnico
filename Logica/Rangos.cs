using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class Rangos
    {
        public List<int> CompletarRango(List<int> input)
        {
            var retorno = new List<int>();
            var minimo = input.Min();
            var maximo = input.Max();

            for (int i = minimo; i <= maximo; i++)
            {
                //si existe el item, se utiliza el existente
                var index = input.IndexOf(i);
                if (index != -1)
                {
                    retorno.Add(input[index]);
                }
                else
                {
                    retorno.Add(i);
                }
            }
            return retorno;
        }
    }
}
