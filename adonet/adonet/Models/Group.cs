using System;
using System.Collections.Generic;

namespace adonet.Models;

public partial class Group
{
    public int Id { get; set; }

    public int Cd { get; set; }

    public int Number { get; set; }

    public string? Curator { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
