using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Caracteristica
{
    [JsonIgnore]
    public int IdCaracteristica { get; set; }

    public int IdAlimentacion { get; set; }

    public int IdTamaño { get; set; }

    public decimal Peso { get; set; }

    [JsonIgnore]
    public virtual Alimentacion? AlimentacionData { get; set; }

    [JsonIgnore]
    public virtual Tamaño? TamañoData { get; set; }

    [JsonIgnore]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
