using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Alimentacion
{
    public int IdAlimentacion { get; set; }

    public string ContentAlimentacion { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Caracteristica> Caracteristicas { get; set; } = new List<Caracteristica>();
}
