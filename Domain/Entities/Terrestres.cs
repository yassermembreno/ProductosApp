using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Terrestres : MediosTransporte
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Transmision Transmision { get; set; }
        public Terrestres(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
    }


}
