using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _201012_API1.Models;

public partial class Alumno
{
    [Key]
    public int IdAlumno { get; set; }

    public string NombreAlumno { get; set; } = null!;

    public int Estado { get; set; }

    public int IdAsignatura { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
}
