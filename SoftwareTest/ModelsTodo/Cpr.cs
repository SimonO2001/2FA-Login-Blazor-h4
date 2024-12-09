using System;
using System.Collections.Generic;

namespace SoftwareTest.ModelsTodo;

public partial class Cpr
{
    public string User { get; set; } = null!;

    public string CprNr { get; set; } = null!;

    public virtual ICollection<Todolist> Todolists { get; set; } = new List<Todolist>();
}
