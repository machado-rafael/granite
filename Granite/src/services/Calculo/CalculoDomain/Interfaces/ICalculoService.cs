using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo.CalculoDomain.Interfaces
{
    public interface ICalculoService
    {
        decimal CalculaJuros(decimal valorInicial, int meses, decimal taxa = 0);

        string RetornaRepositorio();
    }
}
