using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public partial class Pokemon
{
    public int IdPokemon { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdRareza { get; set; }

    public int Tipo1 { get; set; }

    public int? Tipo2 { get; set; }

    [JsonIgnore]
    public int IdCaracteristica { get; set; }

    public string DatoCurioso { get; set; } = null!;

    public virtual Caracteristica CaracteristicaData { get; set; } = null!;

    [JsonIgnore]
    public virtual Rareza? RarezaData { get; set; }

    [JsonIgnore]
    public virtual Tipo? Tipo1Data { get; set; }

    [JsonIgnore]
    public virtual Tipo? Tipo2Data { get; set; }
}
