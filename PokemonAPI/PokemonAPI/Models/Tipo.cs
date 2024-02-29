using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string Tipo1 { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Pokemon> PokemonTipo1Navigations { get; set; } = new List<Pokemon>();

    [JsonIgnore]
    public virtual ICollection<Pokemon> PokemonTipo2Navigations { get; set; } = new List<Pokemon>();
}
