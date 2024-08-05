using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    internal class TabelaMeli
    {
        private readonly Dictionary<double, double> tabelaFrete = new Dictionary<double, double>
        {
            { 0.3, 19.95 },
            { 0.5, 20.45 },
            { 1, 21.45 },
            { 2, 22.95 },
            { 3, 23.95 },
            { 4, 24.95 },
            { 5, 25.95 },
            { 9, 41.95 },
            { 13, 65.95 },
            { 17, 73.45 },
            { 23, 85.95 },
            { 30, 98.95 },
            { 40, 109.45 },
            { 50, 116.95 },
            { 60, 124.95 },
            { 70, 141.45 },
            { 80, 156.95 },
            { 90, 174.95 },
            { 100, 199.95 },
            { 125, 223.45 },
            { 150, 237.45 },
            { 9999, 249.45 }
        };

        public double TabMeliFull(double peso)
        {
            foreach (var limite in tabelaFrete.Keys)
            {
                if (peso <= limite)
                {
                    return tabelaFrete[limite];
                }
            }
            return 0;
        }
    }
}
