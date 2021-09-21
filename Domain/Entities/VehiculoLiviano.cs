using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VehiculoLiviano : Terrestres
    {
        public int NumeroPuertas { get; set; }

        public VehiculoLiviano(string marca, string modelo, int numPuertas) : base(marca,modelo)
        {
            NumeroPuertas = numPuertas;
        }

        public VehiculoLiviano(string marca, string modelo, Transmision transmision) : base(marca, modelo)
        {
            Transmision = transmision;
        }
    }
}
