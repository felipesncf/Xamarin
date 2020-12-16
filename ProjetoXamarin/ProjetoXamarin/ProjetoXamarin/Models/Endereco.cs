﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXamarin.Models
{
    public class Endereco
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
