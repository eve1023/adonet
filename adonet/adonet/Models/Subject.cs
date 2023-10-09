using System;
using System.Collections.Generic;

namespace adonet.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lecturer { get; set; } = null!;

    public DateTime? Date { get; set; }

    public int? IdGroup { get; set; }

    public virtual Group? IdGroupNavigation { get; set; }
}
