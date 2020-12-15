using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjetoXamarin.Models
{
    class ExchangeRate
    {
		[JsonProperty("disclaimer")]
		public string Disclaimer { get; set; }

		[JsonProperty("license")]
		public string Licence { get; set; }

		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }

		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonProperty("rates")]
		public Dictionary<string, decimal> Rates { get; set; }
	}
}
