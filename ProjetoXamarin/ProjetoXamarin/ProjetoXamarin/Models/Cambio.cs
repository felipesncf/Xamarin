using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjetoXamarin.Models
{
    public class Cambio
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public decimal Valor { get; set; }
        public List<Cambio> Cambios { get; set; } = new List<Cambio>();

        public Cambio()
        {
        }

        public Cambio(int id, string sigla, List<Cambio> cambios)
        {
            Id = id;
            Sigla = sigla;
            Cambios = cambios;
        }
    }
}
