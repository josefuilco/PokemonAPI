using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Rareza
{
    public int IdRareza { get; set; }

    public string ContentRareza { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
