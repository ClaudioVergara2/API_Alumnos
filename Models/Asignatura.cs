using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _201012_API1.Models;

public partial class Asignatura
{
    [Key]
    public int IdAsignatura { get; set; }

    public string NomAsignatura { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
