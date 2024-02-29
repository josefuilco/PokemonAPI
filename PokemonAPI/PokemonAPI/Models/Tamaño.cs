using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Tamaño
{
    public int IdTamaño { get; set; }

    public string ContentTamaño { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Caracteristica> Caracteristicas { get; set; } = new List<Caracteristica>();
}
