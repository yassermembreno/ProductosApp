using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VehiculoPesado : Terrestres
    {
        public int NumeroLlantas { get; set; }

        public VehiculoPesado(string marca, string modelo, int NumeroLlantas) : base(marca, modelo)
        {

        }
    }
}
