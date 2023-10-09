using System;
using System.Collections.Generic;

namespace adonet.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Year { get; set; }

    public int? IdGroup { get; set; }

    public virtual Group? IdGroupNavigation { get; set; }
}
